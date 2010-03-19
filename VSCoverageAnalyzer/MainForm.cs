using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Collections;

namespace VSCoverageAnalyzer
{
    public partial class MainForm : Form
    {
        private string[] selectedColumns = new string[]
        {
            "Blocks Covered",
            "Blocks Covered%",
            "Blocks Not Covered",
            "Blocks Not Covered%"
        };
        private CoverageItem[] items = new CoverageItem[] { };
        private string sortingColumn = null;
        private bool sortingAscending = true;

        private class Sorter : IComparer
        {
            private MainForm mainForm = null;

            public Sorter(MainForm mainForm)
            {
                this.mainForm = mainForm;
            }

            private int DirectCompare(CoverageItem itemX, CoverageItem itemY)
            {
                int result = 0;
                if (this.mainForm.sortingColumn == null)
                {
                    result = Comparer<string>.Default.Compare(itemX.Name, itemY.Name);
                }
                else
                {
                    result = Comparer<int>.Default.Compare(itemX[this.mainForm.sortingColumn], itemY[this.mainForm.sortingColumn]);
                }
                return this.mainForm.sortingAscending ? result : -result;
            }

            private List<CoverageItem> GetAncestors(CoverageItem item)
            {
                List<CoverageItem> result = new List<CoverageItem>();
                while (item != null)
                {
                    result.Insert(0, item);
                    item = item.Parent;
                }
                return result;
            }

            #region IComparer Members

            int IComparer.Compare(object x, object y)
            {
                CoverageItem itemX = (x as ListViewItem).Tag as CoverageItem;
                CoverageItem itemY = (y as ListViewItem).Tag as CoverageItem;
                List<CoverageItem> itemXs = GetAncestors(itemX);
                List<CoverageItem> itemYs = GetAncestors(itemY);
                while (true)
                {
                    if (itemXs.Count > 0)
                    {
                        if (itemYs.Count > 0)
                        {
                            if (itemXs[0] == itemYs[0])
                            {
                                itemXs.RemoveAt(0);
                                itemYs.RemoveAt(0);
                            }
                            else
                            {
                                return DirectCompare(itemXs[0], itemYs[0]);
                            }
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if (itemYs.Count > 0)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }

            #endregion
        }

        private void ReloadColumns()
        {
            listViewResults.Columns.Clear();
            listViewResults.Columns.Add(new ColumnHeader()
            {
                Name = "Hierarchy",
                Text = "Hierarchy(A-Z)",
                Width = 300
            });
            listViewResults.Columns.AddRange(selectedColumns
                .Select(c => new ColumnHeader()
                {
                    Name = c,
                    Text = c,
                    Width = 120
                }).ToArray());
        }

        private void LoadItem(CoverageItem item)
        {
            listViewResults.Items.Add(item.ControlItem);
            if (item.Opening)
            {
                foreach (CoverageItem subItem in item.Items)
                {
                    LoadItem(subItem);
                }
            }
        }

        private void ReloadItems()
        {
            listViewResults.Items.Clear();
            foreach (CoverageItem item in this.items)
            {
                item.BuildControlItems(0, this.selectedColumns);
                LoadItem(item);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            listViewResults.ListViewItemSorter = new Sorter(this);
            listViewResults.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(listViewResults, true, new object[] { });
            ReloadColumns();
            ReloadItems();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColumnSelectorForm form = new ColumnSelectorForm())
            {
                form.Columns = this.selectedColumns;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.selectedColumns = form.Columns;
                    ReloadColumns();
                    ReloadItems();
                }
            }
        }

        private void importVisualStudioUnittestResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogOpen.ShowDialog() == DialogResult.OK)
            {
                XDocument document = XDocument.Load(dialogOpen.FileName);
                this.items = CoverageReader.GetModules(document);
                ReloadItems();
            }
        }

        private void listViewResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewResults.HitTest(e.Location);
            if (info.Item != null)
            {
                CoverageItem coverageItem = info.Item.Tag as CoverageItem;
                int index = info.Item.Index;
                coverageItem.Opening = !coverageItem.Opening;
                ReloadItems();
                listViewResults.SelectedIndices.Clear();
                listViewResults.SelectedIndices.Add(index);
                listViewResults.EnsureVisible(index);
            }
        }

        private void listViewResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            foreach (ColumnHeader header in listViewResults.Columns)
            {
                header.Text = header.Name;
            }
            string name = e.Column == 0 ? null : listViewResults.Columns[e.Column].Name;
            if (name == this.sortingColumn)
            {
                this.sortingAscending = !this.sortingAscending;
            }
            else
            {
                this.sortingAscending = true;
            }
            this.sortingColumn = name;
            listViewResults.Columns[e.Column].Text += "(" + (this.sortingAscending ? "A-Z" : "Z-A") + ")";
            listViewResults.Sort();
        }
    }
}
