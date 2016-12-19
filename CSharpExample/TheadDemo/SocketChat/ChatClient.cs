using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace SocketChat
{
    public partial class ChatClient : Form
    {
        public Socket CurrentSocket { get; set; }

        public ChatClient()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Socket socket = null;
            try
            {
                //IPAddress ipAddress = IPAddress.Parse(this.txtIP.Text);
                //IPEndPoint endPoint = new IPEndPoint(ipAddress, int.Parse(this.txtPort.Text));

                ////创建Socket
                //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                ////客户端连接服务端方法： 传 IP 和端口到方法里面去
                ////出现异常
                //socket.Connect(endPoint);

                //使用封装的方法进行客户端的连接
                CurrentSocket = SocketConnection.ConnectServer(this.txtIP.Text, int.Parse(this.txtPort.Text));

                ThreadPool.QueueUserWorkItem(new WaitCallback(ReciveData), CurrentSocket);


                this.lbStatus.Text = "已经连接";

                CurrentSocket = socket;
            }
            catch (Exception ex)
            {
                if (CurrentSocket != null)
                {
                    CurrentSocket.Dispose();
                }
            }
        }

        //接受服务端消息
        public void ReciveData(Object obj)
        {
            Socket socket = (Socket) obj;
            //g j 

            while (socket != null && socket.Connected)
            {
                byte[] buffer = new byte[1024*1024];
                int realLength = socket.Receive(buffer, 0, buffer.Length, 0);

                byte sentType = buffer[0];
                
                //接受的是字符串
                if(sentType == (byte)SendDataTypeEnum.String)
                {
                    string txt = Encoding.Default.GetString(buffer, 1, realLength-1);
                    this.txtLog.Text = string.Format("接受到消息：{0} \r\n {1}", txt, this.txtLog.Text);
                }
                else if(sentType == (byte)SendDataTypeEnum.Shake)//接受到都是震动
                {
                    Random random = new Random();
                    Point oldPoint = this.Location;
                    for(int i=0;i<30;i++)
                    {
                        this.Location = new Point(oldPoint.X + random.Next(1,30),oldPoint.Y + random.Next(1,30));
                        Thread.Sleep(30);
                        this.Location = oldPoint;
                        Thread.Sleep(30);
                    }
                }
                else if (sentType == (byte)SendDataTypeEnum.File)//接受到都是震动
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if(saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        byte[] fileData = new byte[realLength-1];
                        Buffer.BlockCopy(buffer,1,fileData,0,realLength-1);
                        File.WriteAllBytes(saveFileDialog.FileName, fileData);

                        this.txtLog.Text += "保存文件成功！";
                    }
                }


               

                //先判断第一个字节是 Enum.String 直接字符串

            }
        }

        //发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            string strTxt = this.txtMsg.Text;
            if(string.IsNullOrEmpty(strTxt))
            {
                this.txtLog.Text ="发送的消息不能为空。。。\r\n"+ this.txtLog.Text;
            }

            if(CurrentSocket == null)
            {
                MessageBox.Show("请先连接服务端");
                return;
                
            }
            try
            {
                byte[] data = Encoding.Default.GetBytes(strTxt);

                //CurrentSocket.Send(data, 0, data.Length, 0);

                //使用封装的方法发送消息
                SocketConnection.SendData(CurrentSocket,data);
            }
            catch (Exception exception)
            {
                
                CurrentSocket.Dispose();
                CurrentSocket = null;
                
            }

        }
    }
}
