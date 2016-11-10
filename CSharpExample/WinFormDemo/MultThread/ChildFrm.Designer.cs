namespace MultThread
{
    partial class ChildFrm
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnSetMainTxt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(94, 141);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(100, 21);
            this.txtSource.TabIndex = 0;
            // 
            // btnSetMainTxt
            // 
            this.btnSetMainTxt.Location = new System.Drawing.Point(94, 204);
            this.btnSetMainTxt.Name = "btnSetMainTxt";
            this.btnSetMainTxt.Size = new System.Drawing.Size(75, 23);
            this.btnSetMainTxt.TabIndex = 1;
            this.btnSetMainTxt.Text = "设置到主窗体";
            this.btnSetMainTxt.UseVisualStyleBackColor = true;
            this.btnSetMainTxt.Click += new System.EventHandler(this.btnSetMainTxt_Click);
            // 
            // ChildFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 357);
            this.Controls.Add(this.btnSetMainTxt);
            this.Controls.Add(this.txtSource);
            this.Name = "ChildFrm";
            this.Text = "ChildFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnSetMainTxt;
    }
}