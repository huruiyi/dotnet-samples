using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Token.Models;
using Token.Server.Common;

namespace Token.Server.Controllers
{
    public class ServiceController : ApiController
    {
        /// <summary>
        /// 根据用户名获取token
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetToken(string staffId)
        {
            HttpResponseMsg resultMsg;
            int id;

            //判断参数是否合法
            if (string.IsNullOrEmpty(staffId) || (!int.TryParse(staffId, out id)))
            {
                resultMsg = new HttpResponseMsg
                {
                    StatusCode = (int)StatusCodeEnum.ParameterError,
                    Info = StatusCodeEnum.ParameterError.GetEnumText(),
                    Data = ""
                };
                return HttpResponseExtension.ToJson(JsonConvert.SerializeObject(resultMsg));
            }

            //插入缓存
            TokenInfo token = (TokenInfo)HttpRuntime.Cache.Get(id.ToString());
            if (HttpRuntime.Cache.Get(id.ToString()) == null)
            {
                token = new TokenInfo
                {
                    StaffId = id,
                    SignToken = Guid.NewGuid(),
                    ExpireTime = DateTime.Now.AddDays(1)
                };
                HttpRuntime.Cache.Insert(token.StaffId.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            }

            //返回token信息
            resultMsg = new HttpResponseMsg
            {
                StatusCode = (int)StatusCodeEnum.Success,
                Info = "",
                Data = token
            };

            return HttpResponseExtension.ToJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}