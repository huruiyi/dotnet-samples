using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace day0412
{
    public partial class Form1 : Form
    {
        public static void CloseAll(string formName)
        {
            int count = Application.OpenForms.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == formName)
                {
                    Application.OpenForms[i].Close();
                }
            }
            // Application.OpenForms["f2"].Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string name)
        {
            InitializeComponent();
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
                if (fm.Name == "Form2")
                    fm.Close();
            }
        }

        private void 打开Form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.MdiParent = this;
            f.Name = "Form3";
            f.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            CloseAll("Form2");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            CloseAll("Form3");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CloseAll("Form4");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CloseAll("Form5");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            CloseAll("Form6");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CloseAll("Form7");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form3"].Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form4"].Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form5"].Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form6"].Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form7"].Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.MdiParent = this;
            f.Name = "Form4";
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.MdiParent = this;
            f.Name = "Form5";
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.MdiParent = this;
            f.Name = "Form6";
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.MdiParent = this;
            f.Name = "Form7";
            f.Show();
        }
    }
}