using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VSCoverageAnalyzer
{
    enum CoverageType
    {
        Module,
        Namespace,
        Class,
        Method
    }

    class CoverageItem
    {
        private List<CoverageItem> items = new List<CoverageItem>();

        private int calculatePercent(int value, int total)
        {
            return total == 0 ? 0 : (int)Math.Round((double)value * 100 / total);
        }

        private int CoverageTypeToImageIndex(CoverageType type)
        {
            switch (type)
            {
                case CoverageType.Module:
                    return 0;
                case CoverageType.Namespace:
                    return 1;
                case CoverageType.Class:
                    return 2;
                case CoverageType.Method:
                    return 3;
                default:
                    return -1;
            }
        }

        public CoverageItem()
        {
            this.Name = "";
            this.Opening = false;
        }

        public CoverageType CoverageType { get; set; }
        public int BlocksCovered { get; set; }
        public int BlocksNotCovered { get; set; }
        public int LinesCovered { get; set; }
        public int LinesNotCovered { get; set; }
        public int LinesPartiallyCovered { get; set; }
        public string Name { get; set; }
        public bool Opening { get; set; }

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
            }
        }

        public ListViewItem ControlItem { get; private set; }

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
