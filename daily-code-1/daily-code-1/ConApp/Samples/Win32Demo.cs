using System;
using System.Runtime.InteropServices;

namespace ConApp.Samples
{
    internal class Win32Demo
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public static void Message()
        {
            Console.Write("Enter your message: ");
            string myString = Console.ReadLine();
            MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }
    }
}