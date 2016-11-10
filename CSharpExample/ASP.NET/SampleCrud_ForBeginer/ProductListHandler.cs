using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;

namespace HW
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
            ProductModel pro = new ProductModel();

            string ConString = "Data Source=.;Initial Catalog=ProductManage;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string sql = "select * from Product";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        pro = new ProductModel();
                        pro.ProductID = sdr["ProductID"].ToString();
                        pro.ProductName = sdr["ProductName"].ToString();
                        pro.Producttype = sdr["Producttype"].ToString();
                        pro.UnitPrice = Convert.ToDecimal(sdr["UnitPrice"]);
                        pro.ImagePath = "Images/" + sdr["ImagePath"].ToString();
                        pros.Add(pro);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (ProductModel p in pros)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td><a href='Update.aspx?pd={0}'>{1}</a></td>", p.ProductID, p.ProductID);
                sb.Append("<td>" + p.ProductName + "</td>");
                sb.Append("<td>" + p.UnitPrice + "</td>");
                sb.Append("<td>" + p.Producttype + "</td>");
                sb.Append("<td>");
                sb.AppendFormat("<img src=\"../{0}\"/>", p.ImagePath);
                sb.Append("</td>");
                sb.Append("<td>");

                sb.AppendFormat("<a href='ToList.aspx?pd={0}'>删除</a>", p.ProductID);
                sb.AppendFormat("<a href='Update.aspx?pd={0}'>修改</a>", p.ProductID);
                sb.Append("</td>");
                sb.Append("<tr>");
            }

            htnlString = htnlString.Replace("{@Product}", sb.ToString());
            context.Response.Write(htnlString);
        }
    }
}