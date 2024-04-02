using System;
using System.Collections.Generic;
using System.Text;

namespace bmwssq
{
    /// <summary>
    /// 注册实体类
    /// </summary>
    public class MyRegCode
    {
        private static bool _isReg = false;//是否注册

        public static bool IsReg
        {
            get { return MyRegCode._isReg; }
            set { MyRegCode._isReg = value; }
        }
        private static int _usedDays;//已用天数

        public static int UsedDays
        {
            get { return MyRegCode._usedDays; }
            set { MyRegCode._usedDays = value; }
        }
        private static string _regName="";//注册名

        public static string RegName
        {
            get { return MyRegCode._regName; }
            set { MyRegCode._regName = value; }
        }
        private static string _email="";//注册信箱

        public static string Email
        {
            get { return MyRegCode._email; }
            set { MyRegCode._email = value; }
        }
        private static string _machineCode;//机器码

        public static string MachineCode
        {
            get { return MyRegCode._machineCode; }
            set { MyRegCode._machineCode = value; }
        }
        private static string _regCode;//注册码

        public static string RegCode
        {
            get { return MyRegCode._regCode; }
            set { MyRegCode._regCode = value; }
        }
        private static string _regDate;//注册时间

        public static string RegDate
        {
            get { return MyRegCode._regDate; }
            set { MyRegCode._regDate = value; }
        }

        private static string _webIndex ="http://bmw-ruanjian.goofar.com";//主页

        public static string WebIndex
        {
            get { return MyRegCode._webIndex; }
            set { MyRegCode._webIndex = value; }
        }
        private static string _snikID = "5";//皮肤id

        public static string SnikID
        {
            get { return MyRegCode._snikID; }
            set { MyRegCode._snikID = value; }
        }
    }
}
