using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketServer
{
    internal class Program
    {
        private static void Main()
        {
            const int port = 6000;
            const string host = "127.0.0.1";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket.Bind(ipe);
            sSocket.Listen(0);
            Console.WriteLine("监听已经打开，请等待");

            //receive message
            Socket serverSocket = sSocket.Accept();
            Console.WriteLine("连接已经建立");
            string recStr = "";
            byte[] recByte = new byte[4096];
            int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
            recStr += Encoding.ASCII.GetString(recByte, 0, bytes);

            //send message
            Console.WriteLine("服务器端获得信息:{0}", recStr);
            const string sendStr = "send to client :hello";
            byte[] sendByte = Encoding.ASCII.GetBytes(sendStr);
            serverSocket.Send(sendByte, sendByte.Length, 0);
            serverSocket.Close();
            sSocket.Close();

            ThreadPool.QueueUserWorkItem(ShowMsg, "shit");
            Console.Read();
        }

        public static void ShowMsg(Object oje)
        {
            Console.Write("线程池\t" + oje + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10);
        }
    }
}