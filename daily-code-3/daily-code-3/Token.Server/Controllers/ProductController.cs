using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using Token.Models;
using Token.Server.Common;
using Token.Server.Filters;

namespace Token.Server.Controllers
{
    [ApiSecurityFilter]
    public class ProductController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetProduct(string id)
        {
            var product = new Product { Id = 1, Name = "哇哈哈", Count = 10, Price = 38.8 };
            var resultMsg = new HttpResponseMsg
            {
                StatusCode = (int)StatusCodeEnum.Success,
                Info = StatusCodeEnum.Success.GetEnumText(),
                Data = product
            };
            return HttpResponseExtension.ToJson(JsonConvert.SerializeObject(resultMsg));
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddProudct(Product product)
        {
            var resultMsg = new HttpResponseMsg
            {
                StatusCode = (int)StatusCodeEnum.Success,
                Info = StatusCodeEnum.Success.GetEnumText(),
                Data = product
            };
            return HttpResponseExtension.ToJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}