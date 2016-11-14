using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinForm集合
{
    public partial class 图片操作_数据库 : Form
    {
        public 图片操作_数据库()
        {
            InitializeComponent();
        }

        private string ConString = "Data Source=.;Initial Catalog=ExampleDb;User ID=sa;Password=sa";

        private void button1_Click(object sender, EventArgs e)
        {
            PhotoHelp help = new PhotoHelp();
            string pathName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathName = openFileDialog1.FileName;
            }
            byte[] buffbyte = help.AddPhoto(pathName);
            pictureBox2.Image = Image.FromFile(pathName);
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string sqlText = "insert into Photos (photo) values(@photo)";
                using (SqlCommand cmd = new SqlCommand(sqlText, con))
                {
                    cmd.Parameters.AddWithValue("@photo", buffbyte);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConString);
            string sqlPhoto = "select Photo from Photos where pid=1";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlPhoto, con);
            adapter.Fill(dt);
            byte[] byteBuff = (byte[])dt.Rows[0]["Photo"];
            MemoryStream stream = new MemoryStream(byteBuff);
            Image image = Image.FromStream(stream, true);
            pictureBox1.Image = image;
            //pictureBox1.Height = image.Height;
            //pictureBox1.Width = image.Width;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("pictureBox1_DragEnter");
        }

        public void Add()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "图片（*.jpg）|*.jpg";
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                FileStream ms = new FileStream(openfiledialog.FileName, FileMode.Open, FileAccess.Read);
                byte[] buffbyte = new byte[ms.Length];
                ms.Read(buffbyte, 0, (int)(ms.Length));
                ms.Close();

                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    string SQlPhoto = "insert into Photos (photo) values (@photo)";
                    using (SqlCommand cmd = new SqlCommand(SQlPhoto, con))
                    {
                        cmd.Parameters.AddWithValue("@photo", buffbyte);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Query()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string sql = "select photo from Photos where pid=1";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        byte[] photo = (byte[])sdr["Photo"];
                        MemoryStream ms = new MemoryStream(photo);
                        Image image = Image.FromStream(ms, true);
                        pictureBox1.Image = image;
                    }
                }
            }
        }
    }
}