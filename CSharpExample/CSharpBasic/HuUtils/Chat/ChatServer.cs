using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils.Chat
{
    public partial class ChatServer : Form
    {
        #region 窗体状态控制

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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion 窗体状态控制

        public ChatServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Socket _serverSocket = null;

        private string currentSelectedIp;

        private readonly Dictionary<string, Socket> _dicClient = new Dictionary<string, Socket>();

        private void btnConServices_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            IPEndPoint serverPoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(serverPoint);
            _serverSocket.Listen(10);
            richMsg.AppendText("打开服务器成功" + Environment.NewLine);
            btnConServices.Enabled = false;

            #region ThreadAcceptSocket

            //Thread AcceptThread = new Thread(ThreadAcceptSocket);
            //AcceptThread.IsBackground = true;
            //AcceptThread.Start();

            #endregion ThreadAcceptSocket

            ThreadPool.QueueUserWorkItem(this.ThreadPoolAcceptSocket, _serverSocket);
        }

        private void AddItem(Socket item)
        {
            if (!_dicClient.ContainsKey(item.RemoteEndPoint.ToString()))
            {
                _dicClient.Add(item.RemoteEndPoint.ToString(), item);

                lvClient.Items.Add(item.RemoteEndPoint.ToString());
            }
        }

        public void ThreadAcceptSocket()
        {
            while (true)
            {
                Socket client = _serverSocket.Accept();
                AddItem(client);
                client.Send(Encoding.UTF8.GetBytes("已和服务端建立连接！！" + Environment.NewLine));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(client);
            }
        }

        public void ThreadPoolAcceptSocket(object obj)
        {
            Socket socket = (Socket)obj;
            while (true)
            {
                Socket client = socket.Accept();
                AddItem(client);
                client.Send(Encoding.UTF8.GetBytes("已和服务端建立连接！！" + Environment.NewLine));

                ThreadPool.QueueUserWorkItem(ReceiveMessage, client);
            }
        }

        private void ReceiveMessage(object objClient)
        {
            Socket client = (Socket)objClient;
            richMsg.AppendText($"客户端:{client.RemoteEndPoint}连接成功！！" + Environment.NewLine);
            while (client.Connected)
            {
                try
                {
                    byte[] receiveMsg = new byte[1024 * 11024];
                    //Receive：阻塞
                    int resulTLength = client.Receive(receiveMsg);
                    string receiveStringMsg = Encoding.UTF8.GetString(receiveMsg, 0, resulTLength);
                    richMsg.AppendText(client.LocalEndPoint + ":" + Environment.NewLine + "\t" + receiveStringMsg + "" +
                                       Environment.NewLine);
                }
                catch (Exception exc)
                {
                    SocketException ex = exc as SocketException;
                    if (ex.SocketErrorCode == SocketError.ConnectionReset)
                    {
                        richMsg.AppendText(string.Format("{0}关闭了连接" + Environment.NewLine, client.RemoteEndPoint));
                    }
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(currentSelectedIp) && _dicClient[currentSelectedIp].Connected)
            {
                byte[] serverSendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                _dicClient[currentSelectedIp].Send(serverSendMsg);
                txtSendMsg.Text = "";
            }
            else
            {
                MessageBox.Show("未连接客户端！！！");
            }
        }

        private void lvClient_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //获取要发送信息的客户端地址
            currentSelectedIp = e.Item.Text;
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            //new ChatClient().Show();
            ThreadPool.QueueUserWorkItem(o =>
            {
                ChatClient chatClientFrm = new ChatClient();
                chatClientFrm.ShowDialog();
            }, null);
        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(currentSelectedIp) && _dicClient[currentSelectedIp].Connected)
            {
                byte[] serverSendMsg = Encoding.UTF8.GetBytes(txtSendMsg.Text);
                //DicClient[currentSelectedIp];
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                //SendFile
            }
        }

        #region 震动，文件保存

        public void Shanke()
        {
            Random random = new Random();
            Point oldPoint = this.Location;
            for (int i = 0; i < 30; i++)
            {
                this.Location = new Point(oldPoint.X + random.Next(1, 30), oldPoint.Y + random.Next(1, 30));
                Thread.Sleep(30);
                this.Location = oldPoint;
                Thread.Sleep(30);
            }
        }

        public void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //byte[] buffer = new byte[1024 * 1024];
                //int realLength = ClientSocket.Receive(buffer, 0, buffer.Length, 0);

                //byte[] fileData = new byte[realLength - 1];
                //Buffer.BlockCopy(buffer, 1, fileData, 0, realLength - 1);
                //File.WriteAllBytes(saveFileDialog.FileName, fileData);
            }
        }

        #endregion 震动，文件保存

        private void ChatServer_Resize(object sender, EventArgs e)
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