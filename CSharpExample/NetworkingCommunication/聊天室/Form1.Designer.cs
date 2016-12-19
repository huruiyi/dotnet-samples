namespace 聊天室
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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendmsg = new System.Windows.Forms.Button();
            this.txtInputmsg = new System.Windows.Forms.TextBox();
            this.btnOpenClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(43, 91);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(376, 223);
            this.txtMsg.TabIndex = 9;
            // 
            // btnStartServer
            // 
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Location = new System.Drawing.Point(307, 62);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(112, 23);
            this.btnStartServer.TabIndex = 8;
            this.btnStartServer.Text = "打开服务器";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(199, 62);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(89, 21);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "50001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(64, 61);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(89, 21);
            this.txtIp.TabIndex = 7;
            this.txtIp.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // btnSendmsg
            // 
            this.btnSendmsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendmsg.Location = new System.Drawing.Point(81, 385);
            this.btnSendmsg.Name = "btnSendmsg";
            this.btnSendmsg.Size = new System.Drawing.Size(112, 23);
            this.btnSendmsg.TabIndex = 10;
            this.btnSendmsg.Text = "发送消息";
            this.btnSendmsg.UseVisualStyleBackColor = true;
            this.btnSendmsg.Click += new System.EventHandler(this.btnSendmsg_Click);
            // 
            // txtInputmsg
            // 
            this.txtInputmsg.Location = new System.Drawing.Point(43, 343);
            this.txtInputmsg.Name = "txtInputmsg";
            this.txtInputmsg.Size = new System.Drawing.Size(376, 21);
            this.txtInputmsg.TabIndex = 11;
            // 
            // btnOpenClient
            // 
            this.btnOpenClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenClient.Location = new System.Drawing.Point(258, 385);
            this.btnOpenClient.Name = "btnOpenClient";
            this.btnOpenClient.Size = new System.Drawing.Size(112, 23);
            this.btnOpenClient.TabIndex = 10;
            this.btnOpenClient.Text = "启动客户端";
            this.btnOpenClient.UseVisualStyleBackColor = true;
            this.btnOpenClient.Click += new System.EventHandler(this.btnOpenClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.txtInputmsg);
            this.Controls.Add(this.btnOpenClient);
            this.Controls.Add(this.btnSendmsg);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendmsg;
        private System.Windows.Forms.TextBox txtInputmsg;
        private System.Windows.Forms.Button btnOpenClient;
    }
}

