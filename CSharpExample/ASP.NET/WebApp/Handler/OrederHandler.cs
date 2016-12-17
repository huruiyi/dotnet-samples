using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using WebApp.Models;

namespace WebApp.Handler
{
    public class OrederHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string html = File.ReadAllText(context.Server.MapPath("~/htmls/MyOrders.html"));
            StringBuilder sb = new StringBuilder();
            if (DetailGoodsHandler.mss != null)
            {
                foreach (Shopping m in DetailGoodsHandler.mss)
                {
                    string ss = context.Session["sadmin"].ToString();
                    if (m.sadmin == context.Session["sadmin"].ToString())
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + m.proid + "</td>");
                        sb.Append("<td>" + m.proname + "</td>");
                        sb.Append("<td>" + m.proprice + "</td>");
                        sb.Append("<td>" + m.buyCount + "</td>");
                        sb.Append("<td>" + m.userphone + "</td>");
                        sb.Append("<td>" + m.sadmin + "</td>");
                        sb.Append("<td>" + m.useraddress + "</td>");
                        sb.Append("</tr>");
                    }
                }
            }
            html = html.Replace("{详细订单}", sb.ToString());
            context.Response.Write(html);
        }
    }
}