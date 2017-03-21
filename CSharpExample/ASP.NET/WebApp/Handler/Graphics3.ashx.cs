using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// Graphics3 的摘要说明
    /// </summary>
    public class Graphics3 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var drawFont = new Font("微软雅黑", 12);
            var image = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(image);
            SizeF sf = g.MeasureString("仙剑奇侠传", drawFont, 1024); //设置一个显示的宽度

            image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            g = Graphics.FromImage(image);
            g.Clear(Color.Red);
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.DrawString("仙剑奇侠传", drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            image.Save(context.Response.OutputStream, ImageFormat.Png);
            context.Response.ContentType = "image/png";

            //image.Save("D:\\1.jpg", ImageFormat.Png);
            //g.Dispose();
            //image.Dispose();
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