using System;
using System.Threading;
using System.Windows.Forms;

namespace MultThread
{
    public delegate void SetTextDel(string txt);

    public partial class MainFrm : Form
    {
        private SetTextDel MySetCotrolTxt4OtherThreadDel;

        public MainFrm()
        {
            InitializeComponent();

            this.Text = Thread.CurrentThread.ManagedThreadId + "";

            //Control.CheckForIllegalCrossThreadCalls = false;

            MySetCotrolTxt4OtherThreadDel = new SetTextDel(this.SetText4OtherThread);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                ChildFrm frm = new ChildFrm();
                frm._SetTextDel = new SetTextDel(SetText);
                frm.ShowDialog();
            });
            thread.Start();
        }

        public void SetText(string txt)
        {
            //InvokeRequired 当线程执行到此的时候，校验一下txtMessage控件是哪个线程创建的。如果是自己创建的InvokeRequired：fasle反之则为true
            if (this.txtMessage.InvokeRequired)
            {
                this.Invoke(MySetCotrolTxt4OtherThreadDel, txt);
            }
            else
            {
                this.txtMessage.Text = txt;
            }
        }

        public void SetText4OtherThread(string strTxt)
        {
            this.txtMessage.Text = strTxt;
        }
    }
}