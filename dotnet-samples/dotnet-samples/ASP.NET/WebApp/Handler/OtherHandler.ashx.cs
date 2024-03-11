using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using WebApp.Models;

namespace WebApp.Handler
{
    /// <summary>
    /// OtherHandler 的摘要说明
    /// </summary>
    public class OtherHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "NumberFormats":
                    NumberFormats(context);
                    break;

                case "Graphics1":
                    Graphics1(context);
                    break;

                case "Graphics2":
                    Graphics2(context);
                    break;

                case "Graphics3":
                    Graphics3(context);
                    break;

                case "Vcode1":
                    Vcode1(context);
                    break;

                case "GetOrderInfo":
                    GetOrderInfo(context);
                    break;
            }
        }

        private void GetOrderInfo(HttpContext context)
        {
            List<OrderInfo> orderList = new List<OrderInfo>();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                orderList.Add(new OrderInfo
                {
                    OrderId = $"010{i.ToString().PadLeft(4, '0')}",
                    SerialNumber = $"sy010{i.ToString().PadLeft(4, '0')}",
                    ShortNumber = $"{i.ToString().PadLeft(4, '0')}",
                    BookingDate = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd HH:mm:ss"),
                    ProductId = i.ToString().PadLeft(4, '0'),
                    SalePrice = 1000 + i
                });
            }
            string ordersJson = JsonConvert.SerializeObject(orderList);
            context.Response.Write(ordersJson);
        }

        private void Vcode1(HttpContext context)
        {
            string validateCode = "Hello World";
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                    Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        private void Graphics3(HttpContext context)
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

        private void Graphics2(HttpContext context)
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

        private void Graphics1(HttpContext context)
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

        private void NumberFormats(HttpContext context)
        {
            List<object> obj = new List<object>();

            for (int i = 0; i < 1000; i++)
            {
                obj.Add(new
                {
                    Bin = Convert.ToString(i, 2).PadLeft(16, '0'),
                    Oct = "0" + Convert.ToString(i, 8),
                    Dec = i.ToString().PadLeft(8, '0'),
                    Hex1 = "0x" + Convert.ToString(i, 16).ToUpper(),
                    Hex2 = "0x" + i.ToString("x").ToUpper(),
                    Hex3 = "0x" + i.ToString("x2").ToUpper(),
                });
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(obj);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
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