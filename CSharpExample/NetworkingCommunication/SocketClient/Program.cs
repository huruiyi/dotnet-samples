using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int port = 6000;
            const string host = "127.0.0.1"; //服务器端ip地址

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ipe);

            //send message
            const string sendStr = "send to server : hello,ni hao";
            byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
            clientSocket.Send(sendBytes);

            //receive message
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);
            Console.WriteLine(recStr);

            clientSocket.Close();

            Console.ReadKey();
        }
    }
}