using System;
using System.Runtime.InteropServices;

namespace UseCPPDLL
{
    // CPP的DLL需要放到当前项目的执行目录下
    internal class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        private static void Main()
        {
            Console.ReadKey();
            int result = CPPDLL.Add(10, 20);
            Console.WriteLine("10 + 20 = {0}", result);

            result = CPPDLL.Sub(30, 12);
            Console.WriteLine("30 - 12 = {0}", result);

            result = CPPDLL.Multiply(5, 4);
            Console.WriteLine("5 * 4 = {0}", result);

            result = CPPDLL.Divide(30, 5);
            Console.WriteLine("30 / 5 = {0}", result);

            IntPtr ptr = CPPDLL.Create("李平", 27);
            CPPDLL.User user = (CPPDLL.User)Marshal.PtrToStructure(ptr, typeof(CPPDLL.User));
            Console.WriteLine("Name: {0}, Age: {1}", user.Name, user.Age);

            MessageBox(new IntPtr(0), "Hello World!", "标题", 0);

            MessageBox(0, "Content", "My Message Box", 0);
        }
    }

    public class CPPDLL
    {
        //CPPDLL.dll 的输出目录需要设置为： ..\UseCPPDLL\bin\Debug
        [DllImport("CPPDLL.dll", EntryPoint = "Add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int x, int y);

        [DllImport("CPPDLL.dll", EntryPoint = "Sub", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sub(int x, int y);

        [DllImport("CPPDLL.dll", EntryPoint = "Multiply", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int x, int y);

        [DllImport("CPPDLL.dll", EntryPoint = "Divide", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Divide(int x, int y);

        [DllImport("CPPDLL.dll", EntryPoint = "Create", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Create(string name, int age);

        [StructLayout(LayoutKind.Sequential)]
        public struct User
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name;

            public int Age;
        }
    }
}