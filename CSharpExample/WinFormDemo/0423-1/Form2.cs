using System;
using System.Windows.Forms;

namespace _0423_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode.Nodes.Add(textBox1.Text);
                }
                else
                {
                    treeView1.Nodes.Add(textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("请输入节点信息！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Remove();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Nodes.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Expand();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Collapse();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                #region 遍历0级节点

                foreach (TreeNode node0 in treeView1.Nodes)
                {
                    //如果存在子节点
                    if (node0.Nodes.Count > 0)
                    {
                        #region 遍历1级节点

                        foreach (TreeNode node1 in node0.Nodes)
                        {
                            if (node1.Nodes.Count > 0)
                            {
                                #region 遍历2级节点

                                foreach (TreeNode node2 in node1.Nodes)
                                {
                                    if (node2.Nodes.Count > 0)
                                    {
                                        #region 遍历3级节点

                                        foreach (TreeNode node3 in node2.Nodes)
                                        {
                                            if (node3.Text == textBox2.Text)
                                            {
                                                node3.Checked = true;
                                                treeView1.SelectedNode = node3;
                                                //nodes[i].ForeColor = Color.Red;
                                                return;
                                            }
                                        }

                                        #endregion 遍历3级节点
                                    }
                                }

                                #endregion 遍历2级节点
                            }
                        }

                        #endregion 遍历1级节点
                    }
                }

                #endregion 遍历0级节点

                //TreeNodeCollection nodes = treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes;
                //for (int i = 0; i < nodes.Count; i++)
                //{
                //    if (nodes[i].Text == textBox2.Text)
                //    {
                //        nodes[i].Checked = true;
                //        treeView1.SelectedNode = nodes[i];
                //        //nodes[i].ForeColor = Color.Red;
                //        return;
                //    }
                //}

                MessageBox.Show(textBox2.Text + "课程不存在！");
            }
            else
            {
                MessageBox.Show("请输入查找课程名称");
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }
    }
}