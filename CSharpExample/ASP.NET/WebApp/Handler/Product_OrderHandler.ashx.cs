using System.IO;
using System.Text;
using System.Web;
using WebApp.Models;

namespace WebApp.Handler
{
    /// <summary>
    /// Product_OrderHandler 的摘要说明
    /// </summary>
    public class Product_OrderHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string html = File.ReadAllText(context.Server.MapPath("~/htmls/MyOrders.html"));
            StringBuilder sb = new StringBuilder();
            if (Product_DetailGoodsHandler._mss != null)
            {
                foreach (Shopping m in Product_DetailGoodsHandler._mss)
                {
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}