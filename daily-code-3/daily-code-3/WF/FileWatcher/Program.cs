using System;
using System.Windows.Forms;

namespace FileWatcher
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
            //  HideOnStartupApplicationContext context = new HideOnStartupApplicationContext(frmMain.Frm);

            Application.Run(new frmMain());
        }
    }
}