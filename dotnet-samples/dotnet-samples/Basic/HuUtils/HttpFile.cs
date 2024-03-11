using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace HuUtils
{
    public class HttpFile
    {
        public FileReceive FileReceiveForm;
        public int ThreadNum;//线程代号
        public string Filename;//文件名
        public string StrUrl;//接收文件的URL
        public FileStream Fs;
        public HttpWebRequest Request;
        public Stream Ns;
        public byte[] NumBytes;//接收缓冲区
        public int NumReadSize;//接收字节数
        public HttpFile(FileReceive form, int thread)//构造方法
        {
            FileReceiveForm = form;
            ThreadNum = thread;
        }
        HttpFile()//析构方法
        {
            FileReceiveForm.Dispose();
        }
        public void Receive()//接收线程
        {
            Filename = FileReceiveForm.Filenamew[ThreadNum];
            StrUrl = FileReceiveForm.Strurl;
            Ns = null;
            NumBytes = new byte[512];
            NumReadSize = 0;
            FileReceiveForm.listBox1.Items.Add("线程" + ThreadNum + "开始接收");
            Fs = new FileStream(Filename, FileMode.Create);
            try
            {
                Request = (HttpWebRequest)WebRequest.Create(StrUrl);
                //接收的起始位置及接收的长度
                Request.AddRange(FileReceiveForm.Filestartw[ThreadNum],
                    FileReceiveForm.Filestartw[ThreadNum] + FileReceiveForm.Filesizew[ThreadNum]);
                Ns = Request.GetResponse().GetResponseStream();//获得接收流
                NumReadSize = Ns.Read(NumBytes, 0, 512);
                while (NumReadSize > 0)
                {
                    Fs.Write(NumBytes, 0, NumReadSize);
                    NumReadSize = Ns.Read(NumBytes, 0, 512);
                    FileReceiveForm.listBox1.Items.Add("线程" + ThreadNum + "正在接收");
                }
                Fs.Close();
                Ns.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                Fs.Close();
            }
            FileReceiveForm.listBox1.Items.Add("进程" + ThreadNum.ToString() + "接收完毕!");
            FileReceiveForm.Threadw[ThreadNum] = true;
        }
    }

}
