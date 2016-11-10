using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace 资源管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("盘符");
            listView1.View = View.Details;
            string[] drivers = Directory.GetLogicalDrives();
            for (int i = 0; i < drivers.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(drivers[i]);
                DriveInfo df = new DriveInfo(drivers[i]);
                string str1 = (df.TotalFreeSpace / 1024 / 1024 / 1024).ToString("F2");
                string str2 = (df.TotalSize / 1024 / 1024 / 1024).ToString("F2");
                lvi.SubItems.Add(str1);
                lvi.SubItems.Add(str2);
                listView1.Items.Add(lvi);
            }
        }

        private string folder = string.Empty;

        private void listView1_Click(object sender, EventArgs e)
        {
            folder = listView1.SelectedItems[0].Text;
            txtPath.Text = folder;
            Opendorf();
        }

        #region 向ListView中添加记录

        private void Opendorf()
        {
            try
            {
                ListViewItem lvi1 = new ListViewItem(folder);
                string[] directories = Directory.GetDirectories(folder);
                string[] files = Directory.GetFiles(folder);

                listView1.Items.Clear();
                for (int i = 0; i < directories.Length; i++)
                {
                    string path = directories[i];
                    DirectoryInfo fi = new DirectoryInfo(directories[i]);
                    if (fi.Attributes != FileAttributes.Hidden || fi.Attributes != FileAttributes.Encrypted)
                    {
                        listView1.Items.Add(directories[i]);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fi = new FileInfo(files[i]);
                    if (fi.Attributes != FileAttributes.Hidden)
                    {
                        listView1.Items.Add(files[i]);
                    }
                }
            }
            catch
            {
                string extension = Path.GetExtension(folder);
                OpenFiles(extension, folder);
            }
        }

        #endregion 向ListView中添加记录

        #region 打开文件

        private void OpenFiles(string Extension, string files)
        {
            if (Extension == ".txt")
            {
                Process.Start("notepad.exe", files);
                return;
            }
            if (Extension == ".doc")
            {
                Process.Start("winword.exe", files);
            }
            if (Extension == ".ppt")
            {
                Process.Start("POWERPNT.exe", files);
                return;
            }
            if (Extension == ".avi" || Extension == ".mp3")
            {
                Process.Start("wmplayer.exe", files);
                return;
            }
            if (Extension == ".html" || Extension == ".htm")
            {
                Process.Start("iexplore.exe", files);
                return;
            }
        }

        #endregion 打开文件

        private void btnOK_Click(object sender, EventArgs e)
        {
            folder = txtPath.Text;
            Opendorf();
        }
    }
}