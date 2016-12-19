using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo.DataSynchronization
{
    public delegate void SetTextDel(string txt);

    public partial class DSForm1 : Form
    {
        private SetTextDel MySetCotrolTxt4OtherThreadDel;
        public void SetText4OtherThread(string strTxt)
        {
            this.txtMessage.Text = strTxt;
        }
        public DSForm1()
        {
            InitializeComponent();
            this.Text = Thread.CurrentThread.ManagedThreadId + "";

            //Control.CheckForIllegalCrossThreadCalls = false;
            CheckForIllegalCrossThreadCalls = false;

            MySetCotrolTxt4OtherThreadDel = new SetTextDel(this.SetText4OtherThread);
        }

        private void btnOpenDSForm2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                DSForm2 frm = new DSForm2();
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
    }
}
