using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class Key事件 : Form
    {
        public Key事件()
        {
            InitializeComponent();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtName.ForeColor = Color.Red;
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                txtLog.AppendText(string.Format("KeyUp,KeyCode={0},KeyValue={1},A键被点击" + Environment.NewLine, e.KeyCode, e.KeyValue));
            }
            else
            {
                txtLog.AppendText(string.Format("KeyUp,KeyCode={0},KeyValue={1}" + Environment.NewLine, e.KeyCode, e.KeyValue));
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)))
            {
                txtLog.AppendText(string.Format("KeyDown,KeyCode={0},KeyValue={1},你按下的不是数字键" + Environment.NewLine, e.KeyCode, e.KeyValue));
            }
            else
            {
                txtLog.AppendText(string.Format("KeyDown,KeyCode={0},KeyValue={1}" + Environment.NewLine, e.KeyCode, e.KeyValue));
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            int code = Convert.ToChar(txtPwd.Text.Substring(txtPwd.Text.Length - 1));
            if (code < 48 || code > 57)
            {
                txtPwd.Text = txtPwd.Text.Substring(0, txtPwd.Text.Length - 1);
            }
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
            txtNum3.Text = (int.Parse(txtNum1.Text) + int.Parse(txtNum2.Text)).ToString();
        }
    }
}
