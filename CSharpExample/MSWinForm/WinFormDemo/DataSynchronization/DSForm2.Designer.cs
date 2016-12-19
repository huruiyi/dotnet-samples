namespace WinFormDemo.DataSynchronization
{
    partial class DSForm2
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
            this.btnSetMainTxt = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSetMainTxt
            // 
            this.btnSetMainTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMainTxt.Location = new System.Drawing.Point(278, 119);
            this.btnSetMainTxt.Name = "btnSetMainTxt";
            this.btnSetMainTxt.Size = new System.Drawing.Size(138, 23);
            this.btnSetMainTxt.TabIndex = 3;
            this.btnSetMainTxt.Text = "设置到DSForm1";
            this.btnSetMainTxt.UseVisualStyleBackColor = true;
            this.btnSetMainTxt.Click += new System.EventHandler(this.btnSetMainTxt_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(38, 119);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(211, 21);
            this.txtSource.TabIndex = 2;
            // 
            // DSForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 261);
            this.Controls.Add(this.btnSetMainTxt);
            this.Controls.Add(this.txtSource);
            this.Name = "DSForm2";
            this.Text = "DSForm2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetMainTxt;
        private System.Windows.Forms.TextBox txtSource;
    }
}