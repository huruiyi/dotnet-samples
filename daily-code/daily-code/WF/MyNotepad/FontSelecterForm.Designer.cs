namespace MyNotepad
{
    partial class FontSelecterForm
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
            this.listFontBox = new System.Windows.Forms.ListBox();
            this.textBoxFont = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listFontStyleBox = new System.Windows.Forms.ListBox();
            this.textBoxFontStyle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listFontSizeBox = new System.Windows.Forms.ListBox();
            this.textBoxFontSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timerGetFocus = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // listFontBox
            // 
            this.listFontBox.FormattingEnabled = true;
            this.listFontBox.ItemHeight = 12;
            this.listFontBox.Location = new System.Drawing.Point(13, 60);
            this.listFontBox.Name = "listFontBox";
            this.listFontBox.ScrollAlwaysVisible = true;
            this.listFontBox.Size = new System.Drawing.Size(172, 136);
            this.listFontBox.TabIndex = 0;
            this.listFontBox.SelectedValueChanged += new System.EventHandler(this.listFontBox_SelectedValueChanged);
            // 
            // textBoxFont
            // 
            this.textBoxFont.Location = new System.Drawing.Point(13, 39);
            this.textBoxFont.Name = "textBoxFont";
            this.textBoxFont.Size = new System.Drawing.Size(172, 21);
            this.textBoxFont.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "字体(&F)：";
            // 
            // listFontStyleBox
            // 
            this.listFontStyleBox.FormattingEnabled = true;
            this.listFontStyleBox.ItemHeight = 12;
            this.listFontStyleBox.Items.AddRange(new object[] {
            "常规",
            "粗体",
            "倾斜",
            "粗体 倾斜"});
            this.listFontStyleBox.Location = new System.Drawing.Point(200, 60);
            this.listFontStyleBox.Name = "listFontStyleBox";
            this.listFontStyleBox.ScrollAlwaysVisible = true;
            this.listFontStyleBox.Size = new System.Drawing.Size(130, 136);
            this.listFontStyleBox.TabIndex = 3;
            this.listFontStyleBox.SelectedValueChanged += new System.EventHandler(this.listFontStyleBox_SelectedValueChanged);
            // 
            // textBoxFontStyle
            // 
            this.textBoxFontStyle.Location = new System.Drawing.Point(200, 39);
            this.textBoxFontStyle.Name = "textBoxFontStyle";
            this.textBoxFontStyle.Size = new System.Drawing.Size(130, 21);
            this.textBoxFontStyle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(197, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "字形(&Y)：";
            // 
            // listFontSizeBox
            // 
            this.listFontSizeBox.FormattingEnabled = true;
            this.listFontSizeBox.ItemHeight = 12;
            this.listFontSizeBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72",
            "初号",
            "小初",
            "一号",
            "小一",
            "二号",
            "小二",
            "三号",
            "小三",
            "四号",
            "小四",
            "五号",
            "小五",
            "六号",
            "小六",
            "七号",
            "八号"});
            this.listFontSizeBox.Location = new System.Drawing.Point(346, 60);
            this.listFontSizeBox.Name = "listFontSizeBox";
            this.listFontSizeBox.Size = new System.Drawing.Size(63, 112);
            this.listFontSizeBox.TabIndex = 6;
            this.listFontSizeBox.SelectedIndexChanged += new System.EventHandler(this.listFontSizeBox_SelectedIndexChanged);
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(346, 39);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(63, 21);
            this.textBoxFontSize.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(343, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "大小(&S)：";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(249, 225);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(77, 28);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(332, 225);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 28);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // timerGetFocus
            // 
            this.timerGetFocus.Tick += new System.EventHandler(this.timerGetFocus_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 199);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "显示更多字体";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // fontSelecterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 279);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFontSize);
            this.Controls.Add(this.listFontSizeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFontStyle);
            this.Controls.Add(this.listFontStyleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFont);
            this.Controls.Add(this.listFontBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fontSelecterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "字体";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.fontSelecterForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fontSelecterForm_FormClosing);
            this.Load += new System.EventHandler(this.fontSelecterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFontBox;
        private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listFontStyleBox;
        private System.Windows.Forms.TextBox textBoxFontStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listFontSizeBox;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Timer timerGetFocus;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}