using System;
using System.Management;

using Microsoft.Win32;

namespace SearchApp
{
    public class MyRegistry
    {
        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns>硬盘的卷标号</returns>
        private string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetWorkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("WIn32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 取得CPU的序列号
        /// </summary>
        /// <returns>CPU的序列号</returns>
        private string GetCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuCollection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuCollection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        /// <summary>
        /// 返回机器码
        /// </summary>
        /// <returns>机器码</returns>
        public string GetMachineCode()
        {
            string ascii = GetDiskVolumeSerialNumber() + GetCpu();

            var registryAscii = RegInPassword(ascii);
            return registryAscii;
        }

        /// <summary>
        /// 生成加密的机器码
        /// </summary>
        /// <param name="ascii">加密的机器码</param>
        public string RegInPassword(string ascii)
        {
            string regInPasswordString = "";
            char[] charID = new char[24];
            for (int i = 0; i < 24; i++)
            {
                charID[i] = Convert.ToChar(ascii.Substring(i, 1));
                int charIdToInt = Convert.ToInt32(charID[i]) + 5;
                if (charIdToInt >= 48 && charIdToInt <= 57 ||
                    charIdToInt >= 65 && charIdToInt <= 90 ||
                    charIdToInt >= 97 && charIdToInt <= 122
                    )
                {
                    regInPasswordString += Convert.ToChar(charIdToInt).ToString();
                }
                else
                {
                    if (charIdToInt > 122)
                    {
                        regInPasswordString += Convert.ToChar(charIdToInt - 10).ToString();
                    }
                    else
                    {
                        regInPasswordString += Convert.ToChar(charIdToInt - 9).ToString();
                    }
                }
            }
            return regInPasswordString;
        }

        /// <summary>
        /// 设置试用次数
        /// </summary>
        /// <returns>已用次数</returns>
        public int SetRegedit()
        {
            int tLong = 0;

            try
            {
                var res = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BMW");
                if (res == null)
                {
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\BMW");
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\BMW", "UseTimes", 0);
                }
                else
                {
                    tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\BMW", "UseTimes", 0);
                    if (tLong < 100000000)
                    {
                        int time = tLong + 1;
                        Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\BMW", "UseTimes", time);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tLong;
        }
    }
}