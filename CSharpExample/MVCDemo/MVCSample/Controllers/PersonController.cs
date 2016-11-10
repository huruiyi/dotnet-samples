using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class PersonController : Controller
    {
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