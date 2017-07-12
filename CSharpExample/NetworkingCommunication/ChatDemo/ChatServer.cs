using System;
using System.Collections.Generic;
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
            while (true)
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

        private void button1_Click(object sender, EventArgs e)
        {
            new ChatClient().Show();
        }

        private void lvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lvClient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //获取要发送信息的客户端地址
            currentSelectedIp = e.Item.Text;
        }

        private void lvClient_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}