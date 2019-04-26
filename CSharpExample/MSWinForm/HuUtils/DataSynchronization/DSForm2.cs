using System;
using System.Threading;
using System.Windows.Forms;

namespace HuUtils.DataSynchronization
{
    public partial class DsForm2 : Form
    {
        public SetTextDel SetTextDel;

        public DsForm2()
        {
            InitializeComponent();
            this.Text = Thread.CurrentThread.ManagedThreadId + "";
        }

        private void btnSetMainTxt_Click(object sender, EventArgs e)
        {
            /*
                        if (SetTextDel == null)
                        {
                            return;
                        }
                        SetTextDel(this.txtSource.Text);
             */
            SetTextDel?.Invoke(this.txtSource.Text);
        }
    }
}