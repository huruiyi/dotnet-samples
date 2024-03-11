using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    public class Class3
    {
        [XmlAttribute]
        public int IntValue { get; set; }

        [XmlText]
        public string StrValue { get; set; }
    }
}
