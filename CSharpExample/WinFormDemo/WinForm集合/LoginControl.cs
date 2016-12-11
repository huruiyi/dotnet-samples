using System;
using System.Windows.Forms;

namespace WinForm集合
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        public delegate void DelLogin(string str1, string str2);

        public DelLogin Logn;

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text.Trim()) || string.IsNullOrEmpty(UserPwd.Text.Trim()))
            {
                MessageBox.Show(@"用户名或密码不能为空");
            }
            if (Logn != null)
            {
                Logn(UserName.Text, UserPwd.Text);
            }
        }
    }
}