using System.Xml.Serialization;

namespace Fairy.ConApp.Exe
{
    public class Glyph
    {
        [XmlAttribute]
        public int Collapsed { get; set; }
        [XmlAttribute]
        public int Expanded { get; set; }
    }
}
