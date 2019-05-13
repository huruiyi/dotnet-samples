namespace HuUtils.SystemManager
{
    partial class USBMinitor02
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new global::System.Windows.Forms.GroupBox();
            this.txtInfo = new global::System.Windows.Forms.TextBox();
            this.button1 = new global::System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new global::System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new global::System.Drawing.Size(674, 725);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info:";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = global::System.Windows.Forms.DockStyle.Top;
            this.txtInfo.Location = new global::System.Drawing.Point(3, 17);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new global::System.Drawing.Size(668, 676);
            this.txtInfo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new global::System.Drawing.Point(3, 699);
            this.button1.Name = "button1";
            this.button1.Size = new global::System.Drawing.Size(668, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new global::System.EventHandler(this.Button1_Click);
            // 
            // USB监控
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new global::System.Drawing.Size(686, 725);
            this.Controls.Add(this.groupBox1);
            this.Name = "USB监控";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private global::System.Windows.Forms.GroupBox groupBox1;
        private global::System.Windows.Forms.TextBox txtInfo;
        private global::System.Windows.Forms.Button button1;
    }
}