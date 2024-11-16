using HuUtils.Service;

using LibGit2Sharp;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class GitOp : Form
    {
        private const int WmSyscommand = 0x0112;          //点击窗口左上角那个图标时的系统信息
        private const int Htcaption = 0x0002;             //表示鼠标在窗口标题栏时的系统信息
        private const int WmNchittest = 0x84;             //鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int Htclient = 0x1;                 //表示鼠标在窗口客户区的系统消息
        private const int ScMaximize = 0xF030;            //最大化信息
        private const int ScMinimize = 0xF020;            //最小化信息

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WmSyscommand:
                    if (m.WParam == (IntPtr)ScMaximize)
                    {
                        m.WParam = (IntPtr)ScMinimize;
                    }
                    break;

                case WmNchittest:
                    base.WndProc(ref m);
                    if (m.Result == (IntPtr)Htclient)
                    {
                        m.Result = (IntPtr)Htcaption;
                        return;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)

        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }

        public GitOp()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialogGit.ShowDialog())
            {
                txtGitDir.Text = folderBrowserDialogGit.SelectedPath;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialogGit.ShowDialog())
            {
                txtGitPath.Text = folderBrowserDialogGit.SelectedPath;
            }
        }

        public void Fetch(string path)
        {
            try
            {
                string logMessage = "";
                using (var repo = new Repository(path))
                {
                    var remote = repo.Network.Remotes["origin"];
                    var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    Commands.Fetch(repo, remote.Name, refSpecs, new FetchOptions
                    {
                        TagFetchMode = TagFetchMode.All,
                        OnTransferProgress = progress =>
                        {
                            string log = string.Format(CultureInfo.InvariantCulture, "{4}-{0}-{1}/{2}, {3} bytes", remote.Name, progress.ReceivedObjects, progress.TotalObjects, progress.ReceivedBytes, remote.PushUrl);
                            txtLog.AppendText(log + Environment.NewLine + Environment.NewLine);
                            return true;
                        }
                    }, logMessage);
                    txtLog.AppendText((remote.PushUrl ?? path) + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(path);
            }
        }

        public void TaskFetch(string directory, int taskCount)
        {
            Queue<string> list = new Queue<string>();

            string[] directories = Directory.GetDirectories(directory);
            foreach (string path in directories)
            {
                list.Enqueue(path);
            }

            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    while (list.Any())
                        Fetch(list.Dequeue());
                });
                tasks[i] = task;
            }
            Task.WaitAll(tasks);
        }

        private void BtnGetUrl_Click(object sender, EventArgs e)
        {
            try
            {
                SortedBindingList<GitInfoPath> gitPaths = new SortedBindingList<GitInfoPath>();
                if (!string.IsNullOrWhiteSpace(txtGitPath.Text))
                {
                    var directories = Directory.GetDirectories(txtGitPath.Text);
                    foreach (string directory in directories)
                    {
                        var gitInfoPath = new GitInfoPath();
                        using (var repo = new Repository(directory))
                        {
                            var remote = repo.Network.Remotes["origin"];
                            gitInfoPath.DirName = directory.Substring(directory.LastIndexOf('\\') + 1);
                            gitInfoPath.GitPath = remote.PushUrl;
                            gitPaths.Add(gitInfoPath);
                        }
                    }
                }
                dgGitView.DataSource = gitPaths;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGitDir.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }
            string[] directories = Directory.GetDirectories(txtGitDir.Text);
            int taskCount = (directories.Length / 5) + 1;
            TaskFetch(txtGitDir.Text, taskCount);
        }

        public static string GetDestPath(string path)
        {
            string[] strs = path.Split('/');
            int len = strs.Length;
            string newPath = strs[len - 1];
            if (newPath.EndsWith(".git"))
            {
                newPath = newPath.Replace(".git", "");
            }
            return newPath;
        }
    }

    public class GitInfoPath
    {
        public string DirName { get; set; }

        public string GitPath { get; set; }
    }
}