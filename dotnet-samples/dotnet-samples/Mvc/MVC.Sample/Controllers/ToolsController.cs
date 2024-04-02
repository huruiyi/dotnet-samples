using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Json()
        {
            return View();
        }

        public ActionResult Sql()
        {
            return View();
        }
    }
}
