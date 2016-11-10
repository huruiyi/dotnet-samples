using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class AddStuForm : Form
    {
        private Dictionary<string, int> dic = new Dictionary<string, int>();

        public AddStuForm()
        {
            InitializeComponent();
        }

        private void AddStuForm_Load(object sender, EventArgs e)
        {
            string sql = "select GradeId,GradeName from Grade";
            SqlDataReader sdr = DBHelper.ExcuteQuerry(sql);
            dic.Clear();
            while (sdr.Read())
            {
                dic.Add(sdr["GradeName"].ToString(), sdr.GetInt32(0));

                cbxGrade.Items.Add(sdr["GradeName"].ToString());
            }
            cbxGrade.Tag = dic;
            sdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dictionary<string ,int> di=new
            int gradeid = dic[cbxGrade.Text];
            string sql = string.Format(@"insert into Student(
                                         [StudenNo]
                                        ,[LoginPwd]
                                       ,[StudentName]
                                       ,[Sex]
                                       ,[GradeId]
                                       ,[Phone]
                                       ,[Address]
                                       ,[BornDate]
                                       ,[Email])values
                                        ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}')",
                                       txtNo.Text, txtPwd.Text, txtName.Text, cbxSex.Text, gradeid
                                       , txtPhone.Text, txtAddress.Text, dtpBorn.Value, txtEmail.Text);
            int result = DBHelper.ExcuteNoQuerry(sql);
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