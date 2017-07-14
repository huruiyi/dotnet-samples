using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketChat
{
    public partial class ChatMain : Form
    {
        private List<Socket> clientSocketList = new List<Socket>();

        public ChatMain()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string ip = this.txtIP.Text;
            //创建IP地址
            IPAddress ipAddress = IPAddress.Parse(ip);
            //创建代表本机的节点对象：包含ip和端口
            IPEndPoint endPoint = new IPEndPoint(ipAddress, int.Parse(this.txtPort.Text));

            //创建Socket：第一参数：寻址方式，第二个参数： socket传输方式Stream Tcp方式  Dgram:UDP  第三个参数：协议
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //绑定端口和IP
            socket.Bind(endPoint);

            //开启监听
            //请求连接的队列的长度
            socket.Listen(10);

            //线程池开启 监听客户端连接
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.StatAccept), socket);
            this.txtLog.Text += "服务端开始监听客户端连接了....\r\n";
        }

        public void StatAccept(Object obje)
        {
            Socket socket = (Socket)obje;
            while (true)
            {
                //接受客户端的一个连接
                Socket proxSocket = socket.Accept();

                //客户端代理socket对象的队列里面去
                clientSocketList.Add(proxSocket);
                checkedListBox1.Items.Add(proxSocket.LocalEndPoint.ToString());
                //拿到客户端的端口和ip
                this.txtLog.Text += proxSocket.RemoteEndPoint.ToString() + "\r\n";

                ThreadPool.QueueUserWorkItem(new WaitCallback(this.StartReciveClientData), proxSocket);
            }
        }

        //处理客户端发送过来的请求信息
        public void StartReciveClientData(Object obj)
        {
            Socket sokcet = (Socket)obj;
            try
            {
                while (sokcet.Connected)
                {
                    byte[] buffer = new byte[1024 * 1024 * 1];
                    int realLenth = sokcet.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    string strResult = Encoding.Default.GetString(buffer, 0, realLenth);
                    this.txtLog.Text += sokcet.RemoteEndPoint.ToString() + ":" + strResult + "\r\n";
                }
            }
            catch (Exception ex)
            {
                sokcet.Close();

                //从客户端 代理socketlist 中移除
                clientSocketList.Remove(sokcet);
                checkedListBox1.Items.Remove(sokcet.LocalEndPoint.ToString());
            }
        }

        private void btnStarClient_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                ChatClient chatClientFrm = new ChatClient();
                chatClientFrm.ShowDialog();
            }, null);
        }

        /// <summary>
        /// 发送闪屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendShake_Click(object sender, EventArgs e)
        {
            foreach (var socket in clientSocketList)
            {
                SocketConnection.SendShake(socket);
            }
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var socket in clientSocketList)
                {
                    SocketConnection.SendFile(socket, openFileDialog.FileName);
                }
            }
        }
    }
}