using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Controllers
{
    public class IIdentityDemo2Controller : Controller
    {
        // GET: IIdentityDemo2
        public ContentResult Index()
        {
            //var MyIndetity2 = new MyIndetity2("fairy", new List<string> { "admin" }, 13456);
            var MyIndetity2 = new MyIndetity2
            {
                UserName = "user1",
                UserId = 13456,
                Roles = "role1,role2"
            };

            HttpContext.User = new MyPrincal2(MyIndetity2);
            var a = HttpContext.User.Identity.IsAuthenticated;
            var b = HttpContext.User.IsInRole(MyIndetity2.Roles);
            return Content("");
        }
    }

    public class MyIndetity2 : IIdentity
    {
        private static List<string> UesrList;

        public MyIndetity2()
        {
            UesrList = new List<string> { "user1", "user2", "user3", "user4" };
        }

        public string UserName { get; set; }

        public string Roles { get; set; }
        public int UserId { get; set; }

        public decimal UserSalary { get; set; }

        public MyIndetity2(string username, List<string> rolelist, int userid)
        {
            this.UserName = username;
            this.UserId = userid;
        }

        public string AuthenticationType
        {
            get { return "Form"; }
        }

        public bool IsAuthenticated
        {
            get
            {
                if (UesrList.Contains(this.UserName))
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

    public class MyPrincal2 : IPrincipal
    {
        private static List<string> RoleList;

        private readonly MyIndetity2 _MyIndetity2;

        public MyPrincal2(MyIndetity2 MyIndetity2)
        {
            _MyIndetity2 = MyIndetity2;
            RoleList = new List<string> { "role1", "role2", "role3" };
        }

        public IIdentity Identity
        {
            get { return _MyIndetity2; }
        }

        public bool IsInRole(string role)
        {
            if (_MyIndetity2.IsAuthenticated)
            {
                bool flag = false;
                string[] roles = role.Split(',');
                foreach (string item in roles)
                {
                    if (!RoleList.Contains(item))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            else
            {
                return false;
            }
        }
    }
}