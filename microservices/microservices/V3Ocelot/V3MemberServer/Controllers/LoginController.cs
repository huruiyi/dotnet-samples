using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V3MemberServer.Models;

namespace V3MemberServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> RequestToken(LoginRequest model)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["client_id"] = "clientPC1",
                ["client_secret"] = "123321",
                ["grant_type"] = "password",
                ["username"] = model.UserName,
                ["password"] = model.Password
            };

            Console.WriteLine($"用户名：{model.UserName}，密码:{model.Password}");

            //由登录服务器向IdentityServer发请求获取Token
            using (HttpClient http = new HttpClient())
            using (var content = new FormUrlEncodedContent(dict))
            {
                var msg = await http.PostAsync("http://localhost:9500/connect/token", content);
                string result = await msg.Content.ReadAsStringAsync();
                return Content(result, "application/json");
            }
        }
    }
}