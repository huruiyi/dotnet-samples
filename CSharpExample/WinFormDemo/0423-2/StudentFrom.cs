using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class StudentFrom : Form
    {
        public StudentFrom()
        {
            InitializeComponent();
        }

        private void StudentFrom_Load(object sender, EventArgs e)
        {
            BindListView();
        }

        public void BindListView()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DBHelper.GetConstring();
                string sql = "select * from Student";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(sdr["StudenNo"].ToString());
                    lvi.SubItems.Add(sdr["StudentName"].ToString());
                    lvi.SubItems.Add(sdr["Sex"].ToString());
                    listView1.Items.Add(lvi);
                }
                sdr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DBHelper.GetConstring();
                string sql = string.Format(@"select  A.[StudenNo]
                                       ,A.[StudentName]
                                       ,A.[Sex]
                                       ,A.[GradeName]
                                       ,A.[Phone]
                                       ,A.[Address]
                                       ,convert(varchar(10),A.[BornDate],120) as BornDate
                                       ,A.[Email]
                                   from VIEW_Student_Grade as A
                                    where StudentName like '%{0}%'", txtStuNmae.Text);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(sdr["StudenNo"].ToString());
                    lvi.SubItems.Add(sdr["StudentName"].ToString());
                    lvi.SubItems.Add(sdr["Sex"].ToString());
                    lvi.SubItems.Add(sdr["GradeName"].ToString());

                    lvi.SubItems.Add(sdr["Phone"].ToString());
                    lvi.SubItems.Add(sdr["Address"].ToString());
                    lvi.SubItems.Add(sdr["BornDate"].ToString());
                    lvi.SubItems.Add(sdr[7].ToString());
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                updateStuForm usf = new updateStuForm(listView1.SelectedItems[0].Text);
                usf.Show();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string stuNo = listView1.SelectedItems[0].Text;
                string sql = string.Format("delete from Student where StudenNo='{0}'", stuNo);
                int result = DBHelper.ExcuteNoQuerry(sql);
                if (result > 0)
                {
                    MessageBox.Show("删除成功！");
                    BindListView();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }
    }
}