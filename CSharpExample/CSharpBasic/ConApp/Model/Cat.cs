using System.Xml.Serialization;

namespace ConApp.Model
{
    [XmlRoot("Cat")]
    public class Cat
    {
        //定义Color属性的序列化为cat节点的属性
        [XmlAttribute("Color")]
        public string Color { get; set; }

        //要求不序列化Speed属性    [XmlIgnore]
        [XmlElement("Speed")]
        public int Speed { get; set; }

        //设置Saying属性序列化为Xml子元素
        [XmlElement("Saying")]
        public string Saying { get; set; }
    }

    [XmlRoot("RootItem")]
    public class CatCollection
    {
        [XmlArray("ICats"), XmlArrayItem("ICat")]
        public Cat[] Cats { get; set; }
    }
}