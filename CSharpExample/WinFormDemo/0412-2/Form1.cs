using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _0412_2
{
    public partial class Form1 : Form
    {
        private Button[,] btnNew = new Button[5, 5];
        private string name;

        public Form1()
        {
            InitializeComponent();
            SetButtonText();
        }

        public Form1(string name)
        {
            InitializeComponent();
            this.name = name;
            this.Text = name;
        }

        public void SetButtonText()
        {
            btnOk.Text = "OK";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    btnNew[i, j] = new Button();
                    btnNew[i, j].Location = new Point(0 + j * 40, 10 + i * 30);
                    btnNew[i, j].Size = new Size(40, 30);
                    btnNew[i, j].Text = (i + 1).ToString() + "," + (j + 1).ToString();
                    this.btnNew[i, j].Click += new System.EventHandler(this.btnNew_Click);
                    this.Controls.Add(btnNew[i, j]);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Text);
            btn.BackColor = Color.Red;
            btn.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form2"].Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form3"].Close();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 打开Form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void 打开Form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.MdiParent = this;
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

        private void 关闭Form3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            关闭Form3ToolStripMenuItem_Click(sender, e);
        }

        private void 关闭Form2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            关闭Form2ToolStripMenuItem_Click(sender, e);
        }

        private void 打开Form3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.MdiParent = this;
            f2.Show();
        }

        private void 打开Form2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            打开Form2ToolStripMenuItem_Click(sender, e);
        }

        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            打开Form2ToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            progressBar1.Value = 0;
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
        }
    }
}