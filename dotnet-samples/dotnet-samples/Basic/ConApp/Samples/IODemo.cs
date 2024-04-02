using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ConApp
{
    public class IODemo
    {
        public static class DocTreeHelper
        {
            /// <summary>
            /// 输出目录结构树
            /// </summary>
            /// <param name="dirpath">被检查目录</param>
            public static void PrintTree(string dirpath)
            {
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
                if (!Directory.Exists(dirpath))
                {
                    throw new Exception("文件夹不存在");
                }

                PrintDirectory(dirpath, 0, "");
            }

            /// <summary>
            /// 将目录结构树输出到指定文件
            /// </summary>
            /// <param name="dirpath">被检查目录</param>
            /// <param name="outputpath">输出到的文件</param>
            public static void PrintTree(string dirpath, string outputpath)
            {
                if (!Directory.Exists(dirpath))
                {
                    throw new Exception("文件夹不存在");
                }

                //将输出流定向到文件 outputpath
                StringWriter swOutput = new StringWriter();
                Console.SetOut(swOutput);

                PrintDirectory(dirpath, 0, "");

                //将输出流输出到文件 outputpath
                File.WriteAllText(outputpath, swOutput.ToString());

                //将输出流重新定位回文件 outputpath
                StreamWriter swConsole =
                    new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding) { AutoFlush = true };
                Console.SetOut(swConsole);
            }

            /// <summary>
            /// 打印目录结构
            /// </summary>
            /// <param name="dirpath">目录</param>
            /// <param name="depth">深度</param>
            /// <param name="prefix">前缀</param>
            private static void PrintDirectory(string dirpath, int depth, string prefix)
            {
                DirectoryInfo dif = new DirectoryInfo(dirpath);

                //打印当前目录
                if (depth == 0)
                {
                    Console.WriteLine(prefix + dif.Name);
                }
                else
                {
                    Console.WriteLine(prefix.Substring(0, prefix.Length - 2) + "| ");
                    Console.WriteLine(prefix.Substring(0, prefix.Length - 2) + "|-" + dif.Name);
                }

                //打印目录下的目录信息
                for (int counter = 0; counter < dif.GetDirectories().Length; counter++)
                {
                    DirectoryInfo di = dif.GetDirectories()[counter];
                    if (counter != dif.GetDirectories().Length - 1 ||
                        dif.GetFiles().Length != 0)
                    {
                        PrintDirectory(di.FullName, depth + 1, prefix + "| ");
                    }
                    else
                    {
                        PrintDirectory(di.FullName, depth + 1, prefix + "  ");
                    }
                }

                //打印目录下的文件信息
                for (int counter = 0; counter < dif.GetFiles().Length; counter++)
                {
                    FileInfo f = dif.GetFiles()[counter];
                    if (counter == 0)
                    {
                        Console.WriteLine(prefix + "|");
                    }
                    Console.WriteLine(prefix + "|-" + f.Name);
                }
            }

            public static void DocTreeHelperTest()
            {
                string dirpath = @"D:\Software";
                string outputpath = @"output.txt";

                PrintTree(dirpath);
                PrintTree(dirpath, outputpath);

                Console.WriteLine("Output Finished");
                Console.WriteLine("输出完毕");
            }
        }

        public static class DeleteFile
        {
            /// <summary>
            /// 找全部文件
            /// </summary>
            public static void RecursionShow()
            {
                Console.WriteLine("请输入要删除的目录:");
                string s = Console.ReadLine();
                string rootPath = $@"{s}";
                DirectoryInfo dirRoot = new DirectoryInfo(rootPath);
                List<FileInfo> fileInfoList = new List<FileInfo>();
                fileInfoList = GetFileByDir(dirRoot, fileInfoList);
                Directory.Delete(rootPath, true);
            }

            /// </summary>
            /// <param name="dirParent">父目录</param>
            /// <param name="fileInfoList">文件集</param>
            /// <returns></returns>
            private static List<FileInfo> GetFileByDir(DirectoryInfo dirParent, List<FileInfo> fileInfoList)
            {
                FileInfo[] fileArray = dirParent.GetFiles();//找出子文件

                if (fileArray != null && fileArray.Length > 0)
                {
                    fileInfoList.AddRange(fileArray.ToList());//放入集合
                    foreach (FileInfo fi in fileArray)
                    {
                        File.Delete(fi.FullName);
                    }
                }
                DirectoryInfo[] dirArray = dirParent.GetDirectories();//找子文件夹
                if (dirArray != null && dirArray.Length > 0)
                {
                    foreach (DirectoryInfo dir in dirArray)//遍历子文件夹
                    {
                        GetFileByDir(dir, fileInfoList);//每个文件夹  再去找子文件和子文件夹
                    }
                }

                return fileInfoList;
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

            string executingName = Assembly.GetExecutingAssembly().GetName().Name;      //运行程序的名称
        }

        public static void GetDriverInfo()
        {
            DriveInfo[] alldrive = DriveInfo.GetDrives();
            foreach (DriveInfo item in alldrive)
            {
                Console.WriteLine(@"驱动器:{0}", item.Name);
                Console.WriteLine(@" 类型:{0}", item.DriveType);
                if (item.IsReady)
                {
                    Console.WriteLine(@" 卷标:{0}", item.VolumeLabel);
                    Console.WriteLine(@" 文件系统:{0}", item.DriveFormat);
                    Console.WriteLine(@" 当前用户可用空间:{0,15}字节", item.AvailableFreeSpace);
                    Console.WriteLine(@" 可用空间        :{0,15}字节", item.TotalFreeSpace);
                    Console.WriteLine(@" 磁盘总大小:     :{0,15}字节", item.TotalSize);
                }
                Console.ReadKey();
            }
        }

        public static void GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                long totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                Console.WriteLine($"{drive.Name} {totalSize}G {drive.DriveFormat} {drive.DriveType} {drive.IsReady} {drive.RootDirectory} {drive.VolumeLabel}");
            }
        }

        private static void DeleteRecentDemo()
        {
            string recentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            string[] files = Directory.GetFiles(recentPath);

            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }

                Console.WriteLine("清理完成................");
            }
            else
            {
                Console.WriteLine("干干净净的,无需清理");
            }
        }

        private static void DeleteDirectoryDemo()
        {
            //Microsoft.VisualBasic.FileIO
            Console.WriteLine("删除文件夹到回收站");
            string dirpath = "leaver";
            FileSystem.DeleteDirectory(dirpath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            Console.WriteLine("删除文件夹完成");
        }

        private static void DeletFileeDemo()
        {
            Console.WriteLine("删除文件到回收站");
            string filepath = @"D:\xxx.rar";
            FileSystem.DeleteFile(filepath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            Console.WriteLine("删除文件完成");
        }

        #region 控制台文本输出

        private static void ConsoleToFile()
        {
            StreamWriter sw = new StreamWriter(@"ConsoleOutput.txt");
            Console.SetOut(sw);

            string str = File.ReadAllText("D:\\aaa.txt", Encoding.Default);
            str = Regex.Replace(str, "\r|\n", "");
            Console.WriteLine(str);
            Console.WriteLine(DateTime.Today);

            sw.Flush();
            sw.Close();
        }

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
    }
}