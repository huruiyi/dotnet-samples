using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SearchApp;

namespace SearchApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new FrmLogin().Show();
            Application.Run();
        }
    }
}