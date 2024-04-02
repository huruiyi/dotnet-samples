using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V3WebAppOutside.Models;

namespace V3WebAppOutside.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public static string Token;

        public async Task<ActionResult> UserLogin(LoginRequest model)
        {
            LoginRequest req = new LoginRequest
            {
                UserName = model.UserName,
                Password = model.Password
            };
            string jsonReq = JsonConvert.SerializeObject(req);
            using (HttpClient http = new HttpClient())
            using (var content = new StringContent(jsonReq, Encoding.UTF8, "application/json"))
            {
                var resp = await http.PostAsync("http://127.0.0.1:5000/LoginService/Login", content);
                string result = await resp.Content.ReadAsStringAsync();
                if (resp.IsSuccessStatusCode)
                {
                    string jsonResp = await resp.Content.ReadAsStringAsync();
                    dynamic respObj = JsonConvert.DeserializeObject<dynamic>(jsonResp);
                    string accessToken = respObj.access_token;
                    string tokenType = respObj.token_type;
                    Token = tokenType + " " + accessToken;
                }
                return Content(result, "application/json");
            }
        }
    }
}