using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HuUtils.Graphicses
{
    public partial class Demo08 : Form
    {
        public Demo08()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            //从红到黄水平渐变
            LinearGradientBrush brush1 =
                new LinearGradientBrush(new Rectangle(10, 10, 50, 50), Color.Red, Color.Yellow, LinearGradientMode.Horizontal);
            g.FillRectangle(brush1, 10, 10, 300, 100);
            //从红到黄垂直渐变
            LinearGradientBrush brush2 =
                new LinearGradientBrush(new Rectangle(10, 10, 50, 50), Color.Red, Color.Yellow, LinearGradientMode.Vertical);
            g.FillRectangle(brush2, 10, 120, 300, 100);
            //从红到黄左上至右下渐变
            LinearGradientBrush brush3 =
                new LinearGradientBrush(new Rectangle(10, 10, 50, 50), Color.Red, Color.Yellow, LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush3, 10, 230, 300, 100);
            //从红到黄右上至左下渐变
            LinearGradientBrush brush4 =
                new LinearGradientBrush(new Rectangle(10, 10, 50, 50), Color.Red, Color.Yellow, LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(brush4, 10, 340, 300, 100);
        }
    }
}