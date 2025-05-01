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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitClone));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectUrlsFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrlsPath = new System.Windows.Forms.TextBox();
            this.btnPull = new System.Windows.Forms.Button();
            this.openFileDialogGit = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogGit = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::HuUtils.Properties.Resources.bg;
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Font = new System.Drawing.Font("楷体", 14.25F);
            this.groupBox3.Location = new System.Drawing.Point(9, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1143, 537);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("楷体", 10F);
            this.txtLog.Location = new System.Drawing.Point(3, 25);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1137, 509);
            this.txtLog.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = global::HuUtils.Properties.Resources.bg;
            this.groupBox1.Controls.Add(this.btnSelectUrlsFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUrlsPath);
            this.groupBox1.Controls.Add(this.btnPull);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("楷体", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(9, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1143, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拉取代码";
            // 
            // btnSelectUrlsFile
            // 
            this.btnSelectUrlsFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectUrlsFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectUrlsFile.Font = new System.Drawing.Font("楷体", 14.25F);
            this.btnSelectUrlsFile.Location = new System.Drawing.Point(933, 30);
            this.btnSelectUrlsFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectUrlsFile.Name = "btnSelectUrlsFile";
            this.btnSelectUrlsFile.Size = new System.Drawing.Size(88, 33);
            this.btnSelectUrlsFile.TabIndex = 8;
            this.btnSelectUrlsFile.Text = "浏览";
            this.btnSelectUrlsFile.UseVisualStyleBackColor = false;
            this.btnSelectUrlsFile.Click += new System.EventHandler(this.btnSelectUrlsFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 14.25F);
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Uri：";
            // 
            // txtUrlsPath
            // 
            this.txtUrlsPath.BackColor = System.Drawing.Color.White;
            this.txtUrlsPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlsPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUrlsPath.Location = new System.Drawing.Point(80, 32);
            this.txtUrlsPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrlsPath.Multiline = true;
            this.txtUrlsPath.Name = "txtUrlsPath";
            this.txtUrlsPath.Size = new System.Drawing.Size(845, 33);
            this.txtUrlsPath.TabIndex = 6;
            // 
            // btnPull
            // 
            this.btnPull.BackColor = System.Drawing.Color.Transparent;
            this.btnPull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPull.Font = new System.Drawing.Font("楷体", 14.25F);
            this.btnPull.Location = new System.Drawing.Point(1029, 30);
            this.btnPull.Margin = new System.Windows.Forms.Padding(4);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(88, 33);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = false;
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
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HuUtils.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1164, 663);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button btnSelectUrlsFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrlsPath;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.OpenFileDialog openFileDialogGit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGit;
    }
}