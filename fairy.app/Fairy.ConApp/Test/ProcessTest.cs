using System;
using System.Diagnostics;
using System.Management;

namespace Fairy.ConApp.Test
{
    public class ProcessTest
    {
        public static void Test()
        {
            foreach (Process process in Process.GetProcesses())
            {
                try
                {

                    string info = $"{process.ProcessName,-30},{GetProcessUserName(process.Id)}";//这个表示第一个参数str字符串的宽度为10，右对齐
                    Console.WriteLine(info);


                    string processInfo = "";
                    processInfo =   "该进程的总体优先级类别:" + process.PriorityClass  ;
                    Console.WriteLine(processInfo);
                    processInfo =   "由该进程打开的句柄数:" + process.HandleCount  ;
                    Console.WriteLine(processInfo);

                    processInfo =   "该进程的主窗口标题:" + process.MainWindowTitle ;
                    Console.WriteLine(processInfo);

                    processInfo =   "该进程允许的最小工作集大小:" + process.MinWorkingSet;
                    Console.WriteLine(processInfo);

                    processInfo =   "该进程允许的最大工作集大小:" + process.MaxWorkingSet ;
                    Console.WriteLine(processInfo);


                    processInfo =   "该进程的分页内存大小:" + process.PagedMemorySize64 ;
                    Console.WriteLine(processInfo);
                    
                    processInfo =   "该进程的峰值分页内存大小:" + process.PeakPagedMemorySize64 ;
                    Console.WriteLine(processInfo + Environment.NewLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static string GetProcessUserName(int pid)
        {
            string text1 = null;

            SelectQuery query1 = new SelectQuery("Select * from Win32_Process WHERE processID=" + pid);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1);

            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {
                    ManagementBaseObject inPar = disk.GetMethodParameters("GetOwner");

                    ManagementBaseObject outPar = disk.InvokeMethod("GetOwner", inPar, null);

                    text1 = outPar?["User"]?.ToString();
                    break;
                }
            }
            catch
            {
                text1 = "SYSTEM";
            }

            return text1;
        }

        private string RunCmd(string command)
        {
            //实例一个Process类，启动一个独立进程
            Process p = new Process();
            //Process类有一个StartInfo属性
            //设定程序名
            p.StartInfo.FileName = "cmd.exe";
            //设定程式执行参数
            p.StartInfo.Arguments = "/c " + command;
            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            //设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            //启动
            p.Start();
            //也可以用这种方式输入要执行的命令
            //不过要记得加上Exit要不然下一行程式执行的时候会当机
            //p.StandardInput.WriteLine(command);
            //p.StandardInput.WriteLine("exit");
            //从输出流取得命令执行结果
            return p.StandardOutput.ReadToEnd();
        }
    }
}