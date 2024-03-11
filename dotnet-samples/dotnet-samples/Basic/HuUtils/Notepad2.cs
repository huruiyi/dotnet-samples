using System;
using System.Drawing;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class Notepad2 : Form
    {
        public Notepad2()
        {
            InitializeComponent();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog fileOpen = new OpenFileDialog();
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            fileOpen.InitialDirectory = dir;
            fileOpen.Filter = "我的文本文件(*.mytxt)|*.mytxt|All file(*.*)|*.*";
            fileOpen.FilterIndex = 1;
            fileOpen.RestoreDirectory = true;
            if (fileOpen.ShowDialog() == DialogResult.Cancel)
                return;
            else
                filename = fileOpen.FileName;
            richTextBox1.LoadFile(filename);
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog filesave = new SaveFileDialog();
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Templates);
            filesave.InitialDirectory = dir;
            filesave.Filter = "我的文本文件(*.mytxt)|*.mytxt|All file(*.*)|*.*";
            filesave.FilterIndex = 1;
            filesave.DefaultExt = ".mytxt";
            if (filesave.ShowDialog() == DialogResult.Cancel)
                return;
            else
                filename = filesave.FileName;
            richTextBox1.SaveFile(filename);
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog1.Font;
        }

        private void 颜色CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void 粗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool checkState = false;
            if (sender is ToolStripButton)
                checkState = ((ToolStripButton)sender).Checked;
            if (sender is ToolStripMenuItem)
                checkState = ((ToolStripMenuItem)sender).Checked;
            Font newFont;
            if (!checkState)
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style & ~FontStyle.Bold);
            else
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Bold);
            richTextBox1.Font = newFont;
            粗体ToolStripMenuItem.Checked = checkState;
            toolStripButton3.Checked = checkState;
            toolStripStatusLabel2.Enabled = checkState;
        }

        private void 斜体IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool checkState = false;
            if (sender is ToolStripButton)
                checkState = ((ToolStripButton)sender).Checked;
            if (sender is ToolStripMenuItem)
                checkState = ((ToolStripMenuItem)sender).Checked;
            Font newFont;
            if (!checkState)
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style & ~FontStyle.Italic);
            else
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Italic);
            richTextBox1.Font = newFont;
            斜体IToolStripMenuItem.Checked = checkState;
            toolStripButton4.Checked = checkState;
            toolStripStatusLabel3.Enabled = checkState;
        }

        private void 下划线UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool checkState = false;
            if (sender is ToolStripButton)
                checkState = ((ToolStripButton)sender).Checked;
            if (sender is ToolStripMenuItem)
                checkState = ((ToolStripMenuItem)sender).Checked;
            Font newFont;
            if (!checkState)
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style & ~FontStyle.Underline);
            else
                newFont = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Underline);
            richTextBox1.Font = newFont;
            下划线UToolStripMenuItem.Checked = checkState;
            toolStripButton5.Checked = checkState;
            toolStripStatusLabel4.Enabled = checkState;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "字符数：" + richTextBox1.TextLength.ToString();
        }
    }
}
