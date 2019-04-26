using System;
using System.Windows.Forms;

namespace HuUtils.BaseComponent
{
    public partial class ComponentForm : Form
    {
        public ComponentForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "666666")
            {
                MainForm.Flag = true;
                this.Close();
                new Form1().Show();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
