using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace day0412
{
    public partial class Form1 : Form
    {
        private Button[,] btnNew = new Button[5, 5];

        public string name;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string name)
        {
            InitializeComponent();
            this.name = name;
            this.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2
            {
                MdiParent = this,
                Name = "Form2"
            };
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = Application.OpenForms.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "Form2")
                {
                    Application.OpenForms[i].Close();
                }
            }

            // Application.OpenForms["f2"].Close();
        }

        private void 打开Form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Name = "Form2";
            f2.Show();
        }

        private void 关闭Form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] mdiChildren = this.MdiChildren;
            foreach (Form fm in mdiChildren)
            {
                if (fm.Name == "Form2") fm.Close();
            }
        }

        private void 打开Form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Name = "Form3";
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form3"].Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form3"].Show();
        }

        private void 关闭Form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] mdiChildren = this.MdiChildren;
            foreach (Form fm in mdiChildren)
            {
                if (fm.Name == "Form3") fm.Close();
            }
        }

        private void 水平ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 层叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 打开Form2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            打开Form2ToolStripMenuItem_Click(sender, e);
        }

        private void 关闭Form2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            关闭Form2ToolStripMenuItem_Click(sender, e);
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            打开Form2ToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tslDate.Text = DateTime.Now.ToLongDateString();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                sum += i;
                System.Threading.Thread.Sleep(100);
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += 1;
            toolStripProgressBar1.Value += 1;
        }
    }
}