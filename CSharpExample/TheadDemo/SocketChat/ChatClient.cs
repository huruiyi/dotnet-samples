using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

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
                IPAddress ipAddress = IPAddress.Parse(this.txtIP.Text);
                IPEndPoint endPoint = new IPEndPoint(ipAddress, int.Parse(this.txtPort.Text));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(endPoint);

                //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socket.Connect(this.txtIP.Text, int.Parse(this.txtPort.Text));

                this.lbStatus.Text = "已经连接";
                this.Text = "客户端" + socket.LocalEndPoint.ToString();
                CurrentSocket = socket;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReciveData), CurrentSocket);
            }
            catch (Exception ex)
            {
                if (CurrentSocket != null)
                {
                    CurrentSocket.Dispose();
                }
            }
        }

        public void ReciveData(Object obj)
        {
            Socket socket = (Socket)obj;

            while (socket != null && socket.Connected)
            {
                byte[] buffer = new byte[1024 * 1024];
                int realLength = socket.Receive(buffer, 0, buffer.Length, 0);

                byte sentType = buffer[0];

                //接受的是字符串
                if (sentType == (byte)SendDataTypeEnum.String)
                {
                }
                else if (sentType == (byte)SendDataTypeEnum.Shake)//接受到都是震动
                {
                    Random random = new Random();
                    Point oldPoint = this.Location;
                    for (int i = 0; i < 30; i++)
                    {
                        this.Location = new Point(oldPoint.X + random.Next(1, 30), oldPoint.Y + random.Next(1, 30));
                        Thread.Sleep(30);
                        this.Location = oldPoint;
                        Thread.Sleep(30);
                    }
                }
                else if (sentType == (byte)SendDataTypeEnum.File)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        byte[] fileData = new byte[realLength - 1];
                        Buffer.BlockCopy(buffer, 1, fileData, 0, realLength - 1);
                        File.WriteAllBytes(saveFileDialog.FileName, fileData);

                        this.txtLog.Text += "保存文件成功！";
                    }
                }
            }
        }
    }
}