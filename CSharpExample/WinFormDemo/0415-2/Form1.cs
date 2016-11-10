using System;
using System.Windows.Forms;

namespace _0415_2
{
    public partial class Form1 : Form
    {
        public bool tag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "123" && txtPwd.Text == "123")
            {
                Program.IsValid = true;
                this.Close();
            }
            else
            {
                //MessageBox.Show("用户名或密码错误！");
                DialogResult dr = MessageBox.Show("用户名或密码错误！", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                }
                else
                {
                }
            }
        }

        //private void txtName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue < 48 || (e.KeyValue > 57 && e.KeyValue < 96) || e.KeyValue > 105)
        //    {
        //        MessageBox.Show(txtName.Text);

        //    }
        //}

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int keycode=(int)e.KeyChar;
            //if (keycode<48||keycode>57)
            //{
            //    MessageBox.Show(txtName.Text);
            //}
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            tag = false;
            if (e.KeyValue < 48 || (e.KeyValue > 57 && e.KeyValue < 96) || e.KeyValue > 105)
            {
                tag = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(txtName.Text);
            int code = (int)Convert.ToChar(txtName.Text.Substring(txtName.Text.Length - 1));
            if (code < 48 || code > 57)
            {
                txtName.Text = txtName.Text.Substring(0, txtName.Text.Length - 1);
            }
        }
    }
}