namespace HuUtils
{
    partial class 系统字体
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
            this.btnGetFonts = new System.Windows.Forms.Button();
            this.lvFonts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGetFonts
            // 
            this.btnGetFonts.Location = new System.Drawing.Point(344, 34);
            this.btnGetFonts.Name = "btnGetFonts";
            this.btnGetFonts.Size = new System.Drawing.Size(75, 23);
            this.btnGetFonts.TabIndex = 0;
            this.btnGetFonts.Text = "获取字体";
            this.btnGetFonts.UseVisualStyleBackColor = true;
            this.btnGetFonts.Click += new System.EventHandler(this.BtnGetFonts_Click);
            // 
            // lvFonts
            // 
            this.lvFonts.DisplayMember = "Name";
            this.lvFonts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvFonts.FormattingEnabled = true;
            this.lvFonts.ItemHeight = 12;
            this.lvFonts.Location = new System.Drawing.Point(0, 86);
            this.lvFonts.Name = "lvFonts";
            this.lvFonts.Size = new System.Drawing.Size(800, 364);
            this.lvFonts.TabIndex = 1;
            // 
            // 系统字体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvFonts);
            this.Controls.Add(this.btnGetFonts);
            this.Name = "系统字体";
            this.Text = "系统字体";
            this.Load += new System.EventHandler(this.系统字体_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetFonts;
        private System.Windows.Forms.ListBox lvFonts;
    }
}