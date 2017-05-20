using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 无边框移动4 : Form
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                SendMessage(Handle, a, b, 0);
            }
            else
            {
                this.Close();          // 右键可以退出
            }
        }

        private const int a = 0xA1;
        private const int b = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public 无边框移动4()
        {
            InitializeComponent();
        }
    }
}