using System;
using System.Threading;
using System.Windows.Forms;

namespace MultThread
{
    public partial class ChildFrm : Form
    {
        public SetTextDel _SetTextDel;

        public ChildFrm()
        {
            InitializeComponent();
            this.Text = Thread.CurrentThread.ManagedThreadId + "";
        }

        private void btnSetMainTxt_Click(object sender, EventArgs e)
        {
            if (_SetTextDel == null)
            {
                return;
            }
            _SetTextDel(this.txtSource.Text);
        }
    }
}