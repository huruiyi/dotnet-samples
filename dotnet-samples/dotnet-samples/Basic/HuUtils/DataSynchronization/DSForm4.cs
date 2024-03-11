using System;
using System.Windows.Forms;

namespace HuUtils.DataSynchronization
{
    public partial class DSForm4 : Form, IAfterText
    {
        public DSForm4()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.txtMsg.Text = text;
        }

        public void AfterRecieveData(object sender, EventArgs e)
        {
            SendTextEventArgs ev = (SendTextEventArgs)e;
            this.txtMsg.Text = ev.Text;
        }

        public void AfterTextChanger(string text)
        {
            this.txtMsg.Text = text;
        }
    }
}
