using MVC.Sample.Common;
using MVC.Sample.Filters;
using MVC.Sample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class SamplesController : Controller
    {
        public IMathService MathService;
        private AuthorizationDBEntities dbAuthEntities = new AuthorizationDBEntities();

        public SamplesController(IMathService mathService)
        {
            MathService = mathService;
        }

        // GET: Samples
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [MVCAPPActionFilter]
        public ActionResult UserCenter()
        {
            return PartialView();
        }

        [MVCAPPActionFilter]
        public ActionResult UserInfo()
        {
            Person person = new Person
            {
                Age = 5000,
                Hobby = "卧着",
                Name = "黄山"
            };
            return View(person);
        }

        public ActionResult DropDownListSample()
        {
            IDictionary<string, string> makes = GetSampleMakes();
            DropDownSampleModel viewModel = new DropDownSampleModel()
            {
                Makes = makes
            };
            List<SelectListItem> projectProjects = new List<SelectListItem>
            {
                new SelectListItem{Text="跟团游",Value="1"},
                new SelectListItem{Text="团队",Value="2"}
            };
            ViewData["ProjectType"] = projectProjects;
            return View(viewModel);
        }

        private IDictionary<string, string> GetSampleMakes()
        {
            IDictionary<string, string> makes = new Dictionary<string, string>();
            makes.Add("1", "跟团游");
            makes.Add("2", "团队");
            makes.Add("3", "其他");

            return makes;
        }

        public ActionResult PetTextBoxFor()
        {
            return View();
        }

        public ActionResult PersonCreate()
        {
            return View();
        }

        public ActionResult ValidationUrl()
        {
            return View();
        }

        #region EF

        public ActionResult EFIndex(string message = "", bool success = false)
        {
            ViewBag.message = message;
            ViewBag.success = success;
            return View();
        }

        public ActionResult AddPermisson()
        {
            string text = Request["PermissionText"];
            string order = Request["PermissionOrderNumer"];
            Permission pModel = new Permission
            {
                Text = text,
                OrderNumer = Convert.ToInt32(order),
                PermissionTypeId = 1,
                IfDel = DelEnum.No.ToByte(),
                IfValid = ValidEnum.Yes.ToByte()
            };
            dbAuthEntities.Permission.Add(pModel);
            int result = dbAuthEntities.SaveChanges();
            string msg = result > 0 ? "添加成功" : "添加失败";
            //return Content(msg);
            return RedirectToAction("EFIndex", new { success = result > 0, message = msg });
        }

        #endregion EF

        #region Task

        //一直等待, 异常
        //public async Task<ActionResult> AwaitError()
        //{
        //    var responseHtml = GetResponseContentAsync("http://www.cnblogs.com/").Result;
        //    return Content(responseHtml);
        //}

        public async Task<ActionResult> AwaitOk()
        {
            var responseHtml =
                await Task.Factory.StartNew
                (
                    () => GetResponseContentAsync("http://www.cnblogs.com/").Result
                );
            return Content(responseHtml);
        }

        private async Task<string> GetResponseContentAsync(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "error";
        }

        public async Task<ActionResult> AwaitOk2()
        {
            var responseHtml = await GetResponseContentAsync("http://www.baidu.com/");
            return Content(responseHtml);
        }

        public async Task<ActionResult> AsyncAction()
        {
            await Task.Delay(10 * 1000);
            return View();
        }

        public ActionResult SyncAction()
        {
            Thread.Sleep(10 * 1000);
            return View();
        }

        #endregion Task

        #region AES

        public ActionResult AESIndex()
        {
            ViewData["Encrypted"] = TempData["TEncrypted"];
            ViewData["Decrypted"] = TempData["TDecrypted"];
            return View();
        }

        //txtforEN is PlainText
        //Key is Public Secret Key
        [HttpPost]
        public ActionResult Encryption(string Text, string Key)
        {
            // Convert String to Byte

            byte[] MsgBytes = Encoding.UTF8.GetBytes(Text);
            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key);

            // Hash the password with SHA256
            //Secure Hash Algorithm
            //Operation And, Xor, Rot,Add (mod 232),Or, Shr
            //block size 1024
            //Rounds 80
            //rotation operator , rotates point1 to point2 by theta1=> p2=rot(t1)p1
            //SHR shift to right
            KeyBytes = SHA256.Create().ComputeHash(KeyBytes);

            byte[] bytesEncrypted = AES_Encryption(MsgBytes, KeyBytes);

            string encryptionText = Convert.ToBase64String(bytesEncrypted);

            TempData["TEncrypted"] = encryptionText;
            return RedirectToAction("Index");
        }

        public byte[] AES_Encryption(byte[] Msg, byte[] Key)
        {
            byte[] encryptedBytes = null;

            //salt is generated randomly as an additional number to hash password or message in order o dictionary attack
            //against pre computed rainbow table
            //dictionary attack is a systematic way to test all of possibilities words in dictionary wheather or not is true?
            //to find decryption key
            //rainbow table is precomputed key for cracking password
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.  == 16 bits
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(Key, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(Msg, 0, Msg.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        [HttpPost]
        public ActionResult Decryption(string Text2, string Key2)
        {
            // Convert String to Byte
            byte[] MsgBytes = Convert.FromBase64String(Text2);
            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key2);
            KeyBytes = SHA256.Create().ComputeHash(KeyBytes);

            byte[] bytesDecrypted = AES_Decryption(MsgBytes, KeyBytes);

            string decryptionText = Encoding.UTF8.GetString(bytesDecrypted);

            TempData["TDecrypted"] = decryptionText;
            return RedirectToAction("Index");
        }

        public byte[] AES_Decryption(byte[] Msg, byte[] Key)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(Key, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(Msg, 0, Msg.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        #endregion AES
    }
}
