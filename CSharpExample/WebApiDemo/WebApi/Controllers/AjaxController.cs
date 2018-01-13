using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Jsonp()
        {
            //Jsonp MVC.Sample /Ajax/JsonpDemo
            return View();
        }
    }
}