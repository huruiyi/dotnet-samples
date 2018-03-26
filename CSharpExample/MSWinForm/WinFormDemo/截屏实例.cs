using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormDemo
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
                g.CopyFromScreen(new System.Drawing.Point(0, 0), System.Drawing.Point.Empty, s.Bounds.Size);
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
    }
}