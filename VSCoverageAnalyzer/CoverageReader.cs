using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace VSCoverageAnalyzer
{
    static class CoverageReader
    {
        private static CoverageItem FillProperties(XElement element, string nameProperty, CoverageItem item)
        {
            if (item.CoverageType == CoverageType.Method)
            {
                item.BlocksCovered = int.Parse(element.Element("BlocksCovered").Value);
                item.BlocksNotCovered = int.Parse(element.Element("BlocksNotCovered").Value);
                item.LinesCovered = int.Parse(element.Element("LinesCovered").Value);
                item.LinesNotCovered = int.Parse(element.Element("LinesNotCovered").Value);
                item.LinesPartiallyCovered = int.Parse(element.Element("LinesPartiallyCovered").Value);
            }
            item.Name = element.Element(nameProperty).Value;
            return item;
        }

        public static CoverageItem GetModules(XDocument document)
        {
            return new CoverageItem()
            {
                CoverageType = CoverageType.Profile,
                Name = "Profile",
                Opening = true,
                Items = document.Root.Elements("Module")
                    .Select(xModule =>
                        FillProperties(xModule, "ModuleName", new CoverageItem()
                        {
                            CoverageType = CoverageType.Module,
                            Items = xModule.Elements("NamespaceTable")
                                .Select(xNamespace =>
                                    FillProperties(xNamespace, "NamespaceName", new CoverageItem()
                                    {
                                        CoverageType = CoverageType.Namespace,
                                        Items = xNamespace.Elements("Class")
                                            .Select(xClass =>
                                                FillProperties(xClass, "ClassName", new CoverageItem()
                                                {
                                                    CoverageType = CoverageType.Class,
                                                    Items = xClass.Elements("Method")
                                                        .Select(xMethod =>
                                                            FillProperties(xMethod, "MethodName", new CoverageItem()
                                                            {
                                                                CoverageType = CoverageType.Method,
                                                            })
                                                            )
                                                        .ToArray()
                                                })
                                            )
                                            .ToArray()
                                    })
                                    )
                                .ToArray()
                        })
                        )
                    .ToArray()
            };
        }
    }
}
