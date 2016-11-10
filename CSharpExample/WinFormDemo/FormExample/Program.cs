using System;
using System.Windows.Forms;

namespace FormExample
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WelcomForm fm = new WelcomForm();
            fm.ShowDialog();
            Application.Run(new MainForm());
        }
    }
}