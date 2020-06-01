using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Infrastructure
{
    public class HttpFile
    {
        public Form1 formm;
        public int threadh;//线程代号
        public string filename;//文件名
        public string strUrl;//接收文件的URL
        public FileStream fs;
        public HttpWebRequest request;
        public System.IO.Stream ns;
        public byte[] nbytes;//接收缓冲区
        public int nreadsize;//接收字节数
        public HttpFile(Form1 form, int thread)//构造方法
        {
            formm = form;
            threadh = thread;
        }
        HttpFile()//析构方法
        {
            formm.Dispose();
        }
        public void receive()//接收线程
        {
            filename = formm.filenamew[threadh];
            strUrl = formm.strurl;
            ns = null;
            nbytes = new byte[512];
            nreadsize = 0;
            formm.listBox1.Items.Add("线程" + threadh.ToString() + "开始接收");
            fs = new FileStream(filename, System.IO.FileMode.Create);
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                //接收的起始位置及接收的长度
                request.AddRange(formm.filestartw[threadh],
                    formm.filestartw[threadh] + formm.filesizew[threadh]);
                ns = request.GetResponse().GetResponseStream();//获得接收流
                nreadsize = ns.Read(nbytes, 0, 512);
                while (nreadsize > 0)
                {
                    fs.Write(nbytes, 0, nreadsize);
                    nreadsize = ns.Read(nbytes, 0, 512);
                    formm.listBox1.Items.Add("线程" + threadh.ToString() + "正在接收");
                }
                fs.Close();
                ns.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                fs.Close();
            }
            formm.listBox1.Items.Add("进程" + threadh.ToString() + "接收完毕!");
            formm.threadw[threadh] = true;
        }
    }

}