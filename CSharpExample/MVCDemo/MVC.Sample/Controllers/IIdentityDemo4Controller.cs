using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class IIdentityDemo4Controller : Controller
    {
        // GET: IIdentityDemo4
        public ActionResult Index()
        {
            var myIndetity = new MyIndetity4("huruiyi", new List<string> { "user" }, 13456);
            HttpContext.User = new MyPrincal4(myIndetity);
            var a = HttpContext.User.IsInRole("admin");
            var b = HttpContext.User.Identity.IsAuthenticated;
            return View();
        }

        public class MyIndetity4 : IIdentity
        {
            public string UserName { get; set; }

            public int UserId { get; set; }

            public decimal UserSalary { get; set; }

            public List<string> UserRoleList { get; set; }

            public MyIndetity4(string username, List<string> rolelist, int userid)
            {
                this.UserName = username;
                this.UserId = userid;
                this.UserRoleList = rolelist;
            }

            public string AuthenticationType
            {
                get { return "Form"; }
            }

            public bool IsAuthenticated
            {
                get
                {
                    if (this.UserRoleList.Contains("admin"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public string Name
            {
                get { return this.UserName; }
            }
        }

        public class MyPrincal4 : IPrincipal
        {
            private readonly MyIndetity4 _myIndetity;

            public MyPrincal4(MyIndetity4 myIndetity)
            {
                _myIndetity = myIndetity;
            }

            public IIdentity Identity
            {
                get { return _myIndetity; }
            }

            public bool IsInRole(string role)
            {
                if (_myIndetity.UserRoleList.Contains(role))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}