using MVC.Sample.Filters;
using MVC.Sample.Models;
using System.Collections.Generic;
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
            Person person = new Person
            {
                Age = 5000,
                Hobby = "卧着",
                Name = "黄山"
            };
            return View(person);
        }

        public ActionResult DropDownListSample()
        {
            IDictionary<string, string> makes = GetSampleMakes();
            DropDownSampleModel viewModel = new DropDownSampleModel()
            {
                Makes = makes
            };
            List<SelectListItem> projectProjects = new List<SelectListItem>
            {
                new SelectListItem{Text="跟团游",Value="1"},
                new SelectListItem{Text="团队",Value="2"}
            };
            ViewData["ProjectType"] = projectProjects;
            return View(viewModel);
        }

        private IDictionary<string, string> GetSampleMakes()
        {
            IDictionary<string, string> makes = new Dictionary<string, string>();
            makes.Add("1", "跟团游");
            makes.Add("2", "团队");
            makes.Add("3", "其他");

            return makes;
        }
    }
}