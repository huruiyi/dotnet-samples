using System;
using System.Windows.Forms;

namespace WinForm集合
{
    public partial class MainForm : Form
    {
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
    }
}