﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VSCoverageAnalyzer
{
    enum CoverageType
    {
        Profile,
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

        public void SetFilter(string filter)
        {
        }

        public void SetAllVisible()
        {
            this.Visible = true;
            foreach (CoverageItem item in this.items)
            {
                item.SetAllVisible();
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
