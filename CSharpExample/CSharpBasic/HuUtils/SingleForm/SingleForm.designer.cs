namespace HuUtils.SingleForm
{
    partial class SingleForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSingle = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSingle
            // 
            this.cbSingle.AutoSize = true;
            this.cbSingle.Location = new System.Drawing.Point(12, 10);
            this.cbSingle.Name = "cbSingle";
            this.cbSingle.Size = new System.Drawing.Size(96, 16);
            this.cbSingle.TabIndex = 0;
            this.cbSingle.Text = "开启单例模式";
            this.cbSingle.UseVisualStyleBackColor = true;
            this.cbSingle.CheckedChanged += new System.EventHandler(this.cbSingle_CheckedChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(24, 32);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开新窗口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(128, 80);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cbSingle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSingle;
        private System.Windows.Forms.Button btnOpen;
    }
}

