using LibGit2Sharp;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class GitClone : Form
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

        private delegate void CloneDelegate(string url, string destPath);

        public GitClone()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSelectUrlsFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogGit.ShowDialog())
            {
                txtUrlsPath.Text = openFileDialogGit.FileName;
            }
        }

        private void btnPullSourceUrl_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialogGit.ShowDialog())
            {
                txtDestBasePath.Text = folderBrowserDialogGit.SelectedPath;
            }
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrlsPath.Text) || string.IsNullOrWhiteSpace(txtDestBasePath.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }

            TaskClone(txtUrlsPath.Text, txtDestBasePath.Text);
        }

        public void TaskClone(string urlLines, string destPath)
        {
            Queue<string> list = new Queue<string>();
            string[] lines = File.ReadAllLines(urlLines);
            foreach (string pathStr in lines)
            {
                list.Enqueue(pathStr);
            }

            Task[] tasks = new Task[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string gitUrl = list.Dequeue();
                if (string.IsNullOrEmpty(gitUrl))
                {
                    continue;
                }

                tasks[i] = Task.Factory.StartNew(() =>
                {
                    CloneDelegate cloneDelegate = Clone;
                    cloneDelegate.BeginInvoke(gitUrl.Trim(), destPath.Trim(), Callback, gitUrl.Trim());
                });
            }

            Task.WaitAll(tasks);
        }

        private void Clone(string url, string destPath)
        {
            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(destPath))
            {
                return;
            }
            txtLog.AppendText("Clone Start:" + url + Environment.NewLine);
            CloneOptions options = new CloneOptions
            {
                OnCheckoutProgress = (path, completedSteps, totalSteps) =>
                {
                    txtLog.AppendText(url + " " + path + " " + completedSteps + " " + totalSteps + Environment.NewLine);
                },
                OnProgress = serverProgressOutput =>
                {
                    txtLog.AppendText($"{url} Progress: " + serverProgressOutput + Environment.NewLine);
                    return true;
                },
            };
            try
            {
                string dstDir = GetDestPath(url);
                string path = Path.Combine(destPath, dstDir.TrimEnd('.'));
                if (Directory.Exists(path))
                {
                    return;
                }

                string clonedRepoPath = Repository.Clone(url, path, options);
                using (Repository repo = new Repository(clonedRepoPath))
                {
                    Console.WriteLine(repo.Stashes);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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

        private void Callback(IAsyncResult result)
        {
            if (result.IsCompleted)
            {
                string log = $"{result.AsyncState,30}";
                txtLog.AppendText($"{log} Clone Success..." + Environment.NewLine);
            }
        }
    }
}