using Microsoft.AspNetCore.Mvc;

namespace Mvc.Core.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}