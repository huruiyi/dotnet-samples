using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket演示
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //IP地址
            IPAddress address = IPAddress.Loopback;
            IPEndPoint point = new IPEndPoint(address, 12345);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //将Socket绑定到本机的 12345端口
            socket.Bind(point);
            //将socket设置为监听状态
            socket.Listen(10);
            Console.WriteLine("Socket开始监听本机的{0}端口", point.Port);

            while (true)
            {
                // 一个阻塞的方法
                Socket client = socket.Accept();
                Console.WriteLine("接收到客户端的IP地址为：{0}", client.RemoteEndPoint);
                //接收客户端发来的数据
                byte[] buffer = new byte[4096];
                client.Receive(buffer, 4096, SocketFlags.None);
                string requestString = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(requestString);
                //向客户端发送数据
                //状态信息
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = Encoding.UTF8.GetBytes(statusLine);

                //响应空行信息
                string responseSpace = "\r\n";
                byte[] responseSpaceBytes = Encoding.UTF8.GetBytes(responseSpace);
                //响应的内容
                string responseString = "<html><body><a href='http://www.baidu.com'>百度</a></body></html>";
                byte[] repsonseBytes = Encoding.UTF8.GetBytes(responseString);

                //响应头部信息
                string responseHeader = string.Format("Content-Type: text/html;charset=utf-8\r\nContent-Length:{0}\r\n", repsonseBytes.Length);
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);

                client.Send(statusLineBytes);
                client.Send(responseHeaderBytes);
                client.Send(responseSpaceBytes);
                client.Send(repsonseBytes);
                //关闭客户端
                client.Close();

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            //关闭服务器
            socket.Close();
        }
    }
}