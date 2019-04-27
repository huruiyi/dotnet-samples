using System;
using System.Drawing;
using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动1 : Form
    {
        public 无边框移动1()
        {
            InitializeComponent();
        }

        private bool IsMouseDown = false;
        private Point mouseOffset;

        private void 无边框移动1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void 无边框移动1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void 无边框移动1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = true;
            }
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.Cursor = Cursors.Arrow;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("是否退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dir == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}