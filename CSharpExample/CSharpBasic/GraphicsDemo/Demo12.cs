using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo12 : Form
    {
        public Demo12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue, 5);
            g.DrawLine(p, new Point(15, 15), new Point(15, 145));
        }
    }
}