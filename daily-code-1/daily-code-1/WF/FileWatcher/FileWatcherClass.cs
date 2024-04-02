using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileWatcher
{
    public class FileWatcherClass
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        public ListView Lv { get; set; }

        public frmMain Frm { get; set; }

        public string Path { get; set; }

        public string Filter { get; set; }

        public Configuration Con { get; set; }

        public void WatcherFile()
        {
            if (Directory.Exists(Path))
            {
                try
                {
                    watcher.NotifyFilter = NotifyFilters.LastAccess;
                    watcher.Path = Path;
                    watcher.Filter = Filter;
                    watcher.IncludeSubdirectories = true;
                    watcher.NotifyFilter = NotifyFilters.FileName;
                    if (Con.IsRename)
                    {
                        watcher.Renamed += watcher_Renamed;
                    }
                    if (Con.IsModify)
                    {
                        watcher.Changed += watcher_Changed;
                    }
                    if (Con.IsCreate)
                    {
                        watcher.Created += watcher_Changed;
                    }
                    if (Con.IsDelete)
                    {
                        watcher.Deleted += watcher_Changed;
                    }
                    watcher.Error += watcher_Error;
                    watcher.EnableRaisingEvents = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void ClearWatcher()
        {
            if (null != watcher && Con != null)
            {
                if (Con.IsModify == false && Con.IsCreate == false && Con.IsDelete == false && Con.IsRename == false)
                {
                    watcher.Renamed -= watcher_Renamed;
                    watcher.Changed -= watcher_Changed;
                    watcher.Created -= watcher_Changed;
                    watcher.Deleted -= watcher_Changed;
                }
                if (Con.IsRename)
                {
                    watcher.Renamed -= watcher_Renamed;
                }
                if (Con.IsModify)
                {
                    watcher.Changed -= watcher_Changed;
                }
                if (Con.IsCreate)
                {
                    watcher.Created -= watcher_Changed;
                }
                if (Con.IsDelete)
                {
                    watcher.Deleted -= watcher_Changed;
                }
                watcher.Error -= watcher_Error;
            }
        }

        private void watcher_Error(object sender, ErrorEventArgs e)
        {
            try
            {
                Exception watchException = e.GetException();
                WatcherFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                watcher.EnableRaisingEvents = false;
                watcher.EnableRaisingEvents = true;
            }
            File file = new File(e.Name, e.FullPath);
            ListViewItem lvi = new ListViewItem(file.ToString()) { Tag = file };
            Lv.Items.Add(lvi);
            lvi.SubItems.AddRange(new string[] { e.ChangeType.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            del d = Open;
            Frm.Invoke(d, e.Name);
            ToPaly();
        }

        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            File file = new File(e.Name, e.FullPath);
            ListViewItem lvi = new ListViewItem(file.ToString());
            lvi.Tag = file;
            Lv.Items.Add(lvi);
            lvi.SubItems.AddRange(new string[] { e.ChangeType.ToString(), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            del d = Open;
            Frm.Invoke(d, e.Name);
            ToPaly();
        }

        private Thread Tpaly = null;

        private void ContentClick(object obj, EventArgs e)
        {
            Frm.Show();
            if (Frm.WindowState == FormWindowState.Minimized)
            {
                Frm.WindowState = FormWindowState.Normal;
                Frm.TopLevel = true;
            }
            //   ((TaskbarNotifier)(obj)).Hide();
        }

        private delegate void del(string content);

        private void Open(string content)
        {
            //string title = "新消息";
            //content = "文件：\n" + content + "\n被修改";
            //TaskbarNotifier taskbarNotifier = new TaskbarNotifier();
            //Image imgBack = Properties.Resources.skin;//从资源文件里得到背景图
            //taskbarNotifier.SetBackgroundBitmap(imgBack, Color.FromArgb(255, 0, 255));//设置背景图
            //Image imgClose = Properties.Resources.close;//从资源文件里得到关闭按钮图片
            //taskbarNotifier.SetCloseBitmap(imgClose, Color.FromArgb(255, 0, 255), new Point(127, 8));//设置关闭按钮
            //taskbarNotifier.TitleRectangle = new Rectangle(40, 9, 70, 25);//标题位置
            //taskbarNotifier.ContentRectangle = new Rectangle(8, 41, 133, 68);//文本位置
            ////taskbarNotifier1.TitleClick+=new EventHandler(TitleClick);
            //taskbarNotifier.ContentClick += ContentClick;
            //taskbarNotifier.CloseClick += taskbarNotifier_CloseClick;
            //taskbarNotifier.Show(title, content, 500, 3000, 500);//显示
        }

        private void taskbarNotifier_CloseClick(object sender, EventArgs e)
        {
            // ((TaskbarNotifier)(sender)).Hide();
        }

        private void ToPaly()
        {
            string sound = Application.StartupPath + "\\sound\\newmsg.wav";
            PalyWave.Instance.Play(sound);
        }

        public static void CopyFile(string path, string copyPath)
        {
            if (Directory.Exists(copyPath))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        if (fi.Extension == ".xls")
                        {
                            fi.CopyTo(copyPath + "\\" + fi.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("目标路径不存在");
            }
        }

        public static void SaveHis(string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "result";  //
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(content);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            System.Diagnostics.Process.Start(path);
        }
    }
}