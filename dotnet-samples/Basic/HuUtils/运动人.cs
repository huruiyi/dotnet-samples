using System;
using System.Drawing;
using System.Windows.Forms;
using HuUtils.Properties;

namespace HuUtils
{
    public partial class 运动人 : Form
    {
        private Random _random = new Random();
        private readonly Bitmap[] _picsUp = { Resources.P_01, Resources.P_02, Resources.P_03, Resources.P_04, Resources.P_05, Resources.P_06 };
        private readonly Bitmap[] _picsDown = { Resources.P_07, Resources.P_08, Resources.P_09, Resources.P_10, Resources.P_11, Resources.P_12 };
        private readonly Bitmap[] _picsLeft = { Resources.P_13, Resources.P_14, Resources.P_15, Resources.P_16, Resources.P_17, Resources.P_18 };
        private readonly Bitmap[] _picsRight = { Resources.P_19, Resources.P_20, Resources.P_21, Resources.P_22, Resources.P_23, Resources.P_24 };
        private int _count;

        public 运动人()
        {
            InitializeComponent();
        }

        //顺着走
        private void timer1_Tick(object sender, EventArgs e)
        {
            //余数为零行往右走
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Left++;
                //如果碰到边缘，那么就走向下一行
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Left = (panel1.Width - pcbImage.Width);
                    pcbImage.Top++;
                }
            }
            //余数为1行往左走
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Left--;
                //如果碰到边缘，那么就走向下一行
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Left = 0;
                    pcbImage.Top++;
                }
            }
            //如果走到右下角，顺着走的时间（timer1）停止，此时逆着走的时间（ timer3）开始
            if (pcbImage.Top / 64 == 4 && pcbImage.Left == (panel1.Width - pcbImage.Width))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;//控制切换图片的时间
                timer3.Enabled = true;
                timer4.Enabled = true;//控制切换图片的时间
            }
        }

        //逆着走
        private void timer3_Tick(object sender, EventArgs e)
        {
            //余数为0往右走
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Left++;
                //如果碰到边缘，那么就走向上一行
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Left = panel1.Width - pcbImage.Width;
                    pcbImage.Top--;
                }
            }
            //余数为1往左走
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Left--;
                //如果碰到边缘，那么就走向上一行
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Left = 0;
                    pcbImage.Top--;
                }
            }

            //如果走到右上角，逆着走的时间停止，向左走一行的时间（ timer5）开始
            if ((pcbImage.Top) / 2 == 0)
            {
                timer3.Enabled = false;
                timer4.Enabled = false;//控制切换图片的时间
                timer5.Enabled = true;
                timer6.Enabled = true;//控制切换图片的时间
            }
        }

        //向左走一行
        private void timer5_Tick(object sender, EventArgs e)
        {
            pcbImage.Left--;
            //如果碰到边缘，那么向左走一行的时间停止（timer5）顺着走的时间（timer1）开始
            if (pcbImage.Left / 2 == 0)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;//控制切换图片的时间
                timer5.Enabled = false;
                timer6.Enabled = false;//控制切换图片的时间

                lblX.Text = pcbImage.Left.ToString();
                lblY.Text = pcbImage.Top.ToString();
            }
        }

        //顺走时候的图片切换
        private void timer2_Tick(object sender, EventArgs e)
        {
            //余数为0往右走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Image = _picsRight[_count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Image = _picsDown[_count++ % 6];
                }
            }
            //余数为1往左走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Image = _picsLeft[_count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left == 0)
                {
                    pcbImage.Image = _picsDown[_count++ % 6];
                }
            }
            lblX.Text = pcbImage.Left.ToString();
            lblY.Text = pcbImage.Top.ToString();
        }

        ////逆走时候的图片切换
        private void timer4_Tick(object sender, EventArgs e)
        {
            lblX.Text = pcbImage.Left.ToString();
            lblY.Text = pcbImage.Top.ToString();
            //余数为0往右走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Image = _picsRight[_count++ % 6];
                if (pcbImage.Left == (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Image = _picsUp[_count++ % 6];
                }
            }
            //余数为1往左走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Image = _picsLeft[_count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Image = _picsUp[_count++ % 6];
                }
            }
        }

        //向左走一行的图片
        private void timer6_Tick(object sender, EventArgs e)
        {
            pcbImage.Image = _picsLeft[_count++ % 6];
        }
    }
}