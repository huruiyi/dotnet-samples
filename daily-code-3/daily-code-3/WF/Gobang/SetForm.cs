using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gobang
{
    public partial class SetForm : Form
    {
        public bool playerWhite;
        public bool playerFirst;

        public SetForm(bool computerBlack, bool computerFirst)
        {
            InitializeComponent();
            this.playerWhite = true;
            this.playerFirst = true;
            if (computerBlack)
                this.radioButton1.Checked = true;
            else this.radioButton2.Checked = true;
            if (computerFirst)
                this.radioButton4.Checked = true;
            else this.radioButton3.Checked = true;
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"image\white.png");
            this.pictureBox2.Image = Image.FromFile(@"image\black.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
                this.playerWhite = false;
            if (this.radioButton4.Checked)
                this.playerFirst = false;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }
    }
}
