using System;
using System.Windows.Forms;

namespace HuUtils
{
    public class BaseForm : Form
    {
        #region 无边框窗体移动

        private const int WmSyscommand = 0x0112;    //点击窗口左上角那个图标时的系统信息
        private const int ScMove = 0xF010;                    //移动信息
        private const int Htcaption = 0x0002;                //表示鼠标在窗口标题栏时的系统信息
        private const int WmNchittest = 0x84;               //鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int Htclient = 0x1;                         //表示鼠标在窗口客户区的系统消息
        private const int ScMaximize = 0xF030;             //最大化信息
        private const int ScMinimize = 0xF020;              //最小化信息
        public static bool Flag = false;

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

                case WmNchittest:
                    base.WndProc(ref m);
                    if (m.Result == (IntPtr)Htclient)
                    {
                        m.Result = (IntPtr)Htcaption;
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        #endregion 无边框窗体移动

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}