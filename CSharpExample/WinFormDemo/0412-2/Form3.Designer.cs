namespace _0412_2
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.txtkc = new System.Windows.Forms.TextBox();
            this.lsbkc = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnall = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnnonselect = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lsbcourse = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblbanji = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "你选修的课程是";
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(317, 65);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 1;
            this.btnselect.Text = "删除选中";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // txtkc
            // 
            this.txtkc.Location = new System.Drawing.Point(124, 249);
            this.txtkc.Name = "txtkc";
            this.txtkc.Size = new System.Drawing.Size(100, 21);
            this.txtkc.TabIndex = 2;
            // 
            // lsbkc
            // 
            this.lsbkc.FormattingEnabled = true;
            this.lsbkc.ItemHeight = 12;
            this.lsbkc.Items.AddRange(new object[] {
            "C#程序设计",
            "数据结构",
            "网页设计"});
            this.lsbkc.Location = new System.Drawing.Point(124, 65);
            this.lsbkc.Name = "lsbkc";
            this.lsbkc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbkc.Size = new System.Drawing.Size(141, 136);
            this.lsbkc.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(264, 249);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加课程";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnall
            // 
            this.btnall.Location = new System.Drawing.Point(317, 97);
            this.btnall.Name = "btnall";
            this.btnall.Size = new System.Drawing.Size(75, 23);
            this.btnall.TabIndex = 1;
            this.btnall.Text = "删除全部";
            this.btnall.UseVisualStyleBackColor = true;
            this.btnall.Click += new System.EventHandler(this.btnall_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnselectall
            // 
            this.btnselectall.Location = new System.Drawing.Point(317, 129);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(75, 23);
            this.btnselectall.TabIndex = 1;
            this.btnselectall.Text = "全选";
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.btnselectall_Click);
            // 
            // btnnonselect
            // 
            this.btnnonselect.Location = new System.Drawing.Point(317, 161);
            this.btnnonselect.Name = "btnnonselect";
            this.btnnonselect.Size = new System.Drawing.Size(75, 23);
            this.btnnonselect.TabIndex = 1;
            this.btnnonselect.Text = "反选";
            this.btnnonselect.UseVisualStyleBackColor = true;
            this.btnnonselect.Click += new System.EventHandler(this.btnnonselect_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "C#程序设计",
            "英语",
            "数学",
            "语文"});
            this.checkedListBox1.Location = new System.Drawing.Point(100, 301);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(309, 116);
            this.checkedListBox1.TabIndex = 5;
            // 
            // lsbcourse
            // 
            this.lsbcourse.FormattingEnabled = true;
            this.lsbcourse.ItemHeight = 12;
            this.lsbcourse.Location = new System.Drawing.Point(590, 65);
            this.lsbcourse.Name = "lsbcourse";
            this.lsbcourse.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbcourse.Size = new System.Drawing.Size(141, 136);
            this.lsbcourse.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "》》";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(431, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "《《";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(431, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "》";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(431, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "《";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "软件1201",
            "软件1202",
            "软件1203",
            "动漫1201",
            "动漫1202",
            "动漫1203"});
            this.comboBox1.Location = new System.Drawing.Point(455, 313);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "请选择班级";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblbanji
            // 
            this.lblbanji.AutoSize = true;
            this.lblbanji.Location = new System.Drawing.Point(453, 371);
            this.lblbanji.Name = "lblbanji";
            this.lblbanji.Size = new System.Drawing.Size(0, 12);
            this.lblbanji.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(455, 363);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox3.Location = new System.Drawing.Point(696, 313);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 10;
            this.comboBox3.Text = "请选择月份";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(840, 313);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 11;
            this.comboBox4.Text = "请选择日期";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 490);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblbanji);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lsbcourse);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lsbkc);
            this.Controls.Add(this.txtkc);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnnonselect);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnall);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnselect);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.TextBox txtkc;
        private System.Windows.Forms.ListBox lsbkc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnall;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Button btnnonselect;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ListBox lsbcourse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblbanji;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
    }
}