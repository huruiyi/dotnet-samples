using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HuUtils.Graphicses
{
    public partial class Demo05 : Form
    {
        public Demo05()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            //定义圆弧所在椭圆的外接矩形
            Rectangle r = new Rectangle(50, 50, 300, 200);
            Pen p1 = new Pen(Color.Black, 3);//用于绘制坐标系的画笔
            p1.EndCap = LineCap.ArrowAnchor;
            Pen p2 = new Pen(Color.Blue);//绘制外接矩形
            Pen p3 = new Pen(Color.Brown, 5);//用于绘制弧线的画笔
            //确定坐标系原点，即矩形的中心点坐标
            float centerX = (float)((r.Width / 2.0 + r.Left));
            float centerY = (float)((r.Height / 2.0 + r.Top));
            //绘制坐标系
            g.DrawLine(p1, new PointF(centerX - 150, centerY), new PointF(centerX + 150, centerY));
            g.DrawLine(p1, new PointF(centerX, centerY + 100), new PointF(centerX, centerY - 100));
            //绘制外接矩形
            g.DrawRectangle(p2, r);
            g.DrawArc(p3, r, 0, 90);
        }
    }
}