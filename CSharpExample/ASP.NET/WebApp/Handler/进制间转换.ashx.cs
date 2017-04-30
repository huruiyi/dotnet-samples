using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApp.Handler
{
    /// <summary>
    /// 进制间转换 的摘要说明
    /// </summary>
    public class 进制间转换 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            List<object> obj = new List<object>();

            for (int i = 0; i < 1000; i++)
            {
                obj.Add(new
                {
                    Bin = Convert.ToString(i, 2).PadLeft(16, '0'),
                    Oct = "0" + Convert.ToString(i, 8),
                    Dec = i.ToString().PadLeft(8, '0'),
                    Hex1 = "0x" + Convert.ToString(i, 16).ToUpper(),
                    Hex2 = "0x" + i.ToString("x").ToUpper(),
                    Hex3 = "0x" + i.ToString("x2").ToUpper(),
                });
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(obj);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}