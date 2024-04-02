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
    public partial class GoForm : Form
    {
        public GoForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            int selstart = 0;
            int rowNum = 0;
            int newRowNum=0;
            int.TryParse(textBoxRowNo.Text.ToString(),out newRowNum);
            foreach (char ch in mf.mainTextBox.Text)
            {                
                if (ch == '\n')
                {
                    selstart += mf.mainTextBox.Lines[rowNum].Length;
                    selstart++;
                    rowNum++;
                }
                if (rowNum+1==newRowNum)
                {
                    break;
                }                
            }
            mf.mainTextBox.SelectionStart = selstart;
            this.Close();
        }

        private void timerGetFocus_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timerGetFocus.Stop();
        }

        private void goForm_Deactivate(object sender, EventArgs e)
        {
            timerGetFocus.Start();
        }

        private void goForm_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = false;
        }

        private void goForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = true;
        }
    }
}
