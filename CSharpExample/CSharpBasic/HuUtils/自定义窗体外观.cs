using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 自定义窗体外观 : Form
    {
        public 自定义窗体外观()
        {
            InitializeComponent();
        }

        private void buttonCustomPosition_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            int.TryParse(textBox1.Text, out x);
            int.TryParse(textBox2.Text, out y);
            自定义窗体 fm = new 自定义窗体(x, y);
            fm.ShowDialog();
        }

        private void buttonCustomShape_Click(object sender, EventArgs e)
        {
            自定义窗体 fm = new 自定义窗体(true);
            fm.ShowDialog();
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            自定义窗体 fm = new 自定义窗体();
            fm.ShowDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 自定义窗体外观_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainForm().Show();
        }
    }
}