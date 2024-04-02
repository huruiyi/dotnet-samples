namespace WfApp
{
    partial class ConfigForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ClearFields = new System.Windows.Forms.Button();
            this.UpdateXmlDocument = new System.Windows.Forms.Button();
            this.CreateConfigurationFile = new System.Windows.Forms.Button();
            this.LoadXmlDocument = new System.Windows.Forms.Button();
            this.LoadXmlTextReader = new System.Windows.Forms.Button();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.maximumRecords = new System.Windows.Forms.NumericUpDown();
            this.timeoutPeriod = new System.Windows.Forms.NumericUpDown();
            this.serverName = new System.Windows.Forms.TextBox();
            this.lblMaxRecords = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.loggingIsEnabled = new System.Windows.Forms.CheckBox();
            this.toolBarIsVisible = new System.Windows.Forms.CheckBox();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutPeriod)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClearFields
            // 
            this.ClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearFields.Location = new System.Drawing.Point(184, 245);
            this.ClearFields.Name = "ClearFields";
            this.ClearFields.Size = new System.Drawing.Size(90, 25);
            this.ClearFields.TabIndex = 13;
            this.ClearFields.Text = "Clear Fields";
            this.ClearFields.Click += new System.EventHandler(this.ClearFields_Click);
            // 
            // UpdateXmlDocument
            // 
            this.UpdateXmlDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateXmlDocument.Location = new System.Drawing.Point(73, 323);
            this.UpdateXmlDocument.Name = "UpdateXmlDocument";
            this.UpdateXmlDocument.Size = new System.Drawing.Size(327, 24);
            this.UpdateXmlDocument.TabIndex = 12;
            this.UpdateXmlDocument.Text = "Update Configuration File Using XmlDocument";
            this.UpdateXmlDocument.Click += new System.EventHandler(this.UpdateXmlDocument_Click);
            // 
            // CreateConfigurationFile
            // 
            this.CreateConfigurationFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateConfigurationFile.Location = new System.Drawing.Point(73, 288);
            this.CreateConfigurationFile.Name = "CreateConfigurationFile";
            this.CreateConfigurationFile.Size = new System.Drawing.Size(327, 25);
            this.CreateConfigurationFile.TabIndex = 11;
            this.CreateConfigurationFile.Text = "Create Configuration File Using XmlTextWriter";
            this.CreateConfigurationFile.Click += new System.EventHandler(this.CreateConfigurationFile_Click);
            // 
            // LoadXmlDocument
            // 
            this.LoadXmlDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadXmlDocument.Location = new System.Drawing.Point(73, 391);
            this.LoadXmlDocument.Name = "LoadXmlDocument";
            this.LoadXmlDocument.Size = new System.Drawing.Size(327, 25);
            this.LoadXmlDocument.TabIndex = 10;
            this.LoadXmlDocument.Text = "Load Configuration Data Using XmlDocument";
            this.LoadXmlDocument.Click += new System.EventHandler(this.LoadXmlDocument_Click);
            // 
            // LoadXmlTextReader
            // 
            this.LoadXmlTextReader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadXmlTextReader.Location = new System.Drawing.Point(73, 357);
            this.LoadXmlTextReader.Name = "LoadXmlTextReader";
            this.LoadXmlTextReader.Size = new System.Drawing.Size(327, 25);
            this.LoadXmlTextReader.TabIndex = 9;
            this.LoadXmlTextReader.Text = "Load Configuration Data Using XmlTextReader";
            this.LoadXmlTextReader.Click += new System.EventHandler(this.LoadXmlTextReader_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.maximumRecords);
            this.grpSearch.Controls.Add(this.timeoutPeriod);
            this.grpSearch.Controls.Add(this.serverName);
            this.grpSearch.Controls.Add(this.lblMaxRecords);
            this.grpSearch.Controls.Add(this.lblServer);
            this.grpSearch.Controls.Add(this.lblTimeout);
            this.grpSearch.Location = new System.Drawing.Point(75, 124);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(326, 112);
            this.grpSearch.TabIndex = 8;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // maximumRecords
            // 
            this.maximumRecords.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumRecords.Location = new System.Drawing.Point(144, 78);
            this.maximumRecords.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximumRecords.Name = "maximumRecords";
            this.maximumRecords.Size = new System.Drawing.Size(86, 21);
            this.maximumRecords.TabIndex = 7;
            // 
            // timeoutPeriod
            // 
            this.timeoutPeriod.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeoutPeriod.Location = new System.Drawing.Point(144, 52);
            this.timeoutPeriod.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.timeoutPeriod.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.timeoutPeriod.Name = "timeoutPeriod";
            this.timeoutPeriod.Size = new System.Drawing.Size(86, 21);
            this.timeoutPeriod.TabIndex = 6;
            this.timeoutPeriod.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // serverName
            // 
            this.serverName.Location = new System.Drawing.Point(144, 26);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(173, 21);
            this.serverName.TabIndex = 3;
            // 
            // lblMaxRecords
            // 
            this.lblMaxRecords.Location = new System.Drawing.Point(19, 78);
            this.lblMaxRecords.Name = "lblMaxRecords";
            this.lblMaxRecords.Size = new System.Drawing.Size(120, 24);
            this.lblMaxRecords.TabIndex = 2;
            this.lblMaxRecords.Text = "Max Records:";
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(19, 26);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(120, 25);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // lblTimeout
            // 
            this.lblTimeout.Location = new System.Drawing.Point(19, 52);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(120, 24);
            this.lblTimeout.TabIndex = 1;
            this.lblTimeout.Text = "Timeout:";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.loggingIsEnabled);
            this.grpGeneral.Controls.Add(this.toolBarIsVisible);
            this.grpGeneral.Location = new System.Drawing.Point(75, 30);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(326, 86);
            this.grpGeneral.TabIndex = 7;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // loggingIsEnabled
            // 
            this.loggingIsEnabled.Location = new System.Drawing.Point(19, 52);
            this.loggingIsEnabled.Name = "loggingIsEnabled";
            this.loggingIsEnabled.Size = new System.Drawing.Size(163, 26);
            this.loggingIsEnabled.TabIndex = 2;
            this.loggingIsEnabled.Text = "Enable Logging";
            // 
            // toolBarIsVisible
            // 
            this.toolBarIsVisible.Location = new System.Drawing.Point(19, 26);
            this.toolBarIsVisible.Name = "toolBarIsVisible";
            this.toolBarIsVisible.Size = new System.Drawing.Size(163, 26);
            this.toolBarIsVisible.TabIndex = 1;
            this.toolBarIsVisible.Text = "Show Toolbar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 460);
            this.Controls.Add(this.ClearFields);
            this.Controls.Add(this.UpdateXmlDocument);
            this.Controls.Add(this.CreateConfigurationFile);
            this.Controls.Add(this.LoadXmlDocument);
            this.Controls.Add(this.LoadXmlTextReader);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpGeneral);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutPeriod)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClearFields;
        private System.Windows.Forms.Button UpdateXmlDocument;
        private System.Windows.Forms.Button CreateConfigurationFile;
        private System.Windows.Forms.Button LoadXmlDocument;
        private System.Windows.Forms.Button LoadXmlTextReader;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.NumericUpDown maximumRecords;
        private System.Windows.Forms.NumericUpDown timeoutPeriod;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label lblMaxRecords;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.CheckBox loggingIsEnabled;
        private System.Windows.Forms.CheckBox toolBarIsVisible;
    }
}

