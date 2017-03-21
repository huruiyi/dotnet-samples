using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// Graphics2 的摘要说明
    /// </summary>
    public class Graphics2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int width = 500;
            int height = 150;
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphic = Graphics.FromImage(bitmap))
                {
                    graphic.Clear(Color.Purple);
                    graphic.DrawString("仙剑奇侠传", new Font("微软雅黑", 30), Brushes.Yellow, 100, 50);
                    graphic.DrawLine(new Pen(Color.White), new Point(1, 10), new Point(3, 18));
                    graphic.DrawLine(new Pen(Color.White), new Point(3, 14), new Point(6, 38));
                    graphic.DrawLine(new Pen(Color.White), new Point(100, 10), new Point(30, 18));
                    graphic.DrawLine(new Pen(Color.White), new Point(150, 19), new Point(38, 39));
                    bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                }
            }

            context.Response.ContentType = "image/JPEG";
            context.Response.Flush();
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