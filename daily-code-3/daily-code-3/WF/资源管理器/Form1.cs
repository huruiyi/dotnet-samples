using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private string currentPath = ""; //当前路径
        private string[] sources = new string[100];   //复制文件的源路径
        private bool IsMove = false;    //是否移动

        public Form1()
        {
            InitializeComponent();
        }

        //列出磁盘
        private void ListDrivers()
        {
            treeView1.Nodes.Clear();
            listView1.Items.Clear();
            currentPath = "";
            toolStripComboBox1.Text = currentPath;
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo driver in drivers)
            {
                TreeNode node = treeView1.Nodes.Add(driver.Name);
                ListViewItem item = listView1.Items.Add(driver.Name);
                item.Name = driver.Name;
                //判断驱动器类型，用不同图标显示
                switch (driver.DriveType)
                {
                    case DriveType.CDRom:   //光驱
                        {
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 1;
                            item.ImageIndex = 1;
                            break;
                        }
                    default:    //默认，显示为磁盘图标
                        {
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                            item.ImageIndex = 0;
                            break;
                        }
                }
            }
            foreach (TreeNode node in treeView1.Nodes)
            {
                NodeUpdate(node);
            }
        }

        //更新结点(列出当前目录下的子目录)
        private void NodeUpdate(TreeNode node)
        {
            try
            {
                node.Nodes.Clear();
                DirectoryInfo dir = new DirectoryInfo(node.FullPath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo d in dirs)
                {
                    node.Nodes.Add(d.Name);
                }
            }
            catch
            {
            }
        }

        //更新列表(列出当前目录下的目录和文件)
        private void ListUpdate(string newPath)
        {
            if (newPath == "")
                ListDrivers();
            else
            {
                try
                {
                    DirectoryInfo currentDir = new DirectoryInfo(newPath);
                    DirectoryInfo[] dirs = currentDir.GetDirectories(); //获取目录
                    FileInfo[] files = currentDir.GetFiles();   //获取文件
                    //删除ImageList中的程序图标
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Text.EndsWith(".exe"))  //是程序
                        {
                            imageList2.Images.RemoveByKey(item.Text);
                            imageList3.Images.RemoveByKey(item.Text);
                        }
                    }
                    listView1.Items.Clear();
                    //列出文件夹
                    foreach (DirectoryInfo dir in dirs)
                    {
                        ListViewItem dirItem = listView1.Items.Add(dir.Name, 2);
                        dirItem.Name = dir.FullName;
                        dirItem.SubItems.Add("");
                        dirItem.SubItems.Add("文件夹");
                        dirItem.SubItems.Add(dir.LastWriteTimeUtc.ToString());
                    }
                    //列出文件
                    foreach (FileInfo file in files)
                    {
                        ListViewItem fileItem = listView1.Items.Add(file.Name);
                        if (file.Extension == ".exe" || file.Extension == "")   //程序文件或无扩展名
                        {
                            Icon fileIcon = GetSystemIcon.GetIconByFileName(file.FullName);
                            imageList2.Images.Add(file.Name, fileIcon);
                            imageList3.Images.Add(file.Name, fileIcon);
                            fileItem.ImageKey = file.Name;
                        }
                        else    //其它文件
                        {
                            if (!imageList2.Images.ContainsKey(file.Extension))  //ImageList中不存在此类图标
                            {
                                Icon fileIcon = GetSystemIcon.GetIconByFileName(file.FullName);
                                imageList2.Images.Add(file.Extension, fileIcon);
                                imageList3.Images.Add(file.Extension, fileIcon);
                            }
                            fileItem.ImageKey = file.Extension;
                        }
                        fileItem.Name = file.FullName;
                        fileItem.SubItems.Add(file.Length.ToString() + "字节");
                        fileItem.SubItems.Add(file.Extension);
                        fileItem.SubItems.Add(file.LastWriteTimeUtc.ToString());
                    }
                    currentPath = newPath;
                    toolStripComboBox1.Text = currentPath;   //更新地址栏
                    toolStripStatusLabel1.Text = listView1.Items.Count + "个对象";     //更新状态栏
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //打开文件夹或文件
        private void Open()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string newPath = listView1.SelectedItems[0].Name;
                try
                {
                    //判断是目录还是文件
                    if (Directory.Exists(newPath))
                        ListUpdate(newPath);
                    else
                        Process.Start(newPath); //打开文件
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //显示属性窗口
        private void ShowAttributes()
        {
            if (listView1.SelectedItems.Count == 0) //无对象选中时，显示当前文件夹属性
            {
                FormAttributes FormAttributes1 = new FormAttributes(currentPath);
            }
            else    //有对象选中时，显示第一个选中对象的属性
            {
                FormAttributes FormAttributes1 = new FormAttributes(listView1.SelectedItems[0].Name);
            }
        }

        //剪切
        private void Cut()
        {
            Copy();
            IsMove = true;
        }

        //复制
        private void Copy()
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            sources = new string[100];
            int i = 0;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                sources[i++] = item.Name;
            }
            IsMove = false;
        }

        //复制或移动文件
        private void CopyFile(string source)
        {
            try
            {
                FileInfo file = new FileInfo(source);
                string destination = Path.Combine(currentPath, file.Name);
                if (destination == source)  //目标路径和源路径相同，返回
                    return;
                if (IsMove) //移动
                    file.MoveTo(destination);
                else    //复制
                    file.CopyTo(destination);
                //listView1.Items.Add(file.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //递归复制目录下的所有文件
        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            //判断目标文件夹是否是源文件夹的子目录，是则返回
            for (DirectoryInfo temp = target.Parent; temp != null; temp = temp.Parent)
            {
                if (temp.FullName == source.FullName)
                {
                    MessageBox.Show("无法复制！目标文件夹是源文件夹的子目录！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            FileInfo[] files = source.GetFiles();
            DirectoryInfo[] dirs = source.GetDirectories();
            // 检查目标文件夹是否存在，不存在则创建
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }
            //复制所有文件
            foreach (FileInfo fi in files)
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name));
            }
            //递归复制子目录
            foreach (DirectoryInfo diSourceSubDir in dirs)
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        //复制或移动目录
        private void CopyDirectory(string source)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(source);
                string destination = Path.Combine(currentPath, dir.Name);
                if (destination == source)  //目标路径和源路径相同，返回
                    return;
                if (IsMove) //移动
                    dir.MoveTo(destination);
                else    //复制
                {
                    CopyAll(dir, new DirectoryInfo(destination));
                }
                //listView1.Items.Add(dir.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //粘贴
        private void Paste()
        {
            if (sources[0] == null) //无源文件则返回
                return;
            if (!Directory.Exists(currentPath)) //当前路径无效则返回
                return;
            for (int i = 0; sources[i] != null; i++)
            {
                if (File.Exists(sources[i]))    //文件
                {
                    CopyFile(sources[i]);
                }
                else if (Directory.Exists(sources[i]))  //目录
                {
                    CopyDirectory(sources[i]);
                }
            }
            ListUpdate(currentPath);
            sources = new string[100];
        }

        //删除
        private void Delete()
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            DialogResult result = MessageBox.Show("确定要删除吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
                return;
            try
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    string path = item.Name;
                    if (File.Exists(path))  //文件
                        File.Delete(path);
                    else if (Directory.Exists(path))    //目录
                        Directory.Delete(path, true);
                    listView1.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //新建文件夹
        private void CreateFolder()
        {
            try
            {
                string path = Path.Combine(currentPath, "重命名");
                int i = 1;
                string newPath = path;
                while (Directory.Exists(newPath))
                {
                    newPath = path + i;
                    i++;
                }
                Directory.CreateDirectory(newPath);
                listView1.Items.Add(newPath, "重命名" + (i - 1 == 0 ? "" : (i - 1).ToString()), 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListDrivers();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
            ListUpdate(e.Node.FullPath);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            NodeUpdate(e.Node); //更新当前结点
            foreach (TreeNode node in e.Node.Nodes) //更新所有子结点
            {
                NodeUpdate(node);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Open();
        }

        #region 菜单栏代码

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAttributes();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void 工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;
        }

        private void 地址栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip2.Visible = !toolStrip2.Visible;
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
        }

        private void ClearCheck()
        {
            大图标ToolStripMenuItem.Checked = false;
            小图标ToolStripMenuItem.Checked = false;
            详细信息ToolStripMenuItem.Checked = false;
            列表ToolStripMenuItem.Checked = false;
            大图标ToolStripMenuItem1.Checked = false;
            小图标ToolStripMenuItem1.Checked = false;
            详细信息ToolStripMenuItem1.Checked = false;
            列表ToolStripMenuItem1.Checked = false;
        }

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheck();
            大图标ToolStripMenuItem.Checked = true;
            大图标ToolStripMenuItem1.Checked = true;
            listView1.View = View.LargeIcon;
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheck();
            小图标ToolStripMenuItem.Checked = true;
            小图标ToolStripMenuItem1.Checked = true;
            listView1.View = View.SmallIcon;
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheck();
            列表ToolStripMenuItem.Checked = true;
            列表ToolStripMenuItem1.Checked = true;
            listView1.View = View.List;
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCheck();
            详细信息ToolStripMenuItem.Checked = true;
            详细信息ToolStripMenuItem1.Checked = true;
            listView1.View = View.Details;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListUpdate(currentPath);
        }

        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 关于FileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout FormAbout1 = new FormAbout();
            FormAbout1.Show();
        }

        #endregion 菜单栏代码

        #region 工具栏代码

        //后退
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        //前进
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        //向上
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (currentPath == "")
                return;
            DirectoryInfo dir = new DirectoryInfo(currentPath);
            if (dir.Parent != null)
            {
                ListUpdate(dir.Parent.FullName);
            }
            else
            {
                ListDrivers();
            }
        }

        //搜索
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
        }

        //刷新
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ListUpdate(currentPath);
        }

        //属性
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ShowAttributes();
        }

        //剪切
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Cut();
        }

        //复制
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Copy();
        }

        //粘贴
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Paste();
        }

        //删除
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Delete();
        }

        //Blog
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Process.Start("http://blog.csdn.net/zhengzhiren");
        }

        #endregion 工具栏代码

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string newPath = toolStripComboBox1.Text;
            if (newPath == "")
                return;
            ListUpdate(newPath);
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string newPath = toolStripComboBox1.Text;
                if (newPath == "")
                    return;
                ListUpdate(newPath);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("http://blog.csdn.net/zhengzhiren");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            toolStripComboBox1.Width = this.Width - 112;
        }

        #region 上下文菜单代码

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point point = listView1.PointToClient(Cursor.Position);
            ListViewItem item = listView1.GetItemAt(point.X, point.Y);   //获得鼠标坐标处的ListViewItem
            if (item == null)   //当前位置没有ListViewItem
            {
                打开ToolStripMenuItem1.Visible = false;
                剪切ToolStripMenuItem2.Visible = false;
                复制ToolStripMenuItem2.Visible = false;
                删除ToolStripMenuItem2.Visible = false;
                查看ToolStripMenuItem1.Visible = true;
                刷新ToolStripMenuItem1.Visible = true;
                粘贴ToolStripMenuItem1.Visible = true;
                新建文件夹ToolStripMenuItem.Visible = true;
            }
            else    //有
            {
                查看ToolStripMenuItem1.Visible = false;
                刷新ToolStripMenuItem1.Visible = false;
                粘贴ToolStripMenuItem1.Visible = false;
                新建文件夹ToolStripMenuItem.Visible = false;
                打开ToolStripMenuItem1.Visible = true;
                剪切ToolStripMenuItem2.Visible = true;
                复制ToolStripMenuItem2.Visible = true;
                删除ToolStripMenuItem2.Visible = true;
            }
        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void 大图标ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearCheck();
            大图标ToolStripMenuItem.Checked = true;
            大图标ToolStripMenuItem1.Checked = true;
            listView1.View = View.LargeIcon;
        }

        private void 小图标ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearCheck();
            小图标ToolStripMenuItem.Checked = true;
            小图标ToolStripMenuItem1.Checked = true;
            listView1.View = View.SmallIcon;
        }

        private void 列表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearCheck();
            列表ToolStripMenuItem.Checked = true;
            列表ToolStripMenuItem1.Checked = true;
            listView1.View = View.List;
        }

        private void 详细信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearCheck();
            详细信息ToolStripMenuItem.Checked = true;
            详细信息ToolStripMenuItem1.Checked = true;
            listView1.View = View.Details;
        }

        private void 剪切ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void 复制ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }

        private void 属性ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAttributes();
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListUpdate(currentPath);
        }

        #endregion 上下文菜单代码
    }
}