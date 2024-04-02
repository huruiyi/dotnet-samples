using System;
using System.Windows.Forms;

namespace KeyGenerator
{
    public partial class frmIn : Form
    {
        public frmIn()
        {
            InitializeComponent();
        }

        private void btnLookRegText_Click(object sender, EventArgs e)
        {
            RegOperate ro = new RegOperate();
            rtxtRegText.Text = ro.ReadPasswordXml();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            RegOperate ro = new RegOperate();
            ro.XmlToPassword();
        }
    }
}