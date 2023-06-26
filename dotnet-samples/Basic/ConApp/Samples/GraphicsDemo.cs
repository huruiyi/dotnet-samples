using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace ConApp
{
    public partial class Program
    {
        public static void BitmapDemo0()
        {
            Bitmap bmp = new Bitmap(600, 500);
            Graphics dc = Graphics.FromImage(bmp);
            RectangleF[] rects = dc.Clip.GetRegionScans(new Matrix());

            for (int i = 0; i < rects.GetLength(0); i++)
                Console.WriteLine("clip: " + rects[i].ToString());

            Console.WriteLine("VisibleClipBounds: " + dc.VisibleClipBounds);
            Console.WriteLine("IsVisible Point 650, 650: " + dc.IsVisible(650, 650));
            Console.WriteLine("IsVisible Point 0, 0: " + dc.IsVisible(0.0f, 0.0f));

            Console.WriteLine("IsVisible Rectangle (20,20,100,100): " + dc.IsVisible(new Rectangle(20, 20, 100, 100)));
            Console.WriteLine("IsVisible Rectangle (1000, 1000,100,100): " + dc.IsVisible(new RectangleF(1000, 1000, 100, 100)));
        }

        public static void BitmapDemo1()
        {
            float width = 400.0F;
            float height = 800.0F;
            Bitmap bmp = new Bitmap((int)width, (int)height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);

            int LINES = 32;
            float MAX_THETA = (.80F * 90.0F);
            float THETA = (2 * MAX_THETA / (LINES - 1));

            GraphicsState oldState = gr.Save();

            Pen blackPen = new Pen(Color.Black, 2.0F);
            gr.TranslateTransform(width / 2.0F, height / 2.0F);
            gr.RotateTransform(MAX_THETA);
            for (int i = 0; i < LINES; i++)
            {
                gr.DrawLine(blackPen, -2.0F * width, 0.0F, 2.0F * width, 0.0F);
                gr.RotateTransform(-THETA);
            }

            gr.Restore(oldState);

            Pen redPen = new Pen(Color.Red, 6F);
            gr.DrawLine(redPen, width / 4F, 0F, width / 4F, height);
            gr.DrawLine(redPen, 3F * width / 4F, 0F, 3F * width / 4F, height);

            /* save image in all the formats */
            bmp.Save("hering.png", ImageFormat.Png);
            Console.WriteLine("output file hering.png");
            bmp.Save("hering.jpg", ImageFormat.Jpeg);
            Console.WriteLine("output file hering.jpg");
            bmp.Save("hering.bmp", ImageFormat.Bmp);
            Console.WriteLine("output file hering.bmp");
        }

        public static bool GetPicThumbnail(string sourceFile, string dFile, int dHeight, int dWidth, int flag)
        {
            Image iSource = Image.FromFile(sourceFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW, sH;

            //按比例缩放
            Size temSize = new Size(iSource.Width, iSource.Height);
            if (temSize.Width > dHeight || temSize.Width > dWidth) //将**改成c#中的或者操作符号
            {
                if ((temSize.Width * dHeight) > (temSize.Height * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * temSize.Height) / temSize.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (temSize.Width * dHeight) / temSize.Height;
                }
            }
            else
            {
                sW = temSize.Width;

                sH = temSize.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量

            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            //设置压缩的比例1-100

            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayIci = ImageCodecInfo.GetImageEncoders();

                ImageCodecInfo jpegIcIinfo = arrayIci.FirstOrDefault(t => t.FormatDescription.Equals("JPEG"));

                if (jpegIcIinfo != null)
                {
                    ob.Save(dFile, jpegIcIinfo, ep);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();

                ob.Dispose();
            }
        }

        public static bool GetThumImage2(string sourceFile, long quality, int multiple, string outputFile)
        {
            try
            {
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetThumImage(string sourceFile, long quality, int multiple, string outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(sourceFile);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);
                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}