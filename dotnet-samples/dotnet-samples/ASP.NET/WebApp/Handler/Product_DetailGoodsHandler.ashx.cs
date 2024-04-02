using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using WebApp.Infrastructure;
using WebApp.Models;

namespace WebApp.Handler
{
    /// <summary>
    /// Product_DetailGoodsHandler 的摘要说明
    /// </summary>
    public class Product_DetailGoodsHandler : IHttpHandler, IRequiresSessionState
    {
        public static List<Shopping> _mss;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RequestType == "GET")
            {
                string pid = context.Request.QueryString["pid"];

                #region 判断此商品是否已经添加到购物车

                string alreadybuycount = "";
                if (_mss != null)
                {
                    for (int i = 0; i < _mss.Count; i++)
                    {
                        if (_mss[i].proid == pid)
                        {
                            alreadybuycount = _mss[i].buyCount;
                            break;
                        }
                    }
                }

                #endregion 判断此商品是否已经添加到购物车

                string sql = "select * from Product where ProductID=@ProductID";
                SqlDataReader sdr = SQLHelper.ExecuteReader(sql, new SqlParameter("@ProductID", pid));
                Product pro = new Product();
                pro.ProductID = pid;
                while (sdr.Read())
                {
                    pro.ProductName = sdr["ProductName"].ToString();
                    pro.UnitPrice = Convert.ToDecimal(sdr["UnitPrice"]);
                    pro.ImagePath = "../Images/" + sdr["ImagePath"];
                    context.Session["pid"] = pid;
                    context.Session["proname"] = pro.ProductName;
                    context.Session["proprice"] = pro.UnitPrice;
                }

                string html = File.ReadAllText(context.Server.MapPath("~/htmls/DetailGoods.html"));
                html = html.Replace("{产品图片}", $"<img src='{pro.ImagePath}' width='300px' height='300px'>");
                html = html.Replace("{产品ID}", pro.ProductID);
                html = html.Replace("{产品名称}", pro.ProductName);
                html = html.Replace("{产品单价}", pro.UnitPrice.ToString());
                html = html.Replace("{联系电话}", "<input typr='text' name='userphone'/>");
                html = html.Replace("{送货地址}", "<input type='text' name='useraddress'/>");
                string bcount = "0";
                for (int i = 1; i < 51; i++)
                {
                    bcount += string.Format("<option value='{0}'>{0}</option>", i);
                }
                html = html.Replace("{购买数量}", bcount);

                if (alreadybuycount != "")
                {
                    html = html.Replace("{已购买数量}", "<p>已购买:" + alreadybuycount + "件</p>");
                }
                else if (alreadybuycount == "")
                {
                    html = html.Replace("{已购买数量}", "");
                }
                context.Response.Write(html);
            }
            else if (context.Request.RequestType == "POST")
            {
                if (context.Session["sadmin"] != null && context.Session["spwd"] != null)
                {
                    string proid = context.Session["pid"].ToString();
                    string proname = context.Session["proname"].ToString();
                    decimal proprice = Convert.ToDecimal(context.Session["proprice"]);
                    string userphone = context.Request.Form["userphone"];
                    string useraddress = context.Request.Form["useraddress"];
                    string buyCount = context.Request.Form["buyCount"];

                    if (_mss == null)
                    {
                        _mss = new List<Shopping>();

                        #region 添加首个商品

                        Shopping ms = new Shopping();
                        ms.sadmin = context.Session["sadmin"].ToString();
                        ms.proid = proid;
                        ms.proname = proname;
                        ms.proprice = proprice;
                        ms.userphone = userphone;
                        ms.useraddress = useraddress;
                        ms.buyCount = buyCount;
                        _mss.Add(ms);

                        #endregion 添加首个商品
                    }
                    else if (_mss != null)
                    {
                        foreach (Shopping ims in _mss)
                        {
                            if (ims.proid != proid)//如果此商品ID不存在
                            {
                                Shopping ms = new Shopping();
                                ms.sadmin = context.Session["sadmin"].ToString();
                                ms.proid = proid;
                                ms.proname = proname;
                                ms.proprice = proprice;
                                ms.userphone = userphone;
                                ms.useraddress = useraddress;
                                ms.buyCount = buyCount;
                                _mss.Add(ms);
                                break;
                            }
                            else//如果商品已购买过,则增加数量,(修改),(添加)新的联系电话,和送货地址
                            {
                                int ibuyCount = Convert.ToInt32(ims.buyCount);
                                ibuyCount += Convert.ToInt32(buyCount);
                                buyCount = ibuyCount.ToString();
                                ims.buyCount = buyCount;
                                ims.userphone = userphone;
                                ims.useraddress = useraddress;
                                break;
                            }
                        }
                    }
                    context.Response.Redirect("~/SubOrder");
                }
                else
                {
                    context.Response.Redirect("/Htmls/Index.html");
                }
            }
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