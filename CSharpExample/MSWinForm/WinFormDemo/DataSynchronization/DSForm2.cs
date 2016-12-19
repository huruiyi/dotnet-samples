using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormDemo.DataSynchronization
{
    public partial class DSForm2 : Form
    {
        public SetTextDel _SetTextDel;

        public DSForm2()
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