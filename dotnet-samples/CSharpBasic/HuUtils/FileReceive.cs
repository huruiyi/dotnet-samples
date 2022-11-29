using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class FileReceive : Form
    {

        public bool[] Threadw; //每个线程结束标志
        public string[] Filenamew;//每个线程接收文件的文件名
        public int[] Filestartw;//每个线程接收文件的起始位置
        public int[] Filesizew;//每个线程接收文件的大小
        public string Strurl;//接受文件的URL
        public bool Hb;//文件合并标志
        public int ThreadSize;//进程数



        public FileReceive()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            Strurl = textBox2.Text.Trim().ToString();
            HttpWebRequest request;
            long filesize = 0;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(Strurl);
                filesize = request.GetResponse().ContentLength;//取得目标文件的长度
                request.Abort();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            // 接收线程数
            ThreadSize = Convert.ToInt32(textBox4.Text.Trim().ToString(), 10);
            //根据线程数初始化数组
            Threadw = new bool[ThreadSize];
            Filenamew = new string[ThreadSize];
            Filestartw = new int[ThreadSize];
            Filesizew = new int[ThreadSize];
            //计算每个线程应该接收文件的大小
            int filethread = (int)filesize / ThreadSize;//平均分配
            int filethreade = filethread + (int)filesize % ThreadSize;//剩余部分由最后一个线程完成
            //为数组赋值
            for (int i = 0; i < ThreadSize; i++)
            {
                Threadw[i] = false;//每个线程状态的初始值为假
                Filenamew[i] = i + ".dat";//每个线程接收文件的临时文件名
                if (i < ThreadSize - 1)
                {
                    Filestartw[i] = filethread * i;//每个线程接收文件的起始点
                    Filesizew[i] = filethread - 1;//每个线程接收文件的长度
                }
                else
                {
                    Filestartw[i] = filethread * i;
                    Filesizew[i] = filethreade - 1;
                }
            }
            //定义线程数组，启动接收线程
            Thread[] threadk = new Thread[ThreadSize];
            HttpFile[] httpfile = new HttpFile[ThreadSize];
            for (int j = 0; j < ThreadSize; j++)
            {
                httpfile[j] = new HttpFile(this, j);
                threadk[j] = new Thread(new ThreadStart(httpfile[j].receive));
                threadk[j].Start();
            }
            //启动合并各线程接收的文件线程
            Thread hbth = new Thread(new ThreadStart(hbfile));
            hbth.Start();

        }


        public void hbfile()
        {
            while (true)//等待
            {
                Hb = true;
                for (int i = 0; i < ThreadSize; i++)
                {
                    if (Threadw[i] == false)//有未结束线程，等待
                    {
                        Hb = false;
                        Thread.Sleep(100);
                        break;
                    }
                }
                if (Hb == true)//所有线程均已结束，停止等待，
                {
                    break;
                }
            }

            FileStream fstemp;
            int readfile;
            byte[] bytes = new byte[512];
            var fs = new FileStream(textBox3.Text.Trim(), FileMode.Create);
            for (int k = 0; k < ThreadSize; k++)
            {
                fstemp = new FileStream(Filenamew[k], FileMode.Open);
                while (true)
                {
                    readfile = fstemp.Read(bytes, 0, 512);
                    if (readfile > 0)
                    {
                        fs.Write(bytes, 0, readfile);
                    }
                    else
                    {
                        break;
                    }
                }
                fstemp.Close();
            }
            fs.Close();
         
            textBox1.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);//结束时间
            MessageBox.Show("接收完毕!!!");
        }

    }
}
