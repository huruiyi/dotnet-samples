using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils.Chat
{
    public partial class ChatClient : Form
    {
        public ChatClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket _clientSocket;

        private void btnopenServices_Click(object sender, EventArgs e)
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //ClientSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint serverPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            _clientSocket.Connect(serverPoint);
            //ClientSocket.Connect(this.txtIP.Text, int.Parse(this.txtPort.Text));

            #region Poll

            if (!_clientSocket.Connected)
            {
                Console.WriteLine("Unable to connect to host");
            }
            // Use the SelectWrite enumeration to obtain Socket status.
            if (_clientSocket.Poll(-1, SelectMode.SelectWrite))
            {
                Console.WriteLine("This Socket is writable.");
            }
            else if (_clientSocket.Poll(-1, SelectMode.SelectRead))
            {
                Console.WriteLine("This Socket is readable.");
            }
            else if (_clientSocket.Poll(-1, SelectMode.SelectError))
            {
                Console.WriteLine("This Socket has an error.");
            }

            #endregion Poll

            richMsg.AppendText("连接服务器成功." + Environment.NewLine);
            this.Text = "客户端" + _clientSocket.LocalEndPoint;

            #region Thread ReceiveMsg

            //Thread ReceiveThread = new Thread(ThreadReceiveMsg)
            //{
            //    IsBackground = true
            //};
            //ReceiveThread.Start();

            #endregion Thread ReceiveMsg

            ThreadPool.QueueUserWorkItem(ThreadPoolReceiveMsg, _clientSocket);

            btnopenServices.Enabled = false;
            btnSendMsg.Enabled = true;
        }

        public void ThreadReceiveMsg()
        {
            string endpoint = _clientSocket.LocalEndPoint.ToString();
            while (_clientSocket.Connected)
            {
                try
                {
                    byte[] bytes = new byte[1024 * 1024];
                    int resultLength = _clientSocket.Receive(bytes);
                    string resultString = Encoding.UTF8.GetString(bytes, 0, resultLength);

                    richMsg.AppendText(_clientSocket.LocalEndPoint + ":" + Environment.NewLine + "\t" + resultString + Environment.NewLine);
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

            while (socket.Connected)
            {
                try
                {
                    byte[] bytes = new byte[1024 * 1024];
                    int resultLength = socket.Receive(bytes);
                    string resultString = Encoding.UTF8.GetString(bytes, 0, resultLength);

                    richMsg.AppendText(_clientSocket.LocalEndPoint + ":" + Environment.NewLine + "\t" + resultString + Environment.NewLine);
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
            if (_clientSocket.Connected)
            {
                //客户端向服务端发消息
                byte[] sendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                _clientSocket.Send(sendMsg);
                txtSendMsg.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnSendMsg.Enabled = false;
            btnopenServices.Enabled = true;
            _clientSocket.Close();
        }

        private void ChatClient_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsMouseDown;
        private Point mouseOffset;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Point mousePos = MousePosition;
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

        private void ChatClient_Resize(object sender, EventArgs e)
        {
            Control.ControlCollection controls = this.groupBox1.Controls;
            foreach (Control control in controls)
            {
                Type type = control.GetType();
                if (type.Name.Equals("Button"))
                {
                    if (control is Button button)
                    {
                        Rectangle rect = new Rectangle(0, 0, button.Width, button.Height);
                        var formPath = GetRoundedRectPath(rect, 30);
                        button.Region = new Region(formPath);
                    }
                }
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                SetWindowRegion();
            }
            else
            {
                this.Region = null;
            }
        }

        public void SetWindowRegion()
        {
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var formPath = GetRoundedRectPath(rect, 30);
            this.Region = new Region(formPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90); //左上角

            arcRect.X = rect.Right - diameter; //右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter; // 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left; // 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}