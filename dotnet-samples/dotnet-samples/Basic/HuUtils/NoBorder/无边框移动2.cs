﻿using System;
using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动2 : Form
    {
        public 无边框移动2()
        {
            InitializeComponent();
        }

        private const int WmSyscommand = 0x0112;          //点击窗口左上角那个图标时的系统信息
        private const int ScMove = 0xF010;                //移动信息
        private const int Htcaption = 0x0002;             //表示鼠标在窗口标题栏时的系统信息
        private const int WmNchittest = 0x84;             //鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int Htclient = 0x1;                 //表示鼠标在窗口客户区的系统消息
        private const int ScMaximize = 0xF030;            //最大化信息
        private const int ScMinimize = 0xF020;            //最小化信息

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WmSyscommand:
                    if (m.WParam == (IntPtr)ScMaximize)
                    {
                        m.WParam = (IntPtr)ScMinimize;
                    }
                    break;

                case WmNchittest: //如果鼠标移动或单击
                    base.WndProc(ref m);//调用基类的窗口过程——WndProc方法处理这个消息
                    if (m.Result == (IntPtr)Htclient)//如果返回的是HTCLIENT
                    {
                        m.Result = (IntPtr)Htcaption;//把它改为HTCAPTION
                        return;//直接返回退出方法
                    }
                    break;
            }
            base.WndProc(ref m);//如果不是鼠标移动或单击消息就调用基类的窗口过程进行处理
        }
    }
}