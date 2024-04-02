using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using WebApp.Infrastructure;
using WebApp.Models;

namespace WebApp.Handler
{
    /// <summary>
    /// Product_DisplayGoodsHandler 的摘要说明
    /// </summary>
    public class Product_DisplayGoodsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string html = File.ReadAllText(context.Server.MapPath("~/htmls/DisplayGoodsTemp.html"));

            #region 从数据库获取全部商品信息并加入到商品集合中

            List<Product> pros = new List<Product>();
            Product pro;
            string sql = "select * from Product";
            SqlDataReader sdr = SQLHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                pro = new Product
                {
                    AutoKey = sdr["AutoKey"].ToString(),
                    ProductID = sdr["ProductID"].ToString(),
                    ProductName = sdr["ProductName"].ToString(),
                    Producttype = sdr["Producttype"].ToString(),
                    UnitPrice = Convert.ToDecimal(sdr["UnitPrice"]),
                    ImagePath = "../Images/" + sdr["ImagePath"]
                };
                pros.Add(pro);
            }

            #endregion 从数据库获取全部商品信息并加入到商品集合中

            List<string> goodsType = new List<string>();
            for (int i = 0; i < pros.Count; i++)
            {
                if (!goodsType.Contains(pros[i].Producttype))
                {
                    goodsType.Add(pros[i].Producttype);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string gt in goodsType)
            {
                sb.AppendFormat("<p>{0}</p>", gt);
                sb.Append("<table>");
                sb.Append("<tr>");
                for (int i = 0; i < pros.Count; i++)
                {
                    if (gt == pros[i].Producttype)
                    {
                        sb.Append("<td>");
                        sb.AppendFormat("<a href='BuyProduct?pid={0}'>", pros[i].ProductID);
                        sb.AppendFormat("<img src='{0}' width='150px' height='150px'>", pros[i].ImagePath);
                        sb.Append("</a>");
                        sb.Append("</td>");
                    }
                }
                sb.Append("</tr>");
                sb.Append("<tr>");
                for (int i = 0; i < pros.Count; i++)
                {
                    if (gt == pros[i].Producttype)
                    {
                        sb.AppendFormat("<td align='center'>{2:F2}&nbsp;&nbsp;<a href='BuyProduct?pid={1}'>{0}</a></td>",
                            pros[i].ProductName, pros[i].ProductID, pros[i].UnitPrice);
                    }
                }
                sb.Append("</tr>");
                sb.Append("</table>");
            }
            html = html.Replace("{商品列表}", sb.ToString());
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