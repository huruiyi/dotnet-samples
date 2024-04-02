using System;
using System.Windows.Forms;
using System.IO;

namespace SynchronousAD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAd());
        }


    }


    #region## 日志
    /// <summary>
    /// 日志
    /// </summary>
    public class LogRecord
    {
        private LogRecord()
        {
        }

        public static DbMode Mode { set; get; } = DbMode.Enable;

        private static readonly string SLogFile = $@"c:\log\adlog-{DateTime.Now:yyyy-MM-dd}.log";

        public static void WriteLog(string sMsg)
        {
            if (Mode == DbMode.Enable)
            {
                // Write log msg
                try
                {
                    using (StreamWriter sr = new StreamWriter(SLogFile, true))
                    {
                        sr.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss --}:{sMsg}");
                        sr.Flush();
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
    #endregion

    #region## 日志类型（Enum）
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum DbMode : int
    {
        Disable = 0,
        Enable = 1,
    }
    #endregion
}
