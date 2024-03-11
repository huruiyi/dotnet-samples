using System;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils.DataSynchronization
{
    public delegate void SetTextDel(string txt);

    public partial class DsForm1 : Form
    {
        private readonly SetTextDel _mySetCotrolTxt4OtherThreadDel;

        public void SetText4OtherThread(string strTxt)
        {
            this.txtMessage.Text = strTxt;
        }

        public DsForm1()
        {
            InitializeComponent();
            this.Text = Thread.CurrentThread.ManagedThreadId + "";

            //Control.CheckForIllegalCrossThreadCalls = false;
            CheckForIllegalCrossThreadCalls = false;

            _mySetCotrolTxt4OtherThreadDel = this.SetText4OtherThread;
        }

        private void btnOpenDSForm2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                DsForm2 frm = new DsForm2
                {
                    SetTextDel = SetText
                };
                frm.ShowDialog();
            });
            thread.Start();
        }

        public void SetText(string txt)
        {
            //InvokeRequired 当线程执行到此的时候，校验一下txtMessage控件是哪个线程创建的。如果是自己创建的InvokeRequired：fasle反之则为true
            if (this.txtMessage.InvokeRequired)
            {
                this.Invoke(_mySetCotrolTxt4OtherThreadDel, txt);
            }
            else
            {
                this.txtMessage.Text = txt;
            }
        }
    }
}