using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "server=.;database=MySchoolBase;uid=sa;pwd=sa";
            //using (
            SqlConnection con = null;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conString;
                con.Open();
                label1.Text = con.State.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
            finally
            {
                con.Close();
                this.Text = con.State.ToString();
            }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DBHelper.Getconstring();
            string sql = string.Format(@"select count(*) from Admin where loginId={0}
                       and loginPwd='{1}'", txtName.Text, txtPwd.Text);
            SqlCommand cmd = new SqlCommand(sql, con);
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
            //this.Text = con.State.ToString();
            con.Close();
        }
    }
}