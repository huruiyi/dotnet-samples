using System;
using System.Windows.Forms;

namespace day0423
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1
            {
                MdiParent = this,
                Name = "Form1"
            };
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2
            {
                MdiParent = this,
                Name = "Form2"
            };
            f.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3
            {
                MdiParent = this,
                Name = "Form3"
            };
            f.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4
            {
                MdiParent = this,
                Name = "Form4"
            };
            f.Show();
        }
    }
}