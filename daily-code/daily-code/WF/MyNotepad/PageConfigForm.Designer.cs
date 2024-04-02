namespace MyNotepad
{
    partial class PageConfigForm
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
            this.groupBoxPage = new System.Windows.Forms.GroupBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.groupBoxDir = new System.Windows.Forms.GroupBox();
            this.radioButtonS = new System.Windows.Forms.RadioButton();
            this.radioButtonV = new System.Windows.Forms.RadioButton();
            this.groupBoxMargin = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelB = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.labelL = new System.Windows.Forms.Label();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timerGetFocus = new System.Windows.Forms.Timer(this.components);
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.textBoxFooter = new System.Windows.Forms.TextBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelFooter = new System.Windows.Forms.Label();
            this.groupBoxPage.SuspendLayout();
            this.groupBoxDir.SuspendLayout();
            this.groupBoxMargin.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPage
            // 
            this.groupBoxPage.Controls.Add(this.labelSource);
            this.groupBoxPage.Controls.Add(this.labelSize);
            this.groupBoxPage.Controls.Add(this.comboBoxSource);
            this.groupBoxPage.Controls.Add(this.comboBoxSize);
            this.groupBoxPage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPage.Name = "groupBoxPage";
            this.groupBoxPage.Size = new System.Drawing.Size(336, 77);
            this.groupBoxPage.TabIndex = 0;
            this.groupBoxPage.TabStop = false;
            this.groupBoxPage.Text = "纸张";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(18, 54);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(59, 12);
            this.labelSource.TabIndex = 8;
            this.labelSource.Text = "来源(&S)：";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(18, 23);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(59, 12);
            this.labelSize.TabIndex = 0;
            this.labelSize.Text = "大小(&Z)：";
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Items.AddRange(new object[] {
            "自动选择"});
            this.comboBoxSource.Location = new System.Drawing.Point(90, 46);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(240, 20);
            this.comboBoxSource.TabIndex = 7;
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "A4",
            "A5",
            "A6"});
            this.comboBoxSize.Location = new System.Drawing.Point(90, 20);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(240, 20);
            this.comboBoxSize.TabIndex = 6;
            // 
            // groupBoxDir
            // 
            this.groupBoxDir.Controls.Add(this.radioButtonS);
            this.groupBoxDir.Controls.Add(this.radioButtonV);
            this.groupBoxDir.Location = new System.Drawing.Point(12, 95);
            this.groupBoxDir.Name = "groupBoxDir";
            this.groupBoxDir.Size = new System.Drawing.Size(96, 77);
            this.groupBoxDir.TabIndex = 1;
            this.groupBoxDir.TabStop = false;
            this.groupBoxDir.Text = "方向";
            // 
            // radioButtonS
            // 
            this.radioButtonS.AutoSize = true;
            this.radioButtonS.Location = new System.Drawing.Point(12, 55);
            this.radioButtonS.Name = "radioButtonS";
            this.radioButtonS.Size = new System.Drawing.Size(65, 16);
            this.radioButtonS.TabIndex = 1;
            this.radioButtonS.Text = "横向(&A)";
            this.radioButtonS.UseVisualStyleBackColor = true;
            // 
            // radioButtonV
            // 
            this.radioButtonV.AutoSize = true;
            this.radioButtonV.Checked = true;
            this.radioButtonV.Location = new System.Drawing.Point(12, 20);
            this.radioButtonV.Name = "radioButtonV";
            this.radioButtonV.Size = new System.Drawing.Size(65, 16);
            this.radioButtonV.TabIndex = 0;
            this.radioButtonV.TabStop = true;
            this.radioButtonV.Text = "纵向(&O)";
            this.radioButtonV.UseVisualStyleBackColor = true;
            // 
            // groupBoxMargin
            // 
            this.groupBoxMargin.Controls.Add(this.textBox4);
            this.groupBoxMargin.Controls.Add(this.textBox3);
            this.groupBoxMargin.Controls.Add(this.textBox2);
            this.groupBoxMargin.Controls.Add(this.textBox1);
            this.groupBoxMargin.Controls.Add(this.labelB);
            this.groupBoxMargin.Controls.Add(this.labelT);
            this.groupBoxMargin.Controls.Add(this.labelR);
            this.groupBoxMargin.Controls.Add(this.labelL);
            this.groupBoxMargin.Location = new System.Drawing.Point(120, 95);
            this.groupBoxMargin.Name = "groupBoxMargin";
            this.groupBoxMargin.Size = new System.Drawing.Size(228, 77);
            this.groupBoxMargin.TabIndex = 2;
            this.groupBoxMargin.TabStop = false;
            this.groupBoxMargin.Text = "页边距（毫米）";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(48, 20);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 21);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "20";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(48, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "25";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "25";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "20";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(107, 53);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(47, 12);
            this.labelB.TabIndex = 3;
            this.labelB.Text = "下(&B)：";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(6, 53);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(47, 12);
            this.labelT.TabIndex = 2;
            this.labelT.Text = "上(&T)：";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(107, 23);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(47, 12);
            this.labelR.TabIndex = 1;
            this.labelR.Text = "右(&R)：";
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.Location = new System.Drawing.Point(6, 23);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(47, 12);
            this.labelL.TabIndex = 0;
            this.labelL.Text = "左(&L)：";
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.pictureBox1);
            this.groupBoxPreview.Location = new System.Drawing.Point(354, 12);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(162, 230);
            this.groupBoxPreview.TabIndex = 3;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "预览";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyNotepad.Properties.Resources.pageConfigForm;
            this.pictureBox1.Location = new System.Drawing.Point(35, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 127);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(342, 259);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(84, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(432, 259);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // timerGetFocus
            // 
            this.timerGetFocus.Tick += new System.EventHandler(this.timerGetFocus_Tick);
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(87, 185);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.Size = new System.Drawing.Size(261, 21);
            this.textBoxHeader.TabIndex = 6;
            this.textBoxHeader.Text = "&f";
            // 
            // textBoxFooter
            // 
            this.textBoxFooter.Location = new System.Drawing.Point(87, 212);
            this.textBoxFooter.Name = "textBoxFooter";
            this.textBoxFooter.Size = new System.Drawing.Size(261, 21);
            this.textBoxFooter.TabIndex = 7;
            this.textBoxFooter.Text = "第 &p 页";
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(21, 188);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(59, 12);
            this.labelHeader.TabIndex = 8;
            this.labelHeader.Text = "页眉(&H)：";
            // 
            // labelFooter
            // 
            this.labelFooter.AutoSize = true;
            this.labelFooter.Location = new System.Drawing.Point(21, 215);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(59, 12);
            this.labelFooter.TabIndex = 9;
            this.labelFooter.Text = "页脚(&F)：";
            // 
            // pageConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 294);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.textBoxFooter);
            this.Controls.Add(this.textBoxHeader);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.groupBoxMargin);
            this.Controls.Add(this.groupBoxDir);
            this.Controls.Add(this.groupBoxPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "页面设置";
            this.Deactivate += new System.EventHandler(this.pageConfigForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pageConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.pageConfigForm_Load);
            this.groupBoxPage.ResumeLayout(false);
            this.groupBoxPage.PerformLayout();
            this.groupBoxDir.ResumeLayout(false);
            this.groupBoxDir.PerformLayout();
            this.groupBoxMargin.ResumeLayout(false);
            this.groupBoxMargin.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPage;
        private System.Windows.Forms.GroupBox groupBoxDir;
        private System.Windows.Forms.GroupBox groupBoxMargin;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.RadioButton radioButtonS;
        private System.Windows.Forms.RadioButton radioButtonV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelL;
        private System.Windows.Forms.Timer timerGetFocus;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.TextBox textBoxFooter;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelFooter;
    }
}