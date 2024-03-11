namespace HuUtils.DataSynchronization
{
    partial class DsForm1
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnOpenDSForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(47, 119);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(211, 21);
            this.txtMessage.TabIndex = 3;
            // 
            // btnOpenDSForm2
            // 
            this.btnOpenDSForm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDSForm2.Location = new System.Drawing.Point(264, 119);
            this.btnOpenDSForm2.Name = "btnOpenDSForm2";
            this.btnOpenDSForm2.Size = new System.Drawing.Size(138, 23);
            this.btnOpenDSForm2.TabIndex = 2;
            this.btnOpenDSForm2.Text = "打开DSForm2";
            this.btnOpenDSForm2.UseVisualStyleBackColor = true;
            this.btnOpenDSForm2.Click += new System.EventHandler(this.btnOpenDSForm2_Click);
            // 
            // DSForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 261);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnOpenDSForm2);
            this.Name = "DsForm1";
            this.Text = "DSForm1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnOpenDSForm2;
    }
}