using System;
using System.Windows.Forms;

namespace 登陆窗体
{
    public partial class 主窗体 : Form
    {
        public 主窗体()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.MdiParent = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Application.OpenForms["Form2"].Close();

            //关闭多个窗体

            //int count = Application.OpenForms.Count;
            //for (int i = count - 1; i >= 0; i--)
            //{
            //    if (Application.OpenForms[i].Name == "Form2")
            //    {
            //        Application.OpenForms[i].Close();
            //    }
            //}

            Form[] mdiChildren = this.MdiChildren;
            foreach (Form fm in mdiChildren)
            {
                if (fm.Name == "Form2") fm.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}