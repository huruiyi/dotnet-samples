using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WfApp
{
    public partial class AdoForm : Form
    {
        public AdoForm()
        {
            InitializeComponent();
        }

        private void btnImport1_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    con.Open();
                    int i = 0;
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                    foreach (var item in lines)
                    {
                        string[] info = item.Split('，', ',');
                        string sql = string.Format("insert into Admin (LoginID,LoginPwd) values ('{0}','{1}')", info[0], info[1]);
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                            i++;
                        }
                    }

                    MessageBox.Show(i.ToString());
                }
            }
        }

        private void btnImport2_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        //sb连接多个sql语句
                        StringBuilder sb = new StringBuilder();
                        foreach (var line in lines)
                        {
                            string[] arr = line.Split(',', '，');

                            if (arr.Length == 2)
                            {
                                sb.Append(string.Format("insert into [Admin] (LoginID,LoginPwd) values('{0}','{1}');", arr[0], arr[1]));
                            }
                        }
                        conn.Open();
                        cmd.CommandText = sb.ToString();
                        int n = cmd.ExecuteNonQuery();
                        MessageBox.Show(n.ToString());
                    }
                }
            }
        }

        private void btnImport3_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        int i = 0;
                        foreach (var line in lines)
                        {
                            string[] arr = line.Split(new char[] { ',', '，' });
                            if (arr.Length == 2)
                            {
                                string sql = "insert into [Admin](LoginID,LoginPwd) values(@name,@pwd)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@name", arr[0]);
                                cmd.Parameters.AddWithValue("@pwd", arr[1]);
                                cmd.CommandText = sql;
                                i++;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("添加了" + i);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            saveFileDialog1.Filter = "文本文件|*.txt|cs文件|*.cs|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    string sql = string.Format("select * from Admin");
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<string> users = new List<string>();
                            while (dr.Read())
                            {
                                string name = dr["LoginID"].ToString();
                                string pwd = dr["LoginPwd"].ToString();
                                users.Add(name + "," + pwd);
                            }
                            File.WriteAllLines(path, users.ToArray());
                            MessageBox.Show("保存了" + users.Count + "条数据");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConStr = "Data Source=.;Initial Catalog=ExampleDb;uid=sa;pwd=sa";
            saveFileDialog1.Filter = "文本文件|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    string sql = "select * from [Admin]";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<string> users = new List<string>();
                            while (dr.Read())
                            {
                                string name = dr["LoginID"].ToString();

                                string pwd = dr["LoginPwd"].ToString();

                                users.Add(name + "," + pwd);
                            }

                            File.WriteAllLines(path, users.ToArray());
                            MessageBox.Show("保存了" + users.Count);
                        }
                    }
                }
            }
        }

        private void AdoForm_Load(object sender, EventArgs e)
        {
        }
    }
}