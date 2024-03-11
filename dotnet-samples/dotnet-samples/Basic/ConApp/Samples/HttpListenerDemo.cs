using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConApp
{
    public partial class Program
    {
        public static void HttpListenerDemo1()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:1231/");
            listener.Start();
            Console.WriteLine("Listening...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
        }

        public static void HttpListenerDemo2()
        {
            if (HttpListener.IsSupported)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://+:8080/");
                listener.Start();
                while (true)
                {
                    Console.Write(DateTime.Now.ToString());
                    HttpListenerContext context = listener.GetContext();
                    string page = context.Request.Url.LocalPath.Replace("/", "");
                    String query = context.Request.Url.Query.Replace("?", "");
                    StreamReader sr = new StreamReader(context.Request.InputStream);
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine(@"接收到请求{0}{1}", page, query);
                    StreamWriter sw = new StreamWriter(context.Response.OutputStream);
                    sw.Write("Hello World!");
                    sw.Flush();
                    context.Response.Close();
                }
            }
        }

        public static void HttpListenerDemo3()
        {
            // 检查系统是否支持
            if (!HttpListener.IsSupported)
            {
                throw new System.InvalidOperationException("使用 HttpListener 必须为 Windows XP SP2 或 Server 2003 以上系统！");
            }
            // 注意前缀必须以 / 正斜杠结尾
            string[] prefixes = new string[] { "http://localhost:49152/" };
            // 创建监听器.
            HttpListener listener = new HttpListener();
            // 增加监听的前缀.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            // 开始监听
            listener.Start();
            Console.WriteLine("监听中...");
            while (true)
            {
                // 注意: GetContext 方法将阻塞线程，直到请求到达
                HttpListenerContext context = listener.GetContext();
                // 取得请求对象
                HttpListenerRequest request = context.Request;
                Console.WriteLine(@"{0} {1} HTTP/1.1", request.HttpMethod, request.RawUrl);
                Console.WriteLine(@"Accept: {0}", string.Join(",", request.AcceptTypes));
                Console.WriteLine(@"Accept-Language: {0}", string.Join(",", request.UserLanguages));
                Console.WriteLine(@"User-Agent: {0}", request.UserAgent);
                Console.WriteLine(@"Accept-Encoding: {0}", request.Headers["Accept-Encoding"]);
                Console.WriteLine(@"Connection: {0}", request.KeepAlive ? "Keep-Alive" : "close");
                Console.WriteLine(@"Host: {0}", request.UserHostName);
                Console.WriteLine(@"Pragma: {0}", request.Headers["Pragma"]);
                // 取得回应对象
                HttpListenerResponse response = context.Response;
                // 构造回应内容
                string responseString =
                                @"<html>
                                    <head>
                                        <title>From HttpListener Server</title>
                                    </head>
                                    <body>
                                        <h1>Hello, world.</h1>
                                    </body>
                                   </html>";
                // 设置回应头部内容，长度，编码
                response.ContentLength64 = System.Text.Encoding.UTF8.GetByteCount(responseString);
                response.ContentType = "text/html; charset=UTF-8";
                // 输出回应内容
                System.IO.Stream output = response.OutputStream;
                System.IO.StreamWriter writer = new System.IO.StreamWriter(output);
                writer.Write(responseString);
                // 必须关闭输出流
                writer.Close();

                if (Console.KeyAvailable)
                    break;
            }
            // 关闭服务器
            listener.Stop();
        }

        private static HttpListener listener;
        private static Thread listenThread1;

        public static void HttpListenerDemo4()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8000/");
            listener.Prefixes.Add("http://127.0.0.1:8000/");
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            listener.Start();
            listenThread1 = new Thread(new ParameterizedThreadStart(startlistener));
            listenThread1.Start();
        }

        public static void startlistener(object s)
        {
            while (true)
            {
                var result = listener.BeginGetContext(ListenerCallback, listener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        public static void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            Thread.Sleep(1000);
            var data_text = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd();

            //functions used to decode json encoded data.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var data1 = Uri.UnescapeDataString(data_text);
            //string da = Regex.Unescape(data_text);
            //var unserialized = js.Deserialize(data_text, typeof(String));

            var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);

            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";

            var headerText = context.Request.Headers["mycustomHeader"];

            context.Response.Headers["mycustomResponseHeader"] = "mycustomResponse";

            MessageBox.Show(cleaned_data);
            context.Response.Close();
        }

        public static void HttpListenerDemo5()
        {
            IPAddress address = IPAddress.Loopback;
            IPEndPoint point = new IPEndPoint(address, 12345);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(point);
            socket.Listen(10);
            Console.WriteLine(@"Socket开始监听本机的{0}端口", point.Port);

            while (true)
            {
                Socket client = socket.Accept();
                Console.WriteLine(@"接收到客户端的IP地址为：{0}", client.RemoteEndPoint);
                byte[] buffer = new byte[4096];
                client.Receive(buffer, 4096, SocketFlags.None);
                string requestString = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(requestString);
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = Encoding.UTF8.GetBytes(statusLine);

                string responseSpace = "\r\n";
                byte[] responseSpaceBytes = Encoding.UTF8.GetBytes(responseSpace);
                string responseString = "<html><body><a href='http://www.baidu.com'>百度</a></body></html>";
                byte[] repsonseBytes = Encoding.UTF8.GetBytes(responseString);

                string responseHeader = string.Format("Content-Type: text/html;charset=utf-8\r\nContent-Length:{0}\r\n", repsonseBytes.Length);
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);

                client.Send(statusLineBytes);
                client.Send(responseHeaderBytes);
                client.Send(responseSpaceBytes);
                client.Send(repsonseBytes);
                client.Close();

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            socket.Close();
        }

        public static void HttpListenerDemo6()
        {
            IPAddress address = IPAddress.Loopback;
            IPEndPoint point = new IPEndPoint(address, 12345);

            TcpListener server = new TcpListener(point);
            server.Start(10);
            Console.WriteLine(@"开始监听本机的{0}端口", 12345);

            while (true)
            {
                // 阻塞的方法
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine(@"接收到客户端请求，客户端地址为：{0}", client.Client.RemoteEndPoint);
                // 获取一个网络流
                NetworkStream stream = client.GetStream();

                // 获取客户端数据
                byte[] buffer = new byte[4096];
                stream.Read(buffer, 0, 4096);
                Console.Write(Encoding.UTF8.GetString(buffer, 0, 4096));

                // 向客户端写入数据
                //状态信息
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = Encoding.UTF8.GetBytes(statusLine);

                //响应空行信息
                string responseSpace = "\r\n";
                byte[] responseSpaceBytes = Encoding.UTF8.GetBytes(responseSpace);
                //响应的内容
                string responseString = "<html><body><a href='http://www.sina.com'>新浪</a></body></html>";
                byte[] repsonseBytes = Encoding.UTF8.GetBytes(responseString);

                //响应头部信息
                string responseHeader = string.Format("Content-Type: text/html;charset=utf-8\r\nContent-Length:{0}\r\n", repsonseBytes.Length);
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);

                try
                {
                    stream.Write(statusLineBytes, 0, statusLineBytes.Length);
                    stream.Write(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    stream.Write(responseSpaceBytes, 0, responseSpaceBytes.Length);
                    stream.Write(repsonseBytes, 0, repsonseBytes.Length);
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.Message);
                }
                finally
                {
                    stream.Close();
                    client.Close();
                    client.Dispose();
                }

                if (Console.KeyAvailable)
                {
                    break;
                }
            }

            server.Stop();
        }
    }
}