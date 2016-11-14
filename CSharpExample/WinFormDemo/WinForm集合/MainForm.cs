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

        private void button1_Click(object sender, EventArgs e)
        {
            截屏实例 demo = new 截屏实例();
            demo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            调用摄像头实例 demo = new 调用摄像头实例();
            demo.ShowDialog();
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
    }
}