using MVC.Sample.Fliters._1Authentication_Authorization;
using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVC.Sample.Controllers
{
    public class IIdentityDemo3Controller : Controller
    {
        // GET: IIdentityDemo3
        protected MemberPrincipal ShopMember
        {
            get
            {
                return HttpContext.User as MemberPrincipal;
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ContentResult SupperUser()
        {
            return Content("你是管理员");
        }

        [Sys_Authorize_FilterAttribute_IAuthorizationFilter(Roles = "User")]
        public ContentResult OrdinaryUser()
        {
            return Content("你是普通用户");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUser(string userName, string role)
        {
            var serializeModel = new MemberInfo
            {
                MemberId = 87654321,
                MemberName = userName,
                MemberEmail = "1245678",
                MemberMobile = "123456789123",
                MemberTrueName = userName,
                AllRoles = new List<string> { "Admin", "User" },
                Role = role
            };
            var serializer = new JavaScriptSerializer();
            string memberUseruserData = serializer.Serialize(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, serializeModel.MemberName, DateTime.Now, DateTime.Now.AddMinutes(30), false, memberUseruserData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            var loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(loginCookie);

            #region MyRegion

            //var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //string encryptedTicket = authCookie.Value;
            //var ticket = FormsAuthentication.Decrypt(encryptedTicket);  //解密cookie中的票据信息
            //string[] roles = { ticket.UserData };//获取用户角色信息
            //var identity = new FormsIdentity(ticket);    //创建用户标识
            //GenericPrincipal user = new GenericPrincipal(identity, roles);  //创建用户的主体信息
            //HttpContext.User = user;

            #endregion MyRegion

            return RedirectToAction("Index", "Home");
        }

        [Sys_Authorize_FilterAttribute_IAuthorizationFilter(Roles = "Admin", Users = "User1,User2,User3", Order = 1)]
        // [OutputCache]
        public ActionResult Sys_AuthorizeTest()
        {
            return View();
        }
    }
}