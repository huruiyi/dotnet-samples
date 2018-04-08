using MVC.Sample.Common;
using MVC.Sample.Filters;
using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class SamplesController : Controller
    {
        public IMathService MathService;
        private AuthorizationDBEntities dbAuthEntities = new AuthorizationDBEntities();

        public SamplesController(IMathService mathService)
        {
            MathService = mathService;
        }

        // GET: Samples
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [MVCAPPActionFilter]
        public ActionResult UserCenter()
        {
            return PartialView();
        }

        [MVCAPPActionFilter]
        public ActionResult UserInfo()
        {
            Person person = new Person
            {
                Age = 5000,
                Hobby = "卧着",
                Name = "黄山"
            };
            return View(person);
        }

        public ActionResult DropDownListSample()
        {
            IDictionary<string, string> makes = GetSampleMakes();
            DropDownSampleModel viewModel = new DropDownSampleModel()
            {
                Makes = makes
            };
            List<SelectListItem> projectProjects = new List<SelectListItem>
            {
                new SelectListItem{Text="跟团游",Value="1"},
                new SelectListItem{Text="团队",Value="2"}
            };
            ViewData["ProjectType"] = projectProjects;
            return View(viewModel);
        }

        private IDictionary<string, string> GetSampleMakes()
        {
            IDictionary<string, string> makes = new Dictionary<string, string>();
            makes.Add("1", "跟团游");
            makes.Add("2", "团队");
            makes.Add("3", "其他");

            return makes;
        }

        public ActionResult PetTextBoxFor()
        {
            return View();
        }

        public ActionResult PersonCreate()
        {
            return View();
        }

        public ActionResult ValidationUrl()
        {
            return View();
        }

        #region EF

        public ActionResult EFIndex()
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

        #endregion EF

        #region Task

        //一直等待, 异常
        //public async Task<ActionResult> AwaitError()
        //{
        //    var responseHtml = GetResponseContentAsync("http://www.cnblogs.com/").Result;
        //    return Content(responseHtml);
        //}

        public async Task<ActionResult> AwaitOk()
        {
            var responseHtml =
                await Task.Factory.StartNew
                (
                    () => GetResponseContentAsync("http://www.cnblogs.com/").Result
                );
            return Content(responseHtml);
        }

        private async Task<string> GetResponseContentAsync(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "error";
        }

        public async Task<ActionResult> AwaitOk2()
        {
            var responseHtml = await GetResponseContentAsync("http://www.baidu.com/");
            return Content(responseHtml);
        }

        public async Task<ActionResult> AsyncAction()
        {
            await Task.Delay(10 * 1000);
            return View();
        }

        public ActionResult SyncAction()
        {
            Thread.Sleep(10 * 1000);
            return View();
        }

        #endregion

    }
}