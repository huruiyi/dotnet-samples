namespace _0423_1
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询学生信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加年级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加学生信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询学生信息ToolStripMenuItem,
            this.添加年级ToolStripMenuItem,
            this.添加学生信息ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询学生信息ToolStripMenuItem
            // 
            this.查询学生信息ToolStripMenuItem.Name = "查询学生信息ToolStripMenuItem";
            this.查询学生信息ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.查询学生信息ToolStripMenuItem.Text = "查询学生信息";
            this.查询学生信息ToolStripMenuItem.Click += new System.EventHandler(this.查询学生信息ToolStripMenuItem_Click);
            // 
            // 添加年级ToolStripMenuItem
            // 
            this.添加年级ToolStripMenuItem.Name = "添加年级ToolStripMenuItem";
            this.添加年级ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.添加年级ToolStripMenuItem.Text = "添加年级";
            this.添加年级ToolStripMenuItem.Click += new System.EventHandler(this.添加年级ToolStripMenuItem_Click);
            // 
            // 添加学生信息ToolStripMenuItem1
            // 
            this.添加学生信息ToolStripMenuItem1.Name = "添加学生信息ToolStripMenuItem1";
            this.添加学生信息ToolStripMenuItem1.Size = new System.Drawing.Size(89, 20);
            this.添加学生信息ToolStripMenuItem1.Text = "添加学生信息";
            this.添加学生信息ToolStripMenuItem1.Click += new System.EventHandler(this.添加学生信息ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 316);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询学生信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加年级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加学生信息ToolStripMenuItem1;
    }
}