namespace SocketChat
{
    partial class ChatMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(1, 91);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(600, 256);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(508, 388);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "绑定IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "消息:";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(53, 390);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(420, 21);
            this.txtMsg.TabIndex = 3;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(71, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(132, 21);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.1.100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "绑定端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(273, 32);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(132, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8888";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(426, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(528, 35);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(62, 22);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "停止....";
            // 
            // ChatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 478);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChatMain";
            this.Text = "ChatMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMsg;
    }
}