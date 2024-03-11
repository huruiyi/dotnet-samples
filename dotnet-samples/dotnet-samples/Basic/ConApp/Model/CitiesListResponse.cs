using System.Xml.Serialization;

namespace ConApp.Model
{
    [XmlRoot("GetCitiesListResponse")]
    public class CitiesListResponse
    {
        public Result Result { get; set; }

        [XmlArray("CitiesList"), XmlArrayItem("City")]
        public City[] CitiesList { get; set; }
    }

    public class Result
    {
        [XmlAttribute("Code")]
        public string Code { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlRoot("City")]
    public class City
    {
        [XmlAttribute("PinYin")]
        public string PinYin { get; set; }

        [XmlAttribute("HasOutService")]
        public string HasOutService { get; set; }

        [XmlText]
        public string Value { get; set; }

        [XmlIgnore]
        [XmlAttribute("Population")]
        public int Population { get; set; }

        //设置Saying属性序列化为Xml子元素
        [XmlElement("info")]
        public string Info { get; set; }
    }
}