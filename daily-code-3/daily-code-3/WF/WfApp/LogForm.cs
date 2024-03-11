using System;
using System.Threading;
using System.Windows.Forms;

namespace WfApp
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = null;
                string b = a.Trim();
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(ex);
                NLogger.Logger.Error("\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //var a = 1;
                //var b = 0;
                //var c = a / b;
                var thread = new Thread(new ThreadStart(Test));
                thread.IsBackground = true;
                Thread.Sleep(5000);
                thread.Start();
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(ex.Message);
            }
        }

        private void Test()
        {
            throw new Exception("线程异常");
        }
    }
}