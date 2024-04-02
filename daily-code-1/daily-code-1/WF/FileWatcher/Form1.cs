using System;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class frmMain : Form
    {
        private Configuration con = SerializeHelper<Configuration>.DeSerialize();

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            if (con != null)
            {
                txtPath.Text = con.Path;
                txtType.Text = con.Filter;
                txtCopy.Text = con.CopyPath;
                chk0.Checked = con.IsRename;
                chk1.Checked = con.IsModify;
                chk2.Checked = con.IsDelete;
                chk3.Checked = con.IsCreate;
                chkAuto.Checked = con.IsAutoRun;
            }
            LoadWatcher(con);
        }

        private static frmMain frm;

        public static frmMain Frm
        {
            get
            {
                if (frm == null)
                {
                    frm = new frmMain();
                }
                return frm;
            }
        }

        private FileWatcherClass watcher = new FileWatcherClass();

        private void LoadWatcher(Configuration configuration)
        {
            watcher.Con = configuration;
            watcher.ClearWatcher();
            //文件监视
            watcher.Path = txtPath.Text.Trim();
            watcher.Filter = txtType.Text.Trim();
            watcher.Frm = this;
            watcher.Lv = lvFiles;
            watcher.WatcherFile();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //  this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // this.ShowInTaskbar = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //选择要监视的文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
                watcher.Path = txtPath.Text.Trim();
                watcher.Filter = txtType.Text.Trim();
                Configuration configuration = SerializeHelper<Configuration>.DeSerialize();
                LoadWatcher(configuration);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //打开监视的文件夹
            string path = txtPath.Text.Trim();
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //把监视的文件夹复制到目标文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCopy.Text = fbd.SelectedPath;

                FileWatcherClass.CopyFile(txtPath.Text.Trim(), txtCopy.Text.Trim());
                System.Diagnostics.Process.Start("explorer.exe", txtCopy.Text.Trim());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new Configuration
                {
                    Path = txtPath.Text.Trim(),
                    Filter = txtType.Text.Trim(),
                    CopyPath = txtCopy.Text.Trim(),
                    IsRename = chk0.Checked,
                    IsModify = chk1.Checked,
                    IsDelete = chk2.Checked,
                    IsCreate = chk3.Checked,
                    IsAutoRun = chkAuto.Checked
                };
                SerializeHelper<Configuration>.Serialize(con);
                LoadWatcher(con);
            }
        }

        private void ShowOrHide()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void niFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowOrHide();
        }

        private void 主窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrHide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要退出系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //  this.ShowInTaskbar = false;
            }
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                File file = (File)lvFiles.SelectedItems[0].Tag;
                try
                {
                    System.Diagnostics.Process.Start(file.FullName);
                }
                catch (Exception ex)
                {
                    DialogResult dr = MessageBox.Show(ex.Message + "\n确定要用记事本打开吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("notepad.exe", file.FullName);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvFiles.Items.Clear();
        }

        private void btnSaveHis_Click(object sender, EventArgs e)
        {
            if (lvFiles.Items.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            string content = "";
            foreach (ListViewItem lvi in lvFiles.Items)
            {
                content += lvi.SubItems[0].Text + "\t";
                content += lvi.SubItems[1].Text + "\t";
                content += lvi.SubItems[2].Text;
                content += "\n";
            }
            FileWatcherClass.SaveHis(content);
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            con.IsAutoRun = chkAuto.Checked;
            AutoRun.SetAutoRun(con.IsAutoRun);
            SerializeHelper<Configuration>.Serialize(con);
        }
    }
}