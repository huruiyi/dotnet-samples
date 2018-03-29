using ConApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;

namespace ConApp
{
    public partial class Program
    {
        public static unsafe void Main(string[] args)
        {
            ThreadDemo.DeadDemo2();
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

        #region foreach原理

        public static void Cus_foreach()
        {
            MyCollection1 myCol = new MyCollection1();
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

        #endregion foreach原理

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

        public static void PerformanceCounterDemo()
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

        #region 自定义扩展方法

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

        #endregion 自定义扩展方法

        #region ExcuteXCopyCmd

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

            Process compiler = new Process();
            compiler.StartInfo.FileName = "csc.exe";
            compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            compiler.WaitForExit();
        }

        #endregion ExcuteXCopyCmd

        #region 属性相关

        public static void PropertyInfoDemo()
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

        #endregion 属性相关

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

        #region YieldDemo

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

        #endregion YieldDemo

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

        #region 硬盘信息查询

        public static void GetDriverInfo()
        {
            DriveInfo[] alldrive = DriveInfo.GetDrives();
            foreach (DriveInfo item in alldrive)
            {
                Console.WriteLine("驱动器:{0}", item.Name);
                Console.WriteLine(" 类型:{0}", item.DriveType);
                if (item.IsReady)
                {
                    Console.WriteLine(" 卷标:{0}", item.VolumeLabel);
                    Console.WriteLine(" 文件系统:{0}", item.DriveFormat);
                    Console.WriteLine(" 当前用户可用空间:{0,15}字节", item.AvailableFreeSpace);
                    Console.WriteLine(" 可用空间        :{0,15}字节", item.TotalFreeSpace);
                    Console.WriteLine(" 磁盘总大小:     :{0,15}字节", item.TotalSize);
                }
                Console.ReadKey();
            }
        }

        #endregion 硬盘信息查询

        #region 字符串按指定长度分割

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

        #endregion 字符串按指定长度分割

        #region 反转字符串

        public static string ReverseDemo(string str)
        {
            //反转字符串
            char[] arr = str.ToCharArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            //string s = new string(arr);
            return string.Join("", arr);
        }

        #endregion 反转字符串

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

        #endregion AppDomain_AttachDb

        #region 反射获取方法名

        public static void GetMethodsDemo()
        {
            Type t = typeof(ClassDemo);

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

        #endregion 反射获取方法名

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

        #region 差集交集并集

        public static void PrintIntList(IEnumerable<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item.ToString().PadLeft(2, '0') + "\t");
            }
            Console.WriteLine();
        }

        public static void PrintIntList(List<int> list1, List<int> list2)
        {
            Console.Write("list1:");
            PrintIntList(list1);

            Console.WriteLine();
            PrintIntList(list1);
            Console.WriteLine();
        }

        public static void ExceptIntersectUnion()
        {
            List<int> list1 = new List<int>();
            list1.Add(10);
            list1.Add(1);
            list1.Add(4);
            list1.Add(5);
            list1.Add(8);
            list1.Sort();

            List<int> list2 = new List<int>();
            list2.Add(1);
            list2.Add(28);
            list2.Add(4);
            list2.Add(8);
            list2.Add(18);
            list2.Sort();

            PrintIntList(list1, list2);
            Console.WriteLine("+++++++++++++++++++差集+++++++++++++++++++");
            IEnumerable<int> nList1 = list1.Except(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Except(list2)");
            PrintIntList(nList1);

            IEnumerable<int> nList2 = list2.Except(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Except(list1)");
            PrintIntList(nList2);

            Console.WriteLine("+++++++++++++++++++交集+++++++++++++++++++");
            IEnumerable<int> nList3 = list1.Intersect(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Intersect(list2)");
            PrintIntList(nList3);

            IEnumerable<int> nList4 = list2.Intersect(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Intersect(list1)");
            PrintIntList(nList4);

            Console.WriteLine("+++++++++++++++++++并集+++++++++++++++++++");
            IEnumerable<int> nList5 = list2.Union(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Union(list1)");
            PrintIntList(nList5);

            IEnumerable<int> nList6 = list1.Union(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Union(list2)");
            PrintIntList(nList6);
        }

        #endregion 差集交集并集

        #region 特性相关

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

        #endregion 特性相关

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
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ConfigurationFile = Environment.CurrentDirectory + "ADSetup.exe.config";
            domaininfo.ApplicationBase = Environment.CurrentDirectory;

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

            //我们自己写一个AppDomain
            // 设置应用程序域
            AppDomainSetup appDomainSetup = new AppDomainSetup();

            //设置程序集不共享
            appDomainSetup.LoaderOptimization = LoaderOptimization.SingleDomain;

            // 主应用程序域创建 程序域
            AppDomain appDomain = AppDomain.CreateDomain("MultThread", null, appDomainSetup);
            // 程序域  执行exe
            // 每个应用程序域  只能执行一个exe，但是可以加载多个 dll
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
                    arr[i] = string.Format("{0} {1}", array[0] + array[1], array[2]);
                }
                else
                {
                    arr[i] = null;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!string.IsNullOrEmpty(arr[i]))
                {
                    Console.WriteLine(arr[i]);
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

        #region PowerShell命令

        public static void RunPowerShellCmd()
        {
            /*
             using System.Management.Automation;
             using System.Management.Automation.Runspaces;
             */
            // code from 1-code.codeprojet.com
            // Create a RunSpace to host the Powershell script enviroment
            // using RunspaceFactory.CreateRunSpace
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            // Create a Pipeline to host commands to be executed using
            // Runspace.CreatePipeline
            Pipeline pipeLine = runSpace.CreatePipeline();

            // Create a Command object by passing the command to the constructor
            Command getProcessCStarted = new Command("Get-Process");

            // Add parameters to the Command.
            getProcessCStarted.Parameters.Add("name", "C*");

            // Add the commands to the Pipeline
            pipeLine.Commands.Add(getProcessCStarted);

            // Run all commands in the current pipeline by calling Pipeline.Invoke.
            // It returns a System.Collections.ObjectModel.Collection object.
            // In this example, the executed script is "Get-Process -name C*".
            Collection<PSObject> cNameProcesses = pipeLine.Invoke();

            foreach (PSObject psObject in cNameProcesses)
            {
                Process process = psObject.BaseObject as Process;
                Console.WriteLine("Process Name: {0}", process.ProcessName);
            }
        }

        #endregion PowerShell命令

        public async static void AsyncDemo()
        {
            using (StreamWriter writer = File.CreateText("ConsoleOutput.txt"))
            {
                await writer.WriteLineAsync("First line of example");
                await writer.WriteLineAsync("and second line");
            }
        }

        public static void PathDemo()
        {
            AppDomainSetup app1 = AppDomain.CurrentDomain.SetupInformation;
            string entryAssemblyLocation = Assembly.GetEntryAssembly().Location;

            string str1 = Process.GetCurrentProcess().MainModule.FileName;              //可获得当前执行的exe的文件名。
            string str2 = Environment.CurrentDirectory;                                 //获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。(备注:按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠（如“C:\”）。如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径[如“C:\mySubDirectory”])。
            string str3 = Directory.GetCurrentDirectory();                              //获取应用程序的当前工作目录。
            string str4 = System.Windows.Forms.Application.StartupPath;                 //获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
            string str5 = System.Windows.Forms.Application.ExecutablePath;              //获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
            string str6 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;     //获取或设置包含该应用程序的目录的名称。
            string str7 = AppDomain.CurrentDomain.BaseDirectory;                        //获取基目录，它由程序集冲突解决程序用来探测程序集。
            string str8 = AppDomain.CurrentDomain.FriendlyName;

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string codeBase = executingAssembly.CodeBase;
            string location = executingAssembly.Location;

            string executingName = Assembly.GetExecutingAssembly().GetName().Name;//运行程序的名称
        }

        public static void MathDemo()
        {
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

        public void BulidMethod()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);
            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWord", MethodAttributes.Public, null, new Type[] { typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "Hello：{0}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string) }));

            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWord");
            mdi.Invoke(ob, new object[] { "Hello Lind" });
        }

        public void BulidMethodRet()
        {
            //得到当前的应用程序域
            AppDomain appDm = AppDomain.CurrentDomain;
            //初始化AssemblyName的一个实例
            AssemblyName an = new AssemblyName();
            //设置程序集的名称
            an.Name = "EmitLind";
            //动态的在当前应用程序域创建一个应用程序集
            AssemblyBuilder ab = appDm.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            //动态在程序集内创建一个模块
            ModuleBuilder mb = ab.DefineDynamicModule("EmitLind");
            //动态的在模块内创建一个类
            TypeBuilder tb = mb.DefineType("HelloEmit", TypeAttributes.Public | TypeAttributes.Class);

            //动态的为类里创建一个方法
            MethodBuilder mdb = tb.DefineMethod("HelloWorldReturn", MethodAttributes.Public, typeof(string), new Type[] { typeof(string), typeof(string) });

            //得到该方法的ILGenerator
            ILGenerator ilG = mdb.GetILGenerator();
            ilG.Emit(OpCodes.Ldstr, "你好：{0}-{1}");
            //加载传入方法的参数到堆栈
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Ldarg_2);
            //调用Console.WriteLine方法，输出传入的字符
            ilG.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string), typeof(string), typeof(string) }));

            // ilG.Emit(OpCodes.Pop);//加这个就有问题了
            //返回值部分
            LocalBuilder local = ilG.DeclareLocal(typeof(string));
            ilG.Emit(OpCodes.Ldstr, "Return Value：{0}");
            ilG.Emit(OpCodes.Ldarg_1);
            ilG.Emit(OpCodes.Call, typeof(string).GetMethod("Format", new Type[] { typeof(string), typeof(string) }));
            ilG.Emit(OpCodes.Stloc_0, local);
            ilG.Emit(OpCodes.Ldloc_0, local);
            ilG.Emit(OpCodes.Ret);
            //创建类的Type对象
            Type tp = tb.CreateType();
            //实例化一个类
            object ob = Activator.CreateInstance(tp);
            //得到类中的方法，通过Invoke来触发方法的调用..
            MethodInfo mdi = tp.GetMethod("HelloWorldReturn");
            mdi.Invoke(ob, new object[] { "Hello Lind", "OK" });
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

        public static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            Type specificType = generic.MakeGenericType(new Type[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }

        public static void CreateGenericDemo()
        {
            object genericList = CreateGeneric(typeof(List<>), typeof(Person));
            var orderList = genericList as List<Person>;
        }

        public static void StackDemo()
        {
            Stack stack = new Stack();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            stack.Push("e");
            stack.Push("f");
            stack.Push("g");
            stack.Push("h");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);
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

        public static void StackTraceDemo()
        {
            StackTrace stackTrace = new StackTrace();
            int frameCount = stackTrace.FrameCount;
            Console.WriteLine("堆栈跟踪中的帧数:" + frameCount);
            foreach (var item in stackTrace.GetFrames())
            {
                Console.WriteLine(item);
                Console.WriteLine(item.GetFileColumnNumber());
                Console.WriteLine(item.GetFileLineNumber());
                Console.WriteLine("FileName:" + item.GetFileName());
                Console.WriteLine(item.GetHashCode());
                Console.WriteLine(item.GetILOffset());
                Console.WriteLine(item.GetMethod());
                Console.WriteLine(item.GetNativeOffset());
            }
        }

        public static void Json()
        {
            string fff = @"{""kf_list"":[{""kf_account"":""1005@sayyas1998"",""kf_headimgurl"":""http:\/\/ mmbiz.qpic.cn\/ mmbiz\/ oSJVrqYTJPAOvCp0Hg2ia6OhK03NlhClbT94UpcG4R9y1qTwH5ibGqaIJR8jJS0sxK8REGQZStg7AGZFEibz7PoOA\/ 300 ? wx_fmt = png"",""kf_id"":1002,""kf_nick"":""管家"",""kf_wx"":""sayyashome2""},{""kf_account"":""kf2003 @sayyas1998"",""kf_headimgurl"":""http:\/\/ mmbiz.qpic.cn\/ mmbiz\/ oSJVrqYTJPAOHjaQcOU9JBjibZrdYgeD8CYdMxcB9onxXJaIU1NZIvSOGIPMg3nzrhMbPdiarrRH6H3fwAA9OHHg\/ 300 ? wx_fmt = jpeg"",""kf_id"":2003,""kf_nick"":""管家"",""kf_wx"":""zhanghanqi0451""}]}";
            //反序列化JSON
            JObject jo = (JObject)JsonConvert.DeserializeObject(fff);
            //获取值
            var data = jo["kf_list"]; ;
            //json数组
            JArray jar = JArray.Parse(jo["kf_list"].ToString());
            for (int i = 0; i < jar.Count; i++)
            {
                var info = jar[i];
            }
            //非数组使用
            JObject j = JObject.Parse(jar[0].ToString());
            string st = j["kf_account"].ToString();

            //解析json数组
            var twitterObject = JToken.Parse(fff);
            //获取json需要的数据
            var trendsArray = twitterObject.Children<JProperty>().FirstOrDefault(x => x.Name == "kf_list").Value;

            foreach (var item in trendsArray.Children())
            {
                var itemProperties = item.Children<JProperty>();
                //根据key取值
                var myElement = itemProperties.FirstOrDefault(x => x.Name == "kf_account").Value;
            }
        }
    }

    public class Descartes
    {
        public static void run(List<List<string>> dimvalue, List<string> result, int layer, string curstring)
        {
            if (layer < dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                {
                    run(dimvalue, result, layer + 1, curstring);
                }
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        StringBuilder s1 = new StringBuilder();
                        s1.Append(curstring);
                        s1.Append(dimvalue[layer][i]);
                        run(dimvalue, result, layer + 1, s1.ToString());
                    }
                }
            }
            else if (layer == dimvalue.Count - 1)
            {
                if (dimvalue[layer].Count == 0)
                {
                    result.Add(curstring);
                }
                else
                {
                    for (int i = 0; i < dimvalue[layer].Count; i++)
                    {
                        result.Add(curstring + dimvalue[layer][i]);
                    }
                }
            }
        }
    }
}