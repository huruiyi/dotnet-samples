using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_1
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            BindListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DBHelper.Getconstring();
                string sql = string.Format(@"select A.[StudenNo]
                                                   ,A.[StudentName]
                                                   ,A.[Sex]
                                                   ,A.[GradeName]
                                                   ,A.[Phone]
                                                   ,A.[Address]
                                                   ,convert(varchar(10),[BornDate],120) as BornDate
                                                   ,A.[Email]
                                    from VIEW_Grade_Student as A
                                    where StudentName like '%{0}%'", txtStuName.Text);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(sdr["StudenNo"].ToString());
                    lvi.SubItems.Add(sdr[1].ToString());
                    lvi.SubItems.Add(sdr[2].ToString());
                    lvi.SubItems.Add(sdr[3].ToString());
                    lvi.SubItems.Add(sdr[4].ToString());
                    lvi.SubItems.Add(sdr[5].ToString());
                    lvi.SubItems.Add(sdr[6].ToString());
                    lvi.SubItems.Add(sdr[7].ToString());
                    listView1.Items.Add(lvi);
                }
            }
        }

        public void BindListView()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DBHelper.Getconstring();
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtNo.Text == "")
            {
                MessageBox.Show("学号不能为空！");
                return;
            }
            updateStuForm usf = new updateStuForm(txtNo.Text);
            usf.Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string stuNo = listView1.SelectedItems[0].Text;
                updateStuForm usf = new updateStuForm(stuNo);
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