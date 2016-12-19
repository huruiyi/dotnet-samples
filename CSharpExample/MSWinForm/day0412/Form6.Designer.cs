namespace day0412
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("操作系统");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("编译原理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("数据库原理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("计算机技术专业", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("信息学院", 24, 9, new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("基础数学专业");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("应用数学专业");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("数学学院", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("课程信息", 18, 21, new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点4";
            treeNode1.Text = "操作系统";
            treeNode2.Name = "节点7";
            treeNode2.Text = "编译原理";
            treeNode3.Name = "节点8";
            treeNode3.Text = "数据库原理";
            treeNode4.Name = "节点3";
            treeNode4.Text = "计算机技术专业";
            treeNode5.ImageIndex = 24;
            treeNode5.Name = "节点1";
            treeNode5.SelectedImageIndex = 9;
            treeNode5.Text = "信息学院";
            treeNode6.Name = "节点5";
            treeNode6.Text = "基础数学专业";
            treeNode7.Name = "节点6";
            treeNode7.Text = "应用数学专业";
            treeNode8.Name = "节点2";
            treeNode8.Text = "数学学院";
            treeNode9.ImageIndex = 18;
            treeNode9.Name = "节点0";
            treeNode9.SelectedImageIndex = 21;
            treeNode9.Text = "课程信息";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(199, 360);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1-1.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2-1.bmp");
            this.imageList1.Images.SetKeyName(3, "2.bmp");
            this.imageList1.Images.SetKeyName(4, "3-1.bmp");
            this.imageList1.Images.SetKeyName(5, "3.bmp");
            this.imageList1.Images.SetKeyName(6, "4-1.bmp");
            this.imageList1.Images.SetKeyName(7, "4.bmp");
            this.imageList1.Images.SetKeyName(8, "5-1.bmp");
            this.imageList1.Images.SetKeyName(9, "5.bmp");
            this.imageList1.Images.SetKeyName(10, "6-1.bmp");
            this.imageList1.Images.SetKeyName(11, "6.bmp");
            this.imageList1.Images.SetKeyName(12, "7-1.bmp");
            this.imageList1.Images.SetKeyName(13, "7.bmp");
            this.imageList1.Images.SetKeyName(14, "8-1.bmp");
            this.imageList1.Images.SetKeyName(15, "8.bmp");
            this.imageList1.Images.SetKeyName(16, "9-1.bmp");
            this.imageList1.Images.SetKeyName(17, "9.bmp");
            this.imageList1.Images.SetKeyName(18, "10-1.bmp");
            this.imageList1.Images.SetKeyName(19, "10.bmp");
            this.imageList1.Images.SetKeyName(20, "11-1.bmp");
            this.imageList1.Images.SetKeyName(21, "11.bmp");
            this.imageList1.Images.SetKeyName(22, "12-1.bmp");
            this.imageList1.Images.SetKeyName(23, "12.bmp");
            this.imageList1.Images.SetKeyName(24, "13-1.bmp");
            this.imageList1.Images.SetKeyName(25, "13.bmp");
            this.imageList1.Images.SetKeyName(26, "14-1.bmp");
            this.imageList1.Images.SetKeyName(27, "14.bmp");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加节点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "删除节点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(624, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "清空节点";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "展开节点";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(511, 98);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "折叠节点";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(400, 162);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "展开选中节点";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(624, 98);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "折叠选中节点";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(400, 235);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "查找课程";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(276, 235);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 360);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ImageList imageList1;
    }
}