namespace HuUtils
{
    partial class GitClone
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectUrlsFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrlsPath = new System.Windows.Forms.TextBox();
            this.btnPullSourceUrl = new System.Windows.Forms.Button();
            this.txtDestBasePath = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.openFileDialogGit = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogGit = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(19, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1288, 679);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLog.Location = new System.Drawing.Point(3, 17);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1282, 659);
            this.txtLog.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSelectUrlsFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUrlsPath);
            this.groupBox1.Controls.Add(this.btnPullSourceUrl);
            this.groupBox1.Controls.Add(this.txtDestBasePath);
            this.groupBox1.Controls.Add(this.btnPull);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(19, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1288, 131);
            this.groupBox1.TabIndex = 12;
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
            this.btnSelectUrlsFile.Location = new System.Drawing.Point(933, 30);
            this.btnSelectUrlsFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectUrlsFile.Name = "btnSelectUrlsFile";
            this.btnSelectUrlsFile.Size = new System.Drawing.Size(88, 33);
            this.btnSelectUrlsFile.TabIndex = 8;
            this.btnSelectUrlsFile.Text = "浏览";
            this.btnSelectUrlsFile.UseVisualStyleBackColor = true;
            this.btnSelectUrlsFile.Click += new System.EventHandler(this.btnSelectUrlsFile_Click);
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
            this.txtUrlsPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
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
            this.btnPullSourceUrl.Click += new System.EventHandler(this.btnPullSourceUrl_Click);
            // 
            // txtDestBasePath
            // 
            this.txtDestBasePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
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
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // openFileDialogGit
            // 
            this.openFileDialogGit.FileName = "openFileDialogGit";
            // 
            // GitClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(215)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(1324, 850);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GitClone";
            this.Text = "GitClone";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectUrlsFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrlsPath;
        private System.Windows.Forms.Button btnPullSourceUrl;
        private System.Windows.Forms.TextBox txtDestBasePath;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.OpenFileDialog openFileDialogGit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGit;
    }
}