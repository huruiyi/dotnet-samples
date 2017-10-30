using MVC.Sample.Filters;
using MVC.Sample.Models;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class SamplesController : Controller
    {
        // GET: Samples
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [MVCAPPActionFilter]
        public ActionResult UserCenter()
        {
            return PartialView();
        }

        [MVCAPPActionFilter]
        public ActionResult UserInfo()
        {
            Person person = new Person();
            person.Age = 5000;
            person.Hobby = "卧着";
            person.Name = "黄山";
            return View(person);
        }
    }
}