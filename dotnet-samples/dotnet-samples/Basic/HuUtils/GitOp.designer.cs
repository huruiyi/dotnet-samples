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
            this.folderBrowserDialogGit = new System.Windows.Forms.FolderBrowserDialog();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGitDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
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
            this.tabUpdate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.tabUpdate.Controls.Add(this.groupBox3);
            this.tabUpdate.Controls.Add(this.groupBox2);
            this.tabUpdate.Location = new System.Drawing.Point(4, 29);
            this.tabUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.tabUpdate.Size = new System.Drawing.Size(1594, 858);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "更新";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(8, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1561, 712);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLog.Location = new System.Drawing.Point(3, 22);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1555, 687);
            this.txtLog.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGitDir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBrowser);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(11, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1558, 86);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新代码";
            // 
            // txtGitDir
            // 
            this.txtGitDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.txtGitDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGitDir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtGitDir.Location = new System.Drawing.Point(83, 24);
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
            this.label1.Location = new System.Drawing.Point(32, 27);
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
            this.btnBrowser.Location = new System.Drawing.Point(936, 27);
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
            this.btnUpdate.Location = new System.Drawing.Point(1029, 27);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 33);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // tabGetUrls
            // 
            this.tabGetUrls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.tabGetUrls.Controls.Add(this.dgGitView);
            this.tabGetUrls.Controls.Add(this.btnGetUrl);
            this.tabGetUrls.Controls.Add(this.txtGitPath);
            this.tabGetUrls.Controls.Add(this.button1);
            this.tabGetUrls.Controls.Add(this.label2);
            this.tabGetUrls.Location = new System.Drawing.Point(4, 29);
            this.tabGetUrls.Margin = new System.Windows.Forms.Padding(4);
            this.tabGetUrls.Name = "tabGetUrls";
            this.tabGetUrls.Padding = new System.Windows.Forms.Padding(4);
            this.tabGetUrls.Size = new System.Drawing.Size(1594, 858);
            this.tabGetUrls.TabIndex = 0;
            this.tabGetUrls.Text = "获取Url";
            // 
            // dgGitView
            // 
            this.dgGitView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.dgGitView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGitView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgGitView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgGitView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.dgGitView.Location = new System.Drawing.Point(4, 66);
            this.dgGitView.Margin = new System.Windows.Forms.Padding(4);
            this.dgGitView.Name = "dgGitView";
            this.dgGitView.RowTemplate.Height = 23;
            this.dgGitView.Size = new System.Drawing.Size(1586, 788);
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
            this.txtGitPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
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
            this.tabControl.Size = new System.Drawing.Size(1602, 891);
            this.tabControl.TabIndex = 6;
            // 
            // openFileDialogGit
            // 
            this.openFileDialogGit.FileName = "openFileDialog1";
            // 
            // GitOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 891);
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TabPage tabGetUrls;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.TextBox txtGitPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.OpenFileDialog openFileDialogGit;
        private System.Windows.Forms.DataGridView dgGitView;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}