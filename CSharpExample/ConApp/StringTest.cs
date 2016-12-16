using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleAppTest
{
    internal class StringTest
    {
        private static void Main1(string[] args)
        {
            Console.WriteLine("1".Equals("1")); ;
            string newPwd = Password.EncryptPassword("abc123456");
            string orgPwd = Password.DecryptPassword(newPwd);
            Console.WriteLine(newPwd + "                 " + orgPwd);

            #region 课上练习4：把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：

            // 姓名：张三 电话：15001111113

            //string[] lines = File.ReadAllLines("1.csv", Encoding.Default);

            //string[] arr = new string[lines.Length];

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string tmp = lines[i].Replace("\"", "");
            //    string[] array = tmp.Split(',');
            //    if (array.Length == 3)
            //    {
            //        arr[i] = string.Format("{0} {1}", array[0] + array[1], array[2]);
            //    }
            //    else
            //    {
            //        arr[i] = null;
            //    }
            //}

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(arr[i]))
            //    {
            //        Console.WriteLine(arr[i]);
            //    }
            //}
            //Console.Read();

            #endregion 课上练习4：把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：

            Console.Read();

            string s1 = "target";
            StringBuilder sb = new StringBuilder("target");
            string s2 = sb.ToString();
            OpTest<string>(s1, s2);

            CreateInstance<Employee>(5);

            Boss b = CreateBossInstance<Boss>(3);
            b.Name = "Wb";
        }

        private static string Reverse(string str)
        {
            //反转字符串
            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            //string s = new string(arr);
            return string.Join("", arr);
        }

        public static void OpTest<T>(T s, T t) where T : class
        {
            Console.WriteLine(s == t);
        }

        private static T CreateInstance<T>(int n) where T : new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        private static T CreateBossInstance<T>(int n) where T : Boss, new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        public static string GetRequest(string requestUrl, string requestData, string contentType, string codingType, int timeout, out string error)
        {
            string result = "";
            error = "";
            long elapsed = 0;
            string responseData = string.Empty;
            //Post请求地址
            Stopwatch stopWatch = Stopwatch.StartNew();
            try
            {
                HttpWebRequest m_Request = (HttpWebRequest)WebRequest.Create(requestUrl);
                //相应请求的参数
                byte[] data = Encoding.GetEncoding(codingType).GetBytes(requestData);
                m_Request.Method = "Post";
                m_Request.ContentType = contentType;
                m_Request.ContentLength = data.Length;
                m_Request.Timeout = timeout;
                m_Request.ServicePoint.Expect100Continue = false;
                //请求流
                Stream requestStream = m_Request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                //响应流
                HttpWebResponse m_Response = (HttpWebResponse)m_Request.GetResponse();
                Stream responseStream = m_Response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(codingType));
                //获取返回的信息
                result = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
            }
            catch (WebException ex)
            {
                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    error = string.Format("请求超时[{0}],请求地址：{1}", elapsed, requestUrl);
                }
                else
                {
                    error = string.Format("{0},请求地址：{1}", ex.Message, requestUrl);
                }
                result = error;
                responseData = ex.ToString();
            }
            catch (Exception ex)
            {
                error = string.Format("请求接口异常,请求地址：{0}", requestUrl);
                result = error;
                elapsed = stopWatch.ElapsedMilliseconds;
                responseData = ex.ToString();
            }
            if (string.IsNullOrWhiteSpace(responseData))
            {
                responseData = result;
            }

            return responseData;
        }
    }

    internal class Employee
    {
        public Employee()
        {
            Console.WriteLine("无参构造行数------Employee");
        }
    }

    internal class Boss
    {
        public Boss()
        {
            Console.WriteLine("无参构造行数-------Boss来了");
        }

        public Boss(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    internal class Password
    {
        public static string EncryptPassword(string strPassword)
        {
            //加密密码
            string encryPassword = "";
            int i;

            char[] charFont = strPassword.ToCharArray();
            for (i = 0; i < charFont.Length; i++)
            {
                int intFont = charFont[i] + 64;
                charFont[i] = Convert.ToChar(intFont);
            }

            for (i = 0; i < charFont.Length; i++)
            {
                encryPassword += charFont[i];
            }
            return encryPassword;
        }

        public static string DecryptPassword(string encryPassword)
        {
            //解密密码
            string strPassword = "";
            int i;

            char[] charFont = encryPassword.ToCharArray();
            for (i = 0; i < charFont.Length; i++)
            {
                int intFont = (int)charFont[i] - 64;
                charFont[i] = Convert.ToChar(intFont);
            }
            for (i = 0; i < charFont.Length; i++)
            {
                strPassword += charFont[i];
            }
            return strPassword;
        }
    }

    public class EncryptAndDecrypt
    {
        //默认密钥向量
        private static readonly byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /**/

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }

    public class Encryption
    {
        /// <summary>
        /// Default Key
        /// </summary>
        public const string Key = "bmc.1001";

        /// <summary>
        /// Initial
        /// </summary>
        public Encryption()
        {
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中
            //原来使用的UTF8编码，我改成Unicode编码了，不行
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            //使得输入密码必须输入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //创建其支持存储区为内存的流
            MemoryStream ms = new MemoryStream();
            //将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream
            //(It  will  end  up  in  the  memory  stream)
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            //用缓冲区的当前状态更新基础数据源或储存库，随后清除缓冲区
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string
            byte[] EncryptData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String(EncryptData, 0, EncryptData.Length);
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //Put  the  input  string  into  the  byte  array
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);

            //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
}