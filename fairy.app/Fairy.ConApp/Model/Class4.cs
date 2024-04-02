using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    [XmlType("c4")]
    public class Class4
    {
        [XmlAttribute("id")]
        public int IntValue { get; set; }

        [XmlElement("name")]
        public string StrValue { get; set; }
    }
}