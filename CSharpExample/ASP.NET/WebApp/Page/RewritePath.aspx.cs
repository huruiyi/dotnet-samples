using System;
using System.Net;
using System.Web;

namespace WebApp.page
{
    public partial class RewritePath : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(HttpContext.Current.Request.UrlReferrer);
            //Response.Write(HttpContext.Current.Request.RawUrl);
            //Response.Write(HttpContext.Current.Request.Path);

            //根据地址下载文件
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://img1.40017.cn/cn/s/yry/img/shouceV1.1.pdf");
            Response.BinaryWrite(bytes);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.pdf"));

            //根据文件路径下载文件

            //Response.WriteFile(@"H:\Workplace\WebApp\Image\示例图片abc12.jpg", true);
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.jpg"));
        }
    }
}