using System.Xml.Serialization;

namespace Fairy.ConApp.Exe
{
    public class LinkGroup
    {
        [XmlAttribute]
        public string ID { get; set; }
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public int Priority { get; set; }

        public Glyph Glyph { get; set; }
    }
}
