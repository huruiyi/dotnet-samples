using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 数据集 : Form
    {
        public 数据集()
        {
            InitializeComponent();
        }

        private void DataSetExample_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“exampleDbDataSet.Admin”中。您可以根据需要移动或删除它。
            this.adminTableAdapter.Fill(this.exampleDbDataSet.Admin);
            dgGridViewAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            txtId.DataBindings.Add("Text", dgGridViewAdmin.DataSource, "ID");
            txtUserName.DataBindings.Add("Text", dgGridViewAdmin.DataSource, "UserName");
            txtPassword.DataBindings.Add("Text", dgGridViewAdmin.DataSource, "Password");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            adminTableAdapter.FillBy(exampleDbDataSet.Admin, Convert.ToInt64(txtSid.Text));
            //this.adminTableAdapter.FillById(Convert.ToInt64(txtSid.Text));
        }
    }
}