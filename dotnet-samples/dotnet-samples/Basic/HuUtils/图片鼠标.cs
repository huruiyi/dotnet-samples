using System.Drawing;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 图片鼠标 : Form
    {
        public 图片鼠标()
        {
            InitializeComponent();
        }

        //设置鼠标按下是否可用
        private bool ismousedown = false;

        private Point zhizheng;//记录鼠标的坐标

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                zhizheng.X = e.X;
                zhizheng.Y = e.Y;
                ismousedown = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismousedown)
            {
                int left = pictureBox1.Left + e.X - zhizheng.X;
                int Right = pictureBox1.Top + e.Y - zhizheng.Y;
                this.pictureBox1.Location = new Point(left, Right);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ismousedown = false;
            }
        }
    }
}