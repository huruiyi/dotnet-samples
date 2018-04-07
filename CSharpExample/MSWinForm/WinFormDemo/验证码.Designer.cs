namespace WinFormDemo
{
    partial class 验证码
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
            this.CodePictureBox = new System.Windows.Forms.PictureBox();
            this.btnQrCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CodePictureBox
            // 
            this.CodePictureBox.Location = new System.Drawing.Point(99, 63);
            this.CodePictureBox.Name = "CodePictureBox";
            this.CodePictureBox.Size = new System.Drawing.Size(100, 50);
            this.CodePictureBox.TabIndex = 3;
            this.CodePictureBox.TabStop = false;
            // 
            // btnQrCode
            // 
            this.btnQrCode.Location = new System.Drawing.Point(110, 170);
            this.btnQrCode.Name = "btnQrCode";
            this.btnQrCode.Size = new System.Drawing.Size(75, 23);
            this.btnQrCode.TabIndex = 2;
            this.btnQrCode.Text = "生成验证码";
            this.btnQrCode.UseVisualStyleBackColor = true;
            this.btnQrCode.Click += new System.EventHandler(this.btnQrCode_Click);
            // 
            // 验证码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 288);
            this.Controls.Add(this.CodePictureBox);
            this.Controls.Add(this.btnQrCode);
            this.Name = "验证码";
            this.Text = "验证码";
            ((System.ComponentModel.ISupportInitialize)(this.CodePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CodePictureBox;
        private System.Windows.Forms.Button btnQrCode;
    }
}