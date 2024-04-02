using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using V3WebAppOutside.Models;

namespace V3WebAppOutside.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            SendSMSRequest req = new SendSMSRequest
            {
                PhoneNum = "189189189",
                Msg = "hello world!"
            };
            string jsonReq = JsonConvert.SerializeObject(req);

            using (var http = new HttpClient())
            using (var content = new StringContent(jsonReq, Encoding.UTF8, "application/json"))
            {
                http.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(LoginController.Token);
                var resp = await http.PostAsync("http://127.0.0.1:5000/MsgService/SMS/Send_MI", content);
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return Content("登录成功");
                }
                else
                {
                    return Content("登录失败");
                }
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}