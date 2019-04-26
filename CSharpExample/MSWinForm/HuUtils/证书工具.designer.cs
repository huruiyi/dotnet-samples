namespace HuUtils
{
    partial class 证书工具
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMakeCertPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreatPfx = new System.Windows.Forms.Button();
            this.buttonSelectMarkcert = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelExportPfxPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxExportKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExportPfxPath = new System.Windows.Forms.Button();
            this.buttonSelectExportPfxPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelExportCerPath = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonExportCERPath = new System.Windows.Forms.Button();
            this.buttonSelectExportCERPath = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelPfxPath = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPfxKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonGetKeyPair = new System.Windows.Forms.Button();
            this.buttonSelectPfx = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelMd5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPublic = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxPrivate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxOrigin = new System.Windows.Forms.TextBox();
            this.label1Decrypt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEncrypt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMakeCertPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCnName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonCreatPfx);
            this.groupBox1.Controls.Add(this.buttonSelectMarkcert);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建含有私钥的证书";
            // 
            // labelMakeCertPath
            // 
            this.labelMakeCertPath.AutoSize = true;
            this.labelMakeCertPath.Location = new System.Drawing.Point(148, 26);
            this.labelMakeCertPath.Name = "labelMakeCertPath";
            this.labelMakeCertPath.Size = new System.Drawing.Size(29, 12);
            this.labelMakeCertPath.TabIndex = 5;
            this.labelMakeCertPath.Text = "……";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "制定证书名：";
            // 
            // textBoxCnName
            // 
            this.textBoxCnName.Location = new System.Drawing.Point(148, 46);
            this.textBoxCnName.Name = "textBoxCnName";
            this.textBoxCnName.Size = new System.Drawing.Size(135, 21);
            this.textBoxCnName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "makecert的完整路径：";
            // 
            // buttonCreatPfx
            // 
            this.buttonCreatPfx.Location = new System.Drawing.Point(342, 86);
            this.buttonCreatPfx.Name = "buttonCreatPfx";
            this.buttonCreatPfx.Size = new System.Drawing.Size(120, 23);
            this.buttonCreatPfx.TabIndex = 1;
            this.buttonCreatPfx.Text = "创建";
            this.buttonCreatPfx.UseVisualStyleBackColor = true;
            this.buttonCreatPfx.Click += new System.EventHandler(this.buttonCreatPfx_Click);
            // 
            // buttonSelectMarkcert
            // 
            this.buttonSelectMarkcert.Location = new System.Drawing.Point(216, 86);
            this.buttonSelectMarkcert.Name = "buttonSelectMarkcert";
            this.buttonSelectMarkcert.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectMarkcert.TabIndex = 0;
            this.buttonSelectMarkcert.Text = "选择makecert.exe";
            this.buttonSelectMarkcert.UseVisualStyleBackColor = true;
            this.buttonSelectMarkcert.Click += new System.EventHandler(this.buttonSelectMarkcert_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelExportPfxPath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxExportKey);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonExportPfxPath);
            this.groupBox2.Controls.Add(this.buttonSelectExportPfxPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 115);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出为PFX文件";
            // 
            // labelExportPfxPath
            // 
            this.labelExportPfxPath.AutoSize = true;
            this.labelExportPfxPath.Location = new System.Drawing.Point(148, 26);
            this.labelExportPfxPath.Name = "labelExportPfxPath";
            this.labelExportPfxPath.Size = new System.Drawing.Size(29, 12);
            this.labelExportPfxPath.TabIndex = 5;
            this.labelExportPfxPath.Text = "……";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "指定pfx文件密码：";
            // 
            // textBoxExportKey
            // 
            this.textBoxExportKey.Location = new System.Drawing.Point(148, 46);
            this.textBoxExportKey.Name = "textBoxExportKey";
            this.textBoxExportKey.Size = new System.Drawing.Size(135, 21);
            this.textBoxExportKey.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "导出路径：";
            // 
            // buttonExportPfxPath
            // 
            this.buttonExportPfxPath.Location = new System.Drawing.Point(342, 86);
            this.buttonExportPfxPath.Name = "buttonExportPfxPath";
            this.buttonExportPfxPath.Size = new System.Drawing.Size(120, 23);
            this.buttonExportPfxPath.TabIndex = 1;
            this.buttonExportPfxPath.Text = "导出";
            this.buttonExportPfxPath.UseVisualStyleBackColor = true;
            this.buttonExportPfxPath.Click += new System.EventHandler(this.buttonExportPfxPath_Click);
            // 
            // buttonSelectExportPfxPath
            // 
            this.buttonSelectExportPfxPath.Location = new System.Drawing.Point(216, 86);
            this.buttonSelectExportPfxPath.Name = "buttonSelectExportPfxPath";
            this.buttonSelectExportPfxPath.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectExportPfxPath.TabIndex = 0;
            this.buttonSelectExportPfxPath.Text = "选择导出路径";
            this.buttonSelectExportPfxPath.UseVisualStyleBackColor = true;
            this.buttonSelectExportPfxPath.Click += new System.EventHandler(this.buttonSelectExportPfxPath_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelExportCerPath);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.buttonExportCERPath);
            this.groupBox3.Controls.Add(this.buttonSelectExportCERPath);
            this.groupBox3.Location = new System.Drawing.Point(12, 275);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 91);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导出为CER文件";
            // 
            // labelExportCerPath
            // 
            this.labelExportCerPath.AutoSize = true;
            this.labelExportCerPath.Location = new System.Drawing.Point(148, 26);
            this.labelExportCerPath.Name = "labelExportCerPath";
            this.labelExportCerPath.Size = new System.Drawing.Size(29, 12);
            this.labelExportCerPath.TabIndex = 5;
            this.labelExportCerPath.Text = "……";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "导出路径：";
            // 
            // buttonExportCERPath
            // 
            this.buttonExportCERPath.Location = new System.Drawing.Point(342, 53);
            this.buttonExportCERPath.Name = "buttonExportCERPath";
            this.buttonExportCERPath.Size = new System.Drawing.Size(120, 23);
            this.buttonExportCERPath.TabIndex = 1;
            this.buttonExportCERPath.Text = "导出";
            this.buttonExportCERPath.UseVisualStyleBackColor = true;
            this.buttonExportCERPath.Click += new System.EventHandler(this.buttonExportCERPath_Click);
            // 
            // buttonSelectExportCERPath
            // 
            this.buttonSelectExportCERPath.Location = new System.Drawing.Point(216, 53);
            this.buttonSelectExportCERPath.Name = "buttonSelectExportCERPath";
            this.buttonSelectExportCERPath.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectExportCERPath.TabIndex = 0;
            this.buttonSelectExportCERPath.Text = "选择导出路径";
            this.buttonSelectExportCERPath.UseVisualStyleBackColor = true;
            this.buttonSelectExportCERPath.Click += new System.EventHandler(this.buttonSelectExportCERPath_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelPfxPath);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBoxPfxKey);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.buttonGetKeyPair);
            this.groupBox4.Controls.Add(this.buttonSelectPfx);
            this.groupBox4.Location = new System.Drawing.Point(12, 384);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(477, 115);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PFX文件的作用";
            // 
            // labelPfxPath
            // 
            this.labelPfxPath.AutoSize = true;
            this.labelPfxPath.Location = new System.Drawing.Point(148, 26);
            this.labelPfxPath.Name = "labelPfxPath";
            this.labelPfxPath.Size = new System.Drawing.Size(29, 12);
            this.labelPfxPath.TabIndex = 5;
            this.labelPfxPath.Text = "……";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "pfx文件密码：";
            // 
            // textBoxPfxKey
            // 
            this.textBoxPfxKey.Location = new System.Drawing.Point(148, 46);
            this.textBoxPfxKey.Name = "textBoxPfxKey";
            this.textBoxPfxKey.Size = new System.Drawing.Size(135, 21);
            this.textBoxPfxKey.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "文件路径：";
            // 
            // buttonGetKeyPair
            // 
            this.buttonGetKeyPair.Location = new System.Drawing.Point(342, 86);
            this.buttonGetKeyPair.Name = "buttonGetKeyPair";
            this.buttonGetKeyPair.Size = new System.Drawing.Size(120, 23);
            this.buttonGetKeyPair.TabIndex = 1;
            this.buttonGetKeyPair.Text = "获取密钥对";
            this.buttonGetKeyPair.UseVisualStyleBackColor = true;
            this.buttonGetKeyPair.Click += new System.EventHandler(this.buttonGetKeyPair_Click);
            // 
            // buttonSelectPfx
            // 
            this.buttonSelectPfx.Location = new System.Drawing.Point(216, 86);
            this.buttonSelectPfx.Name = "buttonSelectPfx";
            this.buttonSelectPfx.Size = new System.Drawing.Size(120, 23);
            this.buttonSelectPfx.TabIndex = 0;
            this.buttonSelectPfx.Text = "选择PFX文件";
            this.buttonSelectPfx.UseVisualStyleBackColor = true;
            this.buttonSelectPfx.Click += new System.EventHandler(this.buttonSelectPfx_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxEncrypt);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label1Decrypt);
            this.groupBox5.Controls.Add(this.textBoxOrigin);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.textBoxPrivate);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.labelName);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.labelMd5);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.textBoxPublic);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.buttonDecrypt);
            this.groupBox5.Controls.Add(this.buttonEncrypt);
            this.groupBox5.Location = new System.Drawing.Point(495, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(477, 487);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "公钥私钥加解密";
            // 
            // labelMd5
            // 
            this.labelMd5.AutoSize = true;
            this.labelMd5.Location = new System.Drawing.Point(97, 26);
            this.labelMd5.Name = "labelMd5";
            this.labelMd5.Size = new System.Drawing.Size(29, 12);
            this.labelMd5.TabIndex = 5;
            this.labelMd5.Text = "……";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "公钥：";
            // 
            // textBoxPublic
            // 
            this.textBoxPublic.Location = new System.Drawing.Point(91, 86);
            this.textBoxPublic.Multiline = true;
            this.textBoxPublic.Name = "textBoxPublic";
            this.textBoxPublic.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxPublic.Size = new System.Drawing.Size(372, 99);
            this.textBoxPublic.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "证书MD5：";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(343, 458);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(120, 23);
            this.buttonDecrypt.TabIndex = 1;
            this.buttonDecrypt.Text = "使用私钥解密";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(343, 234);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(120, 23);
            this.buttonEncrypt.TabIndex = 0;
            this.buttonEncrypt.Text = "使用公钥加密";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "证书名称：";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(98, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "……";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 8;
            this.label16.Text = "私钥：";
            // 
            // textBoxPrivate
            // 
            this.textBoxPrivate.Location = new System.Drawing.Point(91, 263);
            this.textBoxPrivate.Multiline = true;
            this.textBoxPrivate.Name = "textBoxPrivate";
            this.textBoxPrivate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxPrivate.Size = new System.Drawing.Size(372, 99);
            this.textBoxPrivate.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 10;
            this.label17.Text = "待加密文本：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 437);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 11;
            this.label18.Text = "解密后文本：";
            // 
            // textBoxOrigin
            // 
            this.textBoxOrigin.Location = new System.Drawing.Point(91, 203);
            this.textBoxOrigin.Name = "textBoxOrigin";
            this.textBoxOrigin.Size = new System.Drawing.Size(372, 21);
            this.textBoxOrigin.TabIndex = 6;
            // 
            // label1Decrypt
            // 
            this.label1Decrypt.AutoSize = true;
            this.label1Decrypt.Location = new System.Drawing.Point(98, 437);
            this.label1Decrypt.Name = "label1Decrypt";
            this.label1Decrypt.Size = new System.Drawing.Size(29, 12);
            this.label1Decrypt.TabIndex = 12;
            this.label1Decrypt.Text = "……";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "加密后文本：";
            // 
            // textBoxEncrypt
            // 
            this.textBoxEncrypt.Location = new System.Drawing.Point(91, 378);
            this.textBoxEncrypt.Multiline = true;
            this.textBoxEncrypt.Name = "textBoxEncrypt";
            this.textBoxEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxEncrypt.Size = new System.Drawing.Size(372, 46);
            this.textBoxEncrypt.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(689, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "出处：www.luminji.com; blog.csdn.net/luminji";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 546);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "证书工具类";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreatPfx;
        private System.Windows.Forms.Button buttonSelectMarkcert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCnName;
        private System.Windows.Forms.Label labelMakeCertPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelExportPfxPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxExportKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExportPfxPath;
        private System.Windows.Forms.Button buttonSelectExportPfxPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelExportCerPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonExportCERPath;
        private System.Windows.Forms.Button buttonSelectExportCERPath;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelPfxPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPfxKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonGetKeyPair;
        private System.Windows.Forms.Button buttonSelectPfx;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelMd5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPublic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Label label1Decrypt;
        private System.Windows.Forms.TextBox textBoxOrigin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxPrivate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEncrypt;
        private System.Windows.Forms.Label label6;
    }
}

