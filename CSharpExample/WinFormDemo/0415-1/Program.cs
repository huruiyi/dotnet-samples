using System;
using System.Windows.Forms;

namespace day0415
{
    public static class Program
    {
        public static bool IsValid = false;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Form1 f1 = new Form1();
            f1.ShowDialog();
            if (IsValid)
            {
                Application.Run(new MainForm());
            }
        }
    }
}