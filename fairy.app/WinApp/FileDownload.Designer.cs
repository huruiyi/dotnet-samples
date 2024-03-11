namespace WinApp
{
    partial class FileDownload
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            tbExecutablePath = new TextBox();
            tbStartupPath = new TextBox();
            label3 = new Label();
            tbUrl = new TextBox();
            btnDownload = new Button();
            pbDownload = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(79, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 32);
            label1.TabIndex = 0;
            label1.Text = "StartupPath:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(38, 97);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(202, 32);
            label2.TabIndex = 0;
            label2.Text = "ExecutablePath:";
            // 
            // tbExecutablePath
            // 
            tbExecutablePath.BorderStyle = BorderStyle.FixedSingle;
            tbExecutablePath.Font = new Font("Microsoft YaHei UI", 15F);
            tbExecutablePath.Location = new Point(246, 92);
            tbExecutablePath.Margin = new Padding(2);
            tbExecutablePath.Multiline = true;
            tbExecutablePath.Name = "tbExecutablePath";
            tbExecutablePath.Size = new Size(1280, 42);
            tbExecutablePath.TabIndex = 1;
            // 
            // tbStartupPath
            // 
            tbStartupPath.BorderStyle = BorderStyle.FixedSingle;
            tbStartupPath.Font = new Font("Microsoft YaHei UI", 15F);
            tbStartupPath.Location = new Point(246, 19);
            tbStartupPath.Margin = new Padding(2);
            tbStartupPath.Multiline = true;
            tbStartupPath.Name = "tbStartupPath";
            tbStartupPath.Size = new Size(1280, 42);
            tbStartupPath.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F);
            label3.Location = new Point(156, 212);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 32);
            label3.TabIndex = 0;
            label3.Text = "URL：";
            // 
            // tbUrl
            // 
            tbUrl.BorderStyle = BorderStyle.FixedSingle;
            tbUrl.Font = new Font("Microsoft YaHei UI", 15F);
            tbUrl.Location = new Point(246, 210);
            tbUrl.Margin = new Padding(2);
            tbUrl.Multiline = true;
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(1089, 42);
            tbUrl.TabIndex = 1;
            tbUrl.Text = "https://dldir1.qq.com/qqfile/qq/QQNT/13e10b5b/QQ9.9.6.19689_x64.exe";
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(1388, 210);
            btnDownload.Margin = new Padding(2);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(138, 42);
            btnDownload.TabIndex = 2;
            btnDownload.Text = "下载";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // pbDownload
            // 
            pbDownload.Location = new Point(246, 270);
            pbDownload.Margin = new Padding(2);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(1280, 28);
            pbDownload.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1573, 378);
            Controls.Add(pbDownload);
            Controls.Add(btnDownload);
            Controls.Add(tbStartupPath);
            Controls.Add(tbUrl);
            Controls.Add(label3);
            Controls.Add(tbExecutablePath);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbExecutablePath;
        private TextBox tbStartupPath;
        private Label label3;
        private TextBox tbUrl;
        private Button btnDownload;
        private ProgressBar pbDownload;
    }
}
