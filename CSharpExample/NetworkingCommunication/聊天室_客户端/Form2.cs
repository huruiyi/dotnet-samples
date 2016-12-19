using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 聊天室_客户端
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket socketClient = null;
        private Thread socketReceive = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(txtIP.Text.Trim());
            IPEndPoint enpoint = new IPEndPoint(address, Convert.ToInt32(txtPort.Text));
            socketClient.Connect(enpoint);

            socketReceive = new Thread(SocketReceiveMsg);
            socketReceive.IsBackground = true;
            socketReceive.Start();
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