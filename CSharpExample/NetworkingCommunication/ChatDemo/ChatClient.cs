using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatDemo
{
    public partial class ChatClient : Form
    {
        public ChatClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket ServerSocket = null;
        private Thread AcceptThread = null;

        private void btnopenServices_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint ServerPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(ServerPoint);
            ServerSocket.Listen(10);
            richMsg.AppendText("打开服务器成功\r\n");

            AcceptThread = new Thread(AcceptSocket);
            AcceptThread.IsBackground = true;
            AcceptThread.Start();
        }

        private bool isListenMsg = true;
        private Socket ClientSocket = null;

        public void AcceptSocket()
        {
            //监听的客户端套接字(ClientSocket)
            ClientSocket = ServerSocket.Accept();
            richMsg.AppendText("有客户端连接\r\n");
            while (isListenMsg)
            {
                byte[] receiveMsg = new byte[1024 * 11024];
                int resulTLength = ClientSocket.Receive(receiveMsg);
                string receiveStringMsg = Encoding.UTF8.GetString(receiveMsg, 0, resulTLength);
                richMsg.AppendText(receiveStringMsg + "\r\n");
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //客户端向服务端发消息
            byte[] SendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
            ClientSocket.Send(SendMsg);
        }
    }
}