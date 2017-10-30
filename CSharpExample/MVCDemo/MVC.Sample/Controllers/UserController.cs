using MVC.Sample.Models;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class UserController : Controller
    {
        private IUser service;

        public UserController(IUser service)
        {
            this.service = service;
        }

        // GET: User
        public ActionResult Index()
        {
            var data = this.service.GetUsers();
            return View(data);
        }
    }
}