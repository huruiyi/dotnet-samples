using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDPChat
{
    public partial class Form1 : Form
    {
        #region 状态控制

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

        #endregion 状态控制

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        private UdpClient udpcSend;

        /// <summary>
        /// 用于UDP接收的网络服务类
        /// </summary>
        private UdpClient udpcRecv;

        /// <summary>
        /// 按钮：发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSendMssg.Text))
            {
                MessageBox.Show("请先输入待发送内容");
                return;
            }

            // 匿名发送
            //udpcSend = new UdpClient(0);             // 自动分配本地IPv4地址

            IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(txtIp.Text), Convert.ToInt32(txtPort.Text)); // 本机IP，指定的端口号
            udpcSend = new UdpClient(localIpep);

            Thread thrSend = new Thread(SendMessage);
            thrSend.Start(txtSendMssg.Text);

            Thread thrReceive = new Thread(ReveiveMessage);
            thrReceive.Start();
        }

        private void ReveiveMessage(object obj)
        {
            //IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(txtClentIp.Text), Convert.ToInt32(txtClientPort.Text));
            //byte[] receiveByte = udpcSend.Receive(ref remoteIpep);
            //string reeiveMsg = Encoding.Unicode.GetString(receiveByte);
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            string message = (string)obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);

            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(txtClentIp.Text), Convert.ToInt32(txtClientPort.Text));

            udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
            udpcSend.Close();

            ResetTextBox(txtSendMssg);
        }

        /// <summary>
        /// 开关：在监听UDP报文阶段为true，否则为false
        /// </summary>
        private bool IsUdpcRecvStart = false;

        /// <summary>
        /// 线程：不断监听UDP报文
        /// </summary>
        private Thread thrRecv;

        /// <summary>
        /// 按钮：接收数据开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecv_Click(object sender, EventArgs e)
        {
            if (!IsUdpcRecvStart) // 未监听的情况，开始监听
            {
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(txtClentIp.Text), Convert.ToInt32(txtClientPort.Text)); // 本机IP和监听端口号

                udpcRecv = new UdpClient(localIpep);

                thrRecv = new Thread(ReceiveMessage);
                thrRecv.Start();

                IsUdpcRecvStart = true;
                ShowMessage(txtRecvMssg, "UDP监听器已成功启动");
            }
            else
            {
                thrRecv.Abort();
                udpcRecv.Close();

                IsUdpcRecvStart = false;
                ShowMessage(txtRecvMssg, "UDP监听器已成功关闭");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="obj"></param>
        private void ReceiveMessage(object obj)
        {
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                    string message = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);

                    ShowMessage(txtRecvMssg, string.Format("{0}[{1}]", remoteIpep, message));
                }
                catch (Exception ex)
                {
                    ShowMessage(txtRecvMssg, ex.Message);
                    break;
                }
            }
        }

        // 向TextBox中添加文本
        private delegate void ShowMessageDelegate(TextBox txtbox, string message);

        private void ShowMessage(TextBox txtbox, string message)
        {
            if (txtbox.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                txtbox.Invoke(showMessageDelegate, new object[] { txtbox, message });
            }
            else
            {
                txtbox.Text += message + "\r\n";
            }
        }

        // 清空指定TextBox中的文本
        private delegate void ResetTextBoxDelegate(TextBox txtbox);

        private void ResetTextBox(TextBox txtbox)
        {
            if (txtbox.InvokeRequired)
            {
                ResetTextBoxDelegate resetTextBoxDelegate = ResetTextBox;
                txtbox.Invoke(resetTextBoxDelegate, new object[] { txtbox });
            }
            else
            {
                txtbox.Text = "";
            }
        }

        /// <summary>
        /// 关闭程序，强制退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}