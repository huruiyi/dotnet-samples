namespace HuUtils
{
    partial class 登录窗体
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
            this.button1 = new System.Windows.Forms.Button();
            this.loginControl1 = new HuUtils.LoginControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(64, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "直接登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginControl1
            // 
            this.loginControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginControl1.ForeColor = System.Drawing.Color.Coral;
            this.loginControl1.Location = new System.Drawing.Point(12, 12);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(185, 107);
            this.loginControl1.TabIndex = 0;
            // 
            // 登录窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loginControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "登录窗体";
            this.Text = "登录窗体";
            this.Load += new System.EventHandler(this.登录窗体_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl loginControl1;
        private System.Windows.Forms.Button button1;
    }
}