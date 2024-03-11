using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfApp.Properties;

namespace WfApp
{
    public partial class Basic : Form
    {
        public Basic()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.SelectionFont = new Font("楷体", 12, FontStyle.Bold);
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.Text = "欢迎登录http://www.baidu.com百度";
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionIndent = 8;
            richTextBox1.SelectionRightIndent = 12;

            TreeNode tn1 = treeView1.Nodes.Add("名称");
            TreeNode ntn1 = new TreeNode("天亮以后");
            TreeNode ntn2 = new TreeNode("天外飞仙");
            TreeNode ntn3 = new TreeNode("一生所爱");
            tn1.Nodes.Add(ntn1);
            tn1.Nodes.Add(ntn2);
            tn1.Nodes.Add(ntn3);
            imageList1.Images.Add(Resources._1);
            imageList1.Images.Add(Resources._2);
            ////imageList1.Images.Add(Image.FromFile("./Res/2.png"));
            treeView1.ImageList = imageList1;
            imageList1.ImageSize = new Size(16, 16);
            treeView1.ImageIndex = 0;
            treeView1.SelectedImageIndex = 1;

            dateTimePicker1.Format = DateTimePickerFormat.Time;
            textBox1.Text = dateTimePicker1.Text;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM dd, yyyy - dddd";
            textBox2.Text = dateTimePicker2.Text;
        }

        private void btnDeleteTreeNode_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "名称")
            {
                MessageBox.Show("请选择要删除的子节点");
            }
            else
            {
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label1.Text = "当前选中的节点：" + e.Node.Text;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
