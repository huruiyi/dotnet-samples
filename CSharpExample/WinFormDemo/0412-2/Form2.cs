using System;
using System.Drawing;
using System.Windows.Forms;

namespace _0412_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i <= 100; i++)
            {
                sum += i;
                System.Diagnostics.Debug.Print("第{0}次循环：{1}", i, sum);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            maskedTextBox1.ValidatingType = typeof(System.Int32);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("请输入数字");
                maskedTextBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("黑体", 15, FontStyle.Italic);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblHobby.Text = "你的爱好是：\n";
            if (checkBox1.Checked)
            {
                lblHobby.Text += checkBox1.Text + ",";
            }
            if (checkBox2.Checked)
            {
                lblHobby.Text += checkBox2.Text + ",";
            }
            if (checkBox3.Checked)
            {
                lblHobby.Text += checkBox3.Text + ",";
            }
            if (checkBox4.Checked)
            {
                lblHobby.Text += checkBox4.Text + ",";
            }
            if (checkBox5.Checked)
            {
                lblHobby.Text += checkBox5.Text + ",";
            }
            if (checkBox6.Checked)
            {
                lblHobby.Text += checkBox6.Text + ",";
            }

            if (lblHobby.Text.LastIndexOf(",") == lblHobby.Text.Length - 1)
            {
                lblHobby.Text = lblHobby.Text.Substring(0, lblHobby.Text.Length - 1);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckb = sender as CheckBox;

            if (ckb.Checked)
            {
                if (lblHobby.Text.Length > 6)
                {
                    lblHobby.Text += "," + ckb.Text;
                }
                else
                {
                    lblHobby.Text += ckb.Text;
                }
            }
            else
            {
                lblHobby.Text = lblHobby.Text.Replace(ckb.Text, "");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                lblgrxx.Text += "专业：" + radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                lblgrxx.Text += "专业：" + radioButton5.Text;
            }
            else
            {
                lblgrxx.Text += "专业：" + radioButton6.Text;
            }

            lblgrxx.Text += ",";
            if (radioButton1.Checked)
            {
                lblgrxx.Text += "班级：" + radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                lblgrxx.Text += "班级：" + radioButton2.Text;
            }
            else
            {
                lblgrxx.Text += "班级：" + radioButton3.Text;
            }
        }
    }
}