using System;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace HuUtils.SystemManager
{
    public partial class USBMinitor02 : Form
    {
        public USBMinitor02()
        {
            InitializeComponent();
        }

        public const int WM_DEVICECHANGE = 0x219;//U盘插入后，OS的底层会自动检测到，然后向应用程序发送“硬件设备状态改变“的消息

        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        //A request to change the current configuration (dock or undock) has been canceled.

        public const int DBT_CONFIGCHANGED = 0x0018;
        //The current configuration has changed, due to a dock or undock.

        public const int DBT_CUSTOMEVENT = 0x8006;
        //A custom event has occurred.

        public const int DBT_DEVICEARRIVAL = 0x8000;
        //A device or piece of media has been inserted and is now available.

        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        //Permission is requested to remove a device or piece of media. Any application can deny this request and cancel the removal.

        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        //A request to remove a device or piece of media has been canceled.

        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        //A device or piece of media has been removed.

        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        //A device or piece of media is about to be removed. Cannot be denied.

        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        //A device-specific event has occurred.

        public const int DBT_DEVNODES_CHANGED = 0x0007;
        //A device has been added to or removed from the system.

        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        //Permission is requested to change the current configuration (dock or undock).

        public const int DBT_USERDEFINED = 0xFFFF;
        //The meaning of this message is user-defined.

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICEARRIVAL://U盘插入
                        DriveInfo[] uin = DriveInfo.GetDrives();
                        foreach (DriveInfo drive in uin)
                        {
                            txtInfo.AppendText("U盘已插入，盘符为:" + drive.Name + Environment.NewLine);
                        }
                        break;

                    case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                        this.Text = "！";
                        txtInfo.AppendText("U盘被拔出:" + Environment.NewLine);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //string Namespace = @"root\cimv2";
            //string diskDriveQuery = "SELECT * FROM meta_class WHERE __class = 'Win32_LogicalDisk'";

            //Win32_DiskDrive  / Win32_LogicalDisk
            ManagementClass mc = new ManagementClass("Win32_Account");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (PropertyData data in mo.Properties)
                {
                    string dataName = data.Name;
                    CimType dataType = data.Type;
                    object value = mo.Properties[dataName].Value;
                    txtInfo.AppendText(dataName + "\t\t" + dataType + "\t\t" + value + Environment.NewLine);
                }

                //propertyInfo = ;
            }
        }
    }
}