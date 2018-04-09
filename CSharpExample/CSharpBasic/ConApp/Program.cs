using ConApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace ConApp
{
    public partial class Program
    {
        public static unsafe void Main(string[] args)
        {
            ParallelDemo.Demo2();
            //Mutex
            //Marshal.
            Console.ReadKey();
        }

        public static void Other()
        {
            Hash hash = Hash.CreateMD5(Encoding.UTF8.GetBytes("ABCDEFG"));
            //Hash.CreateSHA1()
            //Hash.CreateSHA1()
            //Hash.CreateSHA256()
            Byte[] bytes = hash.MD5;
            string str = Encoding.UTF8.GetString(bytes);
        }

        #region EventDemo

        public static int WriteLetter(string letter)
        {
            Console.Write(letter + " ");
            return 1;
        }

        public static void ExampleMethod(int a, int b, int c)
        {
            Console.WriteLine("ExampleMethod(int a, int b, int c)");
        }

        public static void ExampleMethod(string p1 = null, object p2 = null)
        {
            Console.WriteLine(@"ExampleMethod: p2 is object");
        }

        public static void ExampleMethod(string p2 = null, object p1 = null, params int[] p3)
        {
            Console.WriteLine(@"ExampleMethod: p2 is string");
        }

        public static void publisher_SampleEvent(object sender, SampleEventArgs e)
        {
            Console.WriteLine("e.Text:" + e.Text);
        }

        public static void EventDemo1()
        {
            ExampleMethod(p2: "");
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            ExampleMethod(WriteLetter("A"), b: WriteLetter("B"), c: WriteLetter("C"));
            ExampleMethod(WriteLetter("A"), c: WriteLetter("C"), b: WriteLetter("B"));
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            var methods = new List<Action>();
            foreach (var word in new string[] { "hello", "world" })
            {
                methods.Add(() => Console.Write(word + " "));
            }

            methods[0]();
            methods[1]();
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

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
                {
                    Console.Write(entry + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

            Model.Publisher publisher = new Model.Publisher();

            publisher.SampleEvent += publisher_SampleEvent;
        }

        #endregion EventDemo

        #region PerformanceCounter

        public static void PerformanceCounterDemo1()
        {
            List<PerformanceCounter> counters = new List<PerformanceCounter>();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }

            int i = 0;

            //Thread.Sleep(1000);

            //格式化输出
            //Console.WriteLine("{0,-7}{1,-24}{2,-6}", "Method", "X-HTTP-Method-Override", "Action");

            foreach (PerformanceCounter counter in counters)
            {
                Console.WriteLine(processes[i].ProcessName + " | CPU% " + (Math.Round(counter.NextValue(), 1)));
                ++i;
            }
        }

        public static void PerformanceCounterDemo2()
        {
            Console.Title = ("Simple CPU Monitor");
            Console.ForegroundColor = ConsoleColor.Green;
            PerformanceCounter perfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                Thread.Sleep(1000);
                Console.Beep();
                Console.WriteLine("CPU Load: {0}%", perfCounter.NextValue());
            }
        }

        #endregion PerformanceCounter

        #region ProcessDemo

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

        #endregion ProcessDemo

        #region ExcuteXCopyCmd

        public static void ExcuteXCopyCmdDemo()
        {
            string sCmd = @"copy D:\a.txt D:\b.txt";
            Process proIP = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            proIP.Start();
            proIP.StandardInput.WriteLine(sCmd);
            proIP.StandardInput.WriteLine("exit");
            string strResult = proIP.StandardOutput.ReadToEnd();
            proIP.Close();
            Console.WriteLine(strResult);

            Process compiler = new Process
            {
                StartInfo =
                {
                    FileName = "csc.exe",
                    Arguments = "/r:System.dll /out:sample.exe stdstr.cs",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            compiler.Start();
            Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            compiler.WaitForExit();
        }

        #endregion ExcuteXCopyCmd

        #region HashtableDemo

        public static void HashtableDemo()
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
        }

        #endregion HashtableDemo

        #region GetEnumeratorDemo

        public static void GetEnumeratorDemo()
        {
            ArrayList arr = new ArrayList() { 12, 13, 1, 4, 15, 16, 17 };
            IEnumerator iEnumerator = arr.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                Console.WriteLine(iEnumerator.Current);
            }
        }

        #endregion GetEnumeratorDemo

        #region WeakReferenceDemo

        public static void WeakRefenceDemo()
        {
            WeakReference mathReference = new WeakReference(new MathDemo());
            MathDemo math;
            if (mathReference.IsAlive)
            {
                math = mathReference.Target as MathDemo;
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
                math = mathReference.Target as MathDemo;
            }
            else
            {
                Console.WriteLine(@"Reference is not available.");
            }
        }

        #endregion WeakReferenceDemo

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

        #region AppDomain_AttachDb

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
                    cmd.CommandText = $"select * from T_Test Where UserName='{username}'";
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            string dbpassword = read.GetString(read.GetOrdinal("Password"));
                            Console.WriteLine(password == dbpassword ? "登陆成功" : "密码错误，登录失败");
                        }
                        else
                        {
                            Console.WriteLine("无此用户名！");
                        }
                    }
                }
            }
        }

        #endregion AppDomain_AttachDb

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

            //控制台输出重定向: > F:\ConsoleOutput.txt
        }

        #endregion 控制台文本输出

        #region TupleDemo

        public static List<Tuple<int, List<string>>> CreateTule()
        {
            List<Tuple<int, List<string>>> tuplerList = new List<Tuple<int, List<string>>>();
            Tuple<int, List<string>> tuples1 = Tuple.Create(1, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples2 = Tuple.Create(2, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples3 = Tuple.Create(3, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples4 = Tuple.Create(4, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples5 = Tuple.Create(5, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples6 = Tuple.Create(6, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples7 = Tuple.Create(7, new List<string> { "xxxxxxx", "ccccccccc" });
            tuplerList.AddRange(new[] { tuples1, tuples2, tuples3, tuples4, tuples5, tuples6, tuples7 });
            return tuplerList;
        }

        public static void TupleDemo()
        {
            List<Tuple<int, List<string>>> vs = CreateTule();
            foreach (Tuple<int, List<string>> tuple in vs)
            {
                if (tuple.Item1 == 5)
                {
                    foreach (string s in tuple.Item2)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }

        #endregion TupleDemo

        #region 文件生成

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

        #endregion 文件生成

        #region 异步委托

        public delegate void AsycRun();

        public static void AsyncCallbackDemo()
        {
            AsyncCallback ac = delegate (IAsyncResult aar)
            {
                Console.WriteLine("跑完了");
                Console.WriteLine(aar.AsyncState);
            };

            AsycRun ar = delegate
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write(i + "\t");
                }
            };
            ar.BeginInvoke(ac, "object");
        }

        #endregion 异步委托

        #region 应用程序域

        public static void AppDomainDemo1()
        {
            AppDomain.CurrentDomain.SetData("name", "Hello");
            string name = AppDomain.CurrentDomain.GetData("name").ToString();
            Console.WriteLine(name);

            // Create application domain setup information
            AppDomainSetup domaininfo = new AppDomainSetup
            {
                ConfigurationFile = Environment.CurrentDirectory + "ADSetup.exe.config",
                ApplicationBase = Environment.CurrentDirectory
            };

            //Create evidence for the new appdomain from evidence of the current application domain
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;

            // Create appdomain
            AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

            // Write out application domain information
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("child domain: " + domain.FriendlyName);
            Console.WriteLine();
            Console.WriteLine("Configuration file is: " + domain.SetupInformation.ConfigurationFile);
            Console.WriteLine("Application Base Directory is: " + domain.BaseDirectory);

            AppDomain.Unload(domain);
        }

        public static void AppDomainDemo2()
        {
            // AppDomain.Unload(AppDomain.CurrentDomain);

            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                Console.WriteLine("hellp");
            }

            AppDomainSetup appDomainSetup = new AppDomainSetup { LoaderOptimization = LoaderOptimization.SingleDomain };
            AppDomain appDomain = AppDomain.CreateDomain("MultThread", null, appDomainSetup);
            appDomain.ExecuteAssembly("ConApp.exe");
        }

        #endregion 应用程序域

        #region 把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本

        public static void ReadAllLinesDemo()
        {
            // 姓名：张三 电话：15001111113

            string[] lines = File.ReadAllLines("1.csv", Encoding.Default);

            string[] arr = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string tmp = lines[i].Replace("\"", "");
                string[] array = tmp.Split(',');
                if (array.Length == 3)
                {
                    arr[i] = $"{array[0] + array[1]} {array[2]}";
                }
                else
                {
                    arr[i] = null;
                }
            }

            foreach (var t in arr)
            {
                if (!string.IsNullOrEmpty(t))
                {
                    Console.WriteLine(t);
                }
            }
        }

        #endregion 把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本

        #region 简单泛型

        public static void GenericDemo<T>(T s, T t) where T : class
        {
            Console.WriteLine(s == t);
        }

        public static void GenericDemo()
        {
            string s1 = "target";
            StringBuilder sb = new StringBuilder("target");
            string s2 = sb.ToString();
            GenericDemo(s1, s2);

            CreateInstance<Person>(5);
            Person b = CreateBossInstance<Person>(3);
            b.Name = "Wb";
        }

        public static T CreateInstance<T>(int n) where T : new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        public static T CreateBossInstance<T>(int n) where T : Person, new()
        {
            T t = default(T);
            for (int i = 0; i < n; i++)
            {
                t = new T();
            }
            return t;
        }

        #endregion 简单泛型

        public async static void AsyncDemo()
        {
            using (StreamWriter writer = File.CreateText("ConsoleOutput.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }

        public static void MathDemo()
        {
            List<int> ids = new List<int>();
            ids.AddRange(new List<int> { 1, 2, 3, 4 });
            ids.AddRange(new List<int> { 5, 6, 7, 8 });
            ids.AddRange(new List<int> { 9, 10, 11, 12 });

            int idg = Convert.ToInt32(Math.Ceiling(ids.Count / 5.0));

            List<int> sInts;
            for (int i = 1; i <= idg; i++)
            {
                sInts = new List<int>();
                sInts.AddRange(ids.Skip((i - 1) * 5).Take(5));

                string jboNumbers = sInts.Aggregate(string.Empty, (current, item) => current + (item + ",")).TrimEnd(',');

                Console.WriteLine(jboNumbers);
            }
        }

        public static void DynamicDemo0()
        {
            dynamic d = new DynamicClass();
            d.X = 123;
            d.Y = "123";
            //d.Z = 123.456; 未包含Z的定义
            Console.WriteLine(d.Return(123));
            Console.WriteLine(d.Return("123"));
            Console.WriteLine(d.Return(123.456));
        }

        public static void DynamicDemo1()
        {
            dynamic calc = Calculator.GetCalculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        public static void StaticDemo()
        {
            var calc = new Calculator();
            int r = calc.Add(2, 3);
            Console.WriteLine(r);
        }

        public static void PropertyInfoDemo()
        {
            Dictionary<int, string> attrs = new Dictionary<int, string> { { 1, "1" } };
            var person = new Person
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
                Hobbys = new[] { "h1", "h2", "h3", "h4" }
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
                if (p.PropertyType.IsGenericType)
                {
                    p.SetValue(person, new List<Equip>
                    {
                        new Equip {Name = "N1111", AttackValue = 123},
                        new Equip {Name = "N2222", AttackValue = 123},
                        new Equip {Name = "N3333", AttackValue = 123},
                    });
                }
            }
        }

        public static void ReflectDemo()
        {
            Person p1 = new Person
            {
                Name = "p1",

                Equips = new List<Equip>
                {
                 new Equip {AttackValue=1,Name="0N1"  },
                 new Equip {AttackValue=2,Name="0N2"  },
                 new Equip {AttackValue=3,Name="0N3"  }
                }
            };

            Type t1 = p1.GetType();
            PropertyInfo[] pi1 = t1.GetProperties();

            var type = pi1[2].PropertyType.IsGenericType;

            var p2type = pi1[2].PropertyType;

            var tyep = typeof(List<Person>);
        }

        public static void GetPortNamesDemo()
        {
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
        }
    }
}
