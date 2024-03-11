using System.Drawing;
using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动6 : Form
    {
        public 无边框移动6()
        {
            InitializeComponent();
        }

        public static Point CPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mp = Control.MousePosition;
                mp.Offset(CPoint.X, CPoint.Y);
                this.DesktopLocation = mp;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CPoint = new Point(-e.X, -e.Y);
        }
    }
}