using ForBeginer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace ForBeginer
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
                            List<string> types = new List<string> { "分类1", "分类2", "分类3", "分类4" };
                            for (int i = 0; i < types.Count; i++)
                            {
                                if (ptype == types[i])
                                {
                                    categories += $"<option value='{i + 1}' selected='selected'>{types[i]}</option>";
                                }
                                else
                                {
                                    categories += $"<option value='{i + 1}'>{types[i]}</option>";
                                }
                            }

                            htnlString = htnlString.Replace("{ptype}", categories);

                            string path = string.Format("../Images/" + sdr["ImagePath"]);
                            htnlString = htnlString.Replace("{pimage}", path);
                            htnlString = htnlString.Replace("{Autokey}", sdr["Autokey"].ToString());
                        }
                    }
                }
                context.Response.ContentType = "text/html";
                context.Response.Write(htnlString);
            }
            else if (context.Request.RequestType == "POST")
            {
                string autoKey = context.Request.Form["AutoKey"];
                string pid = context.Request.Form["pid"];
                string name = context.Request.Form["pnane"];
                string type = context.Request.Form["ptype"];
                string price = context.Request.Form["pprice"];

                string imagesPath = context.Server.MapPath("/Images");
                HttpPostedFile pimage = context.Request.Files["pimage"];
                if (pimage.FileName.Length > 0)
                {
                    pimage.SaveAs(imagesPath + "//" + pid + ".jpg");
                }

                ProductModel pro = new ProductModel
                {
                    ProductId = pid,
                    ProductName = name,
                    UnitPrice = Convert.ToDecimal(price),
                    ProductType = type,
                    ImagePath = pid + ".jpg"
                };
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
                        cmd.Parameters.AddWithValue("@ProductID", pro.ProductId);
                        cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                        cmd.Parameters.AddWithValue("@UnitPrice", pro.UnitPrice);
                        cmd.Parameters.AddWithValue("@Producttype", pro.ProductType);
                        cmd.Parameters.AddWithValue("@ImagePath", pro.ImagePath);
                        cmd.Parameters.AddWithValue("@AutoKey", autoKey);
                        cmd.ExecuteNonQuery();
                        context.Response.Redirect("proList.aspx");
                    }
                }
            }
        }
    }
}