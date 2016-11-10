using System;
using System.Windows.Forms;

namespace 事件委托_自定义控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginControl.Logn = MyLogin;
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
            loginControl.Logn("123", "123");
        }
    }
}