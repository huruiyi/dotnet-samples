namespace HuUtils.BaseComponent
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
            this.btnselect = new System.Windows.Forms.Button();
            this.lstkc = new System.Windows.Forms.ListBox();
            this.txtkc = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnall = new System.Windows.Forms.Button();
            this.cltleft = new System.Windows.Forms.ListBox();
            this.cltrigth = new System.Windows.Forms.ListBox();
            this.btnrigthall = new System.Windows.Forms.Button();
            this.btnrigth = new System.Windows.Forms.Button();
            this.btnleftall = new System.Windows.Forms.Button();
            this.btnleft = new System.Windows.Forms.Button();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnnonselect = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblbanji = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(168, 24);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 0;
            this.btnselect.Text = "删除选中";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // lstkc
            // 
            this.lstkc.FormattingEnabled = true;
            this.lstkc.ItemHeight = 12;
            this.lstkc.Items.AddRange(new object[] {
            "C#程序设计",
            "网页设计",
            "数据库"});
            this.lstkc.Location = new System.Drawing.Point(23, 24);
            this.lstkc.Name = "lstkc";
            this.lstkc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstkc.Size = new System.Drawing.Size(128, 124);
            this.lstkc.TabIndex = 2;
            // 
            // txtkc
            // 
            this.txtkc.Location = new System.Drawing.Point(23, 187);
            this.txtkc.Name = "txtkc";
            this.txtkc.Size = new System.Drawing.Size(128, 21);
            this.txtkc.TabIndex = 3;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(168, 186);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "添加课程";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnall
            // 
            this.btnall.Location = new System.Drawing.Point(168, 105);
            this.btnall.Name = "btnall";
            this.btnall.Size = new System.Drawing.Size(75, 23);
            this.btnall.TabIndex = 0;
            this.btnall.Text = "删除全部";
            this.btnall.UseVisualStyleBackColor = true;
            this.btnall.Click += new System.EventHandler(this.btnall_Click);
            // 
            // cltleft
            // 
            this.cltleft.FormattingEnabled = true;
            this.cltleft.ItemHeight = 12;
            this.cltleft.Items.AddRange(new object[] {
            "软件1201",
            "软件1202",
            "软件1203",
            "计网1201",
            "计网1202",
            "计网1203"});
            this.cltleft.Location = new System.Drawing.Point(40, 35);
            this.cltleft.MultiColumn = true;
            this.cltleft.Name = "cltleft";
            this.cltleft.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cltleft.Size = new System.Drawing.Size(117, 124);
            this.cltleft.TabIndex = 4;
            // 
            // cltrigth
            // 
            this.cltrigth.FormattingEnabled = true;
            this.cltrigth.ItemHeight = 12;
            this.cltrigth.Location = new System.Drawing.Point(329, 35);
            this.cltrigth.Name = "cltrigth";
            this.cltrigth.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cltrigth.Size = new System.Drawing.Size(120, 124);
            this.cltrigth.TabIndex = 4;
            // 
            // btnrigthall
            // 
            this.btnrigthall.Location = new System.Drawing.Point(204, 35);
            this.btnrigthall.Name = "btnrigthall";
            this.btnrigthall.Size = new System.Drawing.Size(75, 23);
            this.btnrigthall.TabIndex = 5;
            this.btnrigthall.Text = "》》";
            this.btnrigthall.UseVisualStyleBackColor = true;
            this.btnrigthall.Click += new System.EventHandler(this.btnrigthall_Click);
            // 
            // btnrigth
            // 
            this.btnrigth.Location = new System.Drawing.Point(204, 66);
            this.btnrigth.Name = "btnrigth";
            this.btnrigth.Size = new System.Drawing.Size(75, 23);
            this.btnrigth.TabIndex = 5;
            this.btnrigth.Text = "》";
            this.btnrigth.UseVisualStyleBackColor = true;
            this.btnrigth.Click += new System.EventHandler(this.btnrigth_Click);
            // 
            // btnleftall
            // 
            this.btnleftall.Location = new System.Drawing.Point(204, 97);
            this.btnleftall.Name = "btnleftall";
            this.btnleftall.Size = new System.Drawing.Size(75, 23);
            this.btnleftall.TabIndex = 5;
            this.btnleftall.Text = "《《";
            this.btnleftall.UseVisualStyleBackColor = true;
            this.btnleftall.Click += new System.EventHandler(this.btnleftall_Click);
            // 
            // btnleft
            // 
            this.btnleft.Location = new System.Drawing.Point(204, 128);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(75, 23);
            this.btnleft.TabIndex = 5;
            this.btnleft.Text = "《";
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // btnselectall
            // 
            this.btnselectall.Location = new System.Drawing.Point(41, 160);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(75, 23);
            this.btnselectall.TabIndex = 5;
            this.btnselectall.Text = "全选";
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.btnselectall_Click);
            // 
            // btnnonselect
            // 
            this.btnnonselect.Location = new System.Drawing.Point(129, 160);
            this.btnnonselect.Name = "btnnonselect";
            this.btnnonselect.Size = new System.Drawing.Size(75, 23);
            this.btnnonselect.TabIndex = 5;
            this.btnnonselect.Text = "反选";
            this.btnnonselect.UseVisualStyleBackColor = true;
            this.btnnonselect.Click += new System.EventHandler(this.btnnonselect_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "软件1201",
            "软件1202",
            "软件1203",
            "计网1201",
            "计网1202",
            "计网1203"});
            this.checkedListBox1.Location = new System.Drawing.Point(21, 20);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(202, 116);
            this.checkedListBox1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblbanji
            // 
            this.lblbanji.AutoSize = true;
            this.lblbanji.Location = new System.Drawing.Point(23, 72);
            this.lblbanji.Name = "lblbanji";
            this.lblbanji.Size = new System.Drawing.Size(65, 12);
            this.lblbanji.TabIndex = 8;
            this.lblbanji.Text = "所选字体：";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "河南省",
            "湖南省",
            "湖北省",
            "陕西省"});
            this.comboBox2.Location = new System.Drawing.Point(42, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(42, 74);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnrigth);
            this.groupBox1.Controls.Add(this.cltleft);
            this.groupBox1.Controls.Add(this.cltrigth);
            this.groupBox1.Controls.Add(this.btnrigthall);
            this.groupBox1.Controls.Add(this.btnleftall);
            this.groupBox1.Controls.Add(this.btnleft);
            this.groupBox1.Location = new System.Drawing.Point(12, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 189);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "班级选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(522, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 185);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "省市联动";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.lblbanji);
            this.groupBox3.Location = new System.Drawing.Point(587, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 229);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "系统字体";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnnonselect);
            this.groupBox4.Controls.Add(this.btnselectall);
            this.groupBox4.Controls.Add(this.checkedListBox1);
            this.groupBox4.Location = new System.Drawing.Point(308, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 229);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "全选反选";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnadd);
            this.groupBox5.Controls.Add(this.btnselect);
            this.groupBox5.Controls.Add(this.btnall);
            this.groupBox5.Controls.Add(this.lstkc);
            this.groupBox5.Controls.Add(this.txtkc);
            this.groupBox5.Location = new System.Drawing.Point(12, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(267, 229);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "选项操作";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 569);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.Text = "这是Form3窗体";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.ListBox lstkc;
        private System.Windows.Forms.TextBox txtkc;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnall;
        private System.Windows.Forms.ListBox cltleft;
        private System.Windows.Forms.ListBox cltrigth;
        private System.Windows.Forms.Button btnrigthall;
        private System.Windows.Forms.Button btnrigth;
        private System.Windows.Forms.Button btnleftall;
        private System.Windows.Forms.Button btnleft;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Button btnnonselect;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblbanji;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}