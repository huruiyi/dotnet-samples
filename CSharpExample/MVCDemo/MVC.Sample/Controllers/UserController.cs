using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Sample.Models;

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