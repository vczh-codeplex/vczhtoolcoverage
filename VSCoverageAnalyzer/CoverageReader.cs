using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace VSCoverageAnalyzer
{
    static class CoverageReader
    {
        private static CoverageItem FillProperties(XElement element, CoverageItem item)
        {
            item.BlocksCovered = int.Parse(element.Attribute("BlocksCovered").Value);
            item.BlocksNotCovered = int.Parse(element.Attribute("BlocksNotCovered").Value);
            item.LinesCovered = int.Parse(element.Attribute("LinesCovered").Value);
            item.LinesNotCovered = int.Parse(element.Attribute("LinesNotCovered").Value);
            item.LinesPartiallyCovered = int.Parse(element.Attribute("LinesPartiallyCovered").Value);
            return item;
        }

        public static CoverageItem[] GetModules(XDocument document)
        {
            return document.Root.Elements("Module")
                .Select(xModule =>
                    FillProperties(xModule, new CoverageItem()
                    {
                        CoverageType = CoverageType.Module,
                        Items = xModule.Elements("Namespace")
                            .Select(xNamespace =>
                                FillProperties(xNamespace, new CoverageItem()
                                {
                                    CoverageType = CoverageType.Namespace,
                                    Items = xModule.Elements("Class")
                                        .Select(xClass =>
                                            FillProperties(xClass, new CoverageItem()
                                            {
                                                CoverageType = CoverageType.Class,
                                                Items = xModule.Elements("Method")
                                                    .Select(xMethod =>
                                                        FillProperties(xMethod,
                                                            new CoverageItem()
                                                            {
                                                                CoverageType = CoverageType.Module,
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
                .ToArray();
        }
    }
}
