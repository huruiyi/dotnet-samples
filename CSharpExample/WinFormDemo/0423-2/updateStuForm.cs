using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class updateStuForm : Form
    {
        private Dictionary<string, int> dic = new Dictionary<string, int>();
        private string stuNo;

        public updateStuForm()
        {
            InitializeComponent();
        }

        public updateStuForm(string stuNo)
        {
            InitializeComponent();
            this.stuNo = stuNo;
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

            string strsql = string.Format(@"select  [StudenNo]
                                       ,LoginPwd
                                       ,[StudentName]
                                       ,[Sex]
                                       ,[GradeId]
                                       ,[Phone]
                                       ,[Address]
                                       ,convert(varchar(10),[BornDate],120) as BornDate
                                       ,[Email] from Student
                                       where StudenNo='{0}'", stuNo);
            sdr = DBHelper.ExcuteQuerry(strsql);
            while (sdr.Read())
            {
                txtAddress.Text = sdr["Address"].ToString();
                txtBorn.Text = sdr["BornDate"].ToString();
                txtEmail.Text = sdr["Email"].ToString();
                txtName.Text = sdr["StudentName"].ToString();
                txtNo.Text = sdr["StudenNo"].ToString();
                txtPhone.Text = sdr["Phone"].ToString();
                txtPwd.Text = sdr["LoginPwd"].ToString();
                cbxSex.Text = sdr["Sex"].ToString();
                string gradename = "";
                foreach (string item in dic.Keys)
                {
                    if (dic[item] == Convert.ToInt32(sdr["GradeId"]))
                    {
                        gradename = item;
                        break;
                    }
                }
                cbxGrade.Text = gradename;
            }
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
                                       , txtPhone.Text, txtAddress.Text, txtBorn.Text, txtEmail.Text);
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