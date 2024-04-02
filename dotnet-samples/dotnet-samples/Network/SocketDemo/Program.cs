using System;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketDemo
{
    internal class Program
    {
        public static void GetIpV4()
        {
            IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());

            // 取得所有 IP 地址
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                // 只取得IP V4的Address
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine("Local IP: " + ipaddress.ToString());
                }
            }
        }

        public static void GetLocalIp()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in hostEntry.AddressList)
            {
                Console.WriteLine($"{ipa} {ipa.AddressFamily.ToString()}   ");
            }

            //IPHostEntry iphostentry = Dns.GetHostByName(Dns.GetHostName());
            //IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];

            string ip = "";
            string mac = "";
            string hostInfo = Dns.GetHostName();

            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0; i < addressList.Length; i++)
            {
                ip = addressList[i].ToString();
            }
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                {
                    mac = mo["MacAddress"].ToString();
                }
            }
            Console.WriteLine($"IP:{ip}"); ;
            Console.WriteLine($"MAC:{mac}"); ;
        }

        #region SynchronousSocket

        public static void SynchronousServer()
        {
            byte[] bytes = new Byte[1024];

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");
            Socket handler = listener.Accept();
            string data = null;

            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

            Console.WriteLine("Server Received : {0}", data);
            byte[] msg = Encoding.ASCII.GetBytes(data);
            handler.Send(msg);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            Console.Read();
        }

        public static void SynchronousClient()
        {
            IPEndPoint remoteEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEp);

            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

            byte[] msg = Encoding.ASCII.GetBytes("I am Client");
            int bytesSent = sender.Send(msg);

            byte[] bytes = new byte[1024];
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Clienet Received: {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        public static void SynchronousDemo()
        {
            Task t1 = Task.Factory.StartNew(() =>
            {
                SynchronousServer();
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                SynchronousClient();
            });
        }

        #endregion SynchronousSocket

        #region SocketDemo

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

        #endregion SocketDemo

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}