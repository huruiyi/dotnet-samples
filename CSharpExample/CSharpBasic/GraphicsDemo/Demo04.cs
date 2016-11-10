using System.Drawing;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo04 : Form
    {
        public Demo04()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 3);
            Point[] points = { new Point(30, 30), new Point(60, 30), new Point(60, 100), new Point(30, 100) };
            g.DrawPolygon(p, points);
        }
    }
}