namespace KeyGenerator
{
    partial class frmIn
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
            System.Windows.Forms.Button btnGet;
            this.rtxtRegText = new System.Windows.Forms.RichTextBox();
            this.btnLookRegText = new System.Windows.Forms.Button();
            btnGet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnGet.Location = new System.Drawing.Point(200, 282);
            btnGet.Name = "btnGet";
            btnGet.Size = new System.Drawing.Size(75, 23);
            btnGet.TabIndex = 1;
            btnGet.Text = "获取";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // rtxtRegText
            // 
            this.rtxtRegText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtRegText.Location = new System.Drawing.Point(12, 12);
            this.rtxtRegText.Name = "rtxtRegText";
            this.rtxtRegText.Size = new System.Drawing.Size(344, 259);
            this.rtxtRegText.TabIndex = 0;
            this.rtxtRegText.Text = "";
            // 
            // btnLookRegText
            // 
            this.btnLookRegText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLookRegText.Location = new System.Drawing.Point(281, 282);
            this.btnLookRegText.Name = "btnLookRegText";
            this.btnLookRegText.Size = new System.Drawing.Size(75, 23);
            this.btnLookRegText.TabIndex = 1;
            this.btnLookRegText.Text = "查看";
            this.btnLookRegText.UseVisualStyleBackColor = true;
            this.btnLookRegText.Click += new System.EventHandler(this.btnLookRegText_Click);
            // 
            // frmIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(368, 314);
            this.Controls.Add(btnGet);
            this.Controls.Add(this.btnLookRegText);
            this.Controls.Add(this.rtxtRegText);
            this.Name = "frmIn";
            this.Text = "查看注册信息";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtRegText;
        private System.Windows.Forms.Button btnLookRegText;
    }
}