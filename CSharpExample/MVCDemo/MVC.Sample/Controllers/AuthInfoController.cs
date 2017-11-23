using MVC.Sample.Common;
using MVC.Sample.Models;
using System;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class AuthInfoController : Controller
    {
        private AuthorizationDBEntities dbAuthEntities = new AuthorizationDBEntities();

        // GET: AuthInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPermisson()
        {
            string text = Request["PermissionText"];
            string order = Request["PermissionOrderNumer"];
            Permission pModel = new Permission
            {
                Text = text,
                OrderNumer = Convert.ToInt32(order),
                PermissionTypeId = 0,
                IfDel = DelEnum.No.ToByte(),
                IfValid = ValidEnum.Yes.ToByte()
            };
            dbAuthEntities.Permission.Add(pModel);
            int result = dbAuthEntities.SaveChanges();
            return Content(result > 0 ? "添加成功" : "添加失败");
        }
    }
}