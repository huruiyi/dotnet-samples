using System;
using System.Windows.Forms;

namespace 登陆窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                Program.b = true;
                this.Close();
            }
        }
    }
}