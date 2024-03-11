using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 登录窗体 : Form
    {
        public 登录窗体()
        {
            InitializeComponent();
        }

        private void 登录窗体_Load(object sender, EventArgs e)
        {
            loginControl1.Logn = MyLogin;
        }

        public void MyLogin(string name, string pwd)
        {
            if (name == "123" && pwd == "123")
            {
                MessageBox.Show(@"登陆成功");
            }
            else
            {
                MessageBox.Show(@"登录失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginControl1.Logn("123", "123");
        }
    }
}