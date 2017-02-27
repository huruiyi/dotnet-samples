using System.Web.Mvc;

namespace MVCDIDemo.Controllers.Resource
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Resource/Index.cshtml");
        }
    }
}