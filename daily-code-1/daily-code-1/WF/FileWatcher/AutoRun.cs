using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
namespace FileWatcher
{
    public class AutoRun
    {

        public static void SetAutoRun(bool isAutoRun)
        {
            string fileName = GetPath();
            RegistryKey reg=null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                    throw new Exception("该文件不存在!");
                String name = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (isAutoRun)
                    reg.SetValue(name, fileName);
                else
                    reg.DeleteValue(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if(reg!=null)
                reg.Close();
            }        

        }
        private static string GetPath()
        {
            //获取当前进程的完整路径，包含文件名(进程名)。
            //string str = this.GetType().Assembly.Location;
            string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            return str;
        }
    }
}
