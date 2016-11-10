using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _0423_1
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

        private void addStuForm_Load(object sender, EventArgs e)
        {
            string strsql = "select * from Grade";

            SqlDataReader sdr = DBHelper.ExcuteQuerry(strsql);
            dic.Clear();
            while (sdr.Read())
            {
                //ListViewItem lvi = new ListViewItem(sdr["GradeName"].ToString());
                //lvi.Tag = sdr["GradeId"];
                dic.Add(sdr["GradeName"].ToString(), sdr.GetInt32(0));
                cbxGrade.Items.Add(sdr["GradeName"].ToString());
            }

            sdr.Close();

            string sql = string.Format(@"select * from Student
                                        where StudenNo='{0}'", stuNo);

            sdr = DBHelper.ExcuteQuerry(sql);
            while (sdr.Read())
            {
                txtstuNo.Text = stuNo;
                txtAddress.Text = sdr["Address"].ToString();
                txtBorn.Text = sdr["BornDate"].ToString();
                txtEmail.Text = sdr["Email"].ToString();
                txtName.Text = sdr["StudentName"].ToString();
                txtPhone.Text = sdr["Phone"].ToString();
                txtPwd.Text = sdr["LoginPwd"].ToString();
                foreach (string item in dic.Keys)
                {
                    if (dic[item] == Convert.ToInt32(sdr["GradeId"]))
                    {
                        cbxGrade.Text = item;
                        break;
                    }
                }

                cbxSex.Text = sdr["Sex"].ToString();
            }
            sdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"insert into Student(StudenNo
                                                   ,LoginPwd
                                                   ,[StudentName]
                                                   ,[Sex]
                                                   ,[GradeId]
                                                   ,[Phone]
                                                   ,[Address]
                                                   ,[BornDate]
                                                   ,[Email])
                                   values('{0}','{1}','{2}','{3}','{4}','{5}'
                                    ,'{6}','{7}','{8}')",
         txtstuNo.Text, txtPwd.Text, txtName.Text, cbxSex.Text,
         cbxGrade.Text, txtPhone.Text, txtAddress.Text, txtBorn.Text,
         txtEmail.Text);
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