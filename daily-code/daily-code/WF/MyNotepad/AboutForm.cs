using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void aboutFormSubmitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerGetFocus_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timerGetFocus.Stop();
        }

        private void aboutForm_Deactivate(object sender, EventArgs e)
        {
            timerGetFocus.Start();  
        }

        private void aboutForm_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = false;
        }

        private void aboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = true;
        }
    }
}
