using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            IPEndPoint recvEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848);
            UdpClient udpcSend = new UdpClient(sendEndPoint);
            UdpClient udpcRecv = new UdpClient(recvEndPoint);

            byte[] toRecerData = Encoding.Unicode.GetBytes("发送的信息");

            udpcSend.Send(toRecerData, toRecerData.Length, recvEndPoint);

            byte[] bytRecv = udpcRecv.Receive(ref recvEndPoint);
            string sendMessage = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
            if (!string.IsNullOrWhiteSpace(sendMessage))
            {
                Console.WriteLine("接收成功");
                Console.WriteLine(sendMessage);

                byte[] toSender = Encoding.Unicode.GetBytes("回复的信息");
                udpcRecv.Send(toSender, toSender.Length, sendEndPoint);
                byte[] replyDatas = udpcSend.Receive(ref sendEndPoint);
                string replymessage = Encoding.Unicode.GetString(replyDatas, 0, replyDatas.Length);
                if (!string.IsNullOrWhiteSpace(replymessage))
                {
                    Console.WriteLine("回复成功");
                    Console.WriteLine(replymessage);
                }
            }
            udpcSend.Close();
            udpcRecv.Close();
        }
    }
}