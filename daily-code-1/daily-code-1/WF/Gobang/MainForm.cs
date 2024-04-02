using System;
using System.Collections;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Gobang
{
    public partial class MainForm : Form
    {
        private int[,] table;
        private int foot;
        private bool canPlay;
        private bool computerFirst;
        private bool computerBlack;
        private ArrayList recordList;
        private Image computerImage;
        private Image playerImage;

        public MainForm()
        {
            InitializeComponent();

            this.table = new int[15, 15];
            this.foot = 1;
            this.canPlay = true;
            this.computerFirst = false;
            this.computerBlack = true;
            this.recordList = new ArrayList();
            this.LoadImage();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.richPictureBox1.Image = Image.FromFile(@"image\board.jpg");
        }

        private void richPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.canPlay)
            {
                Point p = GetMousePoint(e.X, e.Y);
                this.Reword(p, true);
                if (Explore.Test(this.table))
                {
                    new SoundPlayer(@"music\win.wav").Play();
                    MessageBox.Show("恭喜！\r\n玩家获胜！", "温馨提示");
                    this.canPlay = false;
                    return;
                }
                if (this.computerFirst)
                    this.foot += 1;
                p = Explore.FindOptimalPoint(this.table);
                this.Reword(p, false);
                if (Explore.Test(this.table))
                {
                    new SoundPlayer(@"music\fail.wav").Play();
                    MessageBox.Show("很遗憾！\r\n电脑获胜！", "温馨提示");
                    this.canPlay = false;
                    return;
                }
                if (!this.computerFirst)
                    this.foot += 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.canPlay)
                this.canPlay = true;
            this.table = new int[15, 15];
            this.richPictureBox1.Clear();
            this.listBox1.Items.Clear();
            this.recordList.Clear();
            this.foot = 1;
            if (this.computerFirst)
            {
                Point p = Explore.FindOptimalPoint(this.table);
                this.Reword(p, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetForm sf = new SetForm(this.computerBlack, this.computerFirst);
            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (!sf.playerWhite)
                {
                    this.computerBlack = false;
                    this.LoadImage();
                }
                else
                {
                    this.computerBlack = true;
                    this.LoadImage();
                }
                if (!sf.playerFirst)
                {
                    this.computerFirst = true;
                }
                else
                {
                    this.computerFirst = false;
                }
                this.button1_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.foot == 1 || !this.canPlay)
            {
                MessageBox.Show("当前不能悔棋！", "温馨提示");
                return;
            }
            Point p1 = (Point)this.recordList[this.recordList.Count - 1];
            this.recordList.RemoveAt(this.recordList.Count - 1);
            Point p2 = (Point)this.recordList[this.recordList.Count - 1];
            this.recordList.RemoveAt(this.recordList.Count - 1);
            for (int i = 0; i < 2; i++)
                this.listBox1.Items.RemoveAt(this.listBox1.Items.Count - 1);
            this.table[p1.X, p1.Y] = 0;
            this.table[p2.X, p2.Y] = 0;
            string str1 = "", str2 = "";
            if (computerFirst)
            {
                str1 += "computer_" + this.foot.ToString();
                this.foot -= 1;
                str2 += "player_" + this.foot.ToString();
            }
            else
            {
                this.foot -= 1;
                str1 += "computer_" + this.foot.ToString();
                str2 += "player_" + this.foot.ToString();
            }
            this.richPictureBox1.Remove(str1);
            this.richPictureBox1.Remove(str2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static Point GetMousePoint(int mouse_X, int mouse_Y)
        {
            int x = (mouse_X - 1) / 31;
            int y = (mouse_Y - 1) / 31;
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            if (x > 14)
                x = 14;
            if (y > 14)
                y = 14;
            return new Point(x, y);
        }
        private void LoadImage()
        {
            if (this.computerBlack)
            {
                this.computerImage = Image.FromFile(@"image\black.png");
                this.playerImage = Image.FromFile(@"image\white.png");
            }
            else
            {
                this.computerImage = Image.FromFile(@"image\white.png");
                this.playerImage = Image.FromFile(@"image\black.png");
            }
        }
        private void Reword(Point point, bool isPlayer)
        {
            new SoundPlayer(@"music\placing.wav").Play();
            Image image = null;
            string str1 = "", str2 = "";
            if (isPlayer)
            {
                image = this.playerImage;
                str1 += "player_";
                str2 += "玩家第";
                this.table[point.X, point.Y] = 1;
            }
            else
            {
                image = this.computerImage;
                str1 += "computer_";
                str2 += "电脑第";
                this.table[point.X, point.Y] = 2;
            }
            str1 += this.foot.ToString();
            str2 += this.foot.ToString() + "步:(" + (point.X + 1).ToString() + "," + (point.Y + 1).ToString() + ")";
            this.richPictureBox1.Insert(str1, image, point.X * 31 + 1, point.Y * 31 + 1);
            this.recordList.Add(point);
            this.listBox1.Items.Add(str2);
            this.listBox1.TopIndex = this.listBox1.Items.Count - 1;
        }
    }
}