using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace VSCoverageAnalyzer
{
    public partial class ColumnSelectorForm : Form
    {
        public ColumnSelectorForm()
        {
            InitializeComponent();
            this.listColumns.Items.AddRange(CoverageItem.Properties);
        }

        public string[] Columns
        {
            get
            {
                return listColumns.CheckedItems.Cast<string>().ToArray();
            }
            set
            {
                for (int i = 0; i < listColumns.CheckedItems.Count; i++)
                {
                    listColumns.SetItemChecked(i, false);
                }
                foreach (string column in value)
                {
                    listColumns.SetItemChecked(listColumns.Items.Cast<string>().ToList().IndexOf(column), true);
                }
            }
        }
    }
}
