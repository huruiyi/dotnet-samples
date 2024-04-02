using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WfApp
{
    public partial class AndroidForm : Form
    {
        private enum MouseState
        {
            None = 0,
            MouseLeftDown = 1,
            MouseRightDown = 2,
        }

        /// <summary>
        /// 是否停止刷新界面
        /// </summary>
        private bool _isStop = false;

        /// <summary>
        /// 是否存在安卓
        /// </summary>
        private bool HasAndroid = false;

        /// <summary>
        /// 坐标换算乘数
        /// </summary>
        private double multiplierX = 0;

        private double multiplierY = 0;

        /// <summary>
        /// 黑人底部位置
        /// </summary>
        private Point Start;

        /// <summary>
        /// 图案中心或者白点位置
        /// </summary>
        private Point End;

        /// <summary>
        /// 设备后插入延时执行
        /// </summary>
        private System.Timers.Timer myTimer = new System.Timers.Timer(1200);

        public AndroidForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 执行adb命令
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ischeck"></param>
        /// <returns></returns>
        private string cmdAdb(string arguments, bool ischeck = true)
        {
            if (ischeck && !HasAndroid)
            {
                return string.Empty;
            }
            string ret = string.Empty;
            using (Process p = new Process())
            {
                p.StartInfo.FileName = @"D:\Software\android-sdk\platform-tools\adb.exe";// @"C:\Android\sdk\platform-tools\adb.exe";
                p.StartInfo.Arguments = arguments;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
                p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
                p.StartInfo.RedirectStandardError = true;   //重定向错误输出
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                ret = p.StandardOutput.ReadToEnd();
                p.Close();
            }
            return ret;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cmdAdb("shell input keyevent  82 ");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cmdAdb("shell input keyevent  3 ");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            cmdAdb("shell input keyevent 4 ");
        }

        private void AndroidForm_Load(object sender, EventArgs e)
        {
            myTimer.AutoReset = false;//只需要执行一次
            myTimer.Elapsed += (o, e1) => { CheckHasAndroidModel(); };
            if (!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\temp"))
            {
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\temp");
            }
            Environment.CurrentDirectory = Environment.CurrentDirectory + "\\temp";
            CheckHasAndroidModel();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                Debug.WriteLine("WParam：{0} ,LParam:{1},Msg：{2}，Result：{3}", m.WParam, m.LParam, m.Msg, m.Result);
                if (m.WParam.ToInt32() == 7)//设备插入或拔出
                {
                    CheckHasAndroidModel();
                    myTimer.Start();
                }
            }
            try
            {
                base.WndProc(ref m);
            }
            catch { }
        }

        /// <summary>
        /// 检测是否存在手机
        /// </summary>
        private void CheckHasAndroidModel()
        {
            var text = cmdAdb("shell getprop ro.product.model", false);//获取手机型号
            Debug.WriteLine("检查设备：" + text + "  T=" + DateTime.Now);
            if (text.Contains("no devices") || string.IsNullOrWhiteSpace(text))
            {
                HasAndroid = false;
                _isStop = true;
                toolStripStatusLabel2.Text = "未检测到设备";
            }
            else
            {
                HasAndroid = true;
                _isStop = false;
                toolStripStatusLabel2.Text = text.Trim();
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                if (_isStop)
                {
                    return;
                }
                //死循环截屏获取图片
                var tempFileName = "1.png";
                cmdAdb("shell screencap -p /sdcard/" + tempFileName);
                // pictureBox1.ImageLocation = Environment.CurrentDirectory + "\\temp\\" + tempFileName;
                cmdAdb("pull /sdcard/" + tempFileName);
                if (System.IO.File.Exists(tempFileName))
                {
                    //pictureBox1.BackgroundImage = new Bitmap(tempFileName);
                    using (var temp = Image.FromFile(tempFileName))
                    {
                        pictureBox1.Invoke(new Action(() =>
                        {
                            pictureBox1.Image = new Bitmap(temp);
                        }));
                    }
                    if (multiplierX == 0)
                    {
                        multiplierX = pictureBox1.Image.Width / (pictureBox1.Width + 0.00);
                        multiplierY = pictureBox1.Image.Height / (pictureBox1.Height + 0.00);
                    }
                    GC.Collect();
                    if (System.IO.File.Exists(tempFileName))
                    {
                        try
                        {
                            System.IO.File.Delete(tempFileName);
                        }
                        catch
                        {
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var me = ((System.Windows.Forms.MouseEventArgs)(e));
            if (me.Button == MouseButtons.Left)//按下左键是黑人底部的坐标
            {
                Start = ((System.Windows.Forms.MouseEventArgs)(e)).Location;
            }
            else if (me.Button == MouseButtons.Right)//按下右键键是黑人底部的坐标
            {
                End = ((System.Windows.Forms.MouseEventArgs)(e)).Location;
                //计算两点直接的距离
                double value = Math.Sqrt(Math.Abs(Start.X - End.X) * Math.Abs(Start.X - End.X) + Math.Abs(Start.Y - End.Y) * Math.Abs(Start.Y - End.Y));
                Text = string.Format("两点之间的距离：{0}，需要按下时间：{1}", value, (3.999022243950134 * value).ToString("0"));
                //3.999022243950134  这个是我通过多次模拟后得到 我这个分辨率的最佳时间
                cmdAdb(string.Format("shell input swipe 100 100 200 200 {0}", (3.999022243950134 * value).ToString("0")));
            }
        }

        private void AndroidForm_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (cmdAdb("install " + file).Contains("100%"))
                {
                    MessageBox.Show("安装成功");
                }
            }
        }

        private void AndroidForm_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Form1_DragEnter" + e.Data.GetDataPresent(DataFormats.FileDrop));
            if (e.Data.GetDataPresent(DataFormats.FileDrop))    //判断拖来的是否是文件
            {
                Array files = (System.Array)e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    if (System.IO.Path.GetExtension(files.GetValue(0).ToString()).EndsWith(".apk", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Link;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;            //是则将拖动源中的数据连接到控件
        }
    }
}