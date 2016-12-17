using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace WebApp.Handler
{
    public class BitmapHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //var drawFont = new Font("宋体", 12);
            //var image = new Bitmap(1, 1);
            //Graphics g = Graphics.FromImage(image);
            //SizeF sf = g.MeasureString("文本信息", drawFont, 1024); //设置一个显示的宽度

            //image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            //g = Graphics.FromImage(image);
            //g.Clear(Color.Red);
            //g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //g.DrawString("文本信息", drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            //image.Save(context.Response.OutputStream, ImageFormat.Png);
            //context.Response.ContentType = "image/png";

            ////image.Save("D:\\1.jpg", ImageFormat.Png);
            ////g.Dispose();
            ////image.Dispose();

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
    }
}