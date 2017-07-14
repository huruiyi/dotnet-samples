using MVCFilter.Models;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVCFilter.Controllers
{
    public class FormDemoController : Controller
    {
        // GET: FormDemo
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        protected MemberPrincipal ShopMember
        {
            get
            {
                return HttpContext.User as MemberPrincipal;
            }
        }

        [Authorize(Roles = "Admin")]
        public ContentResult Admin()
        {
            return Content("你是管理员");
        }

        [Authorize(Roles = "User")]
        public new ContentResult User()
        {
            return Content("你是普通用户");
        }

        public void Login()
        {
            MemberInfo serializeModel = new MemberInfo
            {
                MemberId = 807776962,
                MemberName = "ifairy",
                MemberEmail = "807776962",
                MemberMobile = "12345678910",
                MemberTrueName = "ifairy",
                Role = "Admin"
            };
            var serializer = new JavaScriptSerializer();
            string memberUseruserData = serializer.Serialize(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, serializeModel.MemberName, DateTime.Now, DateTime.Now.AddMinutes(30), false, memberUseruserData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            var loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(loginCookie);

            #region MyRegion

            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            string encryptedTicket = authCookie.Value;
            var ticket = FormsAuthentication.Decrypt(encryptedTicket);  //解密cookie中的票据信息
            string[] roles = { ticket.UserData };//获取用户角色信息
            var identity = new FormsIdentity(ticket);    //创建用户标识
            GenericPrincipal user = new GenericPrincipal(identity, roles);  //创建用户的主体信息
            HttpContext.User = user;

            #endregion MyRegion
        }
    }
}