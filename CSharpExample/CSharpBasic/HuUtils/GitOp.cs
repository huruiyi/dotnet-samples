using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class GitOp : Form
    {
        public GitOp()
        {
            InitializeComponent();
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

        //Clone 基目录
        private void BtnPullSourceUrl_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialogGit.ShowDialog())
            {
                txtDestBasePath.Text = folderBrowserDialogGit.SelectedPath;
            }
        }

        //Git地址文件地址
        private void BtnSelectUrlsFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogGit.ShowDialog())
            {
                txtUrlsPath.Text = openFileDialogGit.FileName;
            }
        }

        public void ClearText()
        {
            lblTaskCount.Text = "";
        }
        public static String GetDestPath(String path)
        {
            string[] strs = path.Split('/');
            int len = strs.Length;
            string newPath = strs[len - 1] + "【" + strs[len - 2] + "】";
            return newPath;
        }

        public void Fetch(String path)
        {
            try
            {
                //  bool ProgressHandler(string serverProgressOutput);
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

                            txtMessage.AppendText(log + Environment.NewLine);
                            return true;
                        }
                    }, logMessage);
                    Console.WriteLine(remote.PushUrl ?? path);
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

        private static void Clone(string url, string destPath, bool addName)
        {
            string dstDir = GetDestPath(url);
            CloneOptions options = new CloneOptions
            {
                OnCheckoutProgress = (path, completedSteps, totalSteps) =>
                {
                    Console.WriteLine(path + "  " + completedSteps + "  " + totalSteps);
                },
                OnProgress = serverProgressOutput =>
                {
                    Console.WriteLine("Progress: " + serverProgressOutput);
                    return true;
                },
            };
            try
            {
                string path = Path.Combine(destPath, dstDir);
                if (!Directory.Exists(path))
                {
                    string clonedRepoPath = Repository.Clone(url, path, options);
                    using (Repository repo = new Repository(clonedRepoPath))
                    {
                        Console.WriteLine(repo.Stashes);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void TaskClone(string urlLines, string destPath, int taskCount, Boolean addName)
        {
            Queue<string> list = new Queue<string>();
            String[] strs = File.ReadAllLines(urlLines);
            foreach (string pathStr in strs)
            {
                list.Enqueue(pathStr);
            }

            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    while (list.Any())
                        Clone(list.Dequeue(), destPath, addName);
                });
                tasks[i] = task;
            }
           
            Task.WaitAll(tasks);
        }

        //Get Push Urls
        private void BtnGetUrl_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtGitPath.Text))
            {
                var directories = Directory.GetDirectories(txtGitPath.Text);
                foreach (string directory in directories)
                {
                    using (var repo = new Repository(directory))
                    {
                        var remote = repo.Network.Remotes["origin"];
                        txtUrls.AppendText(remote.PushUrl + Environment.NewLine);
                    }
                }
            }
        }

        //Update
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ClearText();
            if (String.IsNullOrWhiteSpace(txtGitDir.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }
            string[] directories = Directory.GetDirectories(txtGitDir.Text);
            int taskCount = (directories.Length / 5) + 1;
            lblTaskCount.Text = lblTaskCount.Text + taskCount;
            TaskFetch(txtGitDir.Text, taskCount);
        }

        //Pull
        private void BtnPull_Click(object sender, EventArgs e)
        {
            ClearText();
            if (String.IsNullOrWhiteSpace(txtUrlsPath.Text) || String.IsNullOrWhiteSpace(txtDestBasePath.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }

            int taskCount = (File.ReadAllLines(txtUrlsPath.Text).Length / 5) + 1;
            lblTaskCount.Text = lblTaskCount.Text + taskCount;
            TaskClone(txtUrlsPath.Text, txtDestBasePath.Text, taskCount, true);
        }
    }
}