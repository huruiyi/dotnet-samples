using System.Xml.Serialization;

namespace Fairy.ConApp.Exe
{
    public class LItem
    {
        [XmlAttribute]
        public string URL { get; set; }
        [XmlAttribute]
        public string LinkGroup { get; set; }

        [XmlText]
        public string Title { get; set; }
    }
}
