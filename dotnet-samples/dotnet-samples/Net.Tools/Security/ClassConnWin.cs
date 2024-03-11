using System;

namespace Net.Tools.Security
{
    public class ClassConnWin
    {
        public string Path { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public string LinkFile()
        {
            if (Path != "" && User != "" && Pass != "")
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();//创建进程对象
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c" + @"Net Use " + Path + " " + Pass + " /user:" + User,
                    UseShellExecute = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };//创建进程时使用的一组值，如下面的属性
                //以下是隐藏cmd窗口的方法
                process.StartInfo = startinfo;
                try
                {
                    if (process.Start())        //开始进程
                    {
                        process.WaitForExit();
                        string output = process.StandardOutput.ReadToEnd();//读取进程的输出
                        Console.WriteLine(output);
                    }
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
                finally
                {
                    process.Close();
                }
                return Path;
            }
            return "路径、用户名或密码错误";
        }

        public void KillLink()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();//创建进程对象
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c" + @"Net Use /delete * /yes",
                UseShellExecute = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };//创建进程时使用的一组值，如下面的属性
            //以下是隐藏cmd窗口的方法
            process.StartInfo = startinfo;

            if (process.Start())        //开始进程
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();//读取进程的输出
                Console.WriteLine(output);
                process.Close();
            }
        }
    }
}