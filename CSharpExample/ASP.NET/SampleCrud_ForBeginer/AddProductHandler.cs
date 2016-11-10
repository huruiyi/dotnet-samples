using System;
using System.Data.SqlClient;
using System.Web;

namespace HW
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
                string pname = context.Request.Form["pronane"];
                string ptype = context.Request.Form["ptype"];
                string pprice = context.Request.Form["pprice"];

                string ImagesPath = context.Server.MapPath("~/Images");
                HttpPostedFile pimage = context.Request.Files["pimage"];
                pimage.SaveAs(ImagesPath + "//" + pid + ".jpg");

                ProductModel pro = new ProductModel();
                pro.ProductID = pid;
                pro.ProductName = pname;
                pro.UnitPrice = Convert.ToDecimal(pprice);
                pro.Producttype = ptype;
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
                        cmd.Parameters.AddWithValue("@pid", pro.ProductID);
                        cmd.Parameters.AddWithValue("@pname", pro.ProductName);
                        cmd.Parameters.AddWithValue("@pprice", pro.UnitPrice);
                        cmd.Parameters.AddWithValue("@ptype", int.Parse(pro.Producttype));
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