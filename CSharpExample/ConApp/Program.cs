using ConApp.Class;
using Net.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ConApp
{
    public class Test
    {
        public string A { get; set; } = "12";

        public int B { get; set; }
    }

    internal class Program
    {
        public delegate void ConPort(int port);

        private delegate void AsycRun();

        public static unsafe void Main(string[] args)
        {
            AppDomainSetup app1 = AppDomain.CurrentDomain.SetupInformation;
            string app2 = System.Reflection.Assembly.GetEntryAssembly().Location;
            string name = AppDomain.CurrentDomain.FriendlyName;

            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。
            string str2 = Environment.CurrentDirectory;//获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。(备注:按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠（如“C:\”）。如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径[如“C:\mySubDirectory”])。
            string str3 = Directory.GetCurrentDirectory(); //获取应用程序的当前工作目录。
            string str4 = AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集。
            //string str5 = Application.StartupPath;//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
            //string str6 = Application.ExecutablePath;//获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
            string str7 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称。

            string exePath = app2;
            string useridsTr = "1,2,3,4,3,2,1,4,5,7,8,";
            string[] idsStr = useridsTr.TrimEnd(',').Split(',');

            if (idsStr != null && idsStr.Any())
            {
                IEnumerable<string> userId = idsStr.Distinct();
                foreach (string item in userId)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("*********************************************");
            List<int> ids = new List<int>();
            ids.AddRange(new List<int> { 1, 2, 3, 4 });
            ids.AddRange(new List<int> { 5, 6, 7, 8 });
            ids.AddRange(new List<int> { 9, 10, 11, 12 });

            int idg = Convert.ToInt32(Math.Ceiling(ids.Count / 5.0));

            List<int> sInts = new List<int>();
            for (int i = 1; i <= idg; i++)
            {
                sInts = new List<int>();
                sInts.AddRange(ids.Skip((i - 1) * 5).Take(5));

                string jboNumbers = sInts.Aggregate(string.Empty, (current, item) => current + (item + ",")).TrimEnd(',');

                Console.WriteLine(jboNumbers);
            }
            /*
                2016/12/18 0:00:00
                2016/12/19 0:00:00

                2016/12/6 0:00:00
                2016/12/7 0:00:00
            */
            Console.WriteLine(DateTime.Today.AddDays(-3));
            Console.WriteLine(DateTime.Today.AddDays(-2));

            Console.WriteLine(DateTime.Today.AddDays(-15));
            Console.WriteLine(DateTime.Today.AddDays(-14));
            Test t = new Test();
            Console.WriteLine(t.A);

            #region 实现IIS应用池的远程回收

            //ServerManager manager = ServerManager.OpenRemote("184.12.15.157");
            //ApplicationPoolCollection appPools = manager.ApplicationPools;
            //foreach (var ap in appPools)
            //{
            //    ap.Recycle();
            //}
            /*
             * 回收注意事项：
                1.需要添加引用 C:\Windows\System32\inetsrv\Microsoft.Web.Administration.dll ,然后using Microsoft.Web.Administration;
                2.远程账号需要有管理员权限；
                3.远程主机的账号密码添加在服务器的凭据管理器中 (控制面板->凭据管理器) ，能成功使用mstsc 登录即可；
                4.远程主机需要关闭UAC！！ 因为这个问题卡了好几个礼拜才无意发现。
             */

            #endregion 实现IIS应用池的远程回收

            #region ConfigurationSection

            //const string siteName = "fairy.vip";

            //using (ServerManager manager = new ServerManager())
            //{
            //    //获得 IIS 站点信息。
            //    var site = manager.Sites[siteName];

            //    //获得站点根目录下的“Web.Config”文件配置信息。
            //    Configuration config = site.GetWebConfiguration();

            //    ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
            //    /*
            //     * 设置节点参数。
            //     * enabled：是否启用。
            //     * destination：目标 URL 或者文件。
            //     * exactDestination：
            //     * httpResponseStatus：
            //     */
            //    httpRedirectSection["enabled"] = false;
            //    httpRedirectSection["destination"] = @"http://www.rapid.com/error/500$S$Q";
            //    httpRedirectSection["exactDestination"] = true;
            //    httpRedirectSection["httpResponseStatus"] = @"Temporary";

            //    //回收应用程序池。
            //    manager.ApplicationPools[siteName].Recycle();

            //    //提交。
            //    manager.CommitChanges();
            //}

            #endregion ConfigurationSection

            #region 运行时控制：得到当前正在处理的请求

            //using (ServerManager manager = new ServerManager())
            //{
            //    foreach (WorkerProcess w3wp in manager.WorkerProcesses)
            //    {
            //        Console.WriteLine("W3WP ()", w3wp.ProcessId);

            //        foreach (Request request in w3wp.GetRequests(0))
            //        {
            //            Console.WriteLine(" - ,,", request.Url, request.ClientIPAddr, request.TimeElapsed, request.TimeInState);
            //        }
            //    }
            //}

            #endregion 运行时控制：得到当前正在处理的请求

            #region aspnet_isapi

            //const string isAPI_partialPath = @"v4.0.30319\aspnet_isapi.dll";
            //using (ServerManager manager = new ServerManager())
            //{
            //    Configuration config = manager.GetApplicationHostConfiguration();

            //    ConfigurationSection section = config.GetSection("system.webServer/security/isapiCgiRestriction");

            //    foreach (ConfigurationElement item in section.GetCollection())
            //    {
            //        if (item.Attributes.Count > 0 && item.Attributes["path"].Value != null && item.Attributes["path"].Value.ToString().EndsWith(isAPI_partialPath))
            //        {
            //            item.Attributes["allowed"].Value = true;
            //        }
            //    }
            //    manager.CommitChanges();
            //}

            #endregion aspnet_isapi

            #region 添加扩展

            ////appcmd.exe set config -section:system.webServer/security/isapiCgiRestriction /+"[path='C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll',allowed='True',groupId='ContosoGroup',description='Contoso Extension']" /commit:apphost
            //using (ServerManager serverManager = new ServerManager())
            //{
            //    Configuration config = serverManager.GetApplicationHostConfiguration();
            //    ConfigurationSection isapiCgiRestrictionSection = config.GetSection("system.webServer/security/isapiCgiRestriction");
            //    ConfigurationElementCollection isapiCgiRestrictionCollection = isapiCgiRestrictionSection.GetCollection();

            //    ConfigurationElement addElement = isapiCgiRestrictionCollection.CreateElement("add");
            //    addElement["path"] = @"C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll";
            //    addElement["allowed"] = true;
            //    addElement["groupId"] = @"ContosoGroup";
            //    addElement["description"] = @"Contoso Extension";
            //    isapiCgiRestrictionCollection.Add(addElement);

            //    serverManager.CommitChanges();
            //}

            #endregion 添加扩展

            XMLDemo2();
            //for (int i = 100; i < 1000; i++)
            //{
            //    Thread t = new Thread(() =>
            //    {
            //        Console.Write(i+"\t");
            //    });
            //    t.Start();
            //    t.Join();
            //}

            #region 多线程查询端口情况

            //for (int i = 1; i <= 8; i++)
            //{
            //    ParameterizedThreadStart pts = x =>
            //     {
            //         for (int j = 1000 * ((int)x - 1) + 1; j <= 1000 * (int)x; j++)
            //         {
            //             PortCon(j);
            //         }
            //     };

            //    Thread t = new Thread(pts);
            //    t.Start(i);
            //}

            #endregion 多线程查询端口情况

            #region 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

            //IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            //TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            //foreach (TcpConnectionInformation t in connections)
            //{
            //    Console.Write(@"Local endpoint: {0} ", t.LocalEndPoint);
            //    Console.Write(@"Remote endpoint: {0} ", t.RemoteEndPoint);
            //    Console.WriteLine(@"{0}", t.State);
            //}

            #endregion 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

            #region TCP检查端口是否打开

            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPEndPoint point = new IPEndPoint(ip, 80);
            //try
            //{
            //    TcpClient tcp = new TcpClient();
            //    tcp.Connect(point);
            //    Console.WriteLine("打开的端口");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("已开启的端口");
            //}

            #endregion TCP检查端口是否打开

            #region Http检查端口是否打开

            //HttpListener httpListner = new HttpListener();
            //httpListner.Prefixes.Add("http://*:8080/");
            //httpListner.Start();
            //Console.WriteLine("Port: 8080 status: " + (PortInUse(8080) ? "in use" : "not in use"));

            #endregion Http检查端口是否打开

            #region 文件权限相关

            //DirectorySecurity security = new DirectorySecurity();
            //const string path = @"D:\temp";
            ////设置权限的应用为文件夹本身、子文件夹及文件,所以需要InheritanceFlags.ContainerInherit 或 InheritanceFlags.ObjectInherit
            //security.AddAccessRule(new FileSystemAccessRule("NETWORK SERVICE",
            //    FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            //    PropagationFlags.None, AccessControlType.Allow));
            //security.AddAccessRule(new FileSystemAccessRule("Everyone",
            //    FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            //Directory.SetAccessControl(path, security);

            #endregion 文件权限相关

            //string name = Assembly.GetExecutingAssembly().GetType().Namespace;
            //Console.WriteLine(name);

            #region 左移

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"{i} {1 << i}");
            //}

            #endregion 左移

            //AppDomain.CurrentDomain.SetData("name", "Hello");
            //string name = AppDomain.CurrentDomain.GetData("name").ToString();
            //Console.WriteLine(name);

            //// Create application domain setup information
            //AppDomainSetup domaininfo = new AppDomainSetup();
            //domaininfo.ConfigurationFile = Environment.CurrentDirectory + "ADSetup.exe.config";
            //domaininfo.ApplicationBase = Environment.CurrentDirectory;

            ////Create evidence for the new appdomain from evidence of the current application domain
            //Evidence adevidence = AppDomain.CurrentDomain.Evidence;

            //// Create appdomain
            //AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

            //// Write out application domain information
            //Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            //Console.WriteLine("child domain: " + domain.FriendlyName);
            //Console.WriteLine();
            //Console.WriteLine("Configuration file is: " + domain.SetupInformation.ConfigurationFile);
            //Console.WriteLine("Application Base Directory is: " + domain.BaseDirectory);

            //AppDomain.Unload(domain);

            #region 异步委托

            //AsyncCallback ac = delegate (IAsyncResult aar)
            //{
            //    Console.WriteLine("跑完了");
            //    Console.WriteLine(aar.AsyncState);
            //};

            //AsycRun ar = delegate
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write(i + "\t");
            //    }
            //};
            //ar.BeginInvoke(ac, "object");

            #endregion 异步委托

            Console.ReadKey();
        }

        #region 01-foreach原理

        public static void Cus_foreach()
        {
            MyCollection myCol = new MyCollection();
            foreach (var a in myCol)
            {
                Console.WriteLine(a);
            }
            MyCollection2 myCol2 = new MyCollection2();
            foreach (var m in myCol2)
            {
                Console.WriteLine(m);
            }
        }

        #endregion 01-foreach原理

        #region 02-EnumDemo

        /*
         “X”或“x” 以十六进制格式表示 value（不带前导“0x”）。
         “D”或“d” 以十进制形式表示 value。
         “F”或“f” 对于“G”或“g”执行的行为是相同的，只是在 Enum 声明中不需要 FlagsAttribute。

         “G”或“g”
         如果 value 等于某个已命名的枚举常数，则返回该常数的名称；否则返回 value 的等效十进制数。
         例如，假定唯一的枚举常数命名为 Red，其值为 1。如果将 value 指定为 1，则此格式返回“Red”。然而，如果将 value 指定为 2，则此格式返回“2”。
         - 或 -
         如果将 FlagsAttribute 自定义特性应用于枚举，则 value 将被视为位域，该位域包含一个或多个由一位或多位组成的标志。
         如果 value i等于命名枚举常数的组合，则将返回这些常量名的分隔符分隔列表。将在 value 中搜索标志，从具有最大值的标志到具有最小值的标志进行搜索。
         对于与 value 中的位域相对应的每个标志，常数的名称连接到用分隔符分隔的列表。则将不再考虑该标记的值，而继续搜索下一个标志。
         如果 value 不等于已命名的枚举常数的组合，则返回 value 的等效十进制数。
     */

        public static void EnumDemo01()
        {
            Console.WriteLine($"Season.夏={Season.夏}");
            Console.WriteLine($"(int)Season.夏={(int)Season.夏}");

            const int b = (int)Season.春;
            Console.WriteLine(b);
            Console.WriteLine((Season)b);

            const Season s = (Season)100;
            const int e = (int)s;
            Console.WriteLine(s);
            Console.WriteLine(e);
        }

        public static void EnumDemo02_Parse()
        {
            const string a = "夏";
            try
            {
                Season season = (Season)(Enum.Parse(typeof(Season), a));
                Console.WriteLine(@"season=" + season);
            }
            catch
            {
                Console.WriteLine(@"无此枚举");
            }
        }

        public static void EnumDemo3_Format()
        {
            Season s = Season.冬;
            Console.WriteLine($"d={Enum.Format(typeof(Season), s, "d")} x={Enum.Format(typeof(Season), s, "x")} g={Enum.Format(typeof(Season), s, "g")} f={Enum.Format(typeof(Season), s, "f")}");
            const Season se = Season.夏 | Season.秋 | Season.冬;
            Console.WriteLine(se);

            Console.WriteLine(Enum.GetName(typeof(Season), 4));
        }

        public static void EnumDemo04_GetNames()
        {
            Type season = typeof(Season);
            foreach (string s in Enum.GetNames(season))
            {
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(season, Enum.Parse(season, s), "d"));
            }
        }

        public static void EnumDemo05_GetValues()
        {
            Type season = typeof(Season);
            foreach (int i in Enum.GetValues(season))
            {
                Console.WriteLine(i);
            }
        }

        #endregion 02-EnumDemo

        #region 03-EventDemo

        public static void EventDemo()
        {
            ExampleMethod(p2: "");
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            ExampleMethod(WriteLetter("A"), b: WriteLetter("B"), c: WriteLetter("C"));
            ExampleMethod(WriteLetter("A"), c: WriteLetter("C"), b: WriteLetter("B"));
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var methods = new List<Action>();
            foreach (var word in new string[] { "hello", "world" })
            {
                methods.Add(() => Console.Write(word + " "));
            }

            methods[0]();
            methods[1]();
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var lines = new List<IEnumerable<string>>();
            int[] numbers = { 1, 2, 3 };
            char[] letters = { 'a', 'b', 'c' };

            foreach (int number in numbers)
            {
                var line = from letter in letters
                           select number.ToString() + letter;

                lines.Add(line);
            }

            foreach (var line in lines)
            {
                foreach (var entry in line)
                    Console.Write(entry + " ");
                Console.WriteLine();
            }
            Console.WriteLine(@"\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Class.Publisher publisher = new Class.Publisher();

            publisher.SampleEvent += publisher_SampleEvent;
        }

        private static int WriteLetter(string letter)
        {
            Console.Write(letter + " ");
            return 1;
        }

        private static void ExampleMethod(int a, int b, int c)
        {
        }

        public static void ExampleMethod(string p1 = null, object p2 = null)
        {
            Console.WriteLine(@"ExampleMethod: p2 is object");
        }

        public static void ExampleMethod(string p2 = null, object p1 = null, params int[] p3)
        {
            Console.WriteLine(@"ExampleMethod: p2 is string");
        }

        private static void publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("e.Text:" + e.Text);
        }

        #endregion 03-EventDemo

        #region 04-PerformanceCounter

        public static void Demo04()
        {
            var counters = new List<PerformanceCounter>();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;

            Thread.Sleep(1000);

            foreach (var counter in counters)
            {
                Console.WriteLine(processes[i].ProcessName + " | CPU% " + (Math.Round(counter.NextValue(), 1)));
                ++i;
            }
        }

        #endregion 04-PerformanceCounter

        #region 05-GetHostEntryDemo

        public static void GetHostEntryDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing request for information...");

            while (result.IsCompleted != true)
            {
                Extension.UpdateUserInterface();
            }

            Console.WriteLine();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 05-GetHostEntryDemo

        #region 06-ProcessDemo

        public static void ProcessDemo()
        {
            Process myProcess = new Process();
            try
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\MyFile.docx";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Win32Exception e)
            {
                if (e.NativeErrorCode == 2)//ErrorFileNotFound
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                }
                else if (e.NativeErrorCode == 5)//ErrorAccessDenied
                {
                    Console.WriteLine(e.Message + ". You do not have permission to print this file.");
                }
            }
        }

        #endregion 06-ProcessDemo

        #region 07-AsyncWaitHandle

        public static void AsyncWaitHandleDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");
            result.AsyncWaitHandle.WaitOne();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine("{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine("{0}", t.ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 07-AsyncWaitHandle

        #region 08-AsyncOperationDemo

        public static void AsyncOperationDemo()
        {
            string[] args = { };

            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing your request for information...");
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion 08-AsyncOperationDemo

        #region 09-AsyncResultDemo

        public static void AsyncResultDemo()
        {
            Func<bool> asncRun = Extension.AutoUpdate;
            asncRun.BeginInvoke(Extension.AutoUpdateSupplierMcScoreAsyncCallback, asncRun);
        }

        #endregion 09-AsyncResultDemo

        #region 10-自定义扩展方法

        public static void CusMethod()
        {
            #region 扩展方法

            //在list上添加一个方法，传一个委托到一个方法，满足当前委托条件的变量都给取出来
            List<string> list = new List<string>()
            {
                "1",
                "2",
                "3",
                "4"
            };
            //自己内部模拟的写法
            var temp1 = list.MyFindStrs(Extension.MyCalc);
            foreach (var item in temp1)
            {
                Console.WriteLine(item);
            }

            //普通写法
            var temp2 = list.FindAll(Extension.MyCalc);

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }

            var temp3 = list.FindAll(a => int.Parse(a) >= 2);

            foreach (var item in temp3)
            {
                //Console.WriteLine(item);
            }

            #endregion 扩展方法
        }

        #endregion 10-自定义扩展方法

        #region 11-ExcuteXCopyCmd

        public static void ExcuteXCopyCmdDemo()
        {
            string sCmd = @"copy D:\a.txt D:\b.txt";
            Process proIP = new Process();
            proIP.StartInfo.FileName = "cmd.exe";
            proIP.StartInfo.UseShellExecute = false;
            proIP.StartInfo.RedirectStandardInput = true;
            proIP.StartInfo.RedirectStandardOutput = true;
            proIP.StartInfo.RedirectStandardError = true;
            proIP.StartInfo.CreateNoWindow = true;
            proIP.Start();
            proIP.StandardInput.WriteLine(sCmd);
            proIP.StandardInput.WriteLine("exit");
            string strResult = proIP.StandardOutput.ReadToEnd();
            proIP.Close();

            Console.WriteLine(strResult);
        }

        #endregion 11-ExcuteXCopyCmd

        #region 12-属性相关

        public static void PropertyInfoTest()
        {
            Dictionary<int, string> attrs = new Dictionary<int, string> { { 1, "1" } };
            Person person = new Person
            {
                Name = "huruiyi",
                Salary = 12345,
                Sex = 'N',
                Equips = new List<Equip>
                {
                    new Equip {Name = "N1", AttackValue = 123},
                    new Equip {Name = "N2", AttackValue = 123},
                    new Equip {Name = "N3", AttackValue = 123},
                },
                Hobbys = new[] { "h1", "h2", "h3", "h4" },
                Attributes = attrs
            };
            Console.WriteLine(typeof(List<>).Name);
            PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                string pName = p.Name;
                string name = p.PropertyType.Name;
                Type t = p.PropertyType.GetType();
                bool pg = p.PropertyType.IsGenericType;
                var a = p.GetValue(person, null);
                if (p.PropertyType.Name == "String")
                {
                    p.SetValue(person, "Name", null);
                }
                if (p.PropertyType.Name == "Double")
                {
                    p.SetValue(person, 123.1345, null);
                }
                if (p.PropertyType.Name == "Char")
                {
                    p.SetValue(person, '男', null);
                }

                //if (p.PropertyType.IsGenericType)
                //{
                //    p.SetValue(person, new List<Equip>{
                //    new Equip {Name = "N1111", AttackValue = 123},
                //    new Equip {Name = "N2222", AttackValue = 123},
                //    new Equip {Name = "N3333", AttackValue = 123},
                //});
                //}
            }
        }

        #endregion 12-属性相关

        #region 13-EnumTest

        public static void EnumTest()
        {
            string idField = ((MemberExpression)((Expression<Func<City, int>>)(c => c.CityId)).Body).Member.Name;
            string textField = ((MemberExpression)((Expression<Func<City, string>>)(c => c.CityName)).Body).Member.Name;

            for (int i = 0; i < 5; i++)
            {
                var enumName = Enum.GetName(typeof(SocialTypeEnum), i);
                Console.WriteLine("{0}:{1}", i, enumName);
            }
            SocialTypeEnum result;
            bool result1 = Enum.TryParse("1", out result);
            bool result2 = Enum.TryParse<SocialTypeEnum>("2", out result);
            //string result3 = Enum.Format(typeof(SocialTypeEnum), "3", "X");

            string result4 = Enum.GetName(typeof(SocialTypeEnum), 2);
            string[] result5 = Enum.GetNames(typeof(SocialTypeEnum));
            Type result6 = Enum.GetUnderlyingType(typeof(SocialTypeEnum));
            Array array = Enum.GetValues(typeof(SocialTypeEnum));
            Console.WriteLine("数字{0}对应的枚举Name值:{1}", 3, Enum.GetName(typeof(SocialTypeEnum), 3));

            Type ste = typeof(SocialTypeEnum);
            object[] result7 = ste.GetField(SocialTypeEnum.Facebook.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
        }

        #endregion 13-EnumTest

        #region 14-HashtableTest

        public static void HashtableTest()
        {
            Hashtable hashtable1 = new Hashtable();
            hashtable1.Add("zd", "600719");
            hashtable1.Add("name", "denylau");
            hashtable1.Add("sex", "男");
            Console.WriteLine("hashtable长度为：" + hashtable1.Count);

            ArrayList akeys = new ArrayList(hashtable1.Keys);
            akeys.Sort();
            foreach (string skey in akeys)
            {
                Console.Write(skey + ":");
                Console.WriteLine(hashtable1[skey]);
            }

            // 默认输出是无序的
            foreach (DictionaryEntry item in hashtable1)
            {
                Console.WriteLine("{0}:\t{1}", item.Key, item.Value);
            }

            IDictionaryEnumerator en = hashtable1.GetEnumerator();
            while (en.MoveNext())
            {
                string str = en.Value.ToString();
                Console.WriteLine(str);
            }

            foreach (var item in hashtable1.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in hashtable1.Values)
            {
                Console.WriteLine(item);
            }

            //hashtable1 .Clear();

            Console.WriteLine(hashtable1.Contains("zd"));
            Console.WriteLine($"{ hashtable1["zd"] }");

            //hashtable1.Remove("zd");

            Console.WriteLine("**********************************************************");
            Hashtable hashtableItem = new Hashtable();
            hashtableItem.Add("Name", "小红");
            hashtableItem.Add("Sex", "女");
            hashtableItem.Add("Age", 20);

            Hashtable hashtableItem1 = new Hashtable();
            hashtableItem1.Add("Name", "小王");
            hashtableItem1.Add("Sex", "男");
            hashtableItem1.Add("Age", 21);

            Hashtable hashtableItem2 = new Hashtable();
            hashtableItem2.Add("Name", "小李");
            hashtableItem2.Add("Sex", "男");
            hashtableItem2.Add("Age", 22);

            ArrayList list = new ArrayList(hashtableItem.Keys);
            list.Add(hashtableItem);
            list.Add(hashtableItem1);
            list.Add(hashtableItem2);

            Tom a = new Tom("小王", 20, '男', "篮球", 12345);
            Tom b = new Tom("小李", 21, '女', "排球", 22345);
            Tom c = new Tom("小胡", 22, '男', "足球", 32345);
            ArrayList array = new ArrayList();
            array.Add(a);
            array.Add(b);
            array.Add(c);
            foreach (Tom item in array)
            {
                Tom tom = (Tom)item;
                Console.WriteLine(tom.Name + " " + tom.Age + " " + tom.Sex);
            }
        }

        #endregion 14-HashtableTest

        #region 15-基本数据类型

        public static void BasicType()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("short.MinValue:" + short.MinValue);
            Console.WriteLine("short.MaxValue:" + short.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("int.MinValue:" + int.MinValue);
            Console.WriteLine("int.MaxValue:" + int.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int16.MinValue:" + Int16.MinValue);
            Console.WriteLine("Int16.MaxValue:" + Int16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int32.MinValue:" + Int32.MinValue);
            Console.WriteLine("Int32.MaxValue:" + Int32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Int64.MinValue:" + Int64.MinValue);
            Console.WriteLine("Int64.MaxValue:" + Int64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt16.MinValue:" + UInt16.MinValue);
            Console.WriteLine("UInt16.MaxValue:" + UInt16.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt32.MinValue:" + UInt32.MinValue);
            Console.WriteLine("UInt32.MaxValue:" + UInt32.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("UInt64.MinValue:" + UInt64.MinValue);
            Console.WriteLine("UInt64.MaxValue:" + UInt64.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("byte.MinValue:" + byte.MinValue);
            Console.WriteLine("byte.MaxValue:" + byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("Byte.MinValue:" + Byte.MinValue);
            Console.WriteLine("Byte.MaxValue:" + Byte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("sbyte.MinValue:" + sbyte.MinValue);
            Console.WriteLine("sbyte.MaxValue:" + sbyte.MaxValue);
            Console.WriteLine("**************************************************");
            Console.WriteLine("SByte.MinValue:" + SByte.MinValue);
            Console.WriteLine("SByte.MaxValue" + SByte.MaxValue);
            Console.WriteLine("**************************************************");
        }

        #endregion 15-基本数据类型

        #region 16-YieldDemo

        /*
        foreach (int i in YieldPower(2, 8))
        {
            Console.Write("{0} ", i);
        }
        */

        public static IEnumerable YieldPower(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        #endregion 16-YieldDemo

        #region 17-GetEnumeratorTest

        public static void GetEnumeratorTest()
        {
            ArrayList arr = new ArrayList() { 12, 13, 1, 4, 15, 16, 17 };
            IEnumerator iEnumerator = arr.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                Console.WriteLine(iEnumerator.Current);
            }
        }

        #endregion 17-GetEnumeratorTest

        #region 18-DateTimeDemo

        public static void DateTimeTest()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(12);
            TimeSpan timeSpan = endTime.Subtract(startTime);
            Console.WriteLine(timeSpan.Days);
        }

        #endregion 18-DateTimeDemo

        #region 19-查看端口是否被占用

        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        public static void PortCon(object port)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip, (int)port);
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(point);
                Console.WriteLine("{0}成功!", point);
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != 10061)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("{0}失败", port);
            }
        }

        #endregion 19-查看端口是否被占用

        #region 20-WeakReferenceDemo

        public static void WeakRefenceDemo()
        {
            WeakReference mathReference = new WeakReference(new MathTest());
            MathTest math;
            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathTest;
                math.Value = 30;
                Console.WriteLine(@"Value field of math variable contains " + math.Value);
                Console.WriteLine(@"Square of 30 is " + math.GetSquare());
            }
            else
            {
                Console.WriteLine(@"Reference is not available.");
            }

            GC.Collect();

            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathTest;
            }
            else
            {
                Console.WriteLine(@"Reference is not available.");
            }
        }

        #endregion 20-WeakReferenceDemo

        #region 21-不安全代码

        public unsafe static void ArrPrintDemo()
        {
            const int al = 10;
            byte[] ints = new byte[al];
            //for (int i = 0; i < 50000; i++)
            //{
            //    new object();
            //}

            fixed (byte* ip = ints)
            {
                for (int i = 0; i < al; i++)
                {
                    Console.WriteLine(Guid.NewGuid().GetHashCode());
                    ip[i] = (byte)new Random().Next(0, 256);
                }
            }

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Array.ForEach(ints, b => Console.WriteLine(b));
        }

        public static unsafe void SquarePtrParamDemo(int i)
        {
            SquareIntPointer(&i);
            Console.WriteLine(i);
        }

        public static void SafeSwapDemo()
        {
            int i = 10, j = 20;
            SafeSwap(ref i, ref j);
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

            unsafe
            {
                UnsafeSwap(&i, &j);
            }
            Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);
        }

        /// <summary>
        /// 求平方
        /// </summary>
        /// <param name="p"></param>
        private static unsafe void SquareIntPointer(int* p)
        {
            *p *= *p;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void SafeSwap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        /// <summary>
        /// 交换两个数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static unsafe void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        public static unsafe void UnsafeAddDemo1()
        {
            int[] a = new int[2];
            a[0] = 1;
            a[1] = 2;
            int b = 3;
            int res = UnsafeAdd1(a, b);
            Console.WriteLine(res);

            unsafe
            {
                int num = 5;
                int* intp = &num;

                int result = UnsafeAdd2(num, intp);
                Console.WriteLine(result);
            }
        }

        public static int UnsafeAdd1(int[] a, int b)
        {
            unsafe
            {
                fixed (int* pa = a)//此处将锁住a，使得在fixed操作块内，a不会被CLR移动
                {
                    return *pa + b;
                }
            }
        }

        public unsafe static int UnsafeAdd2(int a, int* b)//此处使用 指针，需要加入非安全代码关键字unsafe
        {
            return a + *b;
        }

        public static unsafe void UsePointerToPoint()
        {
            PointTest point;
            PointTest* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + p->ToString());

            PointTest point2;
            PointTest* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx:::" + (*p2).ToString());
        }

        public static unsafe void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for (int k = 0; k < 256; k++)
            {
                p[k] = (char)k;
            }
        }

        public static unsafe void PrintValueAndAddress()
        {
            int myInt;

            int* ptrToMyInt = &myInt;

            *ptrToMyInt = 123;

            Console.WriteLine("Vsalue of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        public static unsafe void UseAndPinPoint()
        {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            // pin pt in place so it will not be moved or GC-ed.
            fixed (int* p = &pt.x)
            {
                // Use int* variable here!
            }

            // pt is now unpinned, and ready to be GC-ed once the method completes.
            Console.WriteLine("Point is: {0}", pt);
        }

        private static unsafe void UseSizeOfOperator()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
            Console.WriteLine("The size of Point is {0}.", sizeof(Point));
        }

        /*
          由于涉及指针类型，因此 stackalloc 要求不安全上下文。 有关更多信息，请参见 不安全代码和指针（C# 编程指南）。
          stackalloc 类似于 C 运行库中的 _alloca。
          以下代码示例计算并演示 Fibonacci 序列中的前 20 个数字。 每个数字是先前两个数字的和。
          在代码中，大小足够容纳 20 个 int 类型元素的内存块是在堆栈上分配的，而不是在堆上分配的。
          该块的地址存储在 fib 指针中。 此内存不受垃圾回收的制约，因此不必将其钉住（通过使用 fixed）。
          内存块的生存期受限于定义它的方法的生存期。 不能在方法返回之前释放内存。
      */

        public static unsafe void Demo28()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }
        }

        #endregion 21-不安全代码

        #region 22-TaskDemo

        public static void TasKdemo1()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            token.Register(delegate { Console.WriteLine("cancel........."); });
            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Unable to compute mean: {0}", ((TaskCanceledException)e).Message);
                    }
                    else
                    {
                        Console.WriteLine("Exception: " + e.GetType().Name);
                    }
                }
            }
            finally
            {
                source.Dispose();
            }
        }

        public static void TasKdemo2()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task tack = Task.Factory.StartNew(delegate ()
            {
                GetPseronList1(pers1);
                GetPseronList2(pers2);
                GetPseronList3(pers3);
                GetPseronList4(pers4);
                GetPseronList5(pers5);
            });
            tack.ContinueWith(delegate (Task task)
            {
                Console.WriteLine("执行完成");
            });
        }

        public static void TasKWhenAll3()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task t1 = Task.Run(() => { GetPseronList1(pers1); });
            Task t2 = Task.Run(() => { GetPseronList2(pers2); });
            Task t3 = Task.Run(() => { GetPseronList3(pers3); });
            Task t4 = Task.Run(() => { GetPseronList4(pers4); });
            Task t5 = Task.Run(() => { GetPseronList5(pers5); });

            Task tb = Task.WhenAll(t1, t2, t3, t4, t5);
            tb.ContinueWith((Task tt) => { Console.WriteLine("执行完成"); });
        }

        public static void TaskContinueWithDemo()
        {
            List<Person> pers1 = new List<Person>();
            List<Person> pers2 = new List<Person>();
            List<Person> pers3 = new List<Person>();
            List<Person> pers4 = new List<Person>();
            List<Person> pers5 = new List<Person>();
            Task task = Task.Factory.StartNew(() =>
            {
                Parallel.Invoke(
                    delegate () { GetPseronList1(pers1); },
                    delegate () { GetPseronList2(pers2); },
                    delegate () { GetPseronList3(pers3); },
                    delegate () { GetPseronList4(pers4); },
                    delegate () { GetPseronList5(pers5); });
            });
            Task.WaitAll();
            task.ContinueWith(delegate (Task tt)
                {
                    Console.WriteLine("执行完成");
                }
            );
        }

        public static void GetPseronList1(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p1Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList2(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl1Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p2Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList3(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl2Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p3Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList4(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl3Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p4Listp{0}创建成功", i);
            }
        }

        public static void GetPseronList5(List<Person> pers)
        {
            for (int i = 0; i < 5; i++)
            {
                pers.Add(new Person { Name = "pl4Name" + i, Age = i });
                Thread.Sleep(100 * i);
                Console.WriteLine("p5Listp{0}创建成功", i);
            }
        }

        #endregion 22-TaskDemo

        #region 23-SpinWaitDemo

        public static void SpinWaitDemo()
        {
            // Demonstrates:
            //      SpinWait construction
            //      SpinWait.SpinOnce()
            //      SpinWait.NextSpinWillYield
            //      SpinWait.Count
            bool someBoolean = false;
            int numYields = 0;

            // First task: SpinWait until someBoolean is set to true
            Task t1 = Task.Factory.StartNew(() =>
            {
                SpinWait sw = new SpinWait();
                while (!someBoolean)
                {
                    // The NextSpinWillYield property returns true if
                    // calling sw.SpinOnce() will result in yielding the
                    // processor instead of simply spinning.
                    if (sw.NextSpinWillYield) numYields++;
                    sw.SpinOnce();
                }

                // As of .NET Framework 4: After some initial spinning, SpinWait.SpinOnce() will yield every time.
                Console.WriteLine("SpinWait called {0} times, yielded {1} times", sw.Count, numYields);
            });

            // Second task: Wait 100ms, then set someBoolean to true
            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                someBoolean = true;
            });

            // Wait for tasks to complete
            Task.WaitAll(t1, t2);
        }

        #endregion 23-SpinWaitDemo

        #region 24进制转换_Bin_Oct_Dec_Hex

        public static void Bin_Oct_Dec_Hex()
        {
            Console.WriteLine(UriPartial.Authority);
            Console.WriteLine(UriPartial.Path);
            Console.WriteLine(UriPartial.Query);
            Console.WriteLine(UriPartial.Scheme);
            Console.WriteLine(sizeof(char));
            Console.WriteLine(sizeof(byte));
            Console.WriteLine(sizeof(Byte));

            Console.WriteLine(sizeof(sbyte));
            Console.WriteLine(sizeof(SByte));

            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(ushort));

            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(uint));

            Console.WriteLine(sizeof(Int16));
            Console.WriteLine(sizeof(UInt16));

            Console.WriteLine(sizeof(Int32));
            Console.WriteLine(sizeof(UInt32));

            Console.WriteLine(sizeof(Int64));
            Console.WriteLine(sizeof(UInt64));

            Console.WriteLine(sizeof(decimal));
            Console.WriteLine(sizeof(Decimal));
            Console.WriteLine(sizeof(float));

            Console.WriteLine(sizeof(long));
            Console.WriteLine(sizeof(ulong));
            Console.WriteLine(sizeof(Single));

            Console.WriteLine(sizeof(UriPartial));

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine($"{i.ToString()} {i.ToString("x")} {i.ToString("x2")} {Convert.ToString(i, 2)} {Convert.ToString(i, 8)} {Convert.ToString(i, 16)}");
            }
        }

        #endregion 24进制转换_Bin_Oct_Dec_Hex

        #region 25-XMLDemo

        public static void XMLDemo1()
        {
            //删除节点
            //XDocument XMLDoc = XDocument.Load(path);
            //XElement elment = (from xml1 in XMLDoc.Descendants("Node")
            //                   select xml1).FirstOrDefault();
            //elment.Remove();
            //XMLDoc.Save(path);

            string xmlInfo = Properties.Resources.XML;

            DirectoryInfo basrDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo codeDir = basrDir.Parent.Parent;
            string path = Path.Combine(codeDir.FullName, "Resource", "XML.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/info/collage");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Console.WriteLine(xmlNode["name"].InnerText, xmlNode["students"].InnerText);
            }
        }

        public static void XMLDemo2()
        {
            CitiesListResponse response = new CitiesListResponse
            {
                Result = new Result
                {
                    Value = "123465",
                    Code = "001"
                },
                CitiesList = new CityObj[]
                {
                    new CityObj {PinYin="suzhou",Value="苏州" ,HasOutService="123",Info="苏州",Population=123456},
                    new CityObj {PinYin="wuxi",Value="无锡" ,HasOutService="234",Info="无锡",Population=234567},
                    new CityObj {PinYin="nanjing",Value="南京" ,HasOutService="456",Info="南京",Population=345678},
                }
            };
            string str = XmlSerializeHelper.Serializer(response);
            Console.WriteLine(str);
            Console.ReadLine();

            XmlSerializer serializer = new XmlSerializer(typeof(CitiesListResponse));
            serializer.Serialize(Console.Out, response);
            Console.Read();
        }

        #endregion 25-XMLDemo

        #region 26-WebRequestDemo

        public static void WebRequestDemo()
        {
            WebRequest request = WebRequest.Create("http://www.baidu.com");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            Console.WriteLine("响应信息，内容长度：{0}，类型:{1},Uri:{2}", response.ContentLength, response.ContentType, response.ResponseUri);
            using (StreamReader sr = new StreamReader(stream))
            {
                Console.Write(sr.ReadToEnd());
            }
        }

        #endregion 26-WebRequestDemo

        #region 27-DirectorySecurity

        public static void DirectorySecurityDemo()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ent0 = Dns.GetHostByAddress("10.101.42.77");
            IPHostEntry ent1 = Dns.GetHostEntry(hostEntry.HostName);
            IPHostEntry name = Dns.GetHostEntry("hry6464");
            string hostName = Dns.GetHostName();
            Console.Write("Provide full directory path: ");
            string mentionedDir = @"D:\";
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(mentionedDir);

                if (myDir.Exists)
                {
                    DirectorySecurity myDirSec = myDir.GetAccessControl();

                    foreach (FileSystemAccessRule fileRule in myDirSec.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        Console.WriteLine("{0} {1} {2} access for {3}", mentionedDir, fileRule.AccessControlType == AccessControlType.Allow ? "provides" : "denies", fileRule.FileSystemRights, fileRule.IdentityReference);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect directory provided!");
            }
        }

        #endregion 27-DirectorySecurity

        #region 28-字符串按指定长度分割

        public static void Demo31()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // intList.Find(m => m > 5)

            string longStr = @"标准通用标记语言下的一个应用HTML标准自1999年12月发布的HTML4.01后，后继的HTML5和其它标准被束之高阁，为了推动Web标准化运动的发展，一些公司联合起来，成立了一个叫做 Web Hypertext Application Technology Working Group （Web超文本应用技术工作组 -WHATWG） 的组织。WHATWG 致力于 Web 表单和应用程序，而W3C（World Wide Web Consortium，万维网联盟） 专注于XHTML2.0。在 2006 年，双方决定进行合作，来创建一个新版本的 HTML。";

            int count = (int)Math.Ceiling(longStr.Length / 100.0);
            string[] logStr = new string[count];

            for (int i = 0; i < count; i++)
            {
                if (i + 1 == count)
                {
                    logStr[i] = longStr.Substring(100 * i);
                }
                else
                {
                    logStr[i] = longStr.Substring(100 * i, 100);
                }
            }

            Console.WriteLine("原始");
            Console.WriteLine(longStr);
            Console.WriteLine("+++++++++++++++++++++++++++++++");
            foreach (string item in logStr)
            {
                Console.Write(item);
            }
        }

        #endregion 28-字符串按指定长度分割

        #region 29-AppDomain_AttachDb

        public static void Demo32()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            Console.WriteLine("请输入用户名：");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string password = Console.ReadLine();
            // admin 123456
            //  string ConStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\T_Test.mdf;Integrated Security=True;User Instance=True";
            string ConStr = @"Data Source=.;AttachDbFilename=|DataDirectory|\T_Test.mdf;uid=sa;pwd=sa";
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format("select * from T_Test Where UserName='{0}'", username);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            string dbpassword = read.GetString(read.GetOrdinal("Password"));
                            if (password == dbpassword)
                            {
                                Console.WriteLine("登陆成功");
                            }
                            else
                            {
                                Console.WriteLine("密码错误，登录失败");
                            }
                        }
                        else
                        {
                            Console.WriteLine("无此用户名！");
                        }
                    }
                }
            }
        }

        #endregion 29-AppDomain_AttachDb

        #region 30-反射获取方法名

        public static void GetMethodsDemo()
        {
            Type t = typeof(TestClass);

            MethodInfo[] m01 = t.GetMethods(BindingFlags.CreateInstance);
            MethodInfo[] m02 = t.GetMethods(BindingFlags.DeclaredOnly);
            MethodInfo[] m03 = t.GetMethods(BindingFlags.Default);
            MethodInfo[] m04 = t.GetMethods(BindingFlags.ExactBinding);
            MethodInfo[] m05 = t.GetMethods(BindingFlags.FlattenHierarchy);
            MethodInfo[] m06 = t.GetMethods(BindingFlags.GetField);
            MethodInfo[] m07 = t.GetMethods(BindingFlags.GetProperty);
            MethodInfo[] m08 = t.GetMethods(BindingFlags.IgnoreCase);
            MethodInfo[] m09 = t.GetMethods(BindingFlags.IgnoreReturn);
            MethodInfo[] m10 = t.GetMethods(BindingFlags.Instance);
            MethodInfo[] m11 = t.GetMethods(BindingFlags.InvokeMethod);
            MethodInfo[] m12 = t.GetMethods(BindingFlags.NonPublic);
            MethodInfo[] m13 = t.GetMethods(BindingFlags.OptionalParamBinding);
            MethodInfo[] m14 = t.GetMethods(BindingFlags.Public);
            MethodInfo[] m15 = t.GetMethods(BindingFlags.PutDispProperty);
            MethodInfo[] m16 = t.GetMethods(BindingFlags.PutRefDispProperty);
            MethodInfo[] m17 = t.GetMethods(BindingFlags.SetField);
            MethodInfo[] m18 = t.GetMethods(BindingFlags.SetProperty);
            MethodInfo[] m19 = t.GetMethods(BindingFlags.Static);
            MethodInfo[] m20 = t.GetMethods(BindingFlags.SuppressChangeType);
            MethodInfo[] m21 = t.GetMethods();

            MethodInfo[] m22 = t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (MethodInfo item in m22)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            MethodInfo[] m23 = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo item in m23)
            {
                Console.WriteLine(item.Name);
            }
            string methodName1 = MethodInfo.GetCurrentMethod().Name;
            string methodName2 = MethodBase.GetCurrentMethod().Name;
        }

        #endregion 30-反射获取方法名

        #region 31-HttpListenerDemo

        public static void HttpListenerDemo1()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:1231/");
            listener.Start();
            Console.WriteLine("Listening...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            listener.Stop();
        }

        public static void HttpListenerDemo2()
        {
            if (HttpListener.IsSupported)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://+:8080/");
                listener.Start();
                while (true)
                {
                    Console.Write(DateTime.Now.ToString());
                    HttpListenerContext context = listener.GetContext();
                    string page = context.Request.Url.LocalPath.Replace("/", "");
                    String query = context.Request.Url.Query.Replace("?", "");
                    StreamReader sr = new StreamReader(context.Request.InputStream);
                    Console.WriteLine(sr.ReadToEnd());
                    Console.WriteLine("接收到请求{0}{1}", page, query);
                    StreamWriter sw = new StreamWriter(context.Response.OutputStream);
                    sw.Write("Hello World!");
                    sw.Flush();
                    context.Response.Close();
                }
            }
        }

        #endregion 31-HttpListenerDemo

        #region 32-XmlSerializerDemo

        public static void XmlSerializerDemo()
        {
            RequestPlatform model = new RequestPlatform
            {
                CheckCode = "180014190010",
                Token = "H29G3-MZTKQ535-D7T95OAK-1PKOEV48",
                AplData = new AplDataPlatform
                {
                    Code = "01"
                }
            };

            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            XmlSerializer sz = new XmlSerializer(typeof(RequestPlatform));
            sz.Serialize(tw, model);
            tw.Close();
            Console.WriteLine(sb.ToString());
        }

        #endregion 32-XmlSerializerDemo

        #region Environment信息获取

        public static void EnvironmentDemo()
        {
            string commandLine = Environment.CommandLine;
            string currentDirectory = Environment.CurrentDirectory;
            int currentManagedThreadId = Environment.CurrentManagedThreadId;
            //int ecode = Environment.ExitCode;
            //Environment.Exit(ecode);
            string[] cas = Environment.GetCommandLineArgs();
            string ev = Environment.GetEnvironmentVariable("Path");
            Environment.GetLogicalDrives();
            bool is64 = Environment.Is64BitOperatingSystem;
            bool is64p = Environment.Is64BitProcess;
            string machineName = Environment.MachineName;
            string nl = Environment.NewLine;
            OperatingSystem osVersion = Environment.OSVersion;
            int processorCount = Environment.ProcessorCount;
            string systemDirectory = Environment.SystemDirectory;
            int systemPageSize = Environment.SystemPageSize;
            int tickCount = Environment.TickCount;
            string userDomainName = Environment.UserDomainName;
            string userName = Environment.UserName;
            Version v = Environment.Version;
            long workingSet = Environment.WorkingSet;
            string computerName = Environment.GetEnvironmentVariable("ComputerName");
        }

        #endregion Environment信息获取

        #region 获取注册表的建

        public static void RegistryDemo()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (rk != null)
            {
                String[] names = rk.GetSubKeyNames();
                foreach (string item in names)
                {
                    Console.WriteLine(item);
                }
            }
        }

        #endregion 获取注册表的建

        #region 获取电脑已安装软件

        public static void GetCurrentInstall()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; ; index++)
            {
                StringBuilder productCode = new StringBuilder(39);
                if (MsiEnumProducts(index, productCode) != 0)
                {
                    break;
                }

                foreach (string property in new string[] { "ProductName", "Publisher", "VersionString", })
                {
                    int charCount = 512;
                    StringBuilder value = new StringBuilder(charCount);

                    if (MsiGetProductInfo(productCode.ToString(), property, value, ref charCount) == 0)
                    {
                        value.Length = charCount;
                        result.AppendLine(value.ToString());
                    }
                }
                result.AppendLine();
            }
            Console.WriteLine(result.ToString());
        }

        #endregion 获取电脑已安装软件

        #region 下载相关

        public static void DownLoadDemo1()
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://img1.40017.cn/cn/s/yry/img/shouceV1.1.pdf");
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.pdf"));
        }

        public static void DownLoadDemo2()
        {
            HttpContext.Current.Response.WriteFile(@"H:\Workplace\WebApp\Image\示例图片abc12.jpg", true);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.jpg"));
        }

        #endregion 下载相关

        #region 反射系列

        public static void ReflectionClass1Demo()
        {
            #region Demo1 GetConstructors()

            ConstructorInfo[] p = typeof(ReflectionClass1).GetConstructors();
            Console.WriteLine(p.Length);

            foreach (ConstructorInfo t in p)
            {
                Console.WriteLine(t.IsStatic + "_" + t.DeclaringType);
                MethodBody mb = t.GetMethodBody();
            }

            #endregion Demo1 GetConstructors()

            ConstructorInfo[] p1 = typeof(ReflectionClass1).GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(p1.Length);

            foreach (ConstructorInfo t in p1)
            {
                Console.WriteLine(t.IsStatic);
            }
        }

        /// <summary>
        /// 使用反射获得类中所支持的方法，还有方法的信息。
        /// </summary>
        public static void ReflectionClass2Demo()
        {
            Type t = typeof(ReflectionClass2);   //获取描述MyClassA类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass2"

            MethodInfo[] mi = t.GetMethods();  //MethodInfo对象在System.Reflection命名空间下。
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        /// <summary>
        /// GetMethods(BindingFlags bindingAttr)这个方法，参数可以使用or把两个或更多标记连接在一起，
        /// 实际上至少要有Instance（或Static）与Public（或NonPublic）标记。否则将不会获取任何方法。
        /// </summary>
        public static void ReflectionClass3Demo()
        {
            /*
            DeclareOnly:仅获取指定类定义的方法，而不获取所继承的方法；
            Instance：获取实例方法
            NonPublic: 获取非公有方法
            Public： 获取共有方法
            Static：获取静态方法
            */
            Type t = typeof(ReflectionClass3);   //获取描述ConApp3类型的Type对象
            Console.WriteLine("Analyzing methods in " + t.Name);  //t.Name="ReflectionClass3"

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);  //不获取继承方法，为实例方法，为公开的
            foreach (MethodInfo m in mi) //遍历mi对象数组
            {
                Console.Write(m.ReturnType.Name); //返回方法的返回类型
                Console.Write(" " + m.Name + "("); //返回方法的名称

                ParameterInfo[] pi = m.GetParameters();  //获取方法参数列表并保存在ParameterInfo对象数组中
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name); //方法的参数类型名称
                    Console.Write(" " + pi[i].Name);  // 方法的参数名
                    if (i + 1 < pi.Length)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write(")");
                Console.WriteLine(); //换行
            }
        }

        public static void ReflectionClass4Demo()
        {
            Type t = typeof(ReflectionClass4);
            ReflectionClass4 reflectOb = new ReflectionClass4(10, 20);
            reflectOb.Show();  //输出为： x:10, y:20
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 10;
                    //参数reflectOb,为一个对象引用，将调用他所指向的对象上的方法，如果为静态方法这个参数必须设置为null
                    //参数args，为调用方法的参数数组，如果不需要参数为null
                    m.Invoke(reflectOb, args);   //调用MyClass类中的参数类型为int的Set方法，输出为Inside set(int,int).x:9, y:10
                }
            }
        }

        /// <summary>
        /// 反射获取构造函数并实例化
        /// </summary>
        public static void ReflectionClass5Demo()
        {
            /*
            在这之前的阐述中，由于Class类型的对象是都是显式创建的，
            因此使用反射技术调用Class类中的方法是没有任何优势的，
            还不如以普通方式调用方便简单呢。
            但是，如果对象是在运行时动态创建的，反射功能的优势就会显示出来。
            在这种情况下，要先获取一个构造函数列表，然后调用列表中的某个构造函数，创建一个该类型的实例。
            通过这种机制，可以在运行时实例化任意类型的对象，而不必在声明语句中指定类型。
            */
            Type t = typeof(ReflectionClass5);
            ConstructorInfo[] ci = t.GetConstructors(); //使用这个方法获取构造函数列表

            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters(); //获取当前构造函数的参数列表
                if (pi.Length == 2) break; //如果当前构造函数有2个参数，则跳出循环
            }

            if (x == ci.Length)
            {
                return;
            }

            object[] consargs = new object[2];
            consargs[0] = 10;
            consargs[1] = 20;
            object reflectOb = ci[x].Invoke(consargs); //实例化一个这个构造函数有两个参数的类型对象,如果参数为空，则为null
            ReflectionClass5 ac5 = reflectOb as ReflectionClass5;
            //实例化后，调用ConApp5中的方法
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (MethodInfo m in mi)
            {
                if (m.Name.Equals("sum", StringComparison.Ordinal))
                {
                    int val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine(@" sum is " + val); //输出 sum is 30
                }
            }
        }

        #endregion 反射系列

        #region 发送邮件

        public static void SendEmail()
        {
            SmtpClient client = new SmtpClient("smtp.163.com", 25)
            {
                Credentials = new NetworkCredential("13372171750@163.com", "mima")
            };
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("13372171750@163.com");
                msg.Subject = "Subject..........Greetings from Visual C# Recipes";
                msg.Body = "Body.................This is a message from Recipe 10-07 of";
                msg.Attachments.Add(new Attachment(@"ConsoleOutput.txt", "text/plain"));
                msg.Attachments.Add(new Attachment(@"ConApp.exe", "application/octet-stream"));
                msg.To.Add(new MailAddress("807776962@qq.com"));

                client.Send(msg);
            }
            Console.WriteLine("发送成功");
        }

        #endregion 发送邮件

        #region 控制台文本输出

        public static void StreamWriterSetOut()
        {
            StreamWriter sw = new StreamWriter(@"ConsoleOutput.txt");
            Console.SetOut(sw);

            Console.WriteLine("Here is the result:");
            Console.WriteLine("Processing......");
            Console.WriteLine("OK!");

            sw.Flush();
            sw.Close();

            //控制台输出重定向: > F:\Test\ConsoleOutput.txt
        }

        #endregion 控制台文本输出

        public async static void AsyncTest()
        {
            using (StreamWriter writer = File.CreateText("ConsoleOutput.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }

        public static void ValidateAttribute()
        {
            Person person = new Person { Name = "TT", Age = 20 };
            Type type = person.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Age");
            ValidateAgeAttribute validateAgeAttribute = (ValidateAgeAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ValidateAgeAttribute));
            Console.WriteLine("允许的最大年龄：" + validateAgeAttribute.MaxAge);
            validateAgeAttribute.Validate(person.Age);
            Console.WriteLine(validateAgeAttribute.ValidateResult);
        }

        public static void FontImage()
        {
            //设置画布字体
            Font drawFont = new Font("宋体", 12);
            //实例一个画布起始位置为1.1
            Bitmap image = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(image);
            //string text = File.ReadAllText("D:\\xx.html", Encoding.GetEncoding("GB2312"));
            string text = "互联网出版许可证编号新出网证(京)";
            SizeF sf = g.MeasureString(text, drawFont, 1024); //设置一个显示的宽度
            image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(text, drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            image.Save("D:\\1.jpg", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            image.Dispose();
        }

        public static void DataTableDemo1()
        {
            //DataTable table = new DataTable();
            //table.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn("Resource_Id"),
            //    new DataColumn("TA"),
            //    new DataColumn("TB"),
            //    new DataColumn("TC"),
            //    new DataColumn("TD")
            //});
            //table.Rows.Add(1, 1, 2, 0, 0);
            //table.Rows.Add(1, 3, 0, 3, 4);
            //table.Rows.Add(2, 5, 6, 0, 0);
            //table.Rows.Add(2, 7, 0, 7, 8);

            //var aa = from t in table.AsEnumerable()
            //         group t by new { t1 = t.Field<string>("Resource_Id") } into m
            //         select new
            //         {
            //             name = m.Key.t1,
            //             score = m.Sum(n => n.Field<decimal>("TA"))
            //         };
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("name", typeof(string)),
                new DataColumn("sex", typeof(string)),
                new DataColumn("score", typeof(int))
            });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            DataTable dtResult = dt.Clone();
            DataTable dtName = dt.DefaultView.ToTable(true, "name", "sex");
            for (int i = 0; i < dtName.Rows.Count; i++)
            {
                DataRow[] rows = dt.Select("name='" + dtName.Rows[i]["name"] + "' and sex='" + dtName.Rows[i]["sex"] + "'");
                //temp用来存储筛选出来的数据
                DataTable temp = dtResult.Clone();
                foreach (DataRow row in rows)
                {
                    temp.Rows.Add(row.ItemArray);
                }

                DataRow dr = dtResult.NewRow();
                dr[0] = dtName.Rows[i][0].ToString();
                dr[1] = temp.Compute("sum(score)", "");
                dtResult.Rows.Add(dr);
            }
        }

        public static void DataTableDemo2()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("name", typeof(string)),
                                         new DataColumn("sex", typeof(string)),
                                         new DataColumn("score", typeof(decimal)) });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            var query = from t in dt.AsEnumerable()
                        group t by new { t1 = t.Field<string>("name"), t2 = t.Field<string>("sex") } into m
                        select new
                        {
                            name = m.Key.t1,
                            sex = m.Key.t2,
                            score = m.Sum(n => n.Field<decimal>("score"))
                        };
            if (query.ToList().Count > 0)
            {
                query.ToList().ForEach(q =>
                {
                    Console.WriteLine(q.name + "," + q.sex + "," + q.score);
                });
            }
        }

        public static void DynamicTest()
        {
            dynamic d = new DynamicClass();
            d.X = 123;
            d.Y = "123";
            //d.Z = 123.456; 未包含Z的定义
            Console.WriteLine(d.Test(123));
            Console.WriteLine(d.Test("123"));
            Console.WriteLine(d.Test(123.456));
        }

        [DllImport("msi.dll", SetLastError = true)]
        private static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);

        [DllImport("msi.dll", SetLastError = true)]
        private static extern int MsiGetProductInfo(string szProduct, string szProperty, StringBuilder lpValueBuf, ref int pcchValueBuf);
    }
}