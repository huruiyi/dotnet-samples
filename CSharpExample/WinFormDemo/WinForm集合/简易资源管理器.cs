using System;
using System.IO;
using System.Windows.Forms;

namespace WinForm集合
{
    public partial class 简易资源管理器 : Form
    {
        public 简易资源管理器()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("名称", 300);
            listView1.Columns.Add("修改时间", 300);
            listView1.Columns.Add("创建时间", 300);

            listView1.View = View.Details;
            string[] drivers = Directory.GetLogicalDrives();
            listView1.Width = 800;
            for (int i = 0; i < drivers.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(drivers[i]);

                DriveInfo df = new DriveInfo(drivers[i]);
                string str1 = (df.TotalFreeSpace / 1024 / 1024 / 1024).ToString("F2");
                string str2 = (df.TotalSize / 1024 / 1024 / 1024).ToString("F2");
                lvi.SubItems.Add(str1);
                lvi.SubItems.Add(str2);
                lvi.Tag = drivers[i];
                listView1.Items.Add(lvi);
            }
        }

        private string folder = string.Empty;

        private void listView1_Click(object sender, EventArgs e)
        {
            folder = (string)listView1.SelectedItems[0].Tag;
            txtPath.Text = folder;
            Open();
        }

        private void Open()
        {
            try
            {
                string[] directories = Directory.GetDirectories(folder);
                string[] files = Directory.GetFiles(folder);

                listView1.Items.Clear();

                for (int i = 0; i < directories.Length; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(directories[i]);
                    if (dir.Attributes != FileAttributes.Hidden || dir.Attributes != FileAttributes.Encrypted)
                    {
                        ListViewItem lvi = new ListViewItem(dir.Name);
                        lvi.SubItems.Add(dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        lvi.SubItems.Add(dir.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        lvi.Tag = directories[i];
                        listView1.Items.Add(lvi);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fi = new FileInfo(files[i]);
                    if (fi.Attributes != FileAttributes.Hidden)
                    {
                        ListViewItem lvi = new ListViewItem(fi.Name);
                        lvi.SubItems.Add(fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        lvi.SubItems.Add(fi.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        lvi.Tag = fi.FullName;
                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            folder = txtPath.Text;
            Open();
        }
    }
}