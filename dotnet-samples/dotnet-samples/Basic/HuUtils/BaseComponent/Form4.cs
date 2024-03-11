using System;
using System.IO;
using System.Windows.Forms;

namespace HuUtils.BaseComponent
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = "C:";
            node.Tag = "C:\\";
            treeView1.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "D:";
            node.Tag = "D:\\";
            treeView1.Nodes.Add(node);

            node = new TreeNode();
            node.Text = "E:";
            node.Tag = "E:\\";
            treeView1.Nodes.Add(node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            DirectoryInfo dirinfo = new DirectoryInfo(node.Tag.ToString());
            DirectoryInfo[] dirs = dirinfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                TreeNode node1 = new TreeNode();
                node1.Text = dir.Name;
                node1.Tag = dir.FullName;
                node.Nodes.Add(node1);
            }
            FileInfo[] files = dirinfo.GetFiles();
            listView1.Items.Clear();
            foreach (FileInfo file in files)
            {
                ListViewItem lvi = new ListViewItem(file.Name);
                lvi.SubItems.Add((Math.Ceiling(1.0 * file.Length / 1024)).ToString() + "KB");
                lvi.SubItems.Add(file.Extension);
                lvi.SubItems.Add(file.FullName);
                listView1.Items.Add(lvi);
            }
        }
    }
}