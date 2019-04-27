//用于调用串口类函数

using Microsoft.VisualBasic.Devices;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 串口编程实例 : Form
    {
        public 串口编程实例()
        {
            InitializeComponent();
        }

        //设置变量
        public string Port = "com1";                                  //默认串口为1
        public int Rate = 9600;                                           //波特率. 有1200 2400 4800 9600
        public byte BSize = 8;                                            //数据位 8bits
        public int Timeout = 1000;                                     //延时时长  1秒
        public SerialPort SerialPort1 = new SerialPort();      //定义一个串口类的串口变量
        public bool IsCirlce;                                               //是否循环发送
        public Thread ThdSend;                                         //开辟一个专用于发送数据的线程
        public byte[] Recb;                                                 //用于存放接受数据的数组

        private void Form1_Load(object sender, EventArgs e)
        {
            Computer cmbCom = new Computer();
            foreach (string s in cmbCom.Ports.SerialPortNames)
            {
                cmbPort.Items.Add(s);
            }
            IsCirlce = false;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (SerialPort1.IsOpen)
                {
                    SerialPort1.Close();
                    btnOpenPort.Text = "开启串口";
                    txtShow.AppendText("串口被关闭……\r\n");
                }
                else
                {
                    Parity myParity = Parity.None;          //校验位
                    StopBits MyStopBits = StopBits.One;     //停止位

                    SerialPort1.PortName = cmbPort.Text;
                    SerialPort1.BaudRate = Rate;
                    SerialPort1.DataBits = BSize;
                    SerialPort1.Parity = myParity;
                    SerialPort1.StopBits = MyStopBits;
                    SerialPort1.ReadTimeout = Timeout;

                    SerialPort1.Open();

                    btnOpenPort.Text = "关闭串口";
                    txtShow.AppendText("串口成功开启……\r\n");
                }
            }
            catch (Exception ex)
            {
                txtShow.AppendText("异常: " + ex.Message + "\r\n");
            }
        }

        //打开串口
        public bool OpenCom()
        {
            try
            {
                if (SerialPort1.IsOpen)
                {
                    txtShow.AppendText("串口已打开\r\n");
                }
                else
                {
                    SerialPort1.Open();//打开串口
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("错误：" + e.Message);
                return false;
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if (txtSetDataPakge.Text == "")
            { MessageBox.Show("发送数据为空！"); return; }

            ThdSend = new Thread(SendData);
            ThdSend.Start();
        }

        //发送数据函数
        public void SendData()
        {
            if (Convert.ToBoolean(btnSendData.Text == "发送"))
            {
                if (IsCirlce)
                {
                    btnSendData.Invoke(new MethodInvoker(delegate { btnSendData.Text = "停止"; }));

                    while (true)
                    {
                        if (IsCirlce && SerialPort1.IsOpen && (Convert.ToBoolean(btnSendData.Text == "停止")))
                        {
                            SubSendData();
                        }
                        else
                        { goto L1; }
                    }
                }
                else
                {
                    SubSendData();
                }
            }
            else
            {
                btnSendData.Invoke(new MethodInvoker(delegate { btnSendData.Text = "发送"; }));
            }
        L1:
            btnSendData.Invoke(new MethodInvoker(delegate { btnSendData.Text = "发送"; }));
        }

        //发送数据子函数
        public void SubSendData()
        {
            //byte[] ZhengHeHouData = new byte[mycom1.ReadBufferSize];
            //定义一个无空格二位16进制排列的数组，这样可控制用户输入
            byte[] zhengHeHouData = NoSpace_2Hex_SendData_ZhengHe(); //这里是整合后的发送的数组，每二位组成一个16进制的数排列

            try
            {
                SerialPort1.WriteLine(Dis_Package(zhengHeHouData));

                txtShow.Invoke(new MethodInvoker(delegate { txtShow.AppendText("\r\n发送数据！(" + SerialPort1.BytesToWrite + ")：" + Dis_Package(zhengHeHouData)); }));

                Thread.Sleep(Convert.ToInt32(txtTimeCell.Text));
            }

            //mycom1.Read(ZhengHeHouData,1,1);

            //recb = mycom1.BytesToRead;

            //msg.AppendText("\r\n接收到数据包：" + Dis_Package(recb));

            //mycom1.Read(ZhengHeHouData, 0, ZhengHeHouData.Length);

            //if(recb.Length!=0)

            //msg.AppendText("\r\n接收到数据包：" + Dis_Package(recb));
            catch (Exception ex)
            {
                //msg.AppendText("\r\n发送失败！");
                txtShow.Invoke(new MethodInvoker(delegate { txtShow.AppendText("\r\n" + ex.Message); }));
            }
        }

        //去掉发送数组中的空格
        public string Delspace(string txtSendData)
        {
            string sendData = "";
            for (int i = 0; i < txtSendData.Length; i++)  //txt_SendData.Length为发送框内的数据
            {
                if (txtSendData[i] != ' ')
                    sendData += txtSendData[i];
            }
            return sendData;
        }

        //提取数据包--数组函数，返回整合后的数据，无空格二位16进制排列的数组
        public byte[] NoSpace_2Hex_SendData_ZhengHe()
        {
            try
            {
                string noSpaceSendData = Delspace(txtSetDataPakge.Text);   //去掉所有空格，整合数据
                byte[] sendData = new byte[50];
                int j = 0;
                for (int i = 0; i < noSpaceSendData.Length; i = i + 2, j++) //将无空格发送的数据每二位组成一个数，存放在新的数组SendData中
                    sendData[j] = Convert.ToByte(noSpaceSendData.Substring(i, 2), 16);
                byte[] lastSendData = new byte[j];  //Last_SendData最终返回的发送数据
                Array.Copy(sendData, lastSendData, j); //复制整合后的数据，放入最终返回的数组里，以便调用
                return lastSendData;  //最终返回的发送数据
            }
            catch (Exception ex)
            {
                txtShow.AppendText("异常:" + ex.Message);
                return null;
            }
        }

        //显示包信息
        public string Dis_Package(byte[] reb)
        {
            string temp = "";
            foreach (byte b in reb)
                temp += b.ToString("X2") + " "; //以每二位加一个空格显示数据
            return temp;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSetDataPakge.Text = string.Empty;    //清空发送端
            txtShow.Text = string.Empty;            //清空信息列表框
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                Parity myParity = Parity.None;
                StopBits MyStopBits = StopBits.One;

                if (SerialPort1.IsOpen)
                {
                    //msg.AppendText("串口处于开启状态，若要重新更换端口，请先关闭！\r\n");
                    SerialPort1.Close();
                }
                if (cmbPort.Text == "")
                {
                    txtShow.AppendText("串口不能为空，请选择串口！\r\n");
                }
                else
                {
                    SerialPort1.PortName = Convert.ToString(cmbPort.Text);  //1,2,3,4

                    SerialPort1.BaudRate = Convert.ToInt16(txtBuad.Text); //1200,2400,4800,9600
                    SerialPort1.DataBits = Convert.ToByte(txtDatabit.Text, 10); //8 bits
                    SerialPort1.Parity = myParity; // 0-4=no,odd,even,mark,space
                    SerialPort1.StopBits = MyStopBits;
                    //iTimeout=3;
                    txtShow.AppendText(this.OpenCom() ? "串口初始化成功……\r\n" : "串口初始化失败！\r\n");
                }
            }
            catch (Exception ex)
            {
                txtShow.AppendText("异常:" + ex.Message + "\r\n");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialPort1.Close();
        }

        public string SerialReadString;

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialReadString = "";
            SerialReadString += SerialPort1.ReadExisting();
            txtShow.Invoke(new MethodInvoker(delegate { txtShow.AppendText("\r\n接收数据：" + SerialReadString); }));
        }

        //发送文本框内限制输入，须偶数位
        private void t_send_TextChanged(object sender, EventArgs e)
        {
            btnSendData.Enabled = false;
            string sendDataLength = Delspace(txtSetDataPakge.Text);   //去掉所有空格，整合数据

            if (sendDataLength.Length % 2 != 0)
            {
                txtSetDataPakge.Focus();
            }
            else
            {
                btnSendData.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCirlce)
            {
                IsCirlce = false;
            }
            else
            {
                IsCirlce = true;
            }
        }
    }
}