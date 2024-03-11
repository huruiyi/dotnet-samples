using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
/*    
 * 作者：周公(zhoufoxcn)    
 * 日期：2011-05-08    
 * 原文出处：http://blog.csdn.net/zhoufoxcn 或http://zhoufoxcn.blog.51cto.com    
 * 版权说明：本文可以在保留原文出处的情况下使用于非商业用途，周公对此不作任何担保或承诺。    
 * */
using System.Text.RegularExpressions;

namespace WebApp.Utility
{
    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public static class Http
    {
        private static readonly string DefaultUserAgent;
        static Http()
        {
            DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        }
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            //request.ContentType = "text/html; charset=gb2312";
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters,
            int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }

            HttpWebRequest request;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            request.UserAgent = !string.IsNullOrEmpty(userAgent) ? userAgent : DefaultUserAgent;

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        /// <summary>
        /// 格式化字符串,取字符串前 strLength 位
        /// 计算字符串长度。汉字两个字节，字母一个字节
        /// </summary>
        /// <param name="demand">原字符串</param>
        /// <param name="length">截取的长度</param>
        /// <returns></returns>
        public static string SubString(string demand, int length)
        {
            return SubString(demand, length, "");
        }
        /// <summary>
        /// 格式化字符串,取字符串前 strLength 位
        /// 计算字符串长度。汉字两个字节，字母一个字节
        /// </summary>
        /// <param name="demand">原字符串</param>
        /// <param name="length">截取的长度</param>
        /// <param name="substitute">小尾巴</param>
        /// <returns></returns>
        public static string SubString(string demand, int length, string substitute)
        {
            if (string.IsNullOrEmpty(demand)) return "";
            if (Encoding.Default.GetBytes(demand).Length <= length)
            {
                return demand;
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            length -= Encoding.Default.GetBytes(substitute).Length;
            int num = 0;
            StringBuilder builder = new StringBuilder();
            byte[] bytes = encoding.GetBytes(demand);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num += 2;
                }
                else {
                    num++;
                }
                if (num > length)
                {
                    break;
                }
                builder.Append(demand.Substring(i, 1));
            }
            builder.Append(substitute);
            return builder.ToString();
        }


        /// <summary>
        /// 移除字符串的HTML代码
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static string Nohtml(string htmlString)
        {
            if (string.IsNullOrEmpty(htmlString))
                return "";
            return NoHtml(htmlString, 0);
        }
        /// <summary>
        /// 移除字符串的HTML代码，返回指定长度的字符.
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string NoHtml(string htmlStr, int length)
        {
            string htmlString = string.Empty;
            if (!string.IsNullOrEmpty(htmlStr))
            {
                htmlStr = RemoveHtmlAll(htmlStr);
                htmlString = length > 0 ? SubString(htmlStr, length) : htmlStr;
            }
            return htmlString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string RemoveHtmlAll(string sourceStr)
        {
            //先去掉代码块
            Regex r = new Regex(@"<style.*?\/style>");
            //Server.HtmlDecode  HttpServerUtility
            //string sourceStrdecode = System.Web.HttpUtility.HtmlDecode(sourceStr);//编码转换
            string sourceStrode = sourceStr;
            var destStr = r.Replace(sourceStrode, "");
            r = new Regex(@"<script.*?\/script>");
            destStr = r.Replace(destStr, "");
            //再去除html标记<>，包括<iframe>和闭合块
            r = new Regex(@"<[^>]*>");
            destStr = r.Replace(destStr, "");
            //去除&nbsp;
            r = new Regex(@"&#(\d+?);");
            destStr = r.Replace(destStr, "");
            r = new Regex(@"&[a-zA-Z]+?;");
            destStr = r.Replace(destStr, "");
            r = new Regex(@"[\s]+");
            destStr = r.Replace(destStr, "");
            return destStr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpValue(string url)
        {
            try
            {
                using (WebResponse webResponse = CreateGetHttpResponse(url, 2000, null, null))
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string PostHttpValue(string url, Dictionary<string, string> param)
        {
            try
            {
                using (
                    HttpWebResponse webResponse = CreatePostHttpResponse(url, param, 2000, DefaultUserAgent,
                        Encoding.UTF8, new CookieCollection()))
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";

            }
        }
    }
}