using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 电源管理 : Form
    {
        private int num;
        private int time;
        private int flag;

        public 电源管理()
        {
            InitializeComponent();
        }

        private void Initnum()
        {
            if (textBox1.Text.Length == 0)
            {
                if (MessageBox.Show("请输入时间！", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    textBox1.Focus();
                }
            }
            else
            {
                num = Convert.ToInt32(textBox1.Text);
                time = num * 60;
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initnum();
            flag = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Initnum();
            flag = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Initnum();
            flag = 3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            int min = time / 60;
            int second = time % 60;
            if (min.ToString().Length == 1)
            {
                maskedTextBox1.Text = "0" + min + second;
            }
            if (second.ToString().Length == 1)
            {
                maskedTextBox1.Text = min + "0" + second;
            }
            if (min.ToString().Length == 1 && second.ToString().Length == 1)
            {
                maskedTextBox1.Text = "0" + min + "0" + second;
            }
            if (time == 0)
            {
                timer1.Enabled = false;
                switch (flag)
                {
                    case 1:
                        Process.Start("shutdown", "-s -t 0");
                        break;

                    case 2:
                        Process.Start("shutdown", "-i");
                        break;

                    case 3:
                        Process.Start("shutdown", "-r -t 0");
                        break;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                e.Handled = true;
            }
            if (textBox1.SelectionStart == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }
    }
}