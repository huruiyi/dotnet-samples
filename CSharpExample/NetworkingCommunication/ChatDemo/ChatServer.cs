using System;
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

        private Socket ClientSocket = null;
        private Thread ReceiveThread = null;

        private void btnConServices_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint ServerPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            ClientSocket.Connect(ServerPoint);
            richMsg.AppendText("连接服务器成功.\r\n");

            ReceiveThread = new Thread(ReceiveMsg);
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start();
        }

        private bool isReceiveMsg = true;

        public void ReceiveMsg()
        {
            while (isReceiveMsg)
            {
                byte[] bytes = new byte[1024 * 1024];
                int resultLength = ClientSocket.Receive(bytes);
                string resultString = Encoding.UTF8.GetString(bytes, 0, resultLength);

                richMsg.AppendText(resultString + "\r\n");
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            byte[] ServerSendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
            ClientSocket.Send(ServerSendMsg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ChatClient().Show();
        }
    }
}