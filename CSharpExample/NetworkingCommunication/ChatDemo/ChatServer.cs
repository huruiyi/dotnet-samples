using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatDemo
{
    public partial class ChatServer : Form
    {
        #region 窗体状态控制

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = true;
            }
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion 窗体状态控制

        public ChatServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket ServerSocket = null;

        private string currentSelectedIp;

        private Dictionary<string, Socket> DicClient = new Dictionary<string, Socket>();

        private void btnConServices_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint ServerPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(ServerPoint);
            ServerSocket.Listen(10);
            richMsg.AppendText("打开服务器成功\r\n");
            btnConServices.Enabled = false;

            #region ThreadAcceptSocket

            //Thread AcceptThread = new Thread(ThreadAcceptSocket);
            //AcceptThread.IsBackground = true;
            //AcceptThread.Start();

            #endregion ThreadAcceptSocket

            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ThreadPoolAcceptSocket), ServerSocket);
        }

        private void AddItem(Socket item)
        {
            if (!DicClient.ContainsKey(item.RemoteEndPoint.ToString()))
            {
                DicClient.Add(item.RemoteEndPoint.ToString(), item);

                lvClient.Items.Add(item.RemoteEndPoint.ToString());
            }
        }

        public void ThreadAcceptSocket()
        {
            while (true)
            {
                //监听的客户端套接字(ClientSocket)
                //Accept：阻塞
                Socket client = ServerSocket.Accept();
                AddItem(client);
                client.Send(Encoding.ASCII.GetBytes("已和服务端建立连接！！\r\n"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(client);
            }
        }

        public void ThreadPoolAcceptSocket(object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                //接受客户端的一个连接
                Socket client = socket.Accept();

                client.Send(Encoding.ASCII.GetBytes("已和服务端建立连接！！\r\n"));

                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveMessage), client);
            }
        }

        private void ReceiveMessage(object objClient)
        {
            Socket client = (Socket)objClient;
            richMsg.AppendText(string.Format("{0}有客户端连接\r\n", client.RemoteEndPoint.ToString()));
            while (true && client.Connected)
            {
                try
                {
                    byte[] receiveMsg = new byte[1024 * 11024];
                    //Receive：阻塞
                    int resulTLength = client.Receive(receiveMsg);
                    string receiveStringMsg = Encoding.UTF8.GetString(receiveMsg, 0, resulTLength);
                    richMsg.AppendText(receiveStringMsg + "\r\n");
                }
                catch (Exception exc)
                {
                    SocketException ex = exc as SocketException;
                    if (ex.SocketErrorCode == SocketError.ConnectionReset)
                    {
                        richMsg.AppendText(string.Format("{0}关闭了连接\r\n", client.RemoteEndPoint.ToString()));
                    }
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(currentSelectedIp) && DicClient[currentSelectedIp].Connected)
            {
                byte[] ServerSendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                DicClient[currentSelectedIp].Send(ServerSendMsg);
            }
            else
            {
            }
        }

        private void lvClient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //获取要发送信息的客户端地址
            currentSelectedIp = e.Item.Text;
        }

        private bool IsMouseDown = false;
        private Point mouseOffset;

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            //new ChatClient().Show();
            ThreadPool.QueueUserWorkItem(o =>
            {
                ChatClient chatClientFrm = new ChatClient();
                chatClientFrm.ShowDialog();
            }, null);
        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(currentSelectedIp) && DicClient[currentSelectedIp].Connected)
            {
                byte[] ServerSendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                //DicClient[currentSelectedIp];
            }
        }
    }
}