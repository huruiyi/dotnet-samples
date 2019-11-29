using System;
using System.Net;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class IP地址 : Form
    {
        public IP地址()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void btnConvert_Click(object sender, EventArgs e)
        {
            //记得先using System.Net;  再IPHostEntry
            //IPHostEntry host = Dns.Resolve(txtUrl.Text);
            IPHostEntry host = Dns.GetHostEntry(txtUrl.Text);
            foreach (IPAddress add in host.AddressList)
            {
                long ip = add.Address;
                listBox1.Items.Add(add.ToString());
                listBox1.Items.Add(ip.ToString());
            }
            txtName.Text = host.HostName;//得到主机名称，可能与输入的名称不同//如在txtUrl.Text文本框文本框中输入www.baidu.com或www.sina.com
            txtBroad.Text = IPAddress.Broadcast.ToString();//广播地址
        }
    }
}