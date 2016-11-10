using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class GradeForm : Form
    {
        public GradeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtGradeName.Text == "")
            {
                MessageBox.Show("年级名称不能为空！");
                return;
            }

            using (SqlConnection cn = new SqlConnection(DBHelper.GetConstring()))
            {
                string sql = string.Format(@"insert into Grade(GradeName)
                                       values('{0}')", txtGradeName.Text);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
        }
    }
}