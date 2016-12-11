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

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void openForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.MdiParent = this;
        }

        private void hideForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Hide();
        }

        private void closeForm2ToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}