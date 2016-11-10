using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Udp客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress adress = IPAddress.Loopback;
            IPEndPoint localPoint = new IPEndPoint(adress, 13333);
            UdpClient udpClient = new UdpClient(localPoint);
            
            while (true)
            { 
                IPEndPoint serverPoint = new IPEndPoint(adress, 12222);            
                byte[] buffer = udpClient.Receive(ref serverPoint);
                Console.WriteLine("获取服务端的回应信息：{0}", Encoding.UTF8.GetString(buffer));                


                Console.Write("请输入要发送的消息：");
                string requestString = Console.ReadLine();
                if (requestString == "exit")
                {
                    break;
                }                
                byte[] requestBytes = Encoding.UTF8.GetBytes(requestString);             
                udpClient.Send(requestBytes, requestBytes.Length, serverPoint);            
            }
            udpClient.Close();
        }
    }
}
