namespace ChatDemo
{
    partial class ChatClient
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
            this.btnopenServices = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.d = new System.Windows.Forms.GroupBox();
            this.richMsg = new System.Windows.Forms.RichTextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.d.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnopenServices
            // 
            this.btnopenServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopenServices.Location = new System.Drawing.Point(312, 11);
            this.btnopenServices.Name = "btnopenServices";
            this.btnopenServices.Size = new System.Drawing.Size(144, 23);
            this.btnopenServices.TabIndex = 16;
            this.btnopenServices.Text = "打开服务器";
            this.btnopenServices.UseVisualStyleBackColor = true;
            this.btnopenServices.Click += new System.EventHandler(this.btnopenServices_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMsg.Location = new System.Drawing.Point(381, 315);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 15;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(19, 317);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(345, 21);
            this.txtSendMsg.TabIndex = 14;
            // 
            // d
            // 
            this.d.Controls.Add(this.richMsg);
            this.d.Location = new System.Drawing.Point(12, 40);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(460, 271);
            this.d.TabIndex = 13;
            this.d.TabStop = false;
            this.d.Text = "消息窗口";
            // 
            // richMsg
            // 
            this.richMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richMsg.Location = new System.Drawing.Point(3, 17);
            this.richMsg.Name = "richMsg";
            this.richMsg.Size = new System.Drawing.Size(454, 251);
            this.richMsg.TabIndex = 4;
            this.richMsg.Text = "";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(206, 11);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(85, 21);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "10001";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(63, 11);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(85, 21);
            this.txtIp.TabIndex = 11;
            this.txtIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP地址:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 351);
            this.Controls.Add(this.btnopenServices);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.d);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "客户端";
            this.d.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopenServices;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.GroupBox d;
        private System.Windows.Forms.RichTextBox richMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

