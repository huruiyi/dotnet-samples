using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MultThread
{
    public delegate void SetTextDel(string txt);

    public partial class MainFrm : Form
    {
        private readonly List<Label> lbList = new List<Label>();

        public bool IsCreate = false;

        private SetTextDel MySetCotrolTxt4OtherThreadDel;

        public MainFrm()
        {
            InitializeComponent();

            this.Text = Thread.CurrentThread.ManagedThreadId + "";

            //Control.CheckForIllegalCrossThreadCalls = false;
            CheckForIllegalCrossThreadCalls = false;

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

        public void SetText(int i)
        {
            lbList[i].Text = "ddd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsCreate)
            {
                IsCreate = false;
                btnStart.Text = "开始";
            }
            else
            {
                this.btnStart.Text = "结束";
                IsCreate = true;

                //启动另外一个线程去 改变 lable 的值
                new Thread(() =>
                {
                    Random random = new Random();
                    while (IsCreate)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            //闭包导致了 i的作用域变大了。出现了一些异常的情况
                            //Thread thead = new Thread((a) => SetText(a),i);
                            lbList[i].Text = random.Next(1, 10).ToString();
                        }
                        //让线程停顿一下
                        Thread.Sleep(300);
                    }
                }).Start();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                Label label = new Label
                {
                    Text = i.ToString(),
                    AutoSize = true,
                    Location = new Point(50 * i + 50, 50)
                };

                lbList.Add(label);

                this.Controls.Add(label);
            }
        }
    }
}