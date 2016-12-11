using System.Xml.Serialization;

namespace ConApp.Class
{
    [XmlRoot(ElementName = "request")]
    public class ComplainModel
    {
        [XmlElement("checkCode")]
        public string CheckCode { get; set; }

        [XmlElement("name")]
        public string MethodName { get; set; }

        [XmlElement("token")]
        public string Token { get; set; }

        [XmlElement("aplDate")]
        public AplDate AplDate { get; set; }
    }

    public class AplDate
    {
        /// <summary>
        /// 创建人工号
        /// </summary>
        [XmlElement("createBy")]
        public string CreaterJobNumber { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [XmlElement("customerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        [XmlElement("customerPhone")]
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        [XmlElement("memberId")]
        public string MmemberId { get; set; }
    }

    [XmlRoot("request", Namespace = "")]
    public class RequestPlatform
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