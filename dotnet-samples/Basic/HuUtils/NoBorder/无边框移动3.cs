using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace HuUtils.NoBorder
{
    public partial class 无边框移动3 : Form
    {
        private int _iniY;
        private int _iniX;

        private int _downY;
        private int _downX;

        private int _upY;
        private int _upX;

        public 无边框移动3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.AppendText("Form1_KeyDown" + "\r\n");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //    textBox1.AppendText("Form1_KeyPress" + "\r\n");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //   textBox1.AppendText("Form1_KeyUp" + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 250;

            this.BackColor = Color.Azure;
            textBox1.AppendText("Form1_Load" + "\r\n");
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //  textBox1.AppendText("Form1_MouseEnter" + "\r\n");
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            //  textBox1.AppendText("Form1_MouseHover" + "\r\n");
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //  textBox1.AppendText("Form1_MouseLeave" + "\r\n");
        }

        public Stack s = new Stack();

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //string tl = this.Top + "  " + this.Left;
            //textBox1.AppendText("Form1_MouseMove" + "  " + e.X + "  " + e.Y + "  " + tl + "\r\n");

            //s.Push(e);
            //if (s.Count >= 2)
            //{
            //    MouseEventArgs o1 = s.Pop() as MouseEventArgs;
            //    MouseEventArgs o2 = s.Pop() as MouseEventArgs;

            //    this.Left = this.Left + (o1.X - o2.X);
            //    this.Top = this.Top + (o1.Y - o2.Y);
            //}
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _iniY = this.Top;
            _iniX = this.Left;
            string tl = this.Top + "  " + this.Left;
            this._downX = e.X;
            this._downY = e.Y;
            // textBox1.AppendText("Form1_MouseDown" + "  " + e.X + "  " + e.Y + "  " + tl + "\r\n");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            string tl = this.Top + "  " + this.Left;
            this._upX = e.X;
            this._upY = e.Y;
            //textBox1.AppendText("Form1_MouseUp" + "  " + e.X + "  " + e.Y + "  " + tl + "\r\n");

            //textBox1.AppendText(this.DownX + "  " + this.DownY + "  " + this.UpX + "  " + this.UpY);

            int x = this._upX - this._downX;
            int y = this._upY - this._downY;

            this.Left = this._iniX + x;
            this.Top = this._iniY + y;
        }
    }
}