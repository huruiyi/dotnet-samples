using MVC.Sample.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
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
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";
            ViewBag.Msg = "<a href='http://www.baidu.com'>百度</a>";
            Person p = new Person { Name = "Qingqing", Age = 21 };
            return View(p);
        }

        public ActionResult PersonXml()
        {
            var model = new Person
            {
                FirstName = "Brad",
                LastName = "Wilson",
                Blog = "http://bradwilson.typepad.com"
            };
            return new XmlResult(model);
        }

        public ActionResult About()
        {
            List<Person> pers = new List<Person>
            {
                new Person {Name = "Tom", Age = 20},
                new Person {Name = "Jarry", Age = 22},
                new Person {Name = "Macheal", Age = 23},
                new Person {Name = "Kangkang", Age = 20},
            };

            List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem {Text = "Action", Value = "0"},
                new SelectListItem {Text = "Drama", Value = "1"},
                new SelectListItem {Text = "Comedy", Value = "2", Selected = true},
                new SelectListItem {Text = "Science Fiction", Value = "3"}
            };

            ViewBag.MovieType = items;
            return View(pers);
        }

        public ActionResult HostInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>OSVersion</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.OSVersion);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>MachineName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.MachineName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>ProcessorCount</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.ProcessorCount);
            stringBuilder.Append("</tr>");
            string arg = ((double)Environment.TickCount / 3600000.0).ToString("N2");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>TickCount</td>");
            stringBuilder.AppendFormat("<td>{0}-{1}:小时</td>", Environment.TickCount, arg);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserDomainName:</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserDomainName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserInteractive</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserInteractive);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserName:</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Version</td>");
            stringBuilder.AppendFormat("<td>.NETCLR{0}</td>", Environment.Version);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>EnvironmentVariables.Key</td>");
            stringBuilder.AppendFormat("<td>EnvironmentVariables.Value</td>");
            stringBuilder.Append("</tr>");
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry dictionaryEntry in environmentVariables)
            {
                stringBuilder.Append("<trclass='active'>");
                stringBuilder.AppendFormat("<td>{0}</td>", dictionaryEntry.Key);
                stringBuilder.AppendFormat("<td>{0}</td>", dictionaryEntry.Value);
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.HeaServerVariablesders.Key</td>");
            stringBuilder.AppendFormat("<td>Request.ServerVariables.Key</td>");
            stringBuilder.Append("</tr>");
            NameValueCollection serverVariables = Request.ServerVariables;
            foreach (string text in serverVariables)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.AppendFormat("<td>{0}</td>", text);
                stringBuilder.AppendFormat("<td>{0}</td>", serverVariables[text]);
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Headers.Key</td>");
            stringBuilder.AppendFormat("<td>Request.Headers.Key</td>");
            stringBuilder.Append("</tr>");
            NameValueCollection headers = Request.Headers;
            foreach (string text2 in headers)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.AppendFormat("<td>{0}</td>", text2);
                stringBuilder.AppendFormat("<td>{0}</td>", headers.Get(text2));
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.AbsolutePath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.AbsolutePath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.AbsoluteUri</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.AbsoluteUri);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.Authority</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.Authority);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.IsAbsoluteUri</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.IsAbsoluteUri);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.PathAndQuery</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.PathAndQuery);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.DnsSafeHost</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.DnsSafeHost);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.Host</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.Host);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.HostNameType</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.HostNameType);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.LocalPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.LocalPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.UserInfo</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.UserInfo);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.UserHostName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.UserHostName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.UserHostAddress</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.UserHostAddress);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Path</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Path);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PathInfo</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PathInfo);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PhysicalApplicationPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PhysicalApplicationPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PhysicalPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PhysicalPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.AppRelativeCurrentExecutionFilePath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.AppRelativeCurrentExecutionFilePath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.ApplicationPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.ApplicationPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Server.MachineName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Server.MachineName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Server.ScriptTimeout</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Server.ScriptTimeout);
            stringBuilder.Append("</tr>");

            MachineMessage model = new MachineMessage
            {
                Message = stringBuilder.ToString()
            };
            return View(model);
        }

        public ActionResult Modal()
        {
            return View();
        }

        public ActionResult JsonWebTokenDemo()
        {
            return View();
        }

        public FileResult ExportExcel()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Id", typeof(int)));
            tbl.Columns.Add(new DataColumn("Name", typeof(string)));
            tbl.Columns.Add(new DataColumn("Age", typeof(int)));
            DataRow row;
            for (int i = 0; i < 20; i++)
            {
                row = tbl.NewRow();
                row["Id"] = i;
                row["Name"] = "Name" + i;
                row["Age"] = 22 + i;
                tbl.Rows.Add(row);
            }
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(tbl, true);
                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells["A1:C1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }

                //Example how to Format Column 1 as numeric
                using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
                {
                    col.Style.Numberformat.Format = "#,##0.00";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                //Write it back to the client
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=ExcelDemo.xlsx");
                //Response.BinaryWrite(pck.GetAsByteArray());

                return File(pck.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        public FileContentResult ExportExce2()
        {
            List<Student> lstStudent = new List<Student>()
            {
                new Student(){ID=1,Name="曹操",Sex="男",Email="caocao@163.com",Age=24},
                new Student(){ID=2,Name="李易峰",Sex="女",Email="lilingjie@sina.com.cn",Age=24},
                new Student(){ID=3,Name="张三丰",Sex="男",Email="zhangsanfeng@qq.com",Age=224},
                new Student(){ID=4,Name="孙权",Sex="男",Email="sunquan@163.com",Age=1224},
            };
            string[] columns = { "ID", "Name", "Age", "Sex", "Email" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(lstStudent, "", false, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "MyStudent.xlsx");
        }

        #region 上传与截图

        /*
            * 暂时不兼容Firefox
            * 本案例地址：
            http://www.codeproject.com/Tips/897036/ASP-NET-MVC-Multiple-Image-Uploader-with-Crop
        */

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
                        if (!Directory.Exists(Server.MapPath("~/Images/upload/")))
                            Directory.CreateDirectory(Server.MapPath("~/Images/upload/"));
                        image.Save(Server.MapPath("~/Images/upload/" + imageData.FileName));
                        uploadResult.Add(imageData.FileName, true);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write(ex.Message);
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

        #endregion 上传与截图

        public ActionResult GetValidateCode()
        {
            string code = CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }


                        
        public ActionResult Detais()
        {
            return View();
        }
    }
}