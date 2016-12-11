using System;
using System.Drawing;
using System.Windows.Forms;

namespace day0415
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "abc" && txtPwd.Text == "123")
            {
                Program.IsValid = true;
                this.Close();
            }
            else
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
        }

        //private void txtName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (!((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)))
        //    {
        //        MessageBox.Show("你按下的不是数字键！");
        //    }
        //}

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //MessageBox.Show("你点击Enter键");
                txtName.ForeColor = Color.Red;
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                MessageBox.Show("你点击了A键");
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            int code = (int)(Convert.ToChar(txtPwd.Text.Substring(txtPwd.Text.Length - 1)));
            if (code < 48 || code > 57)
            {
                txtPwd.Text = txtPwd.Text.Substring(0, txtPwd.Text.Length - 1);
            }
        }
    }
}