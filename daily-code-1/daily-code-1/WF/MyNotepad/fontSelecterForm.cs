using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyNotepad
{
    public partial class FontSelecterForm : Form
    {
        public FontSelecterForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void fontSelecterForm_Load(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = false;
            System.Drawing.Text.InstalledFontCollection font = new System.Drawing.Text.InstalledFontCollection();
            System.Drawing.FontFamily[] array= font.Families;
            textBoxFont.Text = Passer.fontNow;
            textBoxFontSize.Text = Passer.fontSizeNow;
            switch(Passer.fontStyleNow)
            {
                case "Regular": textBoxFontStyle.Text ="常规"; break;
                case "Bold": textBoxFontStyle.Text ="粗体"; break;
                case "Italic": textBoxFontStyle.Text ="倾斜"; break;
                case "Bold, Italic": textBoxFontStyle.Text ="粗体 倾斜"; break;
                case "常规": textBoxFontStyle.Text = "常规"; break;
                case "粗体": textBoxFontStyle.Text = "粗体"; break;
                case "倾斜": textBoxFontStyle.Text = "倾斜"; break;
                case "粗体 倾斜": textBoxFontStyle.Text = "粗体 倾斜"; break;
            }
            foreach (var v in array) 
            {
                listFontBox.Items.Add(v.Name);
            }             
        }

        private void listFontBox_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxFont.Text = listFontBox.SelectedItem.ToString();
        }

        private void listFontStyleBox_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxFontStyle.Text = listFontStyleBox.SelectedItem.ToString();
        }

        private void listFontSizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFontSize.Text = listFontSizeBox.SelectedItem.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Passer.fontNow = textBoxFont.Text;
            Passer.fontSizeNow = textBoxFontSize.Text;
            Passer.fontStyleNow = textBoxFontStyle.Text;
            this.Close();
        }

        private void timerGetFocus_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timerGetFocus.Stop();
        }

        private void fontSelecterForm_Deactivate(object sender, EventArgs e)
        {
            timerGetFocus.Start();  
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void fontSelecterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm mf = (MainForm)Application.OpenForms["mainForm"];
            mf.Enabled = true;
        }
    }
}
