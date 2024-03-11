namespace HuUtils
{
	partial class 串口编程实例
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
            this.txtShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.txtChackbit = new System.Windows.Forms.TextBox();
            this.txtStopbit = new System.Windows.Forms.TextBox();
            this.txtDatabit = new System.Windows.Forms.TextBox();
            this.txtBuad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalIp = new System.Windows.Forms.TextBox();
            this.txtSetDataPakge = new System.Windows.Forms.TextBox();
            this.txtTimeCell = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtShow
            // 
            this.txtShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShow.Location = new System.Drawing.Point(1, 2);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(505, 150);
            this.txtShow.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "设置本机地址";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.btnSetting);
            this.groupBox1.Controls.Add(this.txtChackbit);
            this.groupBox1.Controls.Add(this.txtStopbit);
            this.groupBox1.Controls.Add(this.txtDatabit);
            this.groupBox1.Controls.Add(this.txtBuad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Chocolate;
            this.groupBox1.Location = new System.Drawing.Point(5, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 228);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯设置";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(59, 27);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(121, 20);
            this.cmbPort.TabIndex = 4;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(13, 189);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(167, 33);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "应用设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // txtChackbit
            // 
            this.txtChackbit.Location = new System.Drawing.Point(58, 162);
            this.txtChackbit.Name = "txtChackbit";
            this.txtChackbit.ReadOnly = true;
            this.txtChackbit.Size = new System.Drawing.Size(122, 21);
            this.txtChackbit.TabIndex = 1;
            // 
            // txtStopbit
            // 
            this.txtStopbit.Location = new System.Drawing.Point(58, 129);
            this.txtStopbit.Name = "txtStopbit";
            this.txtStopbit.Size = new System.Drawing.Size(122, 21);
            this.txtStopbit.TabIndex = 1;
            this.txtStopbit.Text = "1";
            // 
            // txtDatabit
            // 
            this.txtDatabit.Location = new System.Drawing.Point(58, 99);
            this.txtDatabit.Name = "txtDatabit";
            this.txtDatabit.Size = new System.Drawing.Size(122, 21);
            this.txtDatabit.TabIndex = 1;
            this.txtDatabit.Text = "8";
            // 
            // txtBuad
            // 
            this.txtBuad.Location = new System.Drawing.Point(58, 66);
            this.txtBuad.Name = "txtBuad";
            this.txtBuad.Size = new System.Drawing.Size(122, 21);
            this.txtBuad.TabIndex = 1;
            this.txtBuad.Text = "9600";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "串口号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Chocolate;
            this.label7.Location = new System.Drawing.Point(215, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "时间间隔(ms)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Chocolate;
            this.label8.Location = new System.Drawing.Point(218, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "设置数据包";
            // 
            // txtLocalIp
            // 
            this.txtLocalIp.Location = new System.Drawing.Point(99, 159);
            this.txtLocalIp.Name = "txtLocalIp";
            this.txtLocalIp.Size = new System.Drawing.Size(316, 21);
            this.txtLocalIp.TabIndex = 1;
            // 
            // txtSetDataPakge
            // 
            this.txtSetDataPakge.Location = new System.Drawing.Point(289, 262);
            this.txtSetDataPakge.Name = "txtSetDataPakge";
            this.txtSetDataPakge.Size = new System.Drawing.Size(210, 21);
            this.txtSetDataPakge.TabIndex = 1;
            // 
            // txtTimeCell
            // 
            this.txtTimeCell.Location = new System.Drawing.Point(298, 382);
            this.txtTimeCell.Name = "txtTimeCell";
            this.txtTimeCell.Size = new System.Drawing.Size(114, 21);
            this.txtTimeCell.TabIndex = 1;
            this.txtTimeCell.Text = "10";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(424, 157);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 3;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(220, 296);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(279, 45);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "发送";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(424, 380);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(220, 204);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(279, 50);
            this.btnOpenPort.TabIndex = 3;
            this.btnOpenPort.Text = "开启串口";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Chocolate;
            this.checkBox1.Location = new System.Drawing.Point(220, 351);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "循环发送";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 425);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnOpenPort);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtTimeCell);
            this.Controls.Add(this.txtSetDataPakge);
            this.Controls.Add(this.txtLocalIp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "Form1";
            this.Text = "串口编程实例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtShow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.TextBox txtChackbit;
		private System.Windows.Forms.TextBox txtStopbit;
		private System.Windows.Forms.TextBox txtDatabit;
		private System.Windows.Forms.TextBox txtBuad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtLocalIp;
		private System.Windows.Forms.TextBox txtSetDataPakge;
		private System.Windows.Forms.TextBox txtTimeCell;
		private System.Windows.Forms.Button btnInit;
		private System.Windows.Forms.Button btnSendData;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnOpenPort;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox cmbPort;
	}
}

