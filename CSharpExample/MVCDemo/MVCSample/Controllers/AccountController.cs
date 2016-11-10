using MVCSample.Models;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthorizeError()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //判断用户输入信息是否符合Model中定义的验证
            if (ModelState.IsValid)
            {
                if (model.Password == model.RePassword)
                {
                    // 进行新增用户操作
                    return RedirectToAction("LogOn");
                }
                else
                {
                    // 增加错误信息，第一个参数是 向哪个属性增加错误信息
                    ModelState.AddModelError("RePassword", "确认密码和密码不一致");
                }
            }
            return View(model);
        }

        public ActionResult LogOn(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.xxx = "";
            ViewBag.yyy = "";
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["CurrentUser"] = model.UserName;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}