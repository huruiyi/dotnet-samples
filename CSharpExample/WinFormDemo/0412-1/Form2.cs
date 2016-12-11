using System;
using System.Drawing;
using System.Windows.Forms;

namespace day0412
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

            sum = 0;
            for (int i = Convert.ToInt32(textBox1.Text); i <= Convert.ToInt32(textBox2.Text); i++)
            {
                sum += i;
            }
            MessageBox.Show("结果：" + sum);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            maskedTextBox1.ValidatingType = typeof(System.Int32);
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("请输入数字");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(new FontFamily("黑体"), 15);
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
                lblHobby.Text += checkBox5.Text;
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
                lblHobby.Text += ckb.Text + "\n";
            }
            else
            {
                if (lblHobby.Text.LastIndexOf(ckb.Text) >= 0)
                {
                    lblHobby.Text = lblHobby.Text.Replace(ckb.Text, "");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblinfo.Text = "专业：";
            if (radioButton1.Checked)
            {
                lblinfo.Text += radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                lblinfo.Text += radioButton2.Text;
            }
            else
            {
                lblinfo.Text += radioButton3.Text;
            }

            lblinfo.Text += "\n班级：";
            if (radioButton4.Checked)
            {
                lblinfo.Text += radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                lblinfo.Text += radioButton5.Text;
            }
            else
            {
                lblinfo.Text += radioButton6.Text;
            }
        }
    }
}