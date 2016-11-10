namespace 学习项目
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._916TestDataSet = new 学习项目._916TestDataSet();
            this.adminTableAdapter = new 学习项目._916TestDataSetTableAdapters.AdminTableAdapter();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.fillByIdToolStrip = new System.Windows.Forms.ToolStrip();
            this.aIDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.aIDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByIdToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._916TestDataSet)).BeginInit();
            this.fillByIdToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aIDDataGridViewTextBoxColumn,
            this.aUser,
            this.aPassword});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(33, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(323, 182);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // aIDDataGridViewTextBoxColumn
            // 
            this.aIDDataGridViewTextBoxColumn.DataPropertyName = "aID";
            this.aIDDataGridViewTextBoxColumn.HeaderText = "aID";
            this.aIDDataGridViewTextBoxColumn.Name = "aIDDataGridViewTextBoxColumn";
            this.aIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aUser
            // 
            this.aUser.DataPropertyName = "aAdmin";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.aUser.HeaderText = "用户";
            this.aUser.Name = "aUser";
            // 
            // aPassword
            // 
            this.aPassword.DataPropertyName = "aPassword";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aPassword.DefaultCellStyle = dataGridViewCellStyle4;
            this.aPassword.HeaderText = "密码";
            this.aPassword.Name = "aPassword";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Admin";
            this.bindingSource1.DataSource = this._916TestDataSet;
            // 
            // _916TestDataSet
            // 
            this._916TestDataSet.DataSetName = "_916TestDataSet";
            this._916TestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adminTableAdapter
            // 
            this.adminTableAdapter.ClearBeforeFill = true;
            // 
            // txtAdmin
            // 
            this.txtAdmin.Location = new System.Drawing.Point(53, 270);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(100, 21);
            this.txtAdmin.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(215, 270);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // fillByIdToolStrip
            // 
            this.fillByIdToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aIDToolStripLabel,
            this.aIDToolStripTextBox,
            this.fillByIdToolStripButton});
            this.fillByIdToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByIdToolStrip.Name = "fillByIdToolStrip";
            this.fillByIdToolStrip.Size = new System.Drawing.Size(614, 25);
            this.fillByIdToolStrip.TabIndex = 2;
            this.fillByIdToolStrip.Text = "fillByIdToolStrip";
            // 
            // aIDToolStripLabel
            // 
            this.aIDToolStripLabel.Name = "aIDToolStripLabel";
            this.aIDToolStripLabel.Size = new System.Drawing.Size(32, 22);
            this.aIDToolStripLabel.Text = "AID:";
            // 
            // aIDToolStripTextBox
            // 
            this.aIDToolStripTextBox.Name = "aIDToolStripTextBox";
            this.aIDToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // fillByIdToolStripButton
            // 
            this.fillByIdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByIdToolStripButton.Name = "fillByIdToolStripButton";
            this.fillByIdToolStripButton.Size = new System.Drawing.Size(53, 21);
            this.fillByIdToolStripButton.Text = "FillById";
            this.fillByIdToolStripButton.Click += new System.EventHandler(this.fillByIdToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 386);
            this.Controls.Add(this.fillByIdToolStrip);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAdmin);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._916TestDataSet)).EndInit();
            this.fillByIdToolStrip.ResumeLayout(false);
            this.fillByIdToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private _916TestDataSet _916TestDataSet;
        private _916TestDataSetTableAdapters.AdminTableAdapter adminTableAdapter;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn aIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPassword;
        private System.Windows.Forms.ToolStrip fillByIdToolStrip;
        private System.Windows.Forms.ToolStripLabel aIDToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox aIDToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByIdToolStripButton;
    }
}

