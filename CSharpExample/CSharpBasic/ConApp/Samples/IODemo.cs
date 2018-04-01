using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ConApp
{
    public class IODemo
    {
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

        public static void GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                long totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                Console.WriteLine($"{drive.Name} {totalSize}G {drive.DriveFormat} {drive.DriveType} {drive.IsReady} {drive.RootDirectory} {drive.VolumeLabel}");
            }
        }
    }
}