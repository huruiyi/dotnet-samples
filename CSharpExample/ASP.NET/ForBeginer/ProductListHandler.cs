using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using ForBeginer.Model;

namespace ForBeginer
{
    public class ProductListHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string htmlPath = context.Server.MapPath("/Template/ProductList.html");

            string htnlString = File.ReadAllText(htmlPath);
            List<ProductModel> pros = new List<ProductModel>();

            string ConString = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string sql = "select * from Product";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var pro = new ProductModel
                        {
                            ProductId = sdr["ProductID"].ToString(),
                            ProductName = sdr["ProductName"].ToString(),
                            ProductType = sdr["Producttype"].ToString(),
                            UnitPrice = Convert.ToDecimal(sdr["UnitPrice"]),
                            ImagePath = "Images/" + sdr["ImagePath"]
                        };
                        pros.Add(pro);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (ProductModel p in pros)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td><a href='Update.aspx?pd={0}'>{1}</a></td>", p.ProductId, p.ProductId);
                sb.Append("<td>" + p.ProductName + "</td>");
                sb.Append("<td>" + p.UnitPrice + "</td>");
                sb.Append("<td>" + p.ProductType + "</td>");
                sb.Append("<td>");
                sb.AppendFormat("<img src=\"../{0}\"/>", p.ImagePath);
                sb.Append("</td>");
                sb.Append("<td>");

                sb.AppendFormat("<a href='ToList.aspx?pd={0}'>删除</a>", p.ProductId);
                sb.AppendFormat("<a href='Update.aspx?pd={0}'>修改</a>", p.ProductId);
                sb.Append("</td>");
                sb.Append("<tr>");
            }

            htnlString = htnlString.Replace("{@Product}", sb.ToString());
            context.Response.Write(htnlString);
        }
    }
}