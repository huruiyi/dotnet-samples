using System.Web.Mvc;
using System.Xml.Serialization;

namespace MVC.Sample.Controllers
{
    public class XmlResult : ActionResult
    {
        public object data;

        public XmlResult(object data)
        {
            this.data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response.OutputStream;
            context.HttpContext.Response.ContentType = "text/xml";
            var serializer = new XmlSerializer(data.GetType());
            serializer.Serialize(response, data);
        }
    }
}