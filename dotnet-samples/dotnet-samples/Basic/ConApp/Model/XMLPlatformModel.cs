using System.Xml.Serialization;

namespace ConApp.Model
{
    [XmlRoot("request", Namespace = "")]
    public class XMLPlatformModel
    {
        [XmlElement("checkCode")]
        public string CheckCode { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("token")]
        public string Token { get; set; }

        [XmlElement("aplData")]
        public AplDataPlatform AplData { get; set; }
    }

    [XmlRoot("aplData")]
    public class AplDataPlatform
    {
        [XmlElement("code")]
        public string Code { get; set; }
    }
}