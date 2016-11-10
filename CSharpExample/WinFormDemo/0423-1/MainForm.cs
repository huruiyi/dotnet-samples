using System;
using System.Windows.Forms;

namespace _0423_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 查询学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm sf = new StudentForm();
            sf.MdiParent = this;
            sf.Show();
        }

        private void 添加年级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GradeForm gf = new GradeForm();
            gf.MdiParent = this;
            gf.Show();
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 添加学生信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addStuForm asf = new addStuForm();
            asf.MdiParent = this;
            asf.Show();
        }
    }
}