using System;
using System.Windows.Forms;

namespace day0415
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNum2_TextChanged(object sender, EventArgs e)
        {
            int num1, num2, num3;
            if (txtNum1.Text != "")
            {
                num1 = int.Parse(txtNum1.Text);
            }
            else
            {
                num1 = 0;
            }

            if (txtNum2.Text != "")
            {
                num2 = int.Parse(txtNum2.Text);
            }
            else
            {
                num2 = 0;
            }

            num3 = num1 + num2;
            txtNum3.Text = num3.ToString();
        }
    }
}