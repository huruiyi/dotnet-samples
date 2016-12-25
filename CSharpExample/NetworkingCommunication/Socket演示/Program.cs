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

        public static string data = null;

        public static void SocketServer()
        {
            byte[] bytes = new byte[1024];

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();
                    data = null;

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Text received : {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
        }

        public static void SocketClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    int bytesSent = sender.Send(msg);

                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}