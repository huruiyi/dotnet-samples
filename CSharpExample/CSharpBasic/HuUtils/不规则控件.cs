using HuUtils.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 不规则控件 : Form
    {
        private const int CsDropShadow = 0x20000;
        private const int GclStyle = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public 不规则控件()
        {
            InitializeComponent();
        }

        private void Draw(Rectangle rectangle, Graphics g, int radius, bool cusp, Color beginColor, Color endColor)
        {
            int span = 2;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //渐变填充
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(rectangle, beginColor, endColor, LinearGradientMode.Vertical);
            //画尖角
            if (cusp)
            {
                span = 10;
                PointF p1 = new PointF(rectangle.Width - 12, rectangle.Y + 10);
                PointF p2 = new PointF(rectangle.Width - 12, rectangle.Y + 30);
                PointF p3 = new PointF(rectangle.Width, rectangle.Y + 20);
                PointF[] ptsArray = { p1, p2, p3 };
                g.FillPolygon(myLinearGradientBrush, ptsArray);
            }
            //填充
            g.FillPath(myLinearGradientBrush, DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, radius));
        }

        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        private GraphicsPath GetAutoRgn(Image img, Color transColor)
        {
            Bitmap bm = new Bitmap(img, this.ClientSize);
            //   Bitmap bm = new Bitmap(this.shapeImage);
            GraphicsPath myGraphicsPath = new GraphicsPath();
            //   myGraphicsPath.AddRectangle(new Rectangle(0,0,20,20));
            //   myGraphicsPath.AddRectangle(new Rectangle(20,6,12,12));
            for (int y = 0; y < bm.Height; y++)
            {
                int x = 0;
                while (x < bm.Width)
                {
                    while (x < bm.Width && bm.GetPixel(x, y).ToArgb() == transColor.ToArgb())
                    {
                        x++;
                    }
                    var posT = x;

                    while (x < bm.Width && bm.GetPixel(x, y).ToArgb() != transColor.ToArgb())
                    {
                        x++;
                    }
                    var posS = x - 1;
                    if (posT <= posS)
                    {
                        //合并区域
                        myGraphicsPath.AddRectangle(new Rectangle(posT, y, x - posT, 1));
                    }
                }
            }
            return myGraphicsPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GraphicsPath myg = new GraphicsPath();
            //myg.AddEllipse(new Rectangle(0, 0, button1.Width, button1.Height)); //加椭圆
            //button1.BackColor = Color.Purple;
            //button1.Size = new Size(button1.Width, button1.Height);
            //button1.Region = new Region(myg);

            FontFamily ff = new FontFamily("Arial");
            PointF origin = new PointF(30, 30);
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            //myg.AddString(button1.Text, ff, (int)FontStyle.Bold, 35, origin, sf);

            //myg.AddRectangle(new Rectangle(0, 0, button1.Width, button1.Height));
            myg.AddEllipse(1, 1, 200, 200);
            myg.AddString(button1.Text, ff, (int)FontStyle.Bold, 10, origin, sf);
            button1.Region = new Region(myg);
            button1.Image = Resources.Component;

            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetClassLong(button2.Handle, GclStyle, GetClassLong(button2.Handle, GclStyle) | CsDropShadow);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            //圆角按钮要设置
            // BorderColor,BorderSize ,MouseDownBackColor,MouseOverBackColor
            Draw(e.ClipRectangle, e.Graphics, 28, false, Color.FromArgb(0, 122, 204), Color.FromArgb(8, 39, 57));
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawString("其实我是个按钮", new Font("微软雅黑", 9, FontStyle.Regular), new SolidBrush(Color.White), new PointF(10, 10));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.ClipRectangle, e.Graphics, 28, true, Color.FromArgb(90, 143, 0), Color.FromArgb(41, 67, 0));
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawString("其实我是个Panel", new Font("微软雅黑", 9, FontStyle.Regular), new SolidBrush(Color.White), new PointF(10, 10));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.ClipRectangle, e.Graphics, 28, false, Color.FromArgb(113, 113, 113), Color.FromArgb(0, 0, 0));
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawString("其实我是个Panel", new Font("微软雅黑", 9, FontStyle.Regular), new SolidBrush(Color.White), new PointF(10, 10));
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.ClipRectangle, e.Graphics, 28, false, Color.FromArgb(210, 210, 210), Color.FromArgb(242, 242, 242));
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawString("其实我是Label", new Font("微软雅黑", 9, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(10, 10));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetClassLong(this.Handle, GclStyle, GetClassLong(this.Handle, GclStyle) | CsDropShadow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}