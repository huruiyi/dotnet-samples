using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// Graphics1 的摘要说明
    /// </summary>
    public class Graphics1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";

            using (Image image = new Bitmap(100, 20))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.DrawString("仙剑奇侠传", new Font("微软雅黑", 12), Brushes.OrangeRed, new PointF(0, 0));
                    image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
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