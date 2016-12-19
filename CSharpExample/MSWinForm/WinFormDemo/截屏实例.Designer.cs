namespace WinFormDemo
{
    partial class 截屏实例
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.截屏1 = new System.Windows.Forms.Button();
            this.截屏2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 截屏1
            // 
            this.截屏1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.截屏1.Location = new System.Drawing.Point(175, 49);
            this.截屏1.Name = "截屏1";
            this.截屏1.Size = new System.Drawing.Size(138, 23);
            this.截屏1.TabIndex = 0;
            this.截屏1.Text = "截屏1";
            this.截屏1.UseVisualStyleBackColor = true;
            this.截屏1.Click += new System.EventHandler(this.截屏1_Click);
            // 
            // 截屏2
            // 
            this.截屏2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.截屏2.Location = new System.Drawing.Point(319, 49);
            this.截屏2.Name = "截屏2";
            this.截屏2.Size = new System.Drawing.Size(138, 23);
            this.截屏2.TabIndex = 0;
            this.截屏2.Text = "截屏2";
            this.截屏2.UseVisualStyleBackColor = true;
            this.截屏2.Click += new System.EventHandler(this.截屏2_Click);
            // 
            // 截屏实例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 159);
            this.Controls.Add(this.截屏2);
            this.Controls.Add(this.截屏1);
            this.Name = "截屏实例";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 截屏1;
        private System.Windows.Forms.Button 截屏2;
    }
}

