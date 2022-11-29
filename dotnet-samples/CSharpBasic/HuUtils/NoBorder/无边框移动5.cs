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
    public partial class 无边框移动5 : Form
    {

        private const int WmNchittest = 0x84;
        private const int Htclient = 0x1;
        private const int Htcaption = 0x2;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WmNchittest:
                    base.WndProc(ref m);
                    if ((int)m.Result == Htclient)
                        m.Result = (IntPtr)Htcaption;
                    return;

            }
            base.WndProc(ref m);

        }

        public 无边框移动5()
        {
            InitializeComponent();
        }

        private void 无边框移动5_Load(object sender, EventArgs e)
        {

        }
    }
}
