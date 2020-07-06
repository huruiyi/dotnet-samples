using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动1_1 : Form
    {
        public 无边框移动1_1()
        {
            InitializeComponent();
        }
        private Point _mouseOffset = new Point(0, 0);

        private void 无边框移动1_1_MouseDown(object sender, MouseEventArgs e)
        {
            this._mouseOffset = new Point(-e.X, -e.Y);
        }

        private void 无边框移动1_1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousepos = Control.MousePosition;
                mousepos.Offset(this._mouseOffset.X, this._mouseOffset.Y - SystemInformation.CaptionHeight);
                this.Location = mousepos;
            }
        }
    }
}
