using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace VSCoverageAnalyzer
{
    public partial class FilterForm : Form
    {
        private CoverageItem item = null;

        public FilterForm(CoverageItem item)
        {
            InitializeComponent();
            this.item = item;
            textBoxFilter.Text = item.GetFilterXmlDocument().ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string oldFilter = item.GetFilterXmlDocument().ToString();
            try
            {
                item.Filter = CoverageFilter.FromXml(XDocument.Load(new StringReader(textBoxFilter.Text)));
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                item.Filter = CoverageFilter.FromXml(XDocument.Load(new StringReader(oldFilter)));
                MessageBox.Show(ex.Message);
            }
        }
    }
}
