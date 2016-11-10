namespace UDPTest
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSendMssg = new System.Windows.Forms.TextBox();
            this.txtRecvMssg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRecv = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSendMssg);
            this.groupBox1.Location = new System.Drawing.Point(50, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送数据";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRecvMssg);
            this.groupBox2.Location = new System.Drawing.Point(457, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 296);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // txtSendMssg
            // 
            this.txtSendMssg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendMssg.Location = new System.Drawing.Point(3, 17);
            this.txtSendMssg.Multiline = true;
            this.txtSendMssg.Name = "txtSendMssg";
            this.txtSendMssg.Size = new System.Drawing.Size(387, 276);
            this.txtSendMssg.TabIndex = 0;
            // 
            // txtRecvMssg
            // 
            this.txtRecvMssg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecvMssg.Location = new System.Drawing.Point(3, 17);
            this.txtRecvMssg.Multiline = true;
            this.txtRecvMssg.Name = "txtRecvMssg";
            this.txtRecvMssg.Size = new System.Drawing.Size(387, 276);
            this.txtRecvMssg.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(197, 344);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送数据";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRecv
            // 
            this.btnRecv.Location = new System.Drawing.Point(641, 344);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(134, 23);
            this.btnRecv.TabIndex = 2;
            this.btnRecv.Text = "开始/停止接收数据";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 549);
            this.Controls.Add(this.btnRecv);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSendMssg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRecvMssg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnRecv;
    }
}

