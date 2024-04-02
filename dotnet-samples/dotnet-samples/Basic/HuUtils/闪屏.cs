using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 闪屏 : Form
    {
        public 闪屏()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            System.Drawing.Point point = this.Location;
            for (int i = 0; i < 30; i++)
            {
                this.Location = new System.Drawing.Point(point.X + ran.Next(8), point.Y + ran.Next(8));
                System.Threading.Thread.Sleep(15);
                this.Location = point;
                System.Threading.Thread.Sleep(15);
            }
        }
    }
}