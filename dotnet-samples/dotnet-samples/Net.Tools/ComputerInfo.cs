using System;
using System.Management;

namespace Net.Tools
{
    public class ComputerInfo
    {
        public string CpuId;
        public string MacAddress;
        public string DiskId;
        public string IpAddress;
        public string LoginUserName;

        public string SystemType;
        public string TotalPhysicalMemory;
        private static ComputerInfo _instance;

        public static ComputerInfo Instance()
        {
            return _instance ?? (_instance = new ComputerInfo());
        }

        protected ComputerInfo()
        {
            CpuId = GetCpuID();
            MacAddress = GetMacAddress();
            DiskId = GetDiskID();
            IpAddress = GetIPAddress();
            LoginUserName = GetUserName();
            SystemType = GetSystemType();
            TotalPhysicalMemory = GetTotalPhysicalMemory();
        }

        private string GetCpuID()
        {
            try
            {
                //获取CPU序列号代码
                string cpuInfo = "";//cpu序列号
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
        }

        private string GetMacAddress()
        {
            //获取网卡硬件地址
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }

            return mac;
        }

        private string GetIPAddress()
        {
            //获取IP地址
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    //st=mo["IpAddress"].ToString();
                    Array ar = (Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
            }

            return st;
        }

        private string GetDiskID()
        {
            //获取硬盘ID
            String hDid = "";
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                hDid = (string)mo.Properties["Model"].Value;
            }

            return hDid;
        }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        /// <returns></returns>
        private string GetUserName()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["UserName"].ToString();
            }

            return st;
        }

        /// <summary>
        /// PC类型
        /// </summary>
        /// <returns></returns>
        private string GetSystemType()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["SystemType"].ToString();
            }

            return st;
        }

        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns></returns>
        private string GetTotalPhysicalMemory()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }

            return st;
        }
    }
}