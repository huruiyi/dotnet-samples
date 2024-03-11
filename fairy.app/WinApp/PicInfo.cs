using System.ComponentModel;

namespace WinApp
{
    public partial class PicInfo : Form
    {
        public PicInfo()
        {
            InitializeComponent();
            InitializePictureBox();
            InitializeOpenFileDialog();
        }

        private void InitializePictureBox()
        {
            this.pictureBox1 = new PictureBox();
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Location = new Point(72, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(160, 136);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
        }

        private void InitializeOpenFileDialog()
        {
            this.openFileDialog1 = new OpenFileDialog();

            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "My Image Browser";
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        //https://learn.microsoft.com/zh-cn/dotnet/api/system.windows.forms.application.doevents?view=windowsdesktop-8.0
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Activate();
            string[] files = openFileDialog1.FileNames;

            // Open each file and display the image in pictureBox1.
            // Call Application.DoEvents to force a repaint after each
            // file is read.
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                FileStream fileStream = fileInfo.OpenRead();
                pictureBox1.Image = Image.FromStream(fileStream);
                Application.DoEvents();
                fileStream.Close();

                // Call Sleep so the picture is briefly displayed,
                //which will create a slide-show effect.
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}