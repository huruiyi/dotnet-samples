using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebApiDemo.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index(string callback)
        {
            var a = new { UserName = "UserName", Email = "Email" };
            JavaScriptSerializer js = new JavaScriptSerializer();
            var json = js.Serialize(a);
            json = callback + "(" + json + ")";
            return Content(json);
        }
    }
}