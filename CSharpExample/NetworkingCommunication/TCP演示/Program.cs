using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP演示
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //IP地址
            IPAddress address = IPAddress.Loopback;
            IPEndPoint point = new IPEndPoint(address, 12345);

            TcpListener server = new TcpListener(point);
            server.Start(10);
            Console.WriteLine("开始监听本机的{0}端口", 12345);

            while (true)
            {
                // 阻塞的方法
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("接收到客户端请求，客户端地址为：{0}", client.Client.RemoteEndPoint);
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