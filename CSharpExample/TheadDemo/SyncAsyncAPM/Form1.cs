using System;
using System.Windows.Forms;

namespace SyncAsyncAPM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Demo_APM apmForm = new Demo_APM();
            apmForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Demo_Async asyncForm = new Demo_Async();
            asyncForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Demo_Sync syncDemo = new Demo_Sync();
            syncDemo.ShowDialog();
        }
    }
}