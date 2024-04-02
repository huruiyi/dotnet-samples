namespace WfApp
{
    partial class ExplorerSample
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.backSplitButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.forwardSplitButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.upSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.viewSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.thumbnailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileViewBindingSource)).BeginInit();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.DataSource = this.FileViewBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 17;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 635);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backSplitButton,
            this.forwardSplitButton,
            this.upSplitButton,
            this.viewSplitButton});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1031, 39);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "toolStrip1";
            // 
            // backSplitButton
            // 
            this.backSplitButton.Image = global::WfApp.Properties.Resources.Back;
            this.backSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backSplitButton.Name = "backSplitButton";
            this.backSplitButton.Size = new System.Drawing.Size(75, 36);
            this.backSplitButton.Text = "Back";
            this.backSplitButton.Click += new System.EventHandler(this.backSplitButton_Click);
            // 
            // forwardSplitButton
            // 
            this.forwardSplitButton.Image = global::WfApp.Properties.Resources.Forward;
            this.forwardSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardSplitButton.Name = "forwardSplitButton";
            this.forwardSplitButton.Size = new System.Drawing.Size(95, 36);
            this.forwardSplitButton.Text = "Forward";
            this.forwardSplitButton.Click += new System.EventHandler(this.forwardSplitButton_Click);
            // 
            // upSplitButton
            // 
            this.upSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upSplitButton.Image = global::WfApp.Properties.Resources.Up;
            this.upSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.upSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upSplitButton.Name = "upSplitButton";
            this.upSplitButton.Size = new System.Drawing.Size(48, 36);
            this.upSplitButton.Text = "toolStripSplitButton1";
            this.upSplitButton.ButtonClick += new System.EventHandler(this.upSplitButton_ButtonClick);
            // 
            // viewSplitButton
            // 
            this.viewSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thumbnailsMenuItem,
            this.tilesMenuItem,
            this.iconsMenuItem,
            this.listMenuItem,
            this.detailsMenuItem});
            this.viewSplitButton.Image = global::WfApp.Properties.Resources.Details;
            this.viewSplitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewSplitButton.Name = "viewSplitButton";
            this.viewSplitButton.Size = new System.Drawing.Size(48, 36);
            this.viewSplitButton.Text = "toolStripSplitButton2";
            // 
            // thumbnailsMenuItem
            // 
            this.thumbnailsMenuItem.Name = "thumbnailsMenuItem";
            this.thumbnailsMenuItem.Size = new System.Drawing.Size(142, 22);
            this.thumbnailsMenuItem.Text = "Thumbnails";
            this.thumbnailsMenuItem.Click += new System.EventHandler(this.thumbnailsMenuItem_Click);
            // 
            // tilesMenuItem
            // 
            this.tilesMenuItem.Name = "tilesMenuItem";
            this.tilesMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tilesMenuItem.Text = "Tiles";
            this.tilesMenuItem.Click += new System.EventHandler(this.tilesMenuItem_Click);
            // 
            // iconsMenuItem
            // 
            this.iconsMenuItem.Name = "iconsMenuItem";
            this.iconsMenuItem.Size = new System.Drawing.Size(142, 22);
            this.iconsMenuItem.Text = "Icons";
            this.iconsMenuItem.Click += new System.EventHandler(this.iconsMenuItem_Click);
            // 
            // listMenuItem
            // 
            this.listMenuItem.Name = "listMenuItem";
            this.listMenuItem.Size = new System.Drawing.Size(142, 22);
            this.listMenuItem.Text = "List";
            this.listMenuItem.Click += new System.EventHandler(this.listMenuItem_Click);
            // 
            // detailsMenuItem
            // 
            this.detailsMenuItem.Name = "detailsMenuItem";
            this.detailsMenuItem.Size = new System.Drawing.Size(142, 22);
            this.detailsMenuItem.Text = "Details";
            this.detailsMenuItem.Click += new System.EventHandler(this.detailsMenuItem_Click);
            // 
            // ExplorerSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 635);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ExplorerSample";
            this.Text = "ExplorerSample";
            this.Load += new System.EventHandler(this.ExplorerSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileViewBindingSource)).EndInit();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource FileViewBindingSource;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton backSplitButton;
        private System.Windows.Forms.ToolStripDropDownButton forwardSplitButton;
        private System.Windows.Forms.ToolStripSplitButton upSplitButton;
        private System.Windows.Forms.ToolStripSplitButton viewSplitButton;
        private System.Windows.Forms.ToolStripMenuItem thumbnailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsMenuItem;
    }
}