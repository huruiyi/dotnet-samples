using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo11 : Form
    {
        public Demo11()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 5);
            p.DashStyle = DashStyle.DashDotDot;
            g.DrawLine(p, new Point(45, 45), new Point(145, 145));
            //----设置线段两个端点的形状--------
            p.StartCap = LineCap.RoundAnchor;//指定线段起始端为圆形
            p.EndCap = LineCap.DiamondAnchor;//指定线段终止段为菱形
            g.DrawLine(p, new Point(150, 50), new Point(250, 50));
        }
    }
}