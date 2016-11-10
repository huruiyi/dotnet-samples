using MVCSample.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";
            ViewBag.Msg = "<a href='http://www.baidu.com'>百度</a>";
            Person p = new Person { Name = "Qingqing", Age = 21 };
            return View(p);
        }

        public ActionResult About()
        {
            List<Person> pers = new List<Person>
            {
                new Person {Name = "Tom", Age = 20},
                new Person {Name = "Jarry", Age = 22},
                new Person {Name = "Macheal", Age = 23},
                new Person {Name = "Kangkang", Age = 20},
            };
            return View(pers);
        }

        public ActionResult SelectCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem {Text = "Action", Value = "0"},
                new SelectListItem {Text = "Drama", Value = "1"},
                new SelectListItem {Text = "Comedy", Value = "2", Selected = true},
                new SelectListItem {Text = "Science Fiction", Value = "3"}
            };

            ViewBag.MovieType = items;
            return View();
        }

        public ViewResult CategoryChosen(string movieType)
        {
            ViewBag.messageString = movieType;
            return View("Information");
        }

        public ActionResult Js()
        {
            return View();
        }
    }
}