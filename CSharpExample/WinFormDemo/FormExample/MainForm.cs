using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormExample
{
    public partial class MainForm : Form
    {
        private SubForms subform = new SubForms();

        public MainForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            // this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(900, 900);
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (subform.Visible == false)
            {
                subform.Visible = true;
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (subform.Visible == true)
            {
                subform.Hide();
            }
        }
    }
}