using System;
using System.IO;
using System.ServiceProcess;
using System.Text;

namespace WindowsService
{
    public partial class ServiceTest : ServiceBase
    {
        public ServiceTest()
        {
            InitializeComponent();
            //    ALLUSERSPROFILE
        }

        public void WriteLog(string logConent)
        {
            using (FileStream fs = new FileStream("D:\\log.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(logConent);
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.....");
        }

        protected override void OnStop()
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.....");
        }

        protected override void OnPause()
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Pause.....");
        }

        protected override void OnContinue()
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Continue.....");
        }

        protected override void OnShutdown()
        {
            WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Shutdown.....");
        }
    }
}