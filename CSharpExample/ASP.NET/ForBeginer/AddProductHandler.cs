using ForBeginer.Model;
using System;
using System.Data.SqlClient;
using System.Web;

namespace ForBeginer
{
    public class AddProductHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string ispostback = context.Request.Form["isPostBack"];
            if (ispostback == "true")
            {
                string pid = context.Request.Form["pid"];
                string name = context.Request.Form["pronane"];
                string type = context.Request.Form["ptype"];
                string price = context.Request.Form["pprice"];

                string imagesPath = context.Server.MapPath("~/Images");
                HttpPostedFile pimage = context.Request.Files["pimage"];
                pimage.SaveAs(imagesPath + "//" + pid + ".jpg");

                ProductModel pro = new ProductModel();
                pro.ProductId = pid;
                pro.ProductName = name;
                pro.UnitPrice = Convert.ToDecimal(price);
                pro.ProductType = type;
                pro.ImagePath = pid + ".jpg";

                string ConString = "Data Source=.;Initial Catalog=ProductManage;uid=sa;pwd=sa";
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    string sql = @"INSERT INTO [ProductManage].[dbo].[Product]
                                       ([ProductID]
                                       ,[ProductName]
                                       ,[UnitPrice]
                                       ,[Producttype]
                                       ,[ImagePath])
                                 VALUES
                                      ( @pid    ,@pname  ,@pprice   ,@ptype   ,@pimage)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@pid", pro.ProductId);
                        cmd.Parameters.AddWithValue("@pname", pro.ProductName);
                        cmd.Parameters.AddWithValue("@pprice", pro.UnitPrice);
                        cmd.Parameters.AddWithValue("@ptype", int.Parse(pro.ProductType));
                        cmd.Parameters.AddWithValue("@pimage", pro.ImagePath);
                        cmd.ExecuteNonQuery();
                        context.Response.Redirect("proList.aspx");
                    }
                }
            }
            context.Request.ContentType = "text/html";
        }
    }
}