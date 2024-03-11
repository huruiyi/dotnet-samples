using ConApp.Infrastructure;
using ConApp.Model;

using Microsoft.VisualBasic;

using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConApp
{
    public class Program
    {
        public Program(int mNData)
        {
            MnData = mNData;
        }

        public static string encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        public static string Decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }

        public static void Main(string[] args)
        {
            //https://www.cnblogs.com/dmhp/p/5291129.html
            //https://www.cnblogs.com/dmhp/p/5291106.html
            //stackalloc
            //TypeFilter
            //WeakReference
            //volatile

            ToSimpleChinese(@"D:\Work\CS\00\hello.txt");
            Console.ReadKey();
        }

        public static void MemoryDemo()
        {
            int[] a = { 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
            Memory<int> memory = new Memory<int>(a);
            Console.WriteLine(memory.Length);

            memory = memory.Slice(6);

            Console.WriteLine(memory.Length);

            Console.ReadKey();
        }

        private static void ToSimpleChinese(String file)
        {
                Encoding encoding = TxtFileEncoder.GetEncoding(file);
                //Encoding.GetEncoding(encoding.BodyName);
                string readAllText = File.ReadAllText(file);
                string strConv = Strings.StrConv(readAllText, VbStrConv.SimplifiedChinese);
                Console.WriteLine(strConv);
        }

        //静态变量存储在堆上，查看指针时需用fixed固定
        public static int MSz = 100;

        //普通数据成员，也是放在堆上了，查看指针时需用fixed固定
        public int MnData;

        //等价于C/C++的 #define 语句，不分配内存
        public const int Pi = 31415;

        private static bool RemoteCertificateCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Post数据【参数1：网关地址，2：提交的XML消费交易数据，3：商户号，4商户密码，5：商户证书地址，6：商户证书密码】
        /// </summary>
        public string HttpPost(string sUrl, string sPostData, string sMerId, string sMerPw, string prikeyPath, string prikeyPassword)
        {
            try
            {
                //将输入的xml内容转化为byte数组，
                byte[] data = Encoding.UTF8.GetBytes(sPostData);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateCallback;
                HttpWebRequest xmlhttprequest = (HttpWebRequest)WebRequest.Create(new Uri(sUrl));
                xmlhttprequest.Method = "POST";
                xmlhttprequest.ContentType = "application/x-www-form-urlencoded";
                xmlhttprequest.ContentLength = data.Length;
                xmlhttprequest.Credentials = CredentialCache.DefaultCredentials;
                string userNamePassword = sMerId + ":" + sMerPw;
                CredentialCache mycache = new CredentialCache
                {
                    { new Uri(sUrl), "Basic", new NetworkCredential(sMerId, sMerPw) }
                };
                xmlhttprequest.Credentials = mycache;
                xmlhttprequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(userNamePassword)));
                X509Certificate2 objX5092 = new X509Certificate2(prikeyPath, prikeyPassword);
                xmlhttprequest.ClientCertificates.Add(objX5092);
                Stream newStream = xmlhttprequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse res = (HttpWebResponse)xmlhttprequest.GetResponse();
                string rtnRes = String.Empty;

                if (res.GetResponseStream() != null)
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                    //得到返回值
                    rtnRes = reader.ReadToEnd();
                    reader.Close();
                }

                return rtnRes; //返回TR2数据
            }
            catch (Exception ex)
            {
                string sStr = ex.Message;
                return sStr; //返回错误
            }
        }

        public static void WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was: \n\n" + text + "\n");
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index: {0}, \tString: {1}, \t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));
            }
        }

        public static void CdromManagement()
        {
            WqlEventQuery q;
            ManagementOperationObserver observer = new ManagementOperationObserver();
            observer.Completed += Observer_Completed;
            // Bind to local machine
            ConnectionOptions opt = new ConnectionOptions
            {
                EnablePrivileges = true
            };
            //sets required privilege
            ManagementScope scope = new ManagementScope("root\\CIMV2", opt);
            q = new WqlEventQuery
            {
                EventClassName = "__InstanceModificationEvent",
                WithinInterval = new TimeSpan(0, 0, 1),
                Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5"
            };
            // DriveType - 5: CDROM
            var watcher = new ManagementEventWatcher(scope, q);
            // register async. event handler
            watcher.EventArrived += (sender, e) =>
            {
                // Get the Event object and display it
                PropertyData propertyData = e.NewEvent.Properties["TargetInstance"];
                ManagementBaseObject mbo = propertyData.Value as ManagementBaseObject;

                // if CD removed VolumeName == null
                Console.WriteLine(mbo?.Properties["VolumeName"].Value != null ? "CD has been inserted" : "CD has been ejected");
            };
            watcher.Start();
            // Do something usefull,block thread for testing
            Console.ReadLine();
            watcher.Stop();
        }

        private static void Observer_Completed(object sender, CompletedEventArgs e)
        {
            Console.WriteLine("Observer_Completed.................");
        }

        public static void VolatileTest()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
            {
            }

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }

        private static void StrongBoxInt(StrongBox<int> sint)
        {
            sint.Value = 456789;
        }

        private static void StrongBoxDemo()
        {
            StrongBox<int> sint = new StrongBox<int>(123465);
            Console.WriteLine(sint.Value);
            StrongBoxInt(sint);
            Console.WriteLine(sint.Value);
        }
    }
}