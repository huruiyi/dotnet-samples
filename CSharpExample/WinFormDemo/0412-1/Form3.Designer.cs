namespace _0412_1
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(290, 86);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 0;
            this.btnselect.Text = "删除选中";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "你所选修的课程是：";
            // 
            // lstkc
            // 
            this.lstkc.FormattingEnabled = true;
            this.lstkc.ItemHeight = 12;
            this.lstkc.Items.AddRange(new object[] {
            "C#程序设计",
            "网页设计",
            "数据库"});
            this.lstkc.Location = new System.Drawing.Point(145, 86);
            this.lstkc.Name = "lstkc";
            this.lstkc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstkc.Size = new System.Drawing.Size(120, 124);
            this.lstkc.TabIndex = 2;
            // 
            // txtkc
            // 
            this.txtkc.Location = new System.Drawing.Point(145, 249);
            this.txtkc.Name = "txtkc";
            this.txtkc.Size = new System.Drawing.Size(100, 21);
            this.txtkc.TabIndex = 3;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(290, 249);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "添加课程";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnall
            // 
            this.btnall.Location = new System.Drawing.Point(290, 151);
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
            this.cltleft.Location = new System.Drawing.Point(458, 86);
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
            this.cltrigth.Location = new System.Drawing.Point(747, 86);
            this.cltrigth.Name = "cltrigth";
            this.cltrigth.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cltrigth.Size = new System.Drawing.Size(120, 124);
            this.cltrigth.TabIndex = 4;
            // 
            // btnrigthall
            // 
            this.btnrigthall.Location = new System.Drawing.Point(622, 86);
            this.btnrigthall.Name = "btnrigthall";
            this.btnrigthall.Size = new System.Drawing.Size(75, 23);
            this.btnrigthall.TabIndex = 5;
            this.btnrigthall.Text = "》》";
            this.btnrigthall.UseVisualStyleBackColor = true;
            this.btnrigthall.Click += new System.EventHandler(this.btnrigthall_Click);
            // 
            // btnrigth
            // 
            this.btnrigth.Location = new System.Drawing.Point(622, 115);
            this.btnrigth.Name = "btnrigth";
            this.btnrigth.Size = new System.Drawing.Size(75, 23);
            this.btnrigth.TabIndex = 5;
            this.btnrigth.Text = "》";
            this.btnrigth.UseVisualStyleBackColor = true;
            this.btnrigth.Click += new System.EventHandler(this.btnrigth_Click);
            // 
            // btnleftall
            // 
            this.btnleftall.Location = new System.Drawing.Point(622, 144);
            this.btnleftall.Name = "btnleftall";
            this.btnleftall.Size = new System.Drawing.Size(75, 23);
            this.btnleftall.TabIndex = 5;
            this.btnleftall.Text = "《《";
            this.btnleftall.UseVisualStyleBackColor = true;
            this.btnleftall.Click += new System.EventHandler(this.btnleftall_Click);
            // 
            // btnleft
            // 
            this.btnleft.Location = new System.Drawing.Point(622, 173);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(75, 23);
            this.btnleft.TabIndex = 5;
            this.btnleft.Text = "《";
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // btnselectall
            // 
            this.btnselectall.Location = new System.Drawing.Point(587, 234);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(75, 23);
            this.btnselectall.TabIndex = 5;
            this.btnselectall.Text = "全选";
            this.btnselectall.UseVisualStyleBackColor = true;
            this.btnselectall.Click += new System.EventHandler(this.btnselectall_Click);
            // 
            // btnnonselect
            // 
            this.btnnonselect.Location = new System.Drawing.Point(668, 234);
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
            this.checkedListBox1.Location = new System.Drawing.Point(125, 308);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(131, 116);
            this.checkedListBox1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(290, 308);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblbanji
            // 
            this.lblbanji.AutoSize = true;
            this.lblbanji.Location = new System.Drawing.Point(288, 367);
            this.lblbanji.Name = "lblbanji";
            this.lblbanji.Size = new System.Drawing.Size(0, 12);
            this.lblbanji.TabIndex = 8;
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
            this.comboBox2.Location = new System.Drawing.Point(458, 308);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(668, 308);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 9;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 545);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblbanji);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnnonselect);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.btnleft);
            this.Controls.Add(this.btnleftall);
            this.Controls.Add(this.btnrigth);
            this.Controls.Add(this.btnrigthall);
            this.Controls.Add(this.cltrigth);
            this.Controls.Add(this.cltleft);
            this.Controls.Add(this.txtkc);
            this.Controls.Add(this.lstkc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btnall);
            this.Controls.Add(this.btnselect);
            this.Name = "Form3";
            this.Text = "这是Form3窗体";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label1;
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
    }
}