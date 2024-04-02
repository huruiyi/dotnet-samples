using System;
using System.Windows.Forms;

namespace WfApp
{
    public partial class 移动设备插拔监控 : Form
    {
        public 移动设备插拔监控()
        {
            InitializeComponent();
        }

        public Message mm;

        protected override void WndProc(ref Message m) //监视Windows消息
        {
            const int WM_DEVICECHANGE = 0x219;
            const int WM_DEVICEARRVIAL = 0x8000;//如果m.Msg的值为0x8000那么表示有U盘插入
            const int WM_DEVICEMOVECOMPLETE = 0x8004;
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    {
                        ShowDeviceChanged("WM_DEVICECHANGE");
                        if (m.WParam.ToInt32() == WM_DEVICEARRVIAL)
                            ShowDeviceChanged("WM_DEVICEARRVIAL");
                        else if (m.WParam.ToInt32() == WM_DEVICEMOVECOMPLETE)
                            ShowDeviceChanged("WM_DEVICEMOVECOMPLETE");
                    }
                    break;
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

        public void ShowDeviceChanged(string message)
        {
            switch (message)
            {
                case "WM_DEVICECHANGE":
                    this.textBox_Message.Text += "Device Changed \r\n";
                    break;

                case "WM_DEVICEMOVECOMPLETE":
                    this.textBox_Message.Text += "Device Moved\r\n";
                    break;

                case "WM_DEVICEARRVIAL":
                    this.textBox_Message.Text += "Device Arrived\r\n";
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WndProc(ref mm);
        }
    }
}