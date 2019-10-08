using HuUtils.Model;
using HuUtils.Service;
using System;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 数据绑定 : Form
    {
        public 数据绑定()
        {
            InitializeComponent();
        }

        private static SortedBindingList<Student> students = new SortedBindingList<Student>
        {
            new Student("小明", "男", 19, "江苏"),
            new Student("小红", "女", 23, "南京"),
            new Student("张三", "男", 21, "南京"),
            new Student("李四", "女", 17, "南京")
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<Student> students = new List<Student>();
            //students.Add(new Student("小明", "男", 19, "江苏"));
            //students.Add(new Student("小红", "女", 23, "南京"));
            //students.Add(new Student("张三", "男", 21, "南京"));
            //students.Add(new Student("李四", "女", 17, "南京"));
            //dataGridView1.DataSource = students;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.DataSource = students;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow collection = dataGridView1.Rows[e.RowIndex];
            string name = collection.Cells["Column1"].Value.ToString();
            lblName.Text = "姓名:" + name;
        }

        private void btnSerarch_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            Student student = null;
            foreach (Student item in students)
            {
                if (item.Name.Equals(name))
                {
                    student = item;
                }
            }
            SortedBindingList<Student> searchList = new SortedBindingList<Student>();
            searchList.Add(student);
            dataGridView1.DataSource = searchList;
        }
    }
}