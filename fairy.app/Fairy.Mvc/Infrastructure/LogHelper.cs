using log4net.Config;
using System;
using System.IO;

namespace Fairy.Mvc.Infrastructure
{
    public class LogHelper
    {
        //log4net日志专用
        public static readonly log4net.ILog LogInfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog LogError = log4net.LogManager.GetLogger("logerror");

        public static void SetConfig()
        {
            XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 普通的文件记录日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (LogInfo.IsInfoEnabled)
            {
                LogInfo.Info(info);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void WriteLog(string info, Exception se)
        {
            if (LogError.IsErrorEnabled)
            {
                LogError.Error(info, se);
            }
        }
    }
}