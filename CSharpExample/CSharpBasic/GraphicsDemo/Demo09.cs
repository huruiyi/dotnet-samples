using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Demo09 : Form
    {
        public Demo09()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //红色线条，右上至左下线条
            HatchBrush brush1 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red);
            g.FillRectangle(brush1, 10, 10, 60, 60);
            //白色线条，黑色背景，十字交叉线条
            HatchBrush brush2 = new HatchBrush(HatchStyle.Cross, Color.White, Color.Black);
            g.FillRectangle(brush2, 70, 70, 60, 60);
            //麦黄色线条，黑色背景，砖块式线条
            HatchBrush brush3 = new HatchBrush(HatchStyle.DiagonalBrick, Color.Wheat, Color.Black);
            g.FillRectangle(brush3, 130, 130, 60, 60);
            //紫色线条，黄色背景，草皮式线条
            HatchBrush brush4 = new HatchBrush(HatchStyle.Divot, Color.Violet, Color.Yellow);
            g.FillRectangle(brush4, 190, 190, 60, 60);
        }
    }
}