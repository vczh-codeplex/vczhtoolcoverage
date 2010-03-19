using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Reflection;

namespace VSCoverageAnalyzer
{
    public abstract class CoverageFilter
    {
        public abstract bool Pass(CoverageItem item);
        public abstract XElement GetXml();

        public XDocument GetXmlDocument()
        {
            return new XDocument(GetXml());
        }

        public static CoverageFilter FromXml(XElement element)
        {
            if (element.Name == "true")
            {
                return null;
            }
            else if (element.Name == "or")
            {
                return new CoverageFilterOr()
                {
                    Left = FromXml(element.Elements().ToArray()[0]),
                    Right = FromXml(element.Elements().ToArray()[0])
                };
            }
            else if (element.Name == "and")
            {
                return new CoverageFilterAnd()
                {
                    Left = FromXml(element.Elements().ToArray()[0]),
                    Right = FromXml(element.Elements().ToArray()[0])
                };
            }
            else
            {
                CoverageFilterFunctions function = (CoverageFilterFunctions)typeof(CoverageFilterFunctions).GetField(element.Name.LocalName, BindingFlags.Public | BindingFlags.Static).GetValue(null);
                return new CoverageFilterFunction()
                {
                    Function = function,
                    Parameter = element.Value
                };
            }
        }

        public static CoverageFilter FromXml(XDocument document)
        {
            return FromXml(document.Root);
        }
    }

    class CoverageFilterOr : CoverageFilter
    {
        public CoverageFilter Left { get; set; }
        public CoverageFilter Right { get; set; }

        public override bool Pass(CoverageItem item)
        {
            return Left.Pass(item) || Right.Pass(item);
        }

        public override XElement GetXml()
        {
            return new XElement("or", Left.GetXml(), Right.GetXml());
        }
    }

    class CoverageFilterAnd : CoverageFilter
    {
        public CoverageFilter Left { get; set; }
        public CoverageFilter Right { get; set; }

        public override bool Pass(CoverageItem item)
        {
            return Left.Pass(item) && Right.Pass(item);
        }

        public override XElement GetXml()
        {
            return new XElement("and", Left.GetXml(), Right.GetXml());
        }
    }

    enum CoverageFilterFunctions
    {
        StartsWith,
        NotStartsWith,
        EndsWith,
        NotEndsWith,
        Matches,
        NotMatches,
        Contains,
        NotContains,
        Equal,
        NotEqual,
    }

    class CoverageFilterFunction : CoverageFilter
    {
        private Regex regex = null;
        private string regexCode = null;

        private Regex GetRegex()
        {
            if (this.Parameter != this.regexCode || this.regex == null)
            {
                this.regexCode = this.Parameter;
                this.regex = new Regex(this.regexCode);
            }
            return this.regex;
        }

        public CoverageFilterFunctions Function { get; set; }
        public string Parameter { get; set; }

        public override bool Pass(CoverageItem item)
        {
            switch (this.Function)
            {
                case CoverageFilterFunctions.StartsWith:
                    return item.Name.StartsWith(this.Parameter);
                case CoverageFilterFunctions.NotStartsWith:
                    return !item.Name.StartsWith(this.Parameter);

                case CoverageFilterFunctions.EndsWith:
                    return item.Name.EndsWith(this.Parameter);
                case CoverageFilterFunctions.NotEndsWith:
                    return item.Name.EndsWith(this.Parameter);

                case CoverageFilterFunctions.Matches:
                    return GetRegex().Match(item.Name).Success;
                case CoverageFilterFunctions.NotMatches:
                    return !GetRegex().Match(item.Name).Success;

                case CoverageFilterFunctions.Contains:
                    return item.Name.IndexOf(this.Parameter) != -1;
                case CoverageFilterFunctions.NotContains:
                    return item.Name.IndexOf(this.Parameter) == -1;

                case CoverageFilterFunctions.Equal:
                    return item.Name == this.Parameter;
                case CoverageFilterFunctions.NotEqual:
                    return item.Name != this.Parameter;

                default:
                    return false;
            }
        }

        public override XElement GetXml()
        {
            return new XElement(this.Function.ToString(), this.Parameter);
        }
    }
}
