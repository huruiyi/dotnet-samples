using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Net.Tools.Security
{
    public class MD5Helper
    {
        /// <summary>
        /// GetMd5Hash("DataString", "utf-8")
        /// </summary>
        /// <param name="input"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input, string charset)
        {
            byte[] data = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(charset).GetBytes(input));
            StringBuilder builder = new StringBuilder(32);
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }

        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(GetMd5Hash(input, "utf-8"), hash) == 0;
        }

        /// <summary>
        /// 直接根据当前请求实体和秘钥生成Token令牌
        /// </summary>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public string GetToken(string appSecret)
        {
            return this.GetToken(appSecret, null);
        }

        /// <summary>
        /// 根据请求参数JSON串和秘钥生成Token令牌
        /// </summary>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public string GetToken(string appSecret, string requestJson = null)
        {
            if (string.IsNullOrEmpty(requestJson))
            {
                requestJson = JsonConvert.SerializeObject(this);
            }
            Type type = base.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            PropertyInfo[] array = properties;
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo propertyInfo = array[i];
                if (!IsRef(propertyInfo.PropertyType))
                {
                    string name = propertyInfo.Name;
                    string text = ParseValueFromJson(requestJson, name, propertyInfo.PropertyType);
                    if (text != null)
                    {
                        dictionary.Add(name, text);
                    }
                }
            }
            return this.GetToken(dictionary, appSecret);
        }

        /// <summary>
        /// 根据参数列表和秘钥生成Token令牌
        /// </summary>
        /// <param name="dictParams"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private string GetToken(Dictionary<string, string> dictParams, string appSecret)
        {
            dictParams.Add("appsecret", appSecret);
            string[] array = (from p in dictParams
                              select string.Format("{0}={1}", p.Key.ToLower(), p.Value.ToLower())).ToArray<string>();
            StringBuilder stringBuilder = new StringBuilder();
            string[] array2 = BubbleSort(array); ;
            for (int i = 0; i < array2.Length; i++)
            {
                stringBuilder.AppendFormat("{0}&", array2[i]);
            }
            int length = stringBuilder.Length;
            string s = stringBuilder.ToString().Substring(0, length - 1) + appSecret;
            StringBuilder stringBuilder2 = new StringBuilder(32);
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] array3 = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
            byte[] array4 = array3;
            for (int i = 0; i < array4.Length; i++)
            {
                byte b = array4[i];
                stringBuilder2.Append(b.ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder2.ToString();
        }

        /// <summary>
        /// DES加密方法，使用内部规定的秘钥
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt)
        {
            string s = "3E7E4BBA";
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(s),
                IV = Encoding.ASCII.GetBytes(s)
            };
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            stringBuilder.ToString();
            return stringBuilder.ToString();
        }

        /// <summary>
        /// DES解密方法，使用内部规定的秘钥，与加密方法配合使用
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt)
        {
            string s = "3E7E4BBA";
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] array = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < pToDecrypt.Length / 2; i++)
            {
                int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
                array[i] = (byte)num;
            }
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private static string[] BubbleSort(string[] r)
        {
            bool flag = false;
            for (int i = 0; i < r.Length; i++)
            {
                for (int j = r.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        string text = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = text;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// 是否是引用类别（除DateTime和String外）
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool IsRef(Type t)
        {
            return !t.IsValueType && !(t == typeof(DateTime)) && !(t == typeof(string));
        }

        /// <summary>
        /// 从JSON字符串中根据健名解析对应的值
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        private static string ParseValueFromJson(string jsonString, string propertyName, Type propertyType)
        {
            string text = null;
            MatchCollection matchCollection = null;
            string pattern = string.Format("\"{0}\":\\s*\"(?'Value'[^\"]*)\"", propertyName);
            if (Regex.IsMatch(jsonString, pattern, RegexOptions.ExplicitCapture))
            {
                matchCollection = Regex.Matches(jsonString, pattern, RegexOptions.ExplicitCapture);
            }
            else
            {
                pattern = string.Format("\"{0}\":\\s*(?'Value'[^,}}]*)", propertyName);
                if (Regex.IsMatch(jsonString, pattern, RegexOptions.ExplicitCapture))
                {
                    matchCollection = Regex.Matches(jsonString, pattern, RegexOptions.ExplicitCapture);
                }
            }
            string result;
            if (matchCollection == null)
            {
                result = text;
            }
            else if (matchCollection != null && matchCollection.Count > 1)
            {
                result = text;
            }
            else
            {
                text = matchCollection[0].Groups["Value"].Value;
                if (text != null)
                {
                    if (text.ToLower().Equals("null"))
                    {
                        text = string.Empty;
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        text = ConvertJsonDateToDateString(text);
                    }
                }
                result = text;
            }
            return result;
        }

        /// <summary>
        /// 解析JSON格式的日期 “\/Date(1440052256061+0800)\/”
        /// </summary>
        /// <param name="jsonDate"></param>
        /// <returns></returns>
        private static string ConvertJsonDateToDateString(string jsonDate)
        {
            int num = jsonDate.IndexOf("Date(", StringComparison.Ordinal) + 5;
            int num2 = jsonDate.IndexOf("+", StringComparison.Ordinal);
            long num3 = long.Parse(jsonDate.Substring(num, num2 - num));
            DateTime dateTime = new DateTime(1970, 1, 1);
            return dateTime.AddMilliseconds((double)num3).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}