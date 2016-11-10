using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormPositionExample
{
    public partial class Form2 : Form
    {
        private bool isCustomStyle = false;

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Form2(int screenX, int screenY)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Point p = new Point(screenX, screenY);
            this.Location = p;
        }

        public Form2(bool isCustomStyle)
        {
            this.isCustomStyle = isCustomStyle;
            InitializeComponent();
            if (isCustomStyle)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = Color.AliceBlue;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (isCustomStyle)
            {
                System.Drawing.Drawing2D.GraphicsPath formShape = new System.Drawing.Drawing2D.GraphicsPath();
                formShape.AddEllipse(0, 0, this.Width, this.Height);

                this.Region = new System.Drawing.Region(formShape);
            }
        }
    }
}