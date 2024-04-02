using System;
using System.Diagnostics;
using System.IO;

namespace Fairy.ConApp.Test
{
    public class SystemPath
    {
        public static void Test()
        {
            // 获取程序的基目录。
            string domainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(domainBaseDirectory);
            // 获取模块的完整路径。
            string mainModuleFileName = Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine(mainModuleFileName);

            // 获取和设置当前目录(该进程从中启动的目录)的完全限定目录。
            string currentDirectory = System.Environment.CurrentDirectory;
            Console.WriteLine(currentDirectory);

            // 获取应用程序的当前工作目录。
            string directory = Directory.GetCurrentDirectory();
            Console.WriteLine(directory);

            // 获取和设置包括该应用程序的目录的名称。
            string setupInformationApplicationBase = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine(setupInformationApplicationBase);

            string directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(directoryName);
        }
    }
}