namespace HuUtils
{
    partial class SpeechForm
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
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtContinue = new System.Windows.Forms.Button();
            this.txtRecord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trbVolumn = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVolumn)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(104, 300);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(564, 45);
            this.trackBarSpeed.TabIndex = 0;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(63, 71);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(653, 187);
            this.txtMsg.TabIndex = 1;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(63, 437);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "读";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(206, 437);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtContinue
            // 
            this.txtContinue.Location = new System.Drawing.Point(348, 437);
            this.txtContinue.Name = "txtContinue";
            this.txtContinue.Size = new System.Drawing.Size(75, 23);
            this.txtContinue.TabIndex = 4;
            this.txtContinue.Text = "继续";
            this.txtContinue.UseVisualStyleBackColor = true;
            this.txtContinue.Click += new System.EventHandler(this.txtContinue_Click);
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(491, 437);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(75, 23);
            this.txtRecord.TabIndex = 5;
            this.txtRecord.Text = "录音";
            this.txtRecord.UseVisualStyleBackColor = true;
            this.txtRecord.Click += new System.EventHandler(this.txtRecord_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 437);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "调节语速";
            // 
            // trbVolumn
            // 
            this.trbVolumn.Location = new System.Drawing.Point(104, 351);
            this.trbVolumn.Name = "trbVolumn";
            this.trbVolumn.Size = new System.Drawing.Size(564, 45);
            this.trbVolumn.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "调节声音";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trbVolumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.txtContinue);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.trackBarSpeed);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbVolumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button txtContinue;
        private System.Windows.Forms.Button txtRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbVolumn;
        private System.Windows.Forms.Label label2;
    }
}

