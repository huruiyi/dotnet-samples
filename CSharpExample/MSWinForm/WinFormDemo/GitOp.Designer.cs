namespace WinFormDemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGitDir = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialogGit = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPull = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Git库目录：";
            // 
            // txtGitDir
            // 
            this.txtGitDir.Location = new System.Drawing.Point(95, 33);
            this.txtGitDir.Name = "txtGitDir";
            this.txtGitDir.Size = new System.Drawing.Size(673, 21);
            this.txtGitDir.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(774, 31);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // folderBrowserDialogGit
            // 
            this.folderBrowserDialogGit.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(774, 60);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 23);
            this.btnPull.TabIndex = 3;
            this.btnPull.Text = "更新";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(20, 114);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(748, 231);
            this.txtMessage.TabIndex = 4;
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.AutoSize = true;
            this.lblTaskCount.Location = new System.Drawing.Point(689, 65);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(53, 12);
            this.lblTaskCount.TabIndex = 5;
            this.lblTaskCount.Text = "线程数：";
            // 
            // GitOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.lblTaskCount);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.txtGitDir);
            this.Controls.Add(this.label1);
            this.Name = "GitOp";
            this.Text = "GitOp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGitDir;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGit;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblTaskCount;
    }
}