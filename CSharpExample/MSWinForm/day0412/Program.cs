using System;
using System.Windows.Forms;

namespace day0412
{
    internal static class Program
    {
        public static bool Flag = false;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new Form1("张三"));


            Login login = new Login();
            login.ShowDialog();
            if (Flag == true)
            {
                Application.Run(new Form1());
            }
        }
    }
}