using System;
using System.Windows.Forms;

namespace 学习项目
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.adminTableAdapter.Fill(this._916TestDataSet.Admin);
            txtAdmin.DataBindings.Add("Text", dataGridView1.DataSource, "aAdmin");
            txtPassword.DataBindings.Add("Text", dataGridView1.DataSource, "APassword");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void fillByIdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.adminTableAdapter.FillById(this._916TestDataSet.Admin, ((int)(System.Convert.ChangeType(aIDToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}