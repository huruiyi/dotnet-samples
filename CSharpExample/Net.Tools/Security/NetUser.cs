using System;
using System.Runtime.InteropServices;

namespace Net.Tools.Security
{
    public class NetUser
    {
        //创建用户
        [DllImport("Netapi32.dll")]
        private static extern int NetUserAdd([MarshalAs(UnmanagedType.LPWStr)] string sName, int level, ref UserInfo1 buf, int parmErr);

        //修改用户密码
        [DllImport("Netapi32.dll")]
        private static extern int NetUserChangePassword([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string userName, [MarshalAs(UnmanagedType.LPWStr)] string oldPassword, [MarshalAs(UnmanagedType.LPWStr)] string newPassword);

        //删除用户
        [DllImport("Netapi32.dll")]
        private static extern int NetUserDel([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string userName);

        //枚举全部用户
        [DllImport("Netapi32.dll")]
        private static extern int NetUserEnum([MarshalAs(UnmanagedType.LPWStr)] string sName, int level, int filter, out IntPtr bufPtr, int prefmaxlen, out int entriesread, out int totalentries, out int resumeHandle);

        //获取用户信息
        [DllImport("Netapi32.dll")]
        private static extern int NetUserGetInfo([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string userName, int level, out IntPtr intptr);

        //获取用户所在本地组
        [DllImport("Netapi32.dll")]
        private static extern int NetUserGetLocalGroups([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string userName, int level, int flags, out IntPtr intptr, int prefmaxlen, out int entriesread, out int totalentries);

        //修改用户信息
        [DllImport("Netapi32.dll")]
        private static extern int NetUserSetInfo([MarshalAs(UnmanagedType.LPWStr)] string sName, [MarshalAs(UnmanagedType.LPWStr)] string userName, int level, ref UserInfo1 bufptr, int parmErr);

        //释放API
        [DllImport("Netapi32.dll")]
        private static extern int NetApiBufferFree(IntPtr buffer);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LocalgroupUsersInfo0
        {
            public string GroupName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct UserInfo1
        {
            public string sName;    //用户名
            public string sPass;    //用户密码
            public int PasswordAge; //密码级别
            public int sPriv;       //帐户类型 1
            public string sHomeDir; //用户主目录 null
            public string sComment; //用户描述
            public int sFlags;      //用户权限
            public string sScriptPath;  //登陆脚本路径 null
        }

        //枚举全部用户
        public string UserEnum()
        {
            string tempStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tempStr += "<INFO>\r\n";
            int entriesread;
            int totalEntries;
            int resumeHandle;
            IntPtr bufPtr;
            if (NetUserEnum(null, 1, 0, out bufPtr, -1, out entriesread, out totalEntries, out resumeHandle) != 0)
            {
                throw (new Exception("枚举全部用户失败"));
            }
            if (entriesread > 0)
            {
                UserInfo1[] userInfo = new UserInfo1[entriesread];
                IntPtr iter = bufPtr;
                for (int i = 0; i < entriesread; i++)
                {
                    userInfo[i] = (UserInfo1)Marshal.PtrToStructure(iter, typeof(UserInfo1));
                    iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(UserInfo1)));
                    tempStr += "<ITEM value=\"" + userInfo[i].sComment + "\">" + userInfo[i].sName + "</ITEM>\r\n";
                }
                tempStr += "</INFO>";
            }
            NetApiBufferFree(bufPtr);
            return tempStr;
        }

        //读取用户信息
        public string UserGetInfo(string userName)
        {
            string tmpStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tmpStr += "<INFO>\r\n";
            IntPtr bufPtr;
            if (NetUserGetInfo(null, userName, 1, out bufPtr) != 0)
            {
                throw (new Exception("读取用户信息失败"));
            }
            UserInfo1 userInfo = (UserInfo1)Marshal.PtrToStructure(bufPtr, typeof(UserInfo1));
            tmpStr += "<NAME>" + userInfo.sName + "</NAME>\r\n";
            tmpStr += "<PASS>" + userInfo.sPass + "</PASS>\r\n";
            tmpStr += "<DESC>" + userInfo.sComment + "</DESC>\r\n";
            tmpStr += "</INFO>";
            NetApiBufferFree(bufPtr);
            return tmpStr;
        }

        //删除用户
        public bool UserDelete(string userName)
        {
            return NetUserDel(null, userName) > 0;
        }

        //修改用户信息
        public bool UserSetInfo(string userName, string newUserName, string userPass, string sDescription)
        {
            UserInfo1 userInfo = new UserInfo1
            {
                sName = newUserName,
                sPass = userPass,
                PasswordAge = 0,
                sPriv = 1,
                sHomeDir = null,
                sComment = sDescription,
                sFlags = 0x10040,
                sScriptPath = null
            };
            if (NetUserSetInfo(null, userName, 1, ref userInfo, 0) != 0)
            {
                throw (new Exception("用户信息修改失败"));
            }
            return true;
        }

        //创建系统用户
        public bool UserAdd(string userName, string userPass, string sDescription)
        {
            UserInfo1 userInfo = new UserInfo1
            {
                sName = userName,
                sPass = userPass,
                PasswordAge = 0,
                sPriv = 1,
                sHomeDir = null,
                sComment = sDescription,
                sFlags = 0x10040,
                sScriptPath = null
            };
            //UserInfo.sFlags = 0x0040;
            if (NetUserAdd(null, 1, ref userInfo, 0) != 0)
            {
                throw (new Exception("创建系统用户失败"));
            }
            return true;
        }

        //修改用户密码
        public bool UserChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (NetUserChangePassword(null, userName, oldPassword, newPassword) != 0)
            {
                throw (new Exception("修改系统用户密码失败"));
            }
            return true;
        }

        //获取用户全部所在本地组
        public string UserGetLocalGroups(string userName)
        {
            int entriesRead;
            int totalEntries;
            IntPtr bufPtr;
            string tempStr = "<?xml version=\"1.0\" encoding=\"gb2312\" ?>\r\n";
            tempStr += "<INFO>\r\n";
            if (NetUserGetLocalGroups(null, userName, 0, 0, out bufPtr, 1024, out entriesRead, out totalEntries) != 0)
            {
                throw (new Exception("读取用户所在本地组失败"));
            }
            if (entriesRead > 0)
            {
                LocalgroupUsersInfo0[] groupInfo = new LocalgroupUsersInfo0[entriesRead];
                IntPtr iter = bufPtr;
                for (int i = 0; i < entriesRead; i++)
                {
                    groupInfo[i] = (LocalgroupUsersInfo0)Marshal.PtrToStructure(iter, typeof(LocalgroupUsersInfo0));
                    iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(LocalgroupUsersInfo0)));
                    tempStr += "<GROUP>" + groupInfo[i].GroupName + "</GROUP>\r\n";
                }
                tempStr += "</INFO>";
                NetApiBufferFree(bufPtr);
            }
            return tempStr;
        }
    }
}