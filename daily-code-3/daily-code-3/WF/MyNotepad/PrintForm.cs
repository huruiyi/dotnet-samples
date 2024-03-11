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
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void timerGetFocus_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timerGetFocus.Stop();
        }

        private void printForm_Deactivate(object sender, EventArgs e)
        {
            timerGetFocus.Start();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddPrinter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("control");
        }

        private void buttonFindPrinter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("control");
        }

        private void printForm_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = false;
        }

        private void printForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = true;
        }
    }
}
