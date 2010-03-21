using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace VSCoverageAnalyzer
{
    public enum CoverageType
    {
        Profile,
        Module,
        Namespace,
        Class,
        Method
    }

    public class CoverageItem
    {
        private List<CoverageItem> items = new List<CoverageItem>();
        private CoverageFilter filter = null;

        private int calculatePercent(int value, int total)
        {
            return total == 0 ? 0 : (int)Math.Round((double)value * 100 / total);
        }

        private int CoverageTypeToImageIndex(CoverageType type)
        {
            switch (type)
            {
                case CoverageType.Profile:
                    return 0;
                case CoverageType.Module:
                    return 1;
                case CoverageType.Namespace:
                    return 2;
                case CoverageType.Class:
                    return 3;
                case CoverageType.Method:
                    return 4;
                default:
                    return -1;
            }
        }

        public CoverageItem()
        {
            this.Name = "";
            this.Opening = false;
            this.Visible = true;
        }

        #region Data

        private int propertyBlocksCovered = 0;
        private int propertyBlocksNotCovered = 0;
        private int propertyLinesCovered = 0;
        private int propertyLinesNotCovered = 0;
        private int propertyLinesPartiallyCovered = 0;

        public int BlocksCovered
        {
            get
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    return this.propertyBlocksCovered;
                }
                else
                {
                    return this.items.Where(i => i.Visible).Select(i => i.BlocksCovered).Sum();
                }
            }
            set
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    this.propertyBlocksCovered = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int BlocksNotCovered
        {
            get
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    return this.propertyBlocksNotCovered;
                }
                else
                {
                    return this.items.Where(i => i.Visible).Select(i => i.BlocksNotCovered).Sum();
                }
            }
            set
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    this.propertyBlocksNotCovered = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int LinesCovered
        {
            get
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    return this.propertyLinesCovered;
                }
                else
                {
                    return this.items.Where(i => i.Visible).Select(i => i.LinesCovered).Sum();
                }
            }
            set
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    this.propertyLinesCovered = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int LinesNotCovered
        {
            get
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    return this.propertyLinesNotCovered;
                }
                else
                {
                    return this.items.Where(i => i.Visible).Select(i => i.LinesNotCovered).Sum();
                }
            }
            set
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    this.propertyLinesNotCovered = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public int LinesPartiallyCovered
        {
            get
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    return this.propertyLinesPartiallyCovered;
                }
                else
                {
                    return this.items.Where(i => i.Visible).Select(i => i.LinesPartiallyCovered).Sum();
                }
            }
            set
            {
                if (this.CoverageType == CoverageType.Method)
                {
                    this.propertyLinesPartiallyCovered = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        #endregion

        #region Properties

        public CoverageType CoverageType { get; set; }
        public string Name { get; set; }
        public bool Opening { get; set; }
        public bool Visible { get; set; }

        public int VisibleSubItems
        {
            get
            {
                return (this.items.Count == 0 || !this.Opening) ? 0 : this.items.Select(i => i.VisibleSubItems + 1).Sum();
            }
        }

        public CoverageItem[] Items
        {
            get
            {
                return this.items.ToArray();
            }
            set
            {
                this.items.Clear();
                this.items.AddRange(value);
                foreach (CoverageItem item in this.items)
                {
                    item.Parent = this;
                }
            }
        }

        public ListViewItem ControlItem { get; private set; }
        public CoverageItem Parent { get; private set; }

        public int this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Blocks Covered":
                        return this.BlocksCovered;
                    case "Blocks Covered%":
                        return calculatePercent(this.BlocksCovered, this.BlocksCovered + this.BlocksNotCovered);
                    case "Blocks Not Covered":
                        return this.BlocksNotCovered;
                    case "Blocks Not Covered%":
                        return calculatePercent(this.BlocksNotCovered, this.BlocksCovered + this.BlocksNotCovered);
                    case "Lines Covered":
                        return this.LinesCovered;
                    case "Lines Covered%":
                        return calculatePercent(this.LinesCovered, this.LinesCovered + this.LinesNotCovered + this.LinesPartiallyCovered);
                    case "Lines Not Covered":
                        return this.LinesNotCovered;
                    case "Lines Not Covered%":
                        return calculatePercent(this.LinesNotCovered, this.LinesCovered + this.LinesNotCovered + this.LinesPartiallyCovered);
                    case "Lines Partially Covered":
                        return this.LinesPartiallyCovered;
                    case "Lines Partially Covered%":
                        return calculatePercent(this.LinesPartiallyCovered, this.LinesCovered + this.LinesNotCovered + this.LinesPartiallyCovered);
                    default:
                        throw new ArgumentException("Unexists property \"" + property + "\".");
                }
            }
        }

        #endregion

        #region Operations

        public void BuildControlItems(int level, string[] columns)
        {
            this.ControlItem = new ListViewItem()
            {
                Text = this.Name,
                IndentCount = level,
                ImageIndex = CoverageTypeToImageIndex(this.CoverageType),
                Tag = this
            };
            foreach (string column in columns)
            {
                if (column.EndsWith("%"))
                {
                    this.ControlItem.SubItems.Add(this[column].ToString() + "%");
                }
                else
                {
                    this.ControlItem.SubItems.Add(this[column].ToString());
                }
            }
            foreach (CoverageItem item in this.items)
            {
                item.BuildControlItems(level + 1, columns);
            }
        }

        public CoverageFilter Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                if (this.filter == null)
                {
                    foreach (CoverageItem item in this.items)
                    {
                        item.Visible = true;
                    }
                }
                else
                {
                    foreach (CoverageItem item in this.items)
                    {
                        item.Visible = this.filter.Pass(item);
                    }
                }
            }
        }

        public void Hide()
        {
            if (this.Parent != null)
            {
                CoverageFilterFunction function = new CoverageFilterFunction()
                {
                    Function = CoverageFilterFunctions.NotEqual,
                    Parameter = this.Name
                };
                if (this.Parent.Filter == null)
                {
                    this.Parent.Filter = function;
                }
                else
                {
                    this.Parent.Filter = new CoverageFilterAnd()
                    {
                        Left = function,
                        Right = this.Parent.Filter
                    };
                }
            }
        }

        public void SetAllVisible()
        {
            this.Visible = true;
            foreach (CoverageItem item in this.items)
            {
                item.SetAllVisible();
            }
        }

        public XDocument GetFilterXmlDocument()
        {
            return this.filter == null ? new XDocument(new XElement("true")) : this.filter.GetXmlDocument();
        }

        public void SetFilterXmlDocument(XDocument document)
        {
            this.Filter = CoverageFilter.FromXml(document);
        }

        public XElement GetGlobalFilterXml()
        {
            XElement[] elements = this.items.Select(i => i.GetGlobalFilterXml()).Where(e => e != null).ToArray();
            if (this.Parent == null || this.filter != null || elements.Length > 0)
            {
                return new XElement("item",
                    new XAttribute("name", this.Name),
                    new XElement("filter", this.filter == null ? new XElement("true") : this.filter.GetXml()),
                    new XElement("children", this.items.Select(i => i.GetGlobalFilterXml()))
                    );
            }
            else
            {
                return null;
            }
        }

        public void SetGlobalFilterXml(XElement element)
        {
            CoverageFilter filter = this.Filter;
            try
            {
                this.Filter = CoverageFilter.FromXml(element.Element("filter").Elements().First());
                Dictionary<string, XElement> itemElements = new Dictionary<string, XElement>();
                foreach (XElement itemElement in element.Element("children").Elements("item"))
                {
                    itemElements[itemElement.Attribute("name").Value] = itemElement;
                }
                foreach (CoverageItem item in this.items)
                {
                    if (itemElements.ContainsKey(item.Name))
                    {
                        item.SetGlobalFilterXml(itemElements[item.Name]);
                    }
                    else
                    {
                        item.Filter = null;
                    }
                }
            }
            catch (Exception)
            {
                this.Filter = filter;
                throw;
            }
        }

        public XDocument GetGlobalFilterXmlDocument()
        {
            return new XDocument(GetGlobalFilterXml());
        }

        public void SetGlobalFilterXmlDocument(XDocument document)
        {
            SetGlobalFilterXml(document.Root);
        }

        #endregion

        public static string[] Properties
        {
            get
            {
                return new string[]{
                    "Blocks Covered",
                    "Blocks Covered%",
                    "Blocks Not Covered",
                    "Blocks Not Covered%",
                    "Lines Covered",
                    "Lines Covered%",
                    "Lines Not Covered",
                    "Lines Not Covered%",
                    "Lines Partially Covered",
                    "Lines Partially Covered%",
                };
            }
        }
    }
}
