using System;
using System.Windows.Forms;

namespace 观察者
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObsolotoMgr.Action();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ObsolotoMgr.objHandler += XP;
            ObsolotoMgr.objHandler += WarkUp;
        }

        private void XP()
        {
            MessageBox.Show("吓跑贼...");
        }

        private void WarkUp()
        {
            MessageBox.Show("惊醒主人...");
        }
    }
}