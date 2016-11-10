namespace _0423_2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "C盘",
            "本地磁盘",
            "150G",
            "128G"}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "D盘",
            "本地磁盘",
            "200G",
            "90G"}, 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "E盘",
            "本地磁盘",
            "110G",
            "90G"}, 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(847, 137);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "大图1.png");
            this.imageList1.Images.SetKeyName(1, "大图2.png");
            this.imageList1.Images.SetKeyName(2, "大图3.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "图1.png");
            this.imageList2.Images.SetKeyName(1, "图2.png");
            this.imageList2.Images.SetKeyName(2, "图3.png");
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "可用空间";
            this.columnHeader4.Width = 159;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView2.LargeImageList = this.imageList4;
            this.listView2.Location = new System.Drawing.Point(0, 309);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(847, 135);
            this.listView2.SmallImageList = this.imageList3;
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "14-1.bmp");
            this.imageList3.Images.SetKeyName(1, "1-1.bmp");
            this.imageList3.Images.SetKeyName(2, "2-1.bmp");
            this.imageList3.Images.SetKeyName(3, "3-1.bmp");
            this.imageList3.Images.SetKeyName(4, "4-1.bmp");
            this.imageList3.Images.SetKeyName(5, "5-1.bmp");
            this.imageList3.Images.SetKeyName(6, "6-1.bmp");
            this.imageList3.Images.SetKeyName(7, "7-1.bmp");
            this.imageList3.Images.SetKeyName(8, "8-1.bmp");
            this.imageList3.Images.SetKeyName(9, "9-1.bmp");
            this.imageList3.Images.SetKeyName(10, "10-1.bmp");
            this.imageList3.Images.SetKeyName(11, "11-1.bmp");
            this.imageList3.Images.SetKeyName(12, "12-1.bmp");
            this.imageList3.Images.SetKeyName(13, "13-1.bmp");
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "14.bmp");
            this.imageList4.Images.SetKeyName(1, "1.bmp");
            this.imageList4.Images.SetKeyName(2, "2.bmp");
            this.imageList4.Images.SetKeyName(3, "3.bmp");
            this.imageList4.Images.SetKeyName(4, "4.bmp");
            this.imageList4.Images.SetKeyName(5, "5.bmp");
            this.imageList4.Images.SetKeyName(6, "6.bmp");
            this.imageList4.Images.SetKeyName(7, "7.bmp");
            this.imageList4.Images.SetKeyName(8, "8.bmp");
            this.imageList4.Images.SetKeyName(9, "9.bmp");
            this.imageList4.Images.SetKeyName(10, "10.bmp");
            this.imageList4.Images.SetKeyName(11, "11.bmp");
            this.imageList4.Images.SetKeyName(12, "12.bmp");
            this.imageList4.Images.SetKeyName(13, "13.bmp");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加好友";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "小图标";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(309, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "大图标";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "昵称";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "QQ号码";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "性别";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "年龄";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(412, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "详细信息";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 444);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ImageList imageList4;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button4;
    }
}

