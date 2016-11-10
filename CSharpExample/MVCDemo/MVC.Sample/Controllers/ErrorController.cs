using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return base.View();
        }

        public ActionResult Servererror()
        {
            return base.View();
        }

        public ActionResult NotAllow()
        {
            return base.View();
        }

        public ActionResult BadRequest()
        {
            return View();
        }
    }
}