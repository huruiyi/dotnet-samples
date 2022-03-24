using HuUtils.Service;
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
    public partial class GitOp : BaseForm
    {
        public GitOp()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
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

        public static string GetDestPath(string path)
        {
            string[] strs = path.Split('/');
            int len = strs.Length;
            string newPath = "【" + strs[len - 2] + "】-" + strs[len - 1];
            newPath = strs[len - 1];
            return newPath;
        }

        public void Fetch(String path)
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
                            txtLog.AppendText(log);
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

        private delegate void CloneDele(string url, string destPath);

        private void Clone(string url, string destPath)
        {
            txtLog.AppendText(url + Environment.NewLine);
            string dstDir = GetDestPath(url);
            CloneOptions options = new CloneOptions
            {
                OnCheckoutProgress = (path, completedSteps, totalSteps) =>
                {
                    txtLog.AppendText(path + "  " + completedSteps + "  " + totalSteps + Environment.NewLine);
                },
                OnProgress = serverProgressOutput =>
                {
                    txtLog.AppendText("Progress: " + serverProgressOutput + Environment.NewLine);
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

        public void TaskClone(string urlLines, string destPath, int taskCount)
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
                  {
                      CloneDele cloneDele = Clone;
                      cloneDele.BeginInvoke(list.Dequeue(), destPath, null, null);
                  }
              });
                tasks[i] = task;
            }

            Task.WaitAll(tasks);
        }

        //Get Push Urls
        private void BtnGetUrl_Click(object sender, EventArgs e)
        {
            SortedBindingList<GitInfoPath> gitPaths = new SortedBindingList<GitInfoPath>();
            GitInfoPath gitInfoPath;
            if (!String.IsNullOrWhiteSpace(txtGitPath.Text))
            {
                var directories = Directory.GetDirectories(txtGitPath.Text);
                foreach (string directory in directories)
                {
                    gitInfoPath = new GitInfoPath();
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtGitDir.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }
            string[] directories = Directory.GetDirectories(txtGitDir.Text);
            int taskCount = (directories.Length / 5) + 1;
            TaskFetch(txtGitDir.Text, taskCount);
        }

        /// <summary>
        /// 拉取代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPull_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrlsPath.Text) || string.IsNullOrWhiteSpace(txtDestBasePath.Text))
            {
                MessageBox.Show(@"请选择文件夹", @"Git 库 目录", MessageBoxButtons.AbortRetryIgnore);
                return;
            }

            int taskCount = (File.ReadAllLines(txtUrlsPath.Text).Length / 5) + 1;
            TaskClone(txtUrlsPath.Text, txtDestBasePath.Text, taskCount);
        }

        private void dgGitView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }

    public class GitInfoPath
    {
        public string DirName { get; set; }

        public string GitPath { get; set; }
    }
}