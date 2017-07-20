using System;
using System.Diagnostics;
using System.Drawing;
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
            //ClientSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint ServerPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            ClientSocket.Connect(ServerPoint);

            #region Poll

            if (!ClientSocket.Connected)
            {
                Console.WriteLine("Unable to connect to host");
            }
            // Use the SelectWrite enumeration to obtain Socket status.
            if (ClientSocket.Poll(-1, SelectMode.SelectWrite))
            {
                Console.WriteLine("This Socket is writable.");
            }
            else if (ClientSocket.Poll(-1, SelectMode.SelectRead))
            {
                Console.WriteLine("This Socket is readable.");
            }
            else if (ClientSocket.Poll(-1, SelectMode.SelectError))
            {
                Console.WriteLine("This Socket has an error.");
            }

            #endregion Poll

            //ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //ClientSocket.Connect(this.txtIP.Text, int.Parse(this.txtPort.Text));

            richMsg.AppendText("连接服务器成功.\r\n");
            this.Text = "客户端" + ClientSocket.LocalEndPoint.ToString();

            #region ThreadReceiveMsg

            //Thread ReceiveThread = new Thread(ThreadReceiveMsg)
            //{
            //    IsBackground = true
            //};
            //ReceiveThread.Start();

            #endregion ThreadReceiveMsg

            #region ThreadPoolReceiveMsg

            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolReceiveMsg), ClientSocket);

            #endregion ThreadPoolReceiveMsg

            btnopenServices.Enabled = false;
            btnSendMsg.Enabled = true;
        }

        public void ThreadReceiveMsg()
        {
            string endpoint = ClientSocket.LocalEndPoint.ToString();
            while (true && ClientSocket.Connected)
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
                    SocketException ex = exc as SocketException;
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

        public void ThreadPoolReceiveMsg(Object obj)
        {
            Socket socket = (Socket)obj;

            while (true && socket.Connected)
            {
                try
                {
                    byte[] bytes = new byte[1024 * 1024];
                    int resultLength = socket.Receive(bytes);
                    string resultString = Encoding.UTF8.GetString(bytes, 0, resultLength);

                    richMsg.AppendText(resultString + "\r\n");
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.Message);
                    socket.Dispose();
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
            if (ClientSocket.Connected)
            {
                //客户端向服务端发消息
                byte[] SendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                ClientSocket.Send(SendMsg);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnSendMsg.Enabled = false;
            btnopenServices.Enabled = true;
            ClientSocket.Close();
        }

        private void ChatClient_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsMouseDown = false;
        private Point mouseOffset;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
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
    }
}