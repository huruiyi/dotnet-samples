using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace Fairy.Mvc.Controllers
{
    public class DefaultController : Controller
    {

        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        // GET: Default
        public ActionResult Index()
        {
            string helloWorld = "Hello World！！！世界你好！！";
            for (int i = 0; i < 10000; i++)
            {
                Log.Info(helloWorld);
                Log.Error(helloWorld);
                Log.Fatal(helloWorld);
            }
            return Content(helloWorld);
        }

        public ActionResult Test()
        {
            List<SelectListItem> liker = new List<SelectListItem>
            {
                new SelectListItem { Text = "---请选择--", Value ="1" },
                new SelectListItem { Text = "Drama", Value = "2" }
            };

            ViewBag.Liker = liker;
            return View();
        }

        public ActionResult Ok()
        {
            return View();
        }
    }
}