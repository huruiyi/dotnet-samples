using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils.SingleForm
{
    public partial class SingleForm : Form
    {
        public SingleForm()
        {
            InitializeComponent();
        }

        private void cbSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSingle.Checked == true)
            {
                btnOpen.Text = "只开一个窗口";
            }
            else
            {
                btnOpen.Text = "窗口多开";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cbSingle.Checked == true)//如果选择用单例模式,就酱紫楼
            {
                SingleDialog dgsingle = SingleDialog.dg();
                dgsingle.Show();
                MessageBox.Show("如果你看到这个,说明...单例是先显示窗口后,直接执行后续代码的,这是和ShowDialog的不同的地方");
            }
            else//如果不是单例模式,就酱紫喽
            {
                SingleDialog dgmulity = SingleDialog.dlg();
                dgmulity.Show();
            }
        }
    }
}
