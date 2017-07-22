using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// Graphics4 的摘要说明
    /// </summary>
    public class Graphics4 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        /// <summary>
        /// 为图片生成缩略图 by 何问起
        /// </summary>
        /// <param name="phyPath">原图片的路径</param>
        /// <param name="width">缩略图宽</param>
        /// <param name="height">缩略图高</param>
        /// <returns></returns>
        public Image GetThumbnail(Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle rectDestination = new Rectangle(0, 0, width, height);

            int m_width, m_height;
            if (image.Width * height > image.Height * width)
            {
                m_height = image.Height;
                m_width = (image.Height * width) / height;
            }
            else
            {
                m_width = image.Width;
                m_height = (image.Width * height) / width;
            }

            graphic.DrawImage(image, rectDestination, 0, 0, m_width, m_height, GraphicsUnit.Pixel);

            return bitmap;
        }

        ///<summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        public string MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image originalImage = Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;

                case "W"://指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;

                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;

                case "Cut"://指定高宽裁减（不变形）
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;

                default:
                    break;
            }

            Image bitmap = new Bitmap(towidth, toheight);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.InterpolationMode = InterpolationMode.High;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.Clear(Color.Transparent);
            graphic.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
             new Rectangle(x, y, ow, oh),
             GraphicsUnit.Pixel);
            try
            {
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                graphic.Dispose();
            }

            return thumbnailPath;
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