using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HuUtils.Graphicses
{
    public partial class Demo02 : Form
    {
        public Demo02()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;

            Rectangle rect = new Rectangle(20, 20, 100, 100);//绘制一个矩形
            Pen p1 = new Pen(Color.Red);
            g.DrawRectangle(p1, rect);

            Rectangle rect2 = new Rectangle(70, 70, 100, 100);//绘制一个圆形
            //g.DrawRectangle(p1, rect2);
            g.DrawEllipse(p1, rect2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect2);

            Region region = new Region(rect);//设定矩形与圆形的交集区域
            region.Intersect(path);

            Point point1 = new Point(10, 10);//设置颜色渐变起止位置
            Point point2 = new Point(50, 50);
            LinearGradientBrush brush = new LinearGradientBrush(point1, point2, Color.Green, Color.OrangeRed);
            g.FillRegion(brush, region);
        }
    }
}