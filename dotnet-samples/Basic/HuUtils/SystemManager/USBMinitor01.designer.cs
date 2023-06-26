namespace HuUtils.SystemManager
{
    partial class USBMinitor01
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
            this.CheckDeviceStatus_Lable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckDeviceStatus_Lable
            // 
            this.CheckDeviceStatus_Lable.AutoSize = true;
            this.CheckDeviceStatus_Lable.Location = new System.Drawing.Point(111, 72);
            this.CheckDeviceStatus_Lable.Name = "CheckDeviceStatus_Lable";
            this.CheckDeviceStatus_Lable.Size = new System.Drawing.Size(41, 12);
            this.CheckDeviceStatus_Lable.TabIndex = 0;
            this.CheckDeviceStatus_Lable.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "用户账户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // USBMinitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckDeviceStatus_Lable);
            this.Name = "USBMinitor";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private global::System.Windows.Forms.Label CheckDeviceStatus_Lable;
        private global::System.Windows.Forms.Button button1;
        #endregion
    }
}