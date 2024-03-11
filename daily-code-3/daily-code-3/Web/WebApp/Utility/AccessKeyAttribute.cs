using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApp.Utility
{
    /// <summary>
    ///
    /// </summary>
    public class AccessKeyAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            if (request.Headers.Contains("access-key"))
            {
                var accessKey = request.Headers.GetValues("access-key").SingleOrDefault();
                //TODO 验证Key
                return accessKey == "123456789";
            }
            return false;
        }

        /// <summary>
        ///     处理未授权的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var content = JsonConvert.SerializeObject(new { State = HttpStatusCode.Unauthorized });
            actionContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.Unauthorized
            };
        }
    }
}