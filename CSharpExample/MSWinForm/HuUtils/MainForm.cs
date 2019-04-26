using HuUtils.AlgorithmForm;
using HuUtils.Chat;
using HuUtils.DataSynchronization;
using HuUtils.NoBorder;
using HuUtils.SyncAsyncAPMForm;
using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class MainForm : Form
    {
        #region 无边框窗体移动

        private const int WM_SYSCOMMAND = 0x0112;//点击窗口左上角那个图标时的系统信息
        private const int SC_MOVE = 0xF010;//移动信息
        private const int HTCAPTION = 0x0002;//表示鼠标在窗口标题栏时的系统信息
        private const int WM_NCHITTEST = 0x84;//鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int HTCLIENT = 0x1;//表示鼠标在窗口客户区的系统消息
        private const int SC_MAXIMIZE = 0xF030;//最大化信息
        private const int SC_MINIMIZE = 0xF020;//最小化信息

        public static bool Flag = false;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    if (m.WParam == (IntPtr)SC_MAXIMIZE)
                    {
                        m.WParam = (IntPtr)SC_MINIMIZE;
                    }
                    break;

                case WM_NCHITTEST: //如果鼠标移动或单击
                    base.WndProc(ref m);//调用基类的窗口过程——WndProc方法处理这个消息
                    if (m.Result == (IntPtr)HTCLIENT)//如果返回的是HTCLIENT
                    {
                        m.Result = (IntPtr)HTCAPTION;//把它改为HTCAPTION
                        return;//直接返回退出方法
                    }
                    break;
            }
            base.WndProc(ref m);//如果不是鼠标移动或单击消息就调用基类的窗口过程进行处理
        }

        #endregion 无边框窗体移动

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)

        {
            int WM_KEYDOWN = 256;

            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)

            {
                switch (keyData)

                {
                    case Keys.Escape:

                        this.Close();//esc关闭窗体

                        break;
                }
            }

            return false;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new 截屏实例().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new 调用摄像头实例().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new 简单委托().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new 闪屏().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new 线程抽奖().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new 简易资源管理器().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new 图片操作_数据库().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new 登录窗体().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new 数据绑定().Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            new 无边框移动().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new 添加Windows账户().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
            System.Diagnostics.Process.Start("explorer.exe", "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");

            // System.Diagnostics.Process.Start("explorer.exe");
            System.Diagnostics.Process.Start("explorer.exe", " ::{450D8FBA-AD25-11D0-98A8-0800361B1103}");

            //var s3 = new ActiveXObject("wscript.shell");
            //s3.run("explorer.exe ::{450D8FBA-AD25-11D0-98A8-0800361B1103}");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new APM实例().Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new Async实例().Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Sync实例().Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new DsForm1().Show();
            new DsForm34().Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("用户名或密码错误！", "错误信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("你点击了yes");
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("你点击了no");
            }
            else
            {
                MessageBox.Show("你点击了Cancel");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            new Notepad().Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            new SymmetricAlgorithmForm().Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            new AsymmetricAlgorithmForm().Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            new TreeViewDemo().Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            new 自定义窗体外观().Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            new 验证码().Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            new ShellDemo().Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            new 翻译案例().Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            new GitOp().Show();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            new ChatServer().Show();
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            new BaseComponent.ComponentForm().Show();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            new DynamicButton().Show();
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            new LicGenForm().Show();
        }
    }
}