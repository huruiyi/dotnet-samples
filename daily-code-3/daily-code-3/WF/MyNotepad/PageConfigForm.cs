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
    public partial class PageConfigForm : Form
    {
        public PageConfigForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageConfigForm_Load(object sender, EventArgs e)
        {
            comboBoxSize.Text = "A4";
            comboBoxSource.Text = "自动选择";
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = false;
        }

        private void timerGetFocus_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timerGetFocus.Stop();
        }

        private void pageConfigForm_Deactivate(object sender, EventArgs e)
        {
            timerGetFocus.Start();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = true;
        }
    }
}
