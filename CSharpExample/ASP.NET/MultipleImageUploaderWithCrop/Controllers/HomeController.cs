using MultipleImageUploaderWithCrop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace MultipleImageUploaderWithCrop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [JsonFilter(Param = "widgets", JsonDataType = typeof(List<UploadFileModel>))]
        public JsonResult UploadToServer(List<UploadFileModel> images)
        {
            var uploadResult = new Dictionary<string, bool>();
            if (images != null && images.Count > 0)
            {
                foreach (var imageData in images)
                {
                    try
                    {
                        var base64String = imageData.Content.Substring(imageData.Content.IndexOf(',') + 1);
                        var buffer = Convert.FromBase64String(base64String);
                        Image image;
                        using (Stream sr = new MemoryStream(buffer))
                        {
                            image = Image.FromStream(sr);
                        }

                        image = ResizeImage(image, (int)imageData.ImgWidth, (int)imageData.ImgHeight);
                        image = CropImage(image, new Rectangle((int)imageData.CropX, (int)imageData.CropY, imageData.CropWidth, imageData.CropHeight));
                        if (!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                            Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                        image.Save(Server.MapPath("~/UploadedImages/" + imageData.FileName));
                        uploadResult.Add(imageData.FileName, true);
                    }
                    catch
                    {
                        uploadResult.Add(imageData.FileName, false);
                    }
                }
            }
            return Json(uploadResult);
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

    public class JsonFilter : ActionFilterAttribute
    {
        public string Param { get; set; }
        public Type JsonDataType { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
            {
                string inputContent;
                filterContext.HttpContext.Request.InputStream.Position = 0;
                using (var sr = new StreamReader(filterContext.HttpContext.Request.InputStream))
                {
                    inputContent = sr.ReadToEnd();
                }
                var result = JsonConvert.DeserializeObject(inputContent, JsonDataType);
                filterContext.ActionParameters[Param] = result;
            }
        }
    }
}