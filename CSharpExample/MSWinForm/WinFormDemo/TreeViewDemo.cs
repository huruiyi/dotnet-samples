using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormDemo.Model;

namespace WinFormDemo
{
    public partial class TreeViewDemo : Form
    {
        #region 无边框窗体移动

        private const int WM_SYSCOMMAND = 0x0112;//点击窗口左上角那个图标时的系统信息
        private const int SC_MOVE = 0xF010;//移动信息
        private const int HTCAPTION = 0x0002;//表示鼠标在窗口标题栏时的系统信息
        private const int WM_NCHITTEST = 0x84;//鼠标在窗体客户区（除了标题栏和边框以外的部分）时发送的消息
        private const int HTCLIENT = 0x1;//表示鼠标在窗口客户区的系统消息
        private const int SC_MAXIMIZE = 0xF030;//最大化信息
        private const int SC_MINIMIZE = 0xF020;//最小化信息

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    if (m.WParam == (IntPtr)SC_MAXIMIZE)
                    {
                        m.WParam = (IntPtr)SC_MINIMIZE;
                    }
                    break;

                case WM_NCHITTEST: //如果鼠标移动或单击
                    base.WndProc(ref m);//调用基类的窗口过程——WndProc方法处理这个消息
                    if (m.Result == (IntPtr)HTCLIENT)//如果返回的是HTCLIENT
                    {
                        m.Result = (IntPtr)HTCAPTION;//把它改为HTCAPTION
                        return;//直接返回退出方法
                    }
                    break;
            }
            base.WndProc(ref m);//如果不是鼠标移动或单击消息就调用基类的窗口过程进行处理
        }

        #endregion 无边框窗体移动

        #region 顶部拖动

        private bool IsMouseDown = false;
        private Point mouseOffset;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = true;
            }
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        #endregion 顶部拖动

        public TreeViewDemo()
        {
            InitializeComponent();
        }

        private static List<Department> List;

        private void TreeViewDemo_Load(object sender, EventArgs e)
        {
            List = new List<Department>
            {
                new Department(1, 0, "根节点", false),
                new Department(2, 1, "子节点1", false),
                new Department(3, 1, "子节点2", false),
                new Department(4, 1, "子节点3", false),
                new Department(5, 1, "子节点4", false),
                new Department(6, 2, "子节点11", false),
                new Department(7, 2, "子节点12", false),
                new Department(8, 2, "子节点13", false),
                new Department(9, 2, "子节点13", false),
                new Department(10, 1, "子节点5", false),
                new Department(11, 1, "子节点6", false),
                new Department(12, 1, "子节点7", false),
                new Department(13, 1, "子节点8", false),
                new Department(14, 1, "子节点9", false),
                new Department(15, 1, "子节点10", false),
            };
            foreach (Department department in List)
            {
                if (department.ParentId == 0)
                {
                    TreeNode treeNodel = tvTree.Nodes.Add(department.Id.ToString(), department.Name);
                    treeNodel.Tag = department;
                }
                else
                {
                    TreeNode[] treeNodes = tvTree.Nodes.Find(department.ParentId.ToString(), true);
                    TreeNode treeNodel = treeNodes.FirstOrDefault().Nodes.Add(department.Id.ToString(), department.Name);
                    treeNodel.Tag = department;
                }
            }
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView selected = (TreeView)sender;
            TreeNode selectedNode = selected.SelectedNode;
            Department department = (Department)selectedNode.Tag;
            //MessageBox.Show(string.Format("当前选中节点:{0}({1})", selectedNode.Text, department));
        }

        private void tvTree_DoubleClick(object sender, EventArgs e)
        {
            TreeView selected = (TreeView)sender;
            TreeNode selectedNode = selected.SelectedNode;
            Department department = (Department)selectedNode.Tag;
            //MessageBox.Show(string.Format("双击节点:{0}({1})", selectedNode.Text, department));
        }

        private void tvTree_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                TreeView selected = (TreeView)sender;
                TreeNode selectedNode = selected.SelectedNode;
                CurrentSelectedNode = selectedNode;
                selectedNode.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private TreeNode CurrentSelectedNode { get; set; }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //需要设置LabelEdit  =true
            tvTree.LabelEdit = true;
            CurrentSelectedNode.BeginEdit();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvTree.Nodes.Remove(CurrentSelectedNode);
        }

        private void tvTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //修改失败
            e.CancelEdit = true;
            MessageBox.Show("Invalid tree node label.\nThe label cannot be blank", "Node Label Edit");
            //e.Node.BeginEdit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}