using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// HttpWebRequestImage 的摘要说明
    /// </summary>
    public class HttpWebRequestImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string address = "http://www.baidu.com/img/bdlogo.gif";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(address);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream ImgStream = response.GetResponseStream();
            if (ImgStream != null)
            {
                Image image = new Bitmap(ImgStream);
                string fileName = DateTime.Now.ToString("yyyyMMddss") + ".gif";
                string serverPath = HttpContext.Current.Server.MapPath("~/Images/") + fileName;
                image.Save(serverPath);
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