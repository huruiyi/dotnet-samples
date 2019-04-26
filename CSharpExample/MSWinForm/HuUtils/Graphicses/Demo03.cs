using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HuUtils.Graphicses
{
    public partial class Demo03 : Form
    {
        public Demo03()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            Point p1 = new Point(10, 10);
            Point p2 = new Point(50, 50);

            LinearGradientBrush brush = new LinearGradientBrush(p1, p2, Color.Red, Color.Green);
            Font font = new Font("隶书", 24);
            Point point = new Point(50, 50);
            g.DrawString("这是使用GDI书写的字符串", font, brush, point);
        }
    }
}