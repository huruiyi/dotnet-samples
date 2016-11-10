using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace WinForm集合
{
    public partial class Form1 : Form
    {
        private int IniY;
        private int IniX;

        private int DownY;
        private int DownX;

        private int UpY;
        private int UpX;

        public Form1()
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
            IniY = this.Top;
            IniX = this.Left;
            string tl = this.Top + "  " + this.Left;
            this.DownX = e.X;
            this.DownY = e.Y;
            // textBox1.AppendText("Form1_MouseDown" + "  " + e.X + "  " + e.Y + "  " + tl + "\r\n");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            string tl = this.Top + "  " + this.Left;
            this.UpX = e.X;
            this.UpY = e.Y;
            //textBox1.AppendText("Form1_MouseUp" + "  " + e.X + "  " + e.Y + "  " + tl + "\r\n");

            //textBox1.AppendText(this.DownX + "  " + this.DownY + "  " + this.UpX + "  " + this.UpY);

            int x = this.UpX - this.DownX;
            int y = this.UpY - this.DownY;

            this.Left = this.IniX + x;
            this.Top = this.IniY + y;
        }
    }
}