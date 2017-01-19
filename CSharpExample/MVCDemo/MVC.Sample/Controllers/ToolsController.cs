using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Tab()
        {
            return View("Index");
        }

        public ActionResult Json()
        {
            return View();
        }
    }
}