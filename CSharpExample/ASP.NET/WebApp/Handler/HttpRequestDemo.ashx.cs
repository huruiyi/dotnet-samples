using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace WebApp.Handler
{
    /// <summary>
    /// HttpRequestDemo 的摘要说明
    /// </summary>
    public class HttpRequestDemo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Demo1();
        }

        public static void Demo1()
        {
            WebRequest request = WebRequest.Create("http://www.contoso.com/default.html");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
        }

        public static void Demo2()
        {
            WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            request.Method = "POST";
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public static void Demo3(string url, string indata)
        {
            string outdata = "";
            CookieContainer myCookieContainer = new CookieContainer();
            //新建一个CookieContainer来存放Cookie集合

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //新建一个HttpWebRequest
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = indata.Length;
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; Q312461; .NET CLR 1.0.3705)";
            request.CookieContainer = myCookieContainer;
            //设置HttpWebRequest的CookieContainer为刚才建立的那个myCookieContainer
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(indata, 0, indata.Length);
            //把数据写入HttpWebRequest的Request流
            myStreamWriter.Close();
            myRequestStream.Close();
            //关闭打开对象

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //新建一个HttpWebResponse
            response.Cookies = myCookieContainer.GetCookies(request.RequestUri);
            //获取一个包含url的Cookie集合的CookieCollection
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312"));
            outdata = myStreamReader.ReadToEnd();
            //把数据从HttpWebResponse的Response流中读出
            myStreamReader.Close();
            myResponseStream.Close();
            Console.WriteLine(outdata);
            //显示"登录"

            //拿到了Cookie，再进行请求就能直接读取到登录后的内容了
            request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = myCookieContainer;//*
            //刚才那个CookieContainer已经存有了Cookie,把它附加到HttpWebRequest中则能直接通过验证
            response = (HttpWebResponse)request.GetResponse();
            response.Cookies = myCookieContainer.GetCookies(request.RequestUri);
            myResponseStream = response.GetResponseStream();
            myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312"));
            outdata = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            Console.WriteLine(outdata);
            //再次显示"登录"
            //如果把*行注释调，就显示"没有登录"
            request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = myCookieContainer;//*解析到的CookieContainer
            response = (HttpWebResponse)request.GetResponse();
            response.Cookies = myCookieContainer.GetCookies(request.RequestUri);
            myResponseStream = response.GetResponseStream();
            myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312"));
            outdata = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
        }

        public static void Demo4()
        {
            const string url = "http://www.Baidu.com";
            HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            Cookie requestCookie = new Cookie("Request", "RequestValue", "/", "localhost");
            request.CookieContainer.Add(requestCookie);
            Console.WriteLine("请输入请求参数:");
            string inputData = Console.ReadLine();
            string postData = "firstone=" + inputData;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);
            foreach (Cookie cookie in response.Cookies)
            {
                Console.WriteLine("Name: {0}, Value: {1}", cookie.Name, cookie.Value);
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            Console.WriteLine(readStream.ReadToEnd());
            response.Close();
            readStream.Close();
        }

        public static void Demo5()
        {
            const string url = "http://www.Baidu.com";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            Cookie requestCookie = new Cookie("Request", "RequestValue", "/", "localhost");
            request.CookieContainer.Add(requestCookie);
            Console.WriteLine("请输入请求参数:");
            string inputData = Console.ReadLine();
            string postData = "firstone=" + inputData;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);
            foreach (Cookie cookie in response.Cookies)
            {
                Console.WriteLine("Name: {0}, Value: {1}", cookie.Name, cookie.Value);
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            Console.WriteLine(readStream.ReadToEnd());
            response.Close();
            readStream.Close();
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