using System;
using System.Drawing;
using System.Windows.Forms;

namespace WfApp
{
    public partial class MdiForm : Form
    {
        public MdiForm()
        {
            InitializeComponent();
        }

        private int childCounter = 0;
        private bool scrollPanel;

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            childCounter++;

            ChildForm frm = new ChildForm();
            frm.MdiParent = this;
            frm.Tag = childCounter;

            RadioButton btn = new RadioButton();
            btn.Appearance = Appearance.Button;
            btn.Text = frm.Text + " " + childCounter.ToString();
            btn.Tag = childCounter;
            btn.CheckedChanged += new EventHandler(this.button_Click);
            btn.Location = new Point(((childCounter - 1) * (btn.Width + 3)) + 2 + this.panel1.DisplayRectangle.X, 3);
            this.panel1.Controls.Add(btn);
            btn.Checked = true;

            if (!scrollPanel && (btn.Location.X + btn.Width > this.panel1.Width))
            {
                scrollPanel = true;
                this.panel1.Height += 15;
            }

            frm.Show();
            RichTextBox richTextBox = frm.Controls["rtbNum"] as RichTextBox;
            richTextBox.Text = "这是第" + childCounter + "个子窗体";

            Button button = frm.Controls["btnNum"] as Button;
            button.Text = "Btn" + childCounter;

            TextBox textBox = frm.Controls["txtNum"] as TextBox;
            textBox.Text = childCounter.ToString();
            frm.Dock = DockStyle.Fill;
        }

        private void button_Click(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.Checked)
            {
                if (btn != null)
                {
                    this.MdiChildren[(int)btn.Tag - 1].BringToFront();
                }
            }
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)this.panel1.Controls[(int)this.ActiveMdiChild.Tag - 1];
            if (btn != null)
            {
                btn.Checked = true;
                this.panel1.ScrollControlIntoView(btn);
            }
        }
    }
}