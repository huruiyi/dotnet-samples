using System;
using System.IO;
using System.Windows.Forms;

namespace day0412
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存文件";
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";

            //if (textBox1.Text!="")
            //{
            if (sfd.ShowDialog() == DialogResult.OK)
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            //else
            //{
            //    MessageBox.Show("请输入文件路径！");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            openFileDialog1.Title = "请选择要复制的文件";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Title = "请选择保存位置";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openFileDialog1.FileName, saveFileDialog1.FileName, true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sdir = "", ddir = "";
            folderBrowserDialog1.Description = "请选择要复制的文件夹";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sdir = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.Description = "请选择要复制到的目标文件夹";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ddir = folderBrowserDialog1.SelectedPath;
                    CopyDirectory(sdir, ddir);
                }
            }
        }

        public void CopyDirectory(string sDir, string dDir)
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
            DirectoryInfo[] dirs = sdirinfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                CopyDirectory(dir.FullName, dDir);
            }
        }
    }
}