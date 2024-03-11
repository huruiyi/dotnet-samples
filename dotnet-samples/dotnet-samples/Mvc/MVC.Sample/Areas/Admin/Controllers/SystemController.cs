using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Sample.Areas.Admin.Controllers
{
    public class SystemController : Controller
    {
        // GET: Admin/System
        public ActionResult Index()
        {
            return View();
        }
    }
}