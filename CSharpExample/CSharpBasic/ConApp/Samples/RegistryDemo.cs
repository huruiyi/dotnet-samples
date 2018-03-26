using Microsoft.Win32;
using System;

namespace ConApp
{
    public class RegistryDemo
    {
        public static void StartRun()
        {
            string fileName = "";
            string ShortFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            //打开子键节点
            using (RegistryKey refKey =
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true) ??
                Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"))
            {
                if (refKey != null)
                    refKey.SetValue(ShortFileName, fileName);
            }
        }

        public static void RegistryKeys()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            if (rk != null)
            {
                String[] names = rk.GetSubKeyNames();
                foreach (string item in names)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}