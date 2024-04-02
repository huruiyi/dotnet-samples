namespace WfApp
{
    partial class ChildForm
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
            this.rtbNum = new System.Windows.Forms.RichTextBox();
            this.btnNum = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtbNum
            // 
            this.rtbNum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbNum.Location = new System.Drawing.Point(0, 73);
            this.rtbNum.Name = "rtbNum";
            this.rtbNum.Size = new System.Drawing.Size(645, 293);
            this.rtbNum.TabIndex = 5;
            this.rtbNum.Text = "1";
            // 
            // btnNum
            // 
            this.btnNum.Location = new System.Drawing.Point(164, 29);
            this.btnNum.Name = "btnNum";
            this.btnNum.Size = new System.Drawing.Size(90, 25);
            this.btnNum.TabIndex = 4;
            this.btnNum.Text = "Btn1";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(39, 29);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(90, 21);
            this.txtNum.TabIndex = 3;
            this.txtNum.Text = "1";
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 366);
            this.Controls.Add(this.rtbNum);
            this.Controls.Add(this.btnNum);
            this.Controls.Add(this.txtNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNum;
        private System.Windows.Forms.Button btnNum;
        private System.Windows.Forms.TextBox txtNum;
    }
}