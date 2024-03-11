using System;
using System.Windows.Forms;

namespace bmwssq
{
    /// <summary>
    /// 登陆窗体代码
    /// </summary>
    public partial class FrmLogin : Form
    {
        private MyRegistry rsy = new MyRegistry();
        private XMLOperate xo = new XMLOperate();

        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登陆判断项
        /// </summary>
        private void LoginLoad()
        {
            MyRegCode.UsedDays = rsy.setRegedit();
            MyRegCode.MachineCode = rsy.getMachineCode();
            if (xo.xmlReadKey() && MyRegCode.RegCode.Equals(rsy.regInPassword(MyRegCode.MachineCode)))
            {
                xo.xmlLoadConfig();
                MyRegCode.IsReg = true;
                this.lblLoginSay.Text = "注册版\r\n\r\n 注册用户：\r\n  " + MyRegCode.RegName + "\r\n\r\n 注册日期：\r\n  " + MyRegCode.RegDate;
            }
            else
            {
                this.lblLoginSay.Text = "未注册版\r\n\r\n 可试用：10次\r\n\r\n 已试用：" + MyRegCode.UsedDays + "次";
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)//窗体加载
        {
            LoginLoad();
            tmLogin.Enabled = true;
            tmLogin.Interval = 5000;
        }

        private void tmLogin_Tick(object sender, EventArgs e)//时间事件
        {
            this.Close();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)//窗体关闭
        {
            if (MyRegCode.UsedDays >= 10 && !MyRegCode.IsReg)//判断试用次数和是否注册
            {
                Application.Exit();
            }
            else
            {
                frmMain fm = new frmMain();
                fm.Show();
            }
        }

        private void FrmLogin_Click(object sender, EventArgs e)//窗体单击事件
        {
            tmLogin.Enabled = false;
            this.Close();
        }
    }
}