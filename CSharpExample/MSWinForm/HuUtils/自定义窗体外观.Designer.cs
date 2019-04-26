namespace HuUtils
{
    partial class 自定义窗体外观
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCustomShape = new System.Windows.Forms.Button();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonCustomPosition = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonCustomShape);
            this.groupBox1.Controls.Add(this.buttonCenter);
            this.groupBox1.Controls.Add(this.buttonCustomPosition);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(97, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 139);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义窗体";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(59, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "X:";
            // 
            // buttonCustomShape
            // 
            this.buttonCustomShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomShape.Location = new System.Drawing.Point(241, 59);
            this.buttonCustomShape.Name = "buttonCustomShape";
            this.buttonCustomShape.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomShape.TabIndex = 9;
            this.buttonCustomShape.Text = "显示自定义形状的窗体";
            this.buttonCustomShape.UseVisualStyleBackColor = true;
            this.buttonCustomShape.Click += new System.EventHandler(this.buttonCustomShape_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCenter.Location = new System.Drawing.Point(241, 101);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(202, 23);
            this.buttonCenter.TabIndex = 8;
            this.buttonCenter.Text = "将新窗体显示在屏幕中心";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonCustomPosition
            // 
            this.buttonCustomPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomPosition.Location = new System.Drawing.Point(241, 13);
            this.buttonCustomPosition.Name = "buttonCustomPosition";
            this.buttonCustomPosition.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomPosition.TabIndex = 7;
            this.buttonCustomPosition.Text = "将新窗体显示在屏幕指定位置";
            this.buttonCustomPosition.UseVisualStyleBackColor = true;
            this.buttonCustomPosition.Click += new System.EventHandler(this.buttonCustomPosition_Click);
            // 
            // 自定义窗体外观
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 356);
            this.Controls.Add(this.groupBox1);
            this.Name = "自定义窗体外观";
            this.Text = "自定义窗体外观";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.自定义窗体外观_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCustomShape;
        private System.Windows.Forms.Button buttonCenter;
        private System.Windows.Forms.Button buttonCustomPosition;
    }
}