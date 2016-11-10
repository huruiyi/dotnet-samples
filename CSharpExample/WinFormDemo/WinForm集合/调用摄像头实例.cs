using AForge.Video.DirectShow;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Size = System.Drawing.Size;

/// <summary>
///  注意添加WindowsBase.dll
/// </summary>
namespace WinForm集合
{
    public partial class 调用摄像头实例 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public 调用摄像头实例()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    tscbxCameras.Items.Add(device.Name);
                }

                tscbxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                tscbxCameras.Items.Add("No local capture devices");
                videoDevices = null;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            CameraConn();
        }

        //连接摄像头
        private void CameraConn()
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[tscbxCameras.SelectedIndex].MonikerString);
            videoSource.DesiredFrameSize = new Size(600, 640);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer.VideoSource = videoSource;
            videoSourcePlayer.Start();
        }

        //关闭摄像头
        private void btnClose_Click(object sender, EventArgs e)
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }

        //主窗体关闭
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose_Click(null, null);
        }

        //拍照
        private void Photograph_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSourcePlayer.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer.GetCurrentVideoFrame().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    PngBitmapEncoder pE = new PngBitmapEncoder();
                    pE.Frames.Add(BitmapFrame.Create(bitmapSource));
                    string picName = GetImagePath() + "\\" + "xiaosy" + ".jpg";
                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                    }
                    using (Stream stream = File.Create(picName))
                    {
                        pE.Save(stream);
                    }
                    //拍照完成后关摄像头并刷新同时关窗体
                    if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
                    {
                        videoSourcePlayer.SignalToStop();
                        videoSourcePlayer.WaitForStop();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }

        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }
    }
}