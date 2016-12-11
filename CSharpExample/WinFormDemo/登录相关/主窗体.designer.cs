namespace 登陆窗体
{
    partial class 主窗体
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
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.布局ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openForm2ToolStripMenuItem,
            this.hideForm2ToolStripMenuItem,
            this.closeForm2ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // openForm2ToolStripMenuItem
            // 
            this.openForm2ToolStripMenuItem.Name = "openForm2ToolStripMenuItem";
            this.openForm2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openForm2ToolStripMenuItem.Text = "Open Form2";
            this.openForm2ToolStripMenuItem.Click += new System.EventHandler(this.openForm2ToolStripMenuItem_Click);
            // 
            // hideForm2ToolStripMenuItem
            // 
            this.hideForm2ToolStripMenuItem.Name = "hideForm2ToolStripMenuItem";
            this.hideForm2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hideForm2ToolStripMenuItem.Text = "Hide Form2";
            this.hideForm2ToolStripMenuItem.Click += new System.EventHandler(this.hideForm2ToolStripMenuItem_Click);
            // 
            // closeForm2ToolStripMenuItem
            // 
            this.closeForm2ToolStripMenuItem.Name = "closeForm2ToolStripMenuItem";
            this.closeForm2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeForm2ToolStripMenuItem.Text = "Close Form2";
            this.closeForm2ToolStripMenuItem.Click += new System.EventHandler(this.closeForm2ToolStripMenuItem_Click);
            // 
            // 布局ToolStripMenuItem
            // 
            this.布局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.布局ToolStripMenuItem.Name = "布局ToolStripMenuItem";
            this.布局ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.布局ToolStripMenuItem.Text = "布局";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.tileHorizontalToolStripMenuItem.Text = "TileHorizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.tileVerticalToolStripMenuItem.Text = "TileVertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // 主窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::WinForm1.Properties.Resources.img10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(632, 448);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "主窗体";
            this.Text = "主窗体";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openForm2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideForm2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeForm2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
    }
}