using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string conString = "server=.;database=MySchoolBase;uid=sa;pwd=sa";
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DBHelper.GetConstring();
                con.Open();
                label1.Text = con.State.ToString();
                // con.Close();
                // this.Text = con.State.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = DBHelper.GetConstring();
                //string sql = string.Format("select count(*) from Admin where  loginPwd='{1}' and loginId={0}", txtName.Text, txtPwd.Text);
                string sql = "select count(*) from Admin where  loginPwd=@pwd and loginId=@id";
                SqlParameter[] parameters ={new SqlParameter("@pwd",txtPwd.Text),
                                              new SqlParameter("@id",txtName.Text)
                                          };

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = con;
                //cmd.CommandText = sql;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(parameters);
                con.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    MessageBox.Show("登陆成功！");
                    MainForm mf = new MainForm();
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            }
        }
    }
}