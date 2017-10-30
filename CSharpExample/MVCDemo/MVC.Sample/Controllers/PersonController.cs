using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ValidationUrl()
        {
            return View();
        }
    }
}