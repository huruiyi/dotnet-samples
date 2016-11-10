using System;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 查询学生列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentFrom sf = new StudentFrom();
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
            AddStuForm asf = new AddStuForm();
            asf.MdiParent = this;
            asf.Show();
        }
    }
}