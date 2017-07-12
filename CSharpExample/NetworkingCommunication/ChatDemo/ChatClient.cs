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

        private Socket ClientSocket = null;

        private void btnopenServices_Click(object sender, EventArgs e)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint ServerPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            ClientSocket.Connect(ServerPoint);
            richMsg.AppendText("连接服务器成功.\r\n");
            this.Text = ClientSocket.LocalEndPoint.ToString();

            Thread ReceiveThread = new Thread(ReceiveMsg);
            ReceiveThread.IsBackground = true;
            ReceiveThread.Start();
            btnopenServices.Enabled = false;
        }

        public void ReceiveMsg()
        {
            string endpoint = ClientSocket.LocalEndPoint.ToString();
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024 * 1024];
                    int resultLength = ClientSocket.Receive(bytes);
                    string resultString = Encoding.UTF8.GetString(bytes, 0, resultLength);

                    richMsg.AppendText(resultString + "\r\n");
                }
                catch (Exception exc)
                {
                    //SocketException ex = exc as SocketException;
                    //if (ex.SocketErrorCode == SocketError.ConnectionAborted)
                    //{
                    //    richMsg.AppendText(string.Format("{0}关闭了连接\r\n", endpoint));
                    //}
                    //else
                    //{
                    //    richMsg.AppendText(string.Format("异常\r\n"));
                    //}
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            //客户端向服务端发消息
            byte[] SendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
            ClientSocket.Send(SendMsg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClientSocket.Close();
        }
    }
}