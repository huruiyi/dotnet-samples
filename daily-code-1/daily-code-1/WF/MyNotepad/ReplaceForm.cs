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
    public partial class ReplaceForm : Form
    {
        int index = 0;
        Boolean found = false;
        public ReplaceForm()
        {
            InitializeComponent();
        }
        // 下载于www.51aspx.com
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            MainForm mainform = (MainForm)Application.OpenForms["mainForm"];
            for (; index <= mainform.mainTextBox.Text.Length - textBoxFindContent.Text.Length; index++)
            {
                mainform.mainTextBox.Select(index, textBoxFindContent.Text.Length);
                if (index == mainform.mainTextBox.Text.Length - textBoxFindContent.Text.Length)
                {
                    if (!found)
                    {
                        MessageBox.Show("未找到该字符串！");
                        break;
                    }
                    index = -1;
                }
                if (!checkBoxCase.Checked)
                {
                    if (mainform.mainTextBox.SelectedText.ToLower().Equals(textBoxFindContent.Text.ToLower()))
                    {
                        mainform.mainTextBox.Focus();
                        index++;
                        break;
                    }
                } 
                if (mainform.mainTextBox.SelectedText.Equals(textBoxFindContent.Text))
                {
                    mainform.mainTextBox.Focus();
                    index++;
                    break;
                }
            }
        }

        private void textBoxFindContent_TextChanged(object sender, EventArgs e)
        {
            index = 0;
            found = false;
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {                         
            MainForm mainform = (MainForm)Application.OpenForms["mainForm"];            
            mainform.mainTextBox.Text = mainform.mainTextBox.Text.Replace(textBoxFindContent.Text, textBoxReplaceText.Text);
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            MainForm mainform = (MainForm)Application.OpenForms["mainForm"];
            for (; index <= mainform.mainTextBox.Text.Length - textBoxFindContent.Text.Length; index++)
            {
                mainform.mainTextBox.Select(index, textBoxFindContent.Text.Length);
                if (!checkBoxCase.Checked)
                {
                    if (mainform.mainTextBox.SelectedText.ToLower().Equals(textBoxFindContent.Text.ToLower()))
                    {
                        mainform.mainTextBox.SelectedText = textBoxReplaceText.Text;
                        mainform.mainTextBox.Focus();
                        index++;
                        break;
                    }
                }   
                if (mainform.mainTextBox.SelectedText.Equals(textBoxFindContent.Text))
                {
                    mainform.mainTextBox.SelectedText = textBoxReplaceText.Text;
                    mainform.mainTextBox.Focus();
                    index++;
                    break;
                }
            }
        }
    }
}
