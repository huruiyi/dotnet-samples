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
    public partial class FindForm : Form
    {
        int index = 0;
        int indexUp = 0;
        Boolean found = false;
        Boolean foundUp = false;
        public FindForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            MainForm mainform = (MainForm)Application.OpenForms["mainForm"];
            if(radioButtonDown.Checked)
            {
                for (; index <= mainform.mainTextBox.Text.Length - textBoxContent.Text.Length; index++)
                {
                    mainform.mainTextBox.Select(index, textBoxContent.Text.Length);
                    if (index == mainform.mainTextBox.Text.Length - textBoxContent.Text.Length)
                    {
                        if (!found)
                        {
                            MessageBox.Show("找不到该字符串！");
                            break;
                        }
                        index = -1;
                    }
                    if (!checkBoxCase.Checked)
                    {
                        if (mainform.mainTextBox.SelectedText.ToLower().Equals(textBoxContent.Text.ToLower()))
                        {
                            mainform.mainTextBox.Focus();
                            found = true;
                            index++;
                            break;
                        }
                    }
                    if (mainform.mainTextBox.SelectedText.Equals(textBoxContent.Text))
                    {
                        mainform.mainTextBox.Focus();
                        index++;
                        break;
                    }
                }
            }
            else
            {
                for (; indexUp >= textBoxContent.Text.Length; indexUp--)
                {
                    mainform.mainTextBox.Select(indexUp - textBoxContent.Text.Length, textBoxContent.Text.Length);
                    if (indexUp == textBoxContent.Text.Length)
                    {
                        if (!foundUp)
                        {
                            MessageBox.Show("找不到该字符串！");
                            break;
                        }
                        indexUp = mainform.mainTextBox.Text.Length+1;
                    }
                    if (!checkBoxCase.Checked)
                    {
                        if (mainform.mainTextBox.SelectedText.ToLower().Equals(textBoxContent.Text.ToLower()))
                        {
                            mainform.mainTextBox.Focus();
                            foundUp = true;
                            indexUp--;
                            break;
                        }
                    }
                    if (mainform.mainTextBox.SelectedText.Equals(textBoxContent.Text))
                    {
                        mainform.mainTextBox.Focus();
                        foundUp = true;
                        indexUp--;
                        break;
                    }
                }
            }
        }

        private void textBoxContent_TextChanged(object sender, EventArgs e)
        {
            MainForm mainform = (MainForm)Application.OpenForms["mainForm"];
            index = 0;
            indexUp = mainform.mainTextBox.Text.Length;
            found = false;
            foundUp = false;
        }
    }
}