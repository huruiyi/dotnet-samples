using System;
using System.Drawing;
using System.Windows.Forms;

namespace HuUtils.Graphicses
{
    public partial class Demo06 : Form
    {
        public Demo06()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float pi = 3.14f;
            System.Drawing.Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            float y1 = 50, y2, x1, x2;
            for (int i = 0; i < 540; i++)
            {
                x1 = (float)i;
                x2 = (float)(i + 1);
                y2 = (float)(50 + 50 * Math.Sin(i / 180.0 * pi));
                g.DrawLine(p, new PointF(x1, y1), new PointF(x2, y2));
                y1 = y2;
            }
        }
    }
}