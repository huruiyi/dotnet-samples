using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Socket演示
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IPAddress address = IPAddress.Loopback;
            IPEndPoint point = new IPEndPoint(address, 12345);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(point);
            socket.Listen(10);
            Console.WriteLine("Socket开始监听本机的{0}端口", point.Port);

            while (true)
            {
                Socket client = socket.Accept();
                Console.WriteLine("接收到客户端的IP地址为：{0}", client.RemoteEndPoint);
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

        private static void StartServer()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);

            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket.Bind(ip);
            sSocket.Listen(0);
            Console.WriteLine("监听已经打开，请等待");

            Socket serverSocket = sSocket.Accept();
            Console.WriteLine("连接已经建立");
            byte[] recByte = new byte[4096];
            int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
            string recStr = Encoding.ASCII.GetString(recByte, 0, bytes);

            Console.WriteLine("服务器端获得信息:{0}", recStr);
            const string sendStr = "send to client :hello";
            byte[] sendByte = Encoding.ASCII.GetBytes(sendStr);
            serverSocket.Send(sendByte, sendByte.Length, 0);
            serverSocket.Close();
            sSocket.Close();

            ThreadPool.QueueUserWorkItem(ShowMsg, "shit");
            Console.Read();
        }

        private static void StartClient()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ip);

            const string sendStr = "send to server : hello,ni hao";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            clientSocket.Send(sendBytes);

            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            string recStr = Encoding.ASCII.GetString(recBytes, 0, bytes);
            Console.WriteLine(recStr);
            clientSocket.Close();
        }

        public static void ShowMsg(Object oje)
        {
            Console.Write("线程池\t" + oje + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10);
        }
    }
}