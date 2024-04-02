using NLog;
using System;
using System.Windows.Forms;

namespace WfApp
{
    public static class NLogger
    {
        //由于日志本身就是一个单例，所以这里就没必要再搞一个单例了
        public static readonly Logger Logger = LogManager.GetLogger("LogFile");
    }

    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += Application_ThreadException;
                //处理未捕获的异常
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new 垃圾清理());
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(ex, "异常消息：" + ex.Message + "——堆栈信息：" + ex.StackTrace);
                Application.Restart();
            }
        }

        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //LogHelper.ErrorLog(null, e.Exception as Exception);
            NLogger.Logger.Error(e.Exception, "UI线程异常消息：" + e.Exception.Message + "——堆栈信息：" + e.Exception.StackTrace);
        }

        /// <summary>
        /// 处理未捕获的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            NLogger.Logger.Error(ex, "非UI线程线程异常消息：" + ex.Message + "——堆栈信息：" + ex.StackTrace);
        }
    }
}