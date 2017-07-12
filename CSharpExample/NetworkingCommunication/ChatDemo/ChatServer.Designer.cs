namespace ChatDemo
{
    partial class ChatServer
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
            this.btnConServices = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.d = new System.Windows.Forms.GroupBox();
            this.richMsg = new System.Windows.Forms.RichTextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lvClient = new System.Windows.Forms.ListView();
            this.gboxClient = new System.Windows.Forms.GroupBox();
            this.d.SuspendLayout();
            this.gboxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConServices
            // 
            this.btnConServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConServices.Location = new System.Drawing.Point(309, 11);
            this.btnConServices.Name = "btnConServices";
            this.btnConServices.Size = new System.Drawing.Size(75, 23);
            this.btnConServices.TabIndex = 24;
            this.btnConServices.Text = "启动服务器";
            this.btnConServices.UseVisualStyleBackColor = true;
            this.btnConServices.Click += new System.EventHandler(this.btnConServices_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMsg.Location = new System.Drawing.Point(385, 495);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 23;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(15, 495);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(355, 21);
            this.txtSendMsg.TabIndex = 22;
            // 
            // d
            // 
            this.d.Controls.Add(this.richMsg);
            this.d.Location = new System.Drawing.Point(12, 40);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(448, 435);
            this.d.TabIndex = 21;
            this.d.TabStop = false;
            this.d.Text = "消息窗口";
            // 
            // richMsg
            // 
            this.richMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richMsg.Location = new System.Drawing.Point(3, 17);
            this.richMsg.Name = "richMsg";
            this.richMsg.Size = new System.Drawing.Size(442, 415);
            this.richMsg.TabIndex = 4;
            this.richMsg.Text = "";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(203, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(83, 21);
            this.txtPort.TabIndex = 20;
            this.txtPort.Text = "12345";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(63, 13);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(80, 21);
            this.txtIp.TabIndex = 19;
            this.txtIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP地址:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(385, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "启动客户端";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvClient
            // 
            this.lvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClient.Location = new System.Drawing.Point(3, 17);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(312, 490);
            this.lvClient.TabIndex = 25;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.List;
            this.lvClient.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvClient_ItemSelectionChanged);
            this.lvClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvClient_KeyDown);
            // 
            // gboxClient
            // 
            this.gboxClient.Controls.Add(this.lvClient);
            this.gboxClient.Location = new System.Drawing.Point(486, 8);
            this.gboxClient.Name = "gboxClient";
            this.gboxClient.Size = new System.Drawing.Size(318, 510);
            this.gboxClient.TabIndex = 26;
            this.gboxClient.TabStop = false;
            this.gboxClient.Text = "客户端地址";
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 537);
            this.Controls.Add(this.gboxClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConServices);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.d);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChatServer";
            this.Text = "服务端";
            this.d.ResumeLayout(false);
            this.gboxClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConServices;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.GroupBox d;
        private System.Windows.Forms.RichTextBox richMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.GroupBox gboxClient;
    }
}

