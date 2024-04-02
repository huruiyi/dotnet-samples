using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class Notepad1 : Form
    {
        public Notepad1()
        {
            InitializeComponent();
        }

        /*

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存文件";
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";

            //if (textBox1.Text!="")
            //{
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string[] lines = richTextBox1.Lines;
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
                sw.Close();
                fs.Close();
            }
            //}
            //else
            //{
            //    MessageBox.Show("请输入文件路径！");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string spath, dpath;
            openFileDialog1.Title = "请选择要复制的文件";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                spath = openFileDialog1.FileName;
                saveFileDialog1.Title = "请选择保存位置";
                if (saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    dpath = saveFileDialog1.FileName;
                    File.Copy(spath, dpath, true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sdir="", ddir="";
            folderBrowserDialog1.Description = "请选择要复制的文件夹";
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                sdir = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.Description = "请选择要复制到的目标文件夹";
                if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
                {
                    ddir = folderBrowserDialog1.SelectedPath;
                    CopyDirectory(sdir, ddir);
                }
            }
        }

        public void CopyDirectory(string sDir,string dDir)
        {
            DirectoryInfo sdirinfo = new DirectoryInfo(sDir);
            //获取文件夹下的所有文件
            FileInfo[] files = sdirinfo.GetFiles();
            dDir = dDir + "\\" + sdirinfo.Name;
            if (!Directory.Exists(dDir))
            {
                Directory.CreateDirectory(dDir);
            }
            foreach (FileInfo file in files)
            {
                File.Copy(file.FullName, dDir + "\\" + file.Name, true);
            }

            //获取文件夹下的所有子文件夹
           DirectoryInfo[] dirs=   sdirinfo.GetDirectories();
           foreach (DirectoryInfo dir in dirs)
           {
               CopyDirectory(dir.FullName, dDir);
           }
        }

         */

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                richTextBox1.Text = sr.ReadToEnd();
                MessageBox.Show(path);
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("想保存文件吗", "记事本消息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                保存ToolStripMenuItem_Click(sender, e);
            }
            else if (result == DialogResult.No)
            {
                richTextBox1.Text = "";
            }
            else
            {
                return;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "保存文件";
            sd.Filter = "文本文件(*.txt)|*.txt";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                string path = sd.FileName;
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string[] lines = richTextBox1.Lines;
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
                sw.Close();
                fs.Close();
            }
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "另存文件";
            sd.Filter = "文本文件(*.txt)|*.txt";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                string path = sd.FileName;
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string[] lines = richTextBox1.Lines;
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
                sw.Close();
                fs.Close();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                Application.Exit();
            }
            DialogResult result = MessageBox.Show("想保存文件吗", "记事本消息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                保存ToolStripMenuItem_Click(sender, e);
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void 日期时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToLongDateString());
            richTextBox1.Text += sb.ToString(); ;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
            }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 黏贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 自行换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自行换行ToolStripMenuItem.Checked == false)
            {
                自行换行ToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
            else
            {
                自行换行ToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void 字体ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            字体ToolStripMenuItem_Click(sender, e);
        }

        private void 颜色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            颜色ToolStripMenuItem_Click(sender, e);
        }

        private void 日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            日期时间ToolStripMenuItem_Click(sender, e);
        }

        private void 撤销ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void 全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "总字符数：" + richTextBox1.TextLength.ToString();
        }

        private void richTextBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "选中字符数：" + richTextBox1.SelectionLength.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "现在时间" + DateTime.Now.ToLongTimeString();
        }
    }
}