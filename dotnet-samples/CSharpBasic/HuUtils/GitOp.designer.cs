namespace HuUtils
{
    partial class GitOp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialogGit = new System.Windows.Forms.FolderBrowserDialog();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGitDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectUrlsFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrlsPath = new System.Windows.Forms.TextBox();
            this.btnPullSourceUrl = new System.Windows.Forms.Button();
            this.txtDestBasePath = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.tabGetUrls = new System.Windows.Forms.TabPage();
            this.dgGitView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.txtGitPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.openFileDialogGit = new System.Windows.Forms.OpenFileDialog();
            this.btnClean = new System.Windows.Forms.Button();
            this.tabUpdate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabGetUrls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGitView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialogGit
            // 
            this.folderBrowserDialogGit.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tabUpdate
            // 
            this.tabUpdate.BackColor = System.Drawing.Color.MistyRose;
            this.tabUpdate.Controls.Add(this.groupBox3);
            this.tabUpdate.Controls.Add(this.groupBox2);
            this.tabUpdate.Controls.Add(this.groupBox1);
            this.tabUpdate.Location = new System.Drawing.Point(4, 29);
            this.tabUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.tabUpdate.Size = new System.Drawing.Size(1347, 681);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "更新";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(18, 288);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1326, 386);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.MistyRose;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLog.Location = new System.Drawing.Point(3, 22);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1320, 361);
            this.txtLog.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGitDir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBrowser);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(9, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1329, 107);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新代码";
            // 
            // txtGitDir
            // 
            this.txtGitDir.BackColor = System.Drawing.Color.MistyRose;
            this.txtGitDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGitDir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtGitDir.Location = new System.Drawing.Point(80, 45);
            this.txtGitDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtGitDir.Multiline = true;
            this.txtGitDir.Name = "txtGitDir";
            this.txtGitDir.Size = new System.Drawing.Size(845, 33);
            this.txtGitDir.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dir：";
            // 
            // btnBrowser
            // 
            this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowser.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnBrowser.Location = new System.Drawing.Point(933, 45);
            this.btnBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(88, 33);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnUpdate.Location = new System.Drawing.Point(1026, 45);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 33);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnClean);
            this.groupBox1.Controls.Add(this.btnSelectUrlsFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUrlsPath);
            this.groupBox1.Controls.Add(this.btnPullSourceUrl);
            this.groupBox1.Controls.Add(this.txtDestBasePath);
            this.groupBox1.Controls.Add(this.btnPull);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(9, 136);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1329, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拉取代码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Dest：";
            // 
            // btnSelectUrlsFile
            // 
            this.btnSelectUrlsFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectUrlsFile.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSelectUrlsFile.Location = new System.Drawing.Point(933, 32);
            this.btnSelectUrlsFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectUrlsFile.Name = "btnSelectUrlsFile";
            this.btnSelectUrlsFile.Size = new System.Drawing.Size(88, 34);
            this.btnSelectUrlsFile.TabIndex = 8;
            this.btnSelectUrlsFile.Text = "浏览";
            this.btnSelectUrlsFile.UseVisualStyleBackColor = true;
            this.btnSelectUrlsFile.Click += new System.EventHandler(this.BtnSelectUrlsFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Uri：";
            // 
            // txtUrlsPath
            // 
            this.txtUrlsPath.BackColor = System.Drawing.Color.MistyRose;
            this.txtUrlsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlsPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUrlsPath.Location = new System.Drawing.Point(80, 32);
            this.txtUrlsPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrlsPath.Multiline = true;
            this.txtUrlsPath.Name = "txtUrlsPath";
            this.txtUrlsPath.Size = new System.Drawing.Size(845, 33);
            this.txtUrlsPath.TabIndex = 6;
            // 
            // btnPullSourceUrl
            // 
            this.btnPullSourceUrl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPullSourceUrl.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPullSourceUrl.Location = new System.Drawing.Point(933, 74);
            this.btnPullSourceUrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnPullSourceUrl.Name = "btnPullSourceUrl";
            this.btnPullSourceUrl.Size = new System.Drawing.Size(88, 33);
            this.btnPullSourceUrl.TabIndex = 5;
            this.btnPullSourceUrl.Text = "浏览";
            this.btnPullSourceUrl.UseVisualStyleBackColor = true;
            this.btnPullSourceUrl.Click += new System.EventHandler(this.BtnPullSourceUrl_Click);
            // 
            // txtDestBasePath
            // 
            this.txtDestBasePath.BackColor = System.Drawing.Color.MistyRose;
            this.txtDestBasePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestBasePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDestBasePath.Location = new System.Drawing.Point(80, 74);
            this.txtDestBasePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestBasePath.Multiline = true;
            this.txtDestBasePath.Name = "txtDestBasePath";
            this.txtDestBasePath.Size = new System.Drawing.Size(845, 33);
            this.txtDestBasePath.TabIndex = 4;
            // 
            // btnPull
            // 
            this.btnPull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPull.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPull.Location = new System.Drawing.Point(1026, 74);
            this.btnPull.Margin = new System.Windows.Forms.Padding(4);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(88, 33);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.BtnPull_Click);
            // 
            // tabGetUrls
            // 
            this.tabGetUrls.BackColor = System.Drawing.Color.MistyRose;
            this.tabGetUrls.Controls.Add(this.dgGitView);
            this.tabGetUrls.Controls.Add(this.btnGetUrl);
            this.tabGetUrls.Controls.Add(this.txtGitPath);
            this.tabGetUrls.Controls.Add(this.button1);
            this.tabGetUrls.Controls.Add(this.label2);
            this.tabGetUrls.Location = new System.Drawing.Point(4, 29);
            this.tabGetUrls.Margin = new System.Windows.Forms.Padding(4);
            this.tabGetUrls.Name = "tabGetUrls";
            this.tabGetUrls.Padding = new System.Windows.Forms.Padding(4);
            this.tabGetUrls.Size = new System.Drawing.Size(1347, 681);
            this.tabGetUrls.TabIndex = 0;
            this.tabGetUrls.Text = "获取Url";
            // 
            // dgGitView
            // 
            this.dgGitView.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgGitView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGitView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGitView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgGitView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGitView.GridColor = System.Drawing.Color.MistyRose;
            this.dgGitView.Location = new System.Drawing.Point(4, 85);
            this.dgGitView.Margin = new System.Windows.Forms.Padding(4);
            this.dgGitView.Name = "dgGitView";
            this.dgGitView.RowTemplate.Height = 23;
            this.dgGitView.Size = new System.Drawing.Size(1339, 592);
            this.dgGitView.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DirName";
            this.Column1.HeaderText = "文件夹名称";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "GitPath";
            this.Column2.HeaderText = "Git路径";
            this.Column2.Name = "Column2";
            this.Column2.Width = 790;
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetUrl.Location = new System.Drawing.Point(993, 22);
            this.btnGetUrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(110, 33);
            this.btnGetUrl.TabIndex = 6;
            this.btnGetUrl.Text = "获取PushUrl";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.BtnGetUrl_Click);
            // 
            // txtGitPath
            // 
            this.txtGitPath.BackColor = System.Drawing.Color.MistyRose;
            this.txtGitPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGitPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtGitPath.Location = new System.Drawing.Point(111, 21);
            this.txtGitPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtGitPath.Multiline = true;
            this.txtGitPath.Name = "txtGitPath";
            this.txtGitPath.Size = new System.Drawing.Size(758, 33);
            this.txtGitPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(876, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "GIt库目录：";
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Controls.Add(this.tabGetUrls);
            this.tabControl.Controls.Add(this.tabUpdate);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(1355, 714);
            this.tabControl.TabIndex = 6;
            // 
            // openFileDialogGit
            // 
            this.openFileDialogGit.FileName = "openFileDialog1";
            // 
            // btnClean
            // 
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClean.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClean.Location = new System.Drawing.Point(1026, 31);
            this.btnClean.Margin = new System.Windows.Forms.Padding(4);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(88, 34);
            this.btnClean.TabIndex = 8;
            this.btnClean.Text = "清理";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // GitOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 714);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GitOp";
            this.Text = "GitOp";
            this.tabUpdate.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabGetUrls.ResumeLayout(false);
            this.tabGetUrls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGitView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGit;
        private System.Windows.Forms.TabPage tabUpdate;
        private System.Windows.Forms.TextBox txtGitDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TabPage tabGetUrls;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.TextBox txtGitPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUrlsPath;
        private System.Windows.Forms.Button btnPullSourceUrl;
        private System.Windows.Forms.TextBox txtDestBasePath;
        private System.Windows.Forms.Button btnSelectUrlsFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialogGit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgGitView;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClean;
    }
}