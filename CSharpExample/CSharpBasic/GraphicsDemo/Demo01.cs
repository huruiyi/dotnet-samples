using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo01 : Form
    {
        public Demo01()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, 300, 200);
            Pen p1 = new Pen(Color.Red);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            g.DrawPath(p1, path);

            Matrix m = new Matrix();
            m.Translate(300, 0);
            m.Rotate(30);
            path.Transform(m);
            g.DrawPath(p1, path);
        }
    }
}