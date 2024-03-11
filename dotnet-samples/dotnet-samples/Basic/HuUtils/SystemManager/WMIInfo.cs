using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HuUtils.SystemManager
{
    public partial class WMIInfo : Form
    {
        public WMIInfo()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_VOLUME
        {
            public int dbcv_size;
            public int dbcv_devicetype;
            public int dbcv_reserved;
            public int dbcv_unitmask;
        }

        protected override void WndProc(ref Message m)
        {
            // 发生设备变动
            const int WM_DEVICECHANGE = 0x0219;
            // 系统检测到一个新设备
            const int DBT_DEVICEARRIVAL = 0x8000;
            // 系统完成移除一个设备
            const int DBT_DEVICEREMOVECOMPLETE = 0x8001;
            // 逻辑卷标
            const int DBT_DEVTYP_VOLUME = 0x00000002;
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch (m.WParam.ToInt32())
                    {
                        case DBT_DEVICEARRIVAL:
                            int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME)
                            {
                                DEV_BROADCAST_VOLUME vol;
                                vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(
                                 m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                MessageBox.Show(vol.dbcv_unitmask.ToString("x"));
                            }
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            MessageBox.Show("Removal");
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        #region 取得windows的所有进程

        public static string GetCourse()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string tempName = "";
            int begpos, endpos;
            foreach (System.Diagnostics.Process thisProc in System.Diagnostics.Process.GetProcesses())
            {
                tempName = thisProc.ToString();
                begpos = tempName.IndexOf("(") + 1;
                endpos = tempName.IndexOf(")");
                tempName = tempName.Substring(begpos, endpos - begpos);
                sb.Append(tempName + "<br /> ");
            }
            return sb.ToString();
        }

        #endregion 取得windows的所有进程

        /// <summary>
        /// 判断一个磁盘驱动器的类型
        /// </summary>
        /// <param name="nDrive">包含了驱动器根目录路径的一个字串</param>
        /// <returns>Long，如驱动器不能识别，则返回零。如指定的目录不存在，则返回1。如执行成功，则用下述任何一个常数指定驱动器类型：DRIVE_REMOVABLE， DRIVE_FIXED， DRIVE_REMOTE， DRIVE_CDROM 或 DRIVE_RAMDISK</returns>
        [DllImport("Kernel32.dll", EntryPoint = "0", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long GetDriveType(string nDrive);

        #region 用C#获取硬盘序列号,CPU序列号,网卡MAC地址的源码

        private string[] GetMoc()
        {
            string[] str = new string[3];
            ManagementClass mcCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection mocCpu = mcCpu.GetInstances();
            foreach (ManagementObject m in mocCpu)
            {
                str[0] = m["ProcessorId"].ToString();
            }

            ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
            ManagementObjectCollection mocHD = mcHD.GetInstances();
            foreach (ManagementObject m in mocHD)
            {
                if (m["DeviceID"].ToString() == "C:")
                {
                    str[1] = m["VolumeSerialNumber"].ToString();
                    break;
                }
            }

            ManagementClass mcMAC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mocMAC = mcMAC.GetInstances();
            foreach (ManagementObject m in mocMAC)
            {
                if ((bool)m["IPEnabled"])
                {
                    str[2] = m["MacAddress"].ToString();
                    break;
                }
            }

            return str;
        }

        #endregion 用C#获取硬盘序列号,CPU序列号,网卡MAC地址的源码

        #region 获取U盘序列号

        private List<string> _serialNumber = new List<string>();

        /// <summary>
        /// 调用这个函数将本机所有U盘序列号存储到_serialNumber中
        /// </summary>
        private void matchDriveLetterWithSerial()
        {
            string[] diskArray;
            string driveNumber;
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
            foreach (ManagementObject dm in searcher.Get())
            {
                getValueInQuotes(dm["Dependent"].ToString());
                diskArray = getValueInQuotes(dm["Antecedent"].ToString()).Split(',');
                driveNumber = diskArray[0].Remove(0, 6).Trim();
                var disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject disk in disks.Get())
                {
                    if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber) & disk["InterfaceType"].ToString() == "USB")
                    {
                        _serialNumber.Add(parseSerialFromDeviceID(disk["PNPDeviceID"].ToString()));
                    }
                }
            }
        }

        private static string parseSerialFromDeviceID(string deviceId)
        {
            var splitDeviceId = deviceId.Split('\\');
            var arrayLen = splitDeviceId.Length - 1;
            var serialArray = splitDeviceId[arrayLen].Split('&');
            var serial = serialArray[0];
            return serial;
        }

        private static string getValueInQuotes(string inValue)
        {
            var posFoundStart = inValue.IndexOf("\"");
            var posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);
            var parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);
            return parsedValue;
        }

        #endregion 获取U盘序列号

        public void Test2()
        {
            matchDriveLetterWithSerial();
            string[] aa = _serialNumber.ToArray();
            for (int i = 0; i < aa.Length; i++)
            {
                aa[i].ToString(); //这里就可以拿出现在所有的U盘序列号
            }
        }

        private void LocalDisk()
        {
            WqlObjectQuery wmiquery = new WqlObjectQuery("select * from Win32_LogiCalDisk");
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher(wmiquery);
            //显示
            ShowInfo(wmifind);
        }

        //远程
        private void RemoteDisk()
        {
            string ip = "114.216.27.167";
            string username = "huruiyi";
            string password = "hu629727!";
            ConnectionOptions conn = new ConnectionOptions();
            conn.Username = username;
            conn.Password = password;
            conn.Timeout = new TimeSpan(1, 1, 1, 1);//连接时间
                                                    //ManagementScope 的服务器和命名空间。
            string path = string.Format(@"\\{0}\root\cimv2", ip);
            //表示管理操作的范围（命名空间）,使用指定选项初始化ManagementScope 类的、表示指定范围路径的新实例。
            ManagementScope scope = new ManagementScope(path, conn);
            scope.Connect();
            //查询
            string strQuery = "select * from Win32_LogicalDisk ";
            ObjectQuery query = new ObjectQuery(strQuery);
            //查询ManagementObjectCollection返回结果集
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher(scope, query);
            ShowInfo(wmifind);
        }

        #region 显示磁盘信息

        private void ShowInfo(ManagementObjectSearcher wmifind)
        {
            long gb = 1024 * 1024 * 1024;
            string type = "";
            string str = "";
            double freePath = 0d;
            foreach (var mobj in wmifind.Get())
            {
                type = mobj["Description"].ToString();
                //判断是否是本机固盘
                if (type == "Local Fixed Disk")
                {
                    str = " 磁盘名称:" + mobj["Name"].ToString();
                    freePath = Math.Round(Convert.ToDouble(mobj["FreeSpace"]) / gb, 1);
                    str += " 可用空间:" + freePath + "G";
                    str += " 实际大小:" + Math.Round(Convert.ToDouble(mobj["Size"].ToString()) / gb, 1) + "G";
                    if (freePath < 20)
                    {
                        str += " ----请尽快清理!";
                    }
                    MessageBox.Show(str);
                }
            }
        }

        #endregion 显示磁盘信息
    }
}