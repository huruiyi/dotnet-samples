using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class DemoAController : Controller
    {
        // GET: DemoA
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}