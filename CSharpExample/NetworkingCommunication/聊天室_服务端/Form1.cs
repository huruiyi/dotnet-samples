using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 聊天室
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket socketserver = null;
        private Socket socketClient = null;
        private Thread socketThread = null;

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            socketserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(txtIp.Text);
            IPEndPoint endPoint = new IPEndPoint(ipaddress, Convert.ToInt32(txtPort.Text));
            socketserver.Bind(endPoint);
            socketserver.Listen(10);

            socketThread = new Thread(SocketAccept);
            socketThread.IsBackground = true;
            socketThread.Start();

            txtMsg.Text = @"打开服务器成功" + "\r\n";
        }

        private bool isAccept = true;

        private void SocketAccept()
        {
            while (isAccept)
            {
                socketClient = socketserver.Accept();
                txtMsg.AppendText("有客户端连接成功" + "\r\n");
            }
        }

        private void btnSendmsg_Click(object sender, EventArgs e)
        {
            string sendMsg = txtInputmsg.Text;
            byte[] byteMsg = Encoding.UTF8.GetBytes(sendMsg);
            socketClient.Send(byteMsg);
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}