using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 聊天室_客户端
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /*
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse(txtIp.Text);
            EndPoint endPoint = new IPEndPoint(ipAddress, Convert.ToInt32(txtPort.Text));
            socketServer.Bind(endPoint);
            socketServer.Listen(10000);
            txtMsg.AppendText("打开服务端成功" + Environment.NewLine);
            socketServer.Accept();
            txtMsg.AppendText("有客户端连接");
             */

        private Socket socketClient = null;
        private Thread socketReceive = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(txtIP.Text.Trim());
            IPEndPoint enpoint = new IPEndPoint(address, Convert.ToInt32(txtPort.Text));
            socketClient.Connect(enpoint);

            #region 监听是否有新信息接收

            socketReceive = new Thread(SocketReceiveMsg);
            socketReceive.IsBackground = true;
            socketReceive.Start();

            #endregion 监听是否有新信息接收
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string sendMsg = txtInput.Text;
            byte[] byteMsg = Encoding.UTF8.GetBytes(sendMsg);
            socketClient.Send(byteMsg);
        }

        private bool isReceive = true;

        private void SocketReceiveMsg()
        {
            while (isReceive)
            {
                if (socketClient != null)
                {
                    byte[] byteMsg = new byte[1024 * 1024];
                    socketClient.Receive(byteMsg);
                    string receive = Encoding.UTF8.GetString(byteMsg);
                    txtShow.AppendText(receive + Environment.NewLine);
                }
            }
        }
    }
}