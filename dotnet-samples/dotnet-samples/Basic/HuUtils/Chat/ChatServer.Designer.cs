﻿namespace HuUtils.Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatServer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richMsg = new System.Windows.Forms.RichTextBox();
            this.gboxClient = new System.Windows.Forms.GroupBox();
            this.lvClient = new System.Windows.Forms.ListView();
            this.btnOpenClient = new System.Windows.Forms.Button();
            this.btnConServices = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnShake = new System.Windows.Forms.Button();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.gboxClient.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.richMsg);
            this.groupBox1.Controls.Add(this.gboxClient);
            this.groupBox1.Controls.Add(this.btnOpenClient);
            this.groupBox1.Controls.Add(this.btnConServices);
            this.groupBox1.Controls.Add(this.btnSendFile);
            this.groupBox1.Controls.Add(this.btnShake);
            this.groupBox1.Controls.Add(this.btnSendMsg);
            this.groupBox1.Controls.Add(this.txtSendMsg);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 393);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端";
            // 
            // richMsg
            // 
            this.richMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.richMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.richMsg.ForeColor = System.Drawing.Color.Red;
            this.richMsg.Location = new System.Drawing.Point(20, 44);
            this.richMsg.Name = "richMsg";
            this.richMsg.Size = new System.Drawing.Size(474, 248);
            this.richMsg.TabIndex = 4;
            this.richMsg.Text = "";
            // 
            // gboxClient
            // 
            this.gboxClient.BackColor = System.Drawing.Color.Transparent;
            this.gboxClient.Controls.Add(this.lvClient);
            this.gboxClient.Location = new System.Drawing.Point(505, 14);
            this.gboxClient.Name = "gboxClient";
            this.gboxClient.Size = new System.Drawing.Size(163, 363);
            this.gboxClient.TabIndex = 36;
            this.gboxClient.TabStop = false;
            this.gboxClient.Text = "客户端地址";
            // 
            // lvClient
            // 
            this.lvClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lvClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClient.HideSelection = false;
            this.lvClient.Location = new System.Drawing.Point(3, 17);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(157, 343);
            this.lvClient.TabIndex = 25;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.List;
            this.lvClient.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvClient_ItemSelectionChanged);
            // 
            // btnOpenClient
            // 
            this.btnOpenClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnOpenClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenClient.ForeColor = System.Drawing.Color.White;
            this.btnOpenClient.Location = new System.Drawing.Point(404, 13);
            this.btnOpenClient.Name = "btnOpenClient";
            this.btnOpenClient.Size = new System.Drawing.Size(87, 23);
            this.btnOpenClient.TabIndex = 34;
            this.btnOpenClient.Text = "启动客户端";
            this.btnOpenClient.UseVisualStyleBackColor = false;
            this.btnOpenClient.Click += new System.EventHandler(this.btnOpenClient_Click);
            // 
            // btnConServices
            // 
            this.btnConServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnConServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConServices.ForeColor = System.Drawing.Color.White;
            this.btnConServices.Location = new System.Drawing.Point(300, 13);
            this.btnConServices.Name = "btnConServices";
            this.btnConServices.Size = new System.Drawing.Size(96, 23);
            this.btnConServices.TabIndex = 35;
            this.btnConServices.Text = "启动服务器";
            this.btnConServices.UseVisualStyleBackColor = false;
            this.btnConServices.Click += new System.EventHandler(this.btnConServices_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location = new System.Drawing.Point(406, 355);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(87, 23);
            this.btnSendFile.TabIndex = 33;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnShake
            // 
            this.btnShake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnShake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShake.ForeColor = System.Drawing.Color.White;
            this.btnShake.Location = new System.Drawing.Point(406, 330);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(87, 23);
            this.btnShake.TabIndex = 33;
            this.btnShake.Text = "发送闪屏";
            this.btnShake.UseVisualStyleBackColor = false;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMsg.ForeColor = System.Drawing.Color.White;
            this.btnSendMsg.Location = new System.Drawing.Point(406, 304);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(87, 23);
            this.btnSendMsg.TabIndex = 33;
            this.btnSendMsg.Text = "发送消息";
            this.btnSendMsg.UseVisualStyleBackColor = false;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSendMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtSendMsg.ForeColor = System.Drawing.Color.Red;
            this.txtSendMsg.Location = new System.Drawing.Point(20, 306);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(376, 68);
            this.txtSendMsg.TabIndex = 32;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPort.Location = new System.Drawing.Point(222, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(72, 21);
            this.txtPort.TabIndex = 30;
            this.txtPort.Text = "12345";
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtIp.Location = new System.Drawing.Point(82, 13);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(72, 21);
            this.txtIp.TabIndex = 29;
            this.txtIp.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("隶书", 12F);
            this.label2.Location = new System.Drawing.Point(174, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("隶书", 12F);
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "IP地址:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pbClose);
            this.panel1.Controls.Add(this.pbMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 18);
            this.panel1.TabIndex = 28;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pbClose
            // 
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(650, 0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(27, 18);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClose.TabIndex = 1;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // pbMin
            // 
            this.pbMin.Image = ((System.Drawing.Image)(resources.GetObject("pbMin.Image")));
            this.pbMin.Location = new System.Drawing.Point(622, 0);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(27, 18);
            this.pbMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMin.TabIndex = 2;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // ChatServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(677, 424);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatServer";
            this.Text = "服务端";
            this.Resize += new System.EventHandler(this.ChatServer_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxClient.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gboxClient;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.Button btnOpenClient;
        private System.Windows.Forms.Button btnConServices;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.RichTextBox richMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.Button btnSendFile;
    }
}

