using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFilter.Fliters._0Exception;
using MVCFilter.Fliters._2Action;
using MVCFilter.Models;

namespace MVCFilter.Controllers
{
    /// 1. Exception Filters
    /// 2. Authorization Filters
    /// 3. Action Filters Action
    /// 4. Result Filters Result
    //[Cus_ActionFilter]

    public class HomeController : Controller
    {
        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            ViewBag.UserName = userName;
            return View();
        }

        [AllowAnonymous]
        public JsonResult GetList()
        {
            List<object> objList = new List<object>();
            for (int i = 0; i < 5; i++)
            {
                objList.Add(new { Id = i, Name = "User" + i, Age = 20 + i });
            }
            return Json(objList, JsonRequestBehavior.AllowGet);
        }

        // [Cus_IResultFilter]
        [Cus_ActionFilter]
        public ContentResult Demo1()
        {
            Response.Write("Action正在执行···<br /><br />");
            return Content("正在返回Result···<br /><br />");
        }

        [Cus_ActionFilter]
        public ActionResult Demo2()
        {
            MemberInfo memberInfo = new MemberInfo
            {
                MemberEmail = "123456@xyz.com",
                MemberId = 123456,
                MemberMobile = "133abcdexyzu",
                MemberName = "Kitty",
                MemberTrueName = "mini",
                Role = "Role1,Role2"
            };
            return View(memberInfo);
        }

        [Cus_ActionFilter]
        public ActionResult Demo3(string userName, string userAge)
        {
            Response.Write("Action执行中···<br />");
            MemberInfo memberInfo = new MemberInfo
            {
                MemberEmail = "123456@xyz.com",
                MemberId = 123456,
                MemberMobile = "133abcdexyzu",
                MemberName = "Kitty",
                MemberTrueName = "mini",
                Role = "Role1,Role2"
            };
            return View(memberInfo);
        }

        [Cus_ExceptionFilter]
        public ActionResult Demo4(int a)
        {
            //throw new Exception("异常过滤器测试");
            return Content((21 / a).ToString());
        }

        public ActionResult Demo5()
        {
            return View();
        }

        /*
         [OutputCache(Duration = 60, VaryByParam = "*")]
         [ValidateInput(false)]
         [ValidateAntiForgeryToken]
             */
        // 过滤器：
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Demo6()
        {
            return View();
        }
    }
}