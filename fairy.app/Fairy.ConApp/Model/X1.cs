using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    [XmlType("x1")]
    public class X1 : XBase
    {
        [XmlAttribute("aa")]
        public int AA { get; set; }

        [XmlAttribute("bb")]
        public int BB { get; set; }
    }
}
