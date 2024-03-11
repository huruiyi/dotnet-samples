using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    [XmlType("x2")]
    public class X2 : XBase
    {
        [XmlElement("cc")]
        public string CC { get; set; }

        [XmlElement("dd")]
        public string DD { get; set; }
    }
}