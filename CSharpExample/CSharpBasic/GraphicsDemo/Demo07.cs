using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo07 : Form
    {
        public Demo07()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsPath path = new GraphicsPath();
            Rectangle r1 = new Rectangle(20, 20, 100, 50);
            Rectangle r2 = new Rectangle(40, 45, 60, 90);
            Rectangle r3 = new Rectangle(50, 50, 260, 190);
            path.AddEllipse(r1);
            path.AddRectangle(r2);
            path.AddPie(r3, 30, 30);
            PathGradientBrush brush1 = new PathGradientBrush(path);
            brush1.CenterPoint = new Point(80, 80);
            brush1.CenterColor = Color.Yellow;
            brush1.SurroundColors = new Color[] { Color.Red, Color.Green };
            g.FillRectangle(brush1, 20, 20, 500, 500);
        }
    }
}