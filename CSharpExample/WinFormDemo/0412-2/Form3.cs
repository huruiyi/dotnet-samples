using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace _0412_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Text = "这是Form3窗体";
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            int count = lsbkc.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                lsbkc.Items.Remove(lsbkc.SelectedItems[0]);
            }
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            for (int i = lsbkc.Items.Count - 1; i >= 0; i--)
            {
                lsbkc.Items.RemoveAt(i);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtkc.Text != "")
            {
                lsbkc.Items.Add(txtkc.Text);
            }
        }

        private void btnselectall_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lsbkc.Items.Count; i++)
            //{
            //    lsbkc.SetSelected(i, true);
            //}
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btnnonselect_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lsbkc.Items.Count; i++)
            //{
            //    lsbkc.SetSelected(i, !lsbkc.GetSelected(i));
            //}

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbkc.Items.Count; i++)
            {
                lsbcourse.Items.Add(lsbkc.Items[i]);
            }
            lsbkc.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = lsbkc.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                lsbcourse.Items.Add(lsbkc.SelectedItems[0]);
                lsbkc.Items.Remove(lsbkc.SelectedItems[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbcourse.Items.Count; i++)
            {
                lsbkc.Items.Add(lsbcourse.Items[i]);
            }
            lsbcourse.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int count = lsbcourse.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                lsbkc.Items.Add(lsbcourse.SelectedItems[0]);
                lsbcourse.Items.Remove(lsbcourse.SelectedItems[0]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblbanji.Text = comboBox1.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fontCollection = new InstalledFontCollection();
            for (int i = 0; i < fontCollection.Families.Length; i++)
            {
                comboBox2.Items.Add(fontCollection.Families[i].Name);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    comboBox4.Items.Clear();
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBox4.Items.Add(i);
                    }
                    break;

                case "2":
                    comboBox4.Items.Clear();
                    for (int i = 1; i <= 28; i++)
                    {
                        comboBox4.Items.Add(i);
                    }
                    break;

                case "4":
                case "6":
                case "9":
                case "11":

                    comboBox4.Items.Clear();
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBox4.Items.Add(i);
                    }
                    break;

                default: MessageBox.Show("请选择月份");
                    break;
            }
        }
    }
}