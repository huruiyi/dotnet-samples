using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HuUtils.BaseComponent
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            int count = lstkc.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                lstkc.Items.Remove(lstkc.SelectedItems[0]);
            }

            //for (int i=lstkc.SelectedItems.Count-1; i>=0; i--)
            //{
            //    lstkc.Items.Remove(lstkc.SelectedItems[i]);
            //}
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            //for (int i = lstkc.Items.Count - 1; i >= 0; i--)
            //{
            //    lstkc.Items.Remove(lstkc.Items[i]);
            //}
            lstkc.Items.Clear();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtkc.Text != "")
            {
                lstkc.Items.Add(txtkc.Text);
            }
        }

        private void btnrigthall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cltleft.Items.Count; i++)
            {
                cltrigth.Items.Add(cltleft.Items[i]);
            }
            cltleft.Items.Clear();
        }

        private void btnrigth_Click(object sender, EventArgs e)
        {
            for (int i = cltleft.SelectedItems.Count - 1; i >= 0; i--)
            {
                cltrigth.Items.Add(cltleft.SelectedItems[i]);
                cltleft.Items.Remove(cltleft.SelectedItems[i]);
            }
        }

        private void btnleftall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cltrigth.Items.Count; i++)
            {
                cltleft.Items.Add(cltrigth.Items[i]);
            }
            cltrigth.Items.Clear();
        }

        private void btnleft_Click(object sender, EventArgs e)
        {
            for (int i = cltrigth.SelectedItems.Count - 1; i >= 0; i--)
            {
                cltleft.Items.Add(cltrigth.SelectedItems[i]);
                cltrigth.Items.Remove(cltrigth.SelectedItems[i]);
            }
        }

        private void btnselectall_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lstkc.Items.Count; i++)
            //{
            //    lstkc.SetSelected(i, true);
            //}

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                //cltleft.SetSelected(i, true);
                //cltleft.SelectedItems.Add(cltleft.Items[i]);
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btnnonselect_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < lstkc.Items.Count; i++)
            //{
            //    lstkc.SetSelected(i, !lstkc.GetSelected(i));
            //}

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
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
                comboBox1.Items.Add(fontCollection.Families[i].Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("洛阳市");
                    comboBox3.Items.Add("商丘市");
                    comboBox3.Items.Add("周口市");
                    comboBox3.Items.Add("郑州市");
                    comboBox3.Items.Add("南阳市");
                    break;

                case 1:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("长沙市");
                    comboBox3.Items.Add("湘潭市");
                    comboBox3.Items.Add("株洲市");
                    comboBox3.Items.Add("醴陵市");
                    comboBox3.Items.Add("岳阳市");
                    break;

                case 2:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("武汉市");
                    comboBox3.Items.Add("荆州市");
                    comboBox3.Items.Add("襄樊市");
                    comboBox3.Items.Add("十堰市");

                    break;

                case 3:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("西安市");
                    comboBox3.Items.Add("宝鸡市");
                    comboBox3.Items.Add("延安市");
                    comboBox3.Items.Add("安康市");

                    break;
            }
        }
    }
}