namespace MyNotepad
{
    partial class PrintForm
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
            this.timerGetFocus = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.groupBoxRange = new System.Windows.Forms.GroupBox();
            this.textBoxPageNo = new System.Windows.Forms.TextBox();
            this.radioButtonPageNo = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrentPage = new System.Windows.Forms.RadioButton();
            this.radioButtonSelectRange = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.groupBoxPrinter = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonFindPrinter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddPrinter = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxRange.SuspendLayout();
            this.groupBoxPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerGetFocus
            // 
            this.timerGetFocus.Tick += new System.EventHandler(this.timerGetFocus_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Location = new System.Drawing.Point(8, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 322);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.groupBox1);
            this.tabPage.Controls.Add(this.groupBoxRange);
            this.tabPage.Controls.Add(this.groupBoxPrinter);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(436, 296);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "常规";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Location = new System.Drawing.Point(248, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(71, 15);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 21);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyNotepad.Properties.Resources.printFormAutoPagination;
            this.pictureBox1.Location = new System.Drawing.Point(8, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 52);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(6, 17);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(59, 12);
            this.labelCount.TabIndex = 0;
            this.labelCount.Text = "份数(&C)：";
            // 
            // groupBoxRange
            // 
            this.groupBoxRange.Controls.Add(this.textBoxPageNo);
            this.groupBoxRange.Controls.Add(this.radioButtonPageNo);
            this.groupBoxRange.Controls.Add(this.radioButtonCurrentPage);
            this.groupBoxRange.Controls.Add(this.radioButtonSelectRange);
            this.groupBoxRange.Controls.Add(this.radioButtonAll);
            this.groupBoxRange.Location = new System.Drawing.Point(8, 173);
            this.groupBoxRange.Name = "groupBoxRange";
            this.groupBoxRange.Size = new System.Drawing.Size(225, 103);
            this.groupBoxRange.TabIndex = 1;
            this.groupBoxRange.TabStop = false;
            this.groupBoxRange.Text = "页面范围";
            // 
            // textBoxPageNo
            // 
            this.textBoxPageNo.Location = new System.Drawing.Point(89, 64);
            this.textBoxPageNo.Name = "textBoxPageNo";
            this.textBoxPageNo.Size = new System.Drawing.Size(100, 21);
            this.textBoxPageNo.TabIndex = 4;
            // 
            // radioButtonPageNo
            // 
            this.radioButtonPageNo.AutoSize = true;
            this.radioButtonPageNo.Enabled = false;
            this.radioButtonPageNo.Location = new System.Drawing.Point(6, 64);
            this.radioButtonPageNo.Name = "radioButtonPageNo";
            this.radioButtonPageNo.Size = new System.Drawing.Size(77, 16);
            this.radioButtonPageNo.TabIndex = 3;
            this.radioButtonPageNo.Text = "页码(&G)：";
            this.radioButtonPageNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonCurrentPage
            // 
            this.radioButtonCurrentPage.AutoSize = true;
            this.radioButtonCurrentPage.Enabled = false;
            this.radioButtonCurrentPage.Location = new System.Drawing.Point(101, 42);
            this.radioButtonCurrentPage.Name = "radioButtonCurrentPage";
            this.radioButtonCurrentPage.Size = new System.Drawing.Size(89, 16);
            this.radioButtonCurrentPage.TabIndex = 2;
            this.radioButtonCurrentPage.Text = "当前页面(&U)";
            this.radioButtonCurrentPage.UseVisualStyleBackColor = true;
            // 
            // radioButtonSelectRange
            // 
            this.radioButtonSelectRange.AutoSize = true;
            this.radioButtonSelectRange.Enabled = false;
            this.radioButtonSelectRange.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSelectRange.Name = "radioButtonSelectRange";
            this.radioButtonSelectRange.Size = new System.Drawing.Size(89, 16);
            this.radioButtonSelectRange.TabIndex = 1;
            this.radioButtonSelectRange.Text = "选定范围(&T)";
            this.radioButtonSelectRange.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(6, 20);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(65, 16);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "全部(&L)";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // groupBoxPrinter
            // 
            this.groupBoxPrinter.Controls.Add(this.button1);
            this.groupBoxPrinter.Controls.Add(this.checkBox1);
            this.groupBoxPrinter.Controls.Add(this.buttonFindPrinter);
            this.groupBoxPrinter.Controls.Add(this.label3);
            this.groupBoxPrinter.Controls.Add(this.label2);
            this.groupBoxPrinter.Controls.Add(this.label1);
            this.groupBoxPrinter.Controls.Add(this.buttonAddPrinter);
            this.groupBoxPrinter.Location = new System.Drawing.Point(8, 8);
            this.groupBoxPrinter.Name = "groupBoxPrinter";
            this.groupBoxPrinter.Size = new System.Drawing.Size(417, 149);
            this.groupBoxPrinter.TabIndex = 0;
            this.groupBoxPrinter.TabStop = false;
            this.groupBoxPrinter.Text = "选择打印机";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(336, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "首选项(&R)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(228, 96);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "打印到文件(&F)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonFindPrinter
            // 
            this.buttonFindPrinter.Location = new System.Drawing.Point(299, 119);
            this.buttonFindPrinter.Name = "buttonFindPrinter";
            this.buttonFindPrinter.Size = new System.Drawing.Size(112, 23);
            this.buttonFindPrinter.TabIndex = 12;
            this.buttonFindPrinter.Text = "查找打印机(&D)...";
            this.buttonFindPrinter.UseVisualStyleBackColor = true;
            this.buttonFindPrinter.Click += new System.EventHandler(this.buttonFindPrinter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "位置：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "备注：";
            // 
            // buttonAddPrinter
            // 
            this.buttonAddPrinter.BackColor = System.Drawing.Color.White;
            this.buttonAddPrinter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(215)))), ((int)(((byte)(252)))));
            this.buttonAddPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.buttonAddPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPrinter.Location = new System.Drawing.Point(8, 20);
            this.buttonAddPrinter.Name = "buttonAddPrinter";
            this.buttonAddPrinter.Size = new System.Drawing.Size(244, 23);
            this.buttonAddPrinter.TabIndex = 8;
            this.buttonAddPrinter.Text = "添加打印机";
            this.buttonAddPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddPrinter.UseVisualStyleBackColor = false;
            this.buttonAddPrinter.Click += new System.EventHandler(this.buttonAddPrinter_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Location = new System.Drawing.Point(377, 332);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(296, 332);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Enabled = false;
            this.buttonPrint.Location = new System.Drawing.Point(215, 332);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "打印";
            this.buttonPrint.UseVisualStyleBackColor = true;
            // 
            // printForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 362);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "printForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印";
            this.Deactivate += new System.EventHandler(this.printForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.printForm_FormClosing);
            this.Load += new System.EventHandler(this.printForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxRange.ResumeLayout(false);
            this.groupBoxRange.PerformLayout();
            this.groupBoxPrinter.ResumeLayout(false);
            this.groupBoxPrinter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerGetFocus;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.GroupBox groupBoxPrinter;
        private System.Windows.Forms.GroupBox groupBoxRange;
        private System.Windows.Forms.TextBox textBoxPageNo;
        private System.Windows.Forms.RadioButton radioButtonPageNo;
        private System.Windows.Forms.RadioButton radioButtonCurrentPage;
        private System.Windows.Forms.RadioButton radioButtonSelectRange;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonAddPrinter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFindPrinter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}