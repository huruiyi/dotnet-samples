using System;
using System.Windows.Forms;
using WinFormDemo.DataSynchronization;
using WinFormDemo.SyncAsyncAPMForm;

namespace WinFormDemo
{
    public partial class MainForm : Form
    {
        private void buttonCustomPosition_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            int.TryParse(textBox1.Text, out x);
            int.TryParse(textBox2.Text, out y);
            自定义窗体 fm = new 自定义窗体(x, y);
            fm.ShowDialog();
        }

        private void buttonCustomShape_Click_1(object sender, EventArgs e)
        {
            自定义窗体 fm = new 自定义窗体(true);
            fm.ShowDialog();
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            自定义窗体 fm = new 自定义窗体();
            fm.ShowDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            new 截屏实例().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new 调用摄像头实例().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new 简单委托().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new 无边框移动1().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new 无边框移动2().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new 简易资源管理器().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new 图片操作_数据库().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new 登录窗体().ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new 数据绑定().ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new 无边框移动3().ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new 添加Windows账户().ShowDialog();
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
            new APM实例().ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new Async实例().ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new Sync实例().ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new DSForm1().ShowDialog();
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
            new Notepad().ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
        }
    }
}