using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace HW
{
    public class UpdateProductHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string ConString = "Data Source=.;Initial Catalog=ProductManage;uid=sa;pwd=sa";

            if (context.Request.RequestType == "GET")
            {
                string pid = context.Request.QueryString["pd"];
                string htmlPath = context.Server.MapPath("/Template/UpdateProductInfo.html");
                string htnlString = File.ReadAllText(htmlPath);
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    string sql = string.Format("select * from Product where ProductID='{0}'", pid);
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            htnlString = htnlString.Replace("{pid}", sdr["ProductID"].ToString());
                            htnlString = htnlString.Replace("{pname}", sdr["ProductName"].ToString());
                            htnlString = htnlString.Replace("{pprice}", sdr["UnitPrice"].ToString());

                            string ptype = sdr["Producttype"].ToString();
                            string categories = "";
                            List<string> ltypes = new List<string> { "分类1", "分类2", "分类3", "分类4" };
                            foreach (string item in ltypes)
                            {
                                if (ptype == item)
                                {
                                    categories += string.Format("<option value='{0}' selected='selected'>{0}</option>", item);
                                }
                                else
                                {
                                    categories += string.Format("<option value='{0}'>{0}</option>", item);
                                }
                            }
                            htnlString = htnlString.Replace("{ptype}", categories);

                            string ipath = string.Format("../Images/" + sdr["ImagePath"].ToString());
                            htnlString = htnlString.Replace("{pimage}", ipath);
                            htnlString = htnlString.Replace("{Autokey}", sdr["Autokey"].ToString());
                        }
                    }
                }
                context.Response.ContentType = "text/html";
                context.Response.Write(htnlString);
            }
            else if (context.Request.RequestType == "POST")
            {
                string AutoKey = context.Request.Form["AutoKey"];
                string pid = context.Request.Form["pid"];
                string pname = context.Request.Form["pnane"];
                string ptype = context.Request.Form["ptype"];
                string pprice = context.Request.Form["pprice"];

                string ImagesPath = context.Server.MapPath("/Images");
                HttpPostedFile pimage = context.Request.Files["pimage"];
                if (pimage.FileName.Length > 0)
                {
                    pimage.SaveAs(ImagesPath + "//" + pid + ".jpg");
                }

                ProductModel pro = new ProductModel();
                pro.ProductID = pid;
                pro.ProductName = pname;
                pro.UnitPrice = Convert.ToDecimal(pprice);
                pro.Producttype = ptype;
                pro.ImagePath = pid + ".jpg";
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    string sql = @"UPDATE Product
                                           SET ProductID = @ProductID
                                              ,ProductName = @ProductName
                                              ,UnitPrice= @UnitPrice
                                              ,Producttype = @Producttype
                                              ,ImagePath= @ImagePath
                                         WHERE Autokey=@Autokey";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", pro.ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                        cmd.Parameters.AddWithValue("@UnitPrice", pro.UnitPrice);
                        cmd.Parameters.AddWithValue("@Producttype", pro.Producttype);
                        cmd.Parameters.AddWithValue("@ImagePath", pro.ImagePath);
                        cmd.Parameters.AddWithValue("@AutoKey", AutoKey.ToString());
                        cmd.ExecuteNonQuery();
                        context.Response.Redirect("proList.");
                    }
                }
            }
        }
    }
}