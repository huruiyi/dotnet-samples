using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HuUtils.DataSynchronization
{
    public partial class DSForm3 : Form
    {
        public DSForm3()
        {
            InitializeComponent();
        }

        public Action<string> SendMsg;
        public DSForm4 F2Demo { get; set; }

        public List<IAfterText> ListOb = new List<IAfterText>();

        public event EventHandler AfterSendText;

        private void btnSend_Click(object sender, EventArgs e)
        {
            //if (SendMsg != null)
            //{
            //    //SendMsg(this.txtMsg.Text);
            //}

            //F2Demo.SetText("sss");

            AfterSendText(this, new SendTextEventArgs() { Text = this.txtMsg.Text });

            foreach (var afterText in ListOb)
            {
                afterText.AfterTextChanger(txtMsg.Text);
            }
        }

     
    }
}