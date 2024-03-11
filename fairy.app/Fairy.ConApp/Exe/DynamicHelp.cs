using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fairy.ConApp.Exe
{
    [XmlRoot(Namespace = "http://msdn.microsoft.com/vsdata/xsd/vsdh.xsd")]
    public class DynamicHelp
    {
        [XmlElement("LinkGroup")]
        public List<LinkGroup> Groups { get; set; }

        public Context Context { get; set; }
    }
}
