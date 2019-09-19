using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动 : Form
    {
        public 无边框移动()
        {
            InitializeComponent();
        }

        private void 无边框移动_FormClosed(object sender, FormClosedEventArgs e)
        {
            new AppMain().Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            new 无边框移动1().Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            new 无边框移动2().Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            new 无边框移动3().Show();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            new 无边框移动4().Show();
        }
    }
}