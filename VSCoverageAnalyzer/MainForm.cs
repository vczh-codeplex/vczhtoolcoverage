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

        private void ReloadColumns()
        {
            listViewResults.Columns.Clear();
            listViewResults.Columns.Add("Hierarchy").Width = 300;
            listViewResults.Columns.AddRange(selectedColumns
                .Select(c => new ColumnHeader()
                {
                    Text = c,
                    Width = 120
                }).ToArray());
        }

        private void LoadItem(CoverageItem item, ref int index)
        {
            listViewResults.Items.Insert(index, item.ControlItem);
            index++;
            if (item.Opening)
            {
                foreach (CoverageItem subItem in item.Items)
                {
                    LoadItem(subItem, ref index);
                }
            }
        }

        private void LoadItem(CoverageItem item)
        {
            int index = listViewResults.Items.Count;
            LoadItem(item, ref index);
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
                /*if (coverageItem.Opening)
                {
                    int count = coverageItem.VisibleSubItems;
                    while (count-- > 0)
                    {
                        listViewResults.Items.RemoveAt(index + 1);
                    }
                }
                else
                {
                    int currentIndex = index + 1;
                    foreach (CoverageItem subItem in coverageItem.Items)
                    {
                        LoadItem(subItem, ref currentIndex);
                    }
                }*/
                coverageItem.Opening = !coverageItem.Opening;
                ReloadItems();
                listViewResults.SelectedIndices.Clear();
                listViewResults.SelectedIndices.Add(index);
                listViewResults.EnsureVisible(index);
            }
        }
    }
}
