using System.Xml.Serialization;

namespace ConsoleApp2.Model
{
    public class TestIgnore
    {
        [XmlIgnore]    // 这个属性将不会参与序列化
        public int IntValue { get; set; }

        [XmlElement(Order = 1)]
        public string StrValue { get; set; }

        [XmlElement(Order = 2)]

        public string Url;
    }
}
