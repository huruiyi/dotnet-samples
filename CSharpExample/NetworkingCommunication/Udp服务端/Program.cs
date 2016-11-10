using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp服务端
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IPAddress serverAddress = IPAddress.Loopback;
            IPEndPoint serverPoint = new IPEndPoint(serverAddress, 12222);

            UdpClient udpClient = new UdpClient(serverPoint);
            Console.WriteLine("开启UDP监听本机端口：{0}", 12222);
            while (true)
            {
                //IPEndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);
                IPEndPoint remotePoint = new IPEndPoint(serverAddress, 13333);

                Console.Write("服务端发送信息:");
                string responseString = Console.ReadLine();
                if (responseString == "exit")
                {
                    break;
                }
                byte[] responseBytes = Encoding.UTF8.GetBytes(responseString);
                udpClient.Send(responseBytes, responseBytes.Length, remotePoint);

                byte[] buffer = udpClient.Receive(ref remotePoint);
                string receivedString = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("从IP:{0} 接收到信息：{1}", remotePoint, receivedString);
            }

            udpClient.Close();
        }
    }
}