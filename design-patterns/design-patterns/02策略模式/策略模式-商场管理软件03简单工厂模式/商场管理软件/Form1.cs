using System;
using System.Windows.Forms;

namespace 商场管理软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //客户端窗体程序（主要部分）
        private double total = 0.0d;

        private void btnOk_Click(object sender, EventArgs e)
        {
            //利用简单工厂模式根据下拉选择框，生成相应的对象
            CashSuper csuper = CashFactory.createCashAccept(cbxType.SelectedItem.ToString());
            //通过多态，可以得到收取费用的结果
            var totalPrices = csuper.acceptCash(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text + " " + cbxType.SelectedItem + " 合计：" + totalPrices);
            lblResult.Text = total.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            total = 0d;
            txtPrice.Text = "0.00";
            txtNum.Text = "0";
            lbxList.Items.Clear();
            lblResult.Text = "0.00";
        }
    }
}