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

            Thread AcceptThread = new Thread(AcceptSocket);
            AcceptThread.IsBackground = true;
            AcceptThread.Start();
        }

        private void AddItem(Socket item)
        {
            if (!DicClient.ContainsKey(item.RemoteEndPoint.ToString()))
            {
                DicClient.Add(item.RemoteEndPoint.ToString(), item);

                lvClient.Items.Add(item.RemoteEndPoint.ToString());
            }
        }

        public void AcceptSocket()
        {
            while (true)
            {
                //监听的客户端套接字(ClientSocket)
                //Accept：阻塞
                Socket client = ServerSocket.Accept();
                AddItem(client);
                client.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(client);
            }
        }

        private void ReceiveMessage(object objClient)
        {
            Socket client = (Socket)objClient;
            richMsg.AppendText(string.Format("{0}有客户端连接\r\n", client.RemoteEndPoint.ToString()));
            while (true&& client.Connected)
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
            if (!string.IsNullOrWhiteSpace(currentSelectedIp))
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

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            new ChatClient().Show();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}