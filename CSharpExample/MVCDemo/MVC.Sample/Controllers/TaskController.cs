using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

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
    }
}