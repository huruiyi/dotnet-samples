using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

//https://msdn.microsoft.com/zh-cn/library/system.net.sockets.udpclient(v=vs.110).aspx

namespace UdpDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string hostNmae = Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(hostNmae);
            IPAddress ipAddress = hostEntry.AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);

            IPEndPoint sendEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            UdpClient udpcSend = new UdpClient(sendEndPoint);

            IPEndPoint recvEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848);
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

            Console.ReadKey();
        }

        #region Demo1

        private static void StartServer()
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

        private static void StartClient()
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

        #endregion Demo1

        private static void Demo2()
        {
            // This constructor arbitrarily assigns the local port number.
            UdpClient udpClient = new UdpClient(11000);
            try
            {
                udpClient.Connect("www.contoso.com", 11000);

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

                udpClient.Send(sendBytes, sendBytes.Length);

                // Sends a message to a different host using optional hostname and port parameters.
                UdpClient udpClientB = new UdpClient();
                udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000);

                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                Console.WriteLine("This is the message you received " + returnData.ToString());
                Console.WriteLine("This message was sent from " + RemoteIpEndPoint.Address.ToString() + " on their port number " + RemoteIpEndPoint.Port.ToString());

                udpClient.Close();
                udpClientB.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Demo3()
        {
            // Bind and listen on port 2000. This constructor creates a socket
            // and binds it to the port on which to receive data. The family
            // parameter specifies that this connection uses an IPv6 address.
            UdpClient clientOriginator = new UdpClient(2000, AddressFamily.InterNetworkV6);

            // Join or create a multicast group. The multicast address ranges
            // to use are specified in RFC#2375. You are free to use
            // different addresses.

            // Transform the string address into the internal format.
            IPAddress m_GrpAddr = IPAddress.Parse("FF01::1");

            // Display the multicast address used.
            Console.WriteLine("Multicast Address: [" + m_GrpAddr.ToString() + "]");

            // Exercise the use of the IPv6MulticastOption.
            Console.WriteLine("Instantiate IPv6MulticastOption(IPAddress)");

            // Instantiate IPv6MulticastOption using one of the
            // overloaded constructors.
            IPv6MulticastOption ipv6MulticastOption = new IPv6MulticastOption(m_GrpAddr);

            // Store the IPAdress multicast options.
            IPAddress group = ipv6MulticastOption.Group;
            long interfaceIndex = ipv6MulticastOption.InterfaceIndex;

            // Display IPv6MulticastOption properties.
            Console.WriteLine("IPv6MulticastOption.Group: [" + group + "]");
            Console.WriteLine("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex + "]");

            // Instantiate IPv6MulticastOption using another
            // overloaded constructor.
            IPv6MulticastOption ipv6MulticastOption2 = new IPv6MulticastOption(group, interfaceIndex);

            // Store the IPAdress multicast options.
            group = ipv6MulticastOption2.Group;
            interfaceIndex = ipv6MulticastOption2.InterfaceIndex;

            // Display the IPv6MulticastOption2 properties.
            Console.WriteLine("IPv6MulticastOption.Group: [" + group + "]");
            Console.WriteLine("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex + "]");

            // Join the specified multicast group using one of the
            // JoinMulticastGroup overloaded methods.
            clientOriginator.JoinMulticastGroup((int)interfaceIndex, group);

            // Define the endpoint data port. Note that this port number
            // must match the ClientTarget UDP port number which is the
            // port on which the ClientTarget is receiving data.
            IPEndPoint m_ClientTargetdest = new IPEndPoint(m_GrpAddr, 1000);
        }

        public static bool messageReceived = false;

        public static void ReceiveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).Client;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).EndPonint;

            Byte[] receiveBytes = u.EndReceive(ar, ref e);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);

            Console.WriteLine("Received: {0}", receiveString);
            messageReceived = true;
        }

        public static void ReceiveMessages()
        {
            // Receive a message and write it to the console.
            IPEndPoint endponit = new IPEndPoint(IPAddress.Any, 8080);
            UdpClient client = new UdpClient(endponit);

            UdpState s = new UdpState();
            s.EndPonint = endponit;
            s.Client = client;

            Console.WriteLine("listening for messages");
            client.BeginReceive(new AsyncCallback(ReceiveCallback), s);

            // Do some work while we wait for a message. For this example,
            // we'll just sleep
            while (!messageReceived)
            {
                Thread.Sleep(100);
            }
        }

        public static bool messageSent = false;

        public static void SendCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)ar.AsyncState;

            Console.WriteLine("number of bytes sent: {0}", u.EndSend(ar));
            messageSent = true;
        }

        private static void SendMessage1(string server, string message)
        {
            // create the udp socket
            UdpClient u = new UdpClient();

            u.Connect(server, 8080);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

            // send the message
            // the destination is defined by the call to .Connect()
            u.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), u);

            // Do some work while we wait for the send to complete. For
            // this example, we'll just sleep
            while (!messageSent)
            {
                Thread.Sleep(100);
            }
        }

        private static void SendMessage2(string server, string message)
        {
            // create the udp socket
            UdpClient u = new UdpClient();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

            // resolve the server name
            IPHostEntry heserver = Dns.GetHostEntry(server);

            IPEndPoint e = new IPEndPoint(heserver.AddressList[0], 8080);

            // send the message
            // the destination is defined by the IPEndPoint
            u.BeginSend(sendBytes, sendBytes.Length, e, new AsyncCallback(SendCallback), u);

            // Do some work while we wait for the send to complete. For
            // this example, we'll just sleep
            while (!messageSent)
            {
                Thread.Sleep(100);
            }
        }

        private static void SendMessage3(string server, string message)
        {
            // create the udp socket
            UdpClient u = new UdpClient();

            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

            // send the message
            // the destination is defined by the server name and port
            u.BeginSend(sendBytes, sendBytes.Length, server, 8080, new AsyncCallback(SendCallback), u);

            // Do some work while we wait for the send to complete. For
            // this example, we'll just sleep
            while (!messageSent)
            {
                Thread.Sleep(100);
            }
        }
    }
}