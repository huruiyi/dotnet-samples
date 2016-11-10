namespace FormPositionExample
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCustomPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonCustomShape = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCustomPosition
            // 
            this.buttonCustomPosition.Location = new System.Drawing.Point(180, 19);
            this.buttonCustomPosition.Name = "buttonCustomPosition";
            this.buttonCustomPosition.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomPosition.TabIndex = 0;
            this.buttonCustomPosition.Text = "将新窗体显示在屏幕指定位置";
            this.buttonCustomPosition.UseVisualStyleBackColor = true;
            this.buttonCustomPosition.Click += new System.EventHandler(this.buttonCustomPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(40, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // buttonCenter
            // 
            this.buttonCenter.Location = new System.Drawing.Point(180, 107);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(202, 23);
            this.buttonCenter.TabIndex = 5;
            this.buttonCenter.Text = "将新窗体显示在屏幕中心";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonCustomShape
            // 
            this.buttonCustomShape.Location = new System.Drawing.Point(180, 65);
            this.buttonCustomShape.Name = "buttonCustomShape";
            this.buttonCustomShape.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomShape.TabIndex = 6;
            this.buttonCustomShape.Text = "显示自定义形状的窗体";
            this.buttonCustomShape.UseVisualStyleBackColor = true;
            this.buttonCustomShape.Click += new System.EventHandler(this.buttonCustomShape_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 180);
            this.Controls.Add(this.buttonCustomShape);
            this.Controls.Add(this.buttonCenter);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCustomPosition);
            this.Name = "Form1";
            this.Text = "窗体显示位置及窗体外观控制";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCustomPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonCenter;
        private System.Windows.Forms.Button buttonCustomShape;
    }
}

