namespace WinFormDemo.SyncAsyncAPMForm
{
    partial class Async实例
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
            this.txbAsynMethodID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMainThreadID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnClick = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbAsynMethodID
            // 
            this.txbAsynMethodID.Location = new System.Drawing.Point(335, 267);
            this.txbAsynMethodID.Name = "txbAsynMethodID";
            this.txbAsynMethodID.Size = new System.Drawing.Size(100, 21);
            this.txbAsynMethodID.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "运行异步方法的线程ID:";
            // 
            // txbMainThreadID
            // 
            this.txbMainThreadID.Location = new System.Drawing.Point(101, 267);
            this.txbMainThreadID.Name = "txbMainThreadID";
            this.txbMainThreadID.Size = new System.Drawing.Size(100, 21);
            this.txbMainThreadID.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "主线程ID为:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(411, 220);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(117, 12);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(75, 23);
            this.btnClick.TabIndex = 9;
            this.btnClick.Text = "点击我";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(209, 12);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 23);
            this.btnAsync.TabIndex = 9;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // Async实例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 342);
            this.Controls.Add(this.txbAsynMethodID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbMainThreadID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnClick);
            this.Name = "Async实例";
            this.Text = "Async使用CSharp5新特性来实现异步编程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAsynMethodID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMainThreadID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Button btnAsync;
    }
}