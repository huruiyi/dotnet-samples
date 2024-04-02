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
                refKey?.SetValue(ShortFileName, fileName);
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

        private static void RegistryKeyDemo()
        {
            RegistryKey rk = Registry.ClassesRoot;
            string[] vn = rk.GetSubKeyNames();

            RegistryKey rk0 = Registry.CurrentConfig;
            string[] vn0 = rk0.GetSubKeyNames();

            RegistryKey rk1 = Registry.CurrentUser;
            string[] vn1 = rk1.GetSubKeyNames();

            RegistryKey rk2 = Registry.LocalMachine;
            string[] vn2 = rk2.GetSubKeyNames();

            RegistryKey rk3 = Registry.PerformanceData;
            string[] vn3 = rk3.GetSubKeyNames();

            RegistryKey rk4 = Registry.Users;
            string[] vn4 = rk4.GetSubKeyNames();
        }

        private static void PrintKeys(RegistryKey rkey)
        {
            // Retrieve all the subkeys for the specified key.
            string[] names = rkey.GetSubKeyNames();

            int icount = 0;

            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-----------------------------------------------");

            // Print the contents of the array to the console.
            foreach (string s in names)
            {
                Console.WriteLine(s);

                icount++;
                if (icount >= 10)
                    break;
            }
        }
    }
}