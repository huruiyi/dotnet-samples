using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    public class Class2
    {
        [XmlAttribute]
        public int IntValue { get; set; }

        [XmlElement]
        public string StrValue { get; set; }
    }
}