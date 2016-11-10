namespace FormExample
{
    partial class MainForm
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
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonShow
            // 
            this.buttonShow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonShow.FlatAppearance.BorderSize = 2;
            this.buttonShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Location = new System.Drawing.Point(136, 151);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(206, 65);
            this.buttonShow.TabIndex = 0;
            this.buttonShow.Text = "显示SubForm";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonHide.FlatAppearance.BorderSize = 2;
            this.buttonHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHide.Location = new System.Drawing.Point(136, 240);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(206, 65);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "隐藏SubForm";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 469);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonShow);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonHide;
    }
}

