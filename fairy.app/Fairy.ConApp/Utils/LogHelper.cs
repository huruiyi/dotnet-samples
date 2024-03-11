using System;
using System.IO;
using System.Threading;
using log4net;

namespace Fairy.ConApp.Utils
{
    public class LogHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger("LogHelper");

        static LogHelper()
        {
            Thread.CurrentThread.Name = "main";//为了让主线程名显示

            string directory = Directory.GetCurrentDirectory();
            string xmlPath = Path.Combine(directory, "config", "log4net.config");

            FileInfo file = new FileInfo(xmlPath);

            GlobalContext.Properties["LogName"] = "2023_dir_";
            log4net.Config.XmlConfigurator.Configure(file);
        }

        public static void Debug(string str)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss") + " DEBUG:" + str);
            Logger.Debug(str);
        }

        public static void Info(string str)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss") + " INFO:" + str);
            Logger.Info(str);
        }

        public static void Warn(string str)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss") + " WARN:" + str);
            Logger.Warn(str);
        }

        public static void Error(string str)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-mm-dd HH:MM:ss") + " ERROR:" + str);
            Logger.Error(str);
        }
    }
}