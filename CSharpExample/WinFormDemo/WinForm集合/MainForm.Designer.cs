﻿namespace WinForm集合
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "01-截屏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "02-调用摄像头";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(431, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "03-委托实例";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(61, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "04-无边框移动1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "05-无边框移动2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(431, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "06-资源管理器";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(61, 180);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(138, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "07-保存图片到数据库";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(246, 180);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(138, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "08-登录窗体";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(431, 180);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(138, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "09-数据绑定";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(61, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 139);
            this.groupBox1.TabIndex = 8;
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
            this.buttonCustomShape.Location = new System.Drawing.Point(241, 59);
            this.buttonCustomShape.Name = "buttonCustomShape";
            this.buttonCustomShape.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomShape.TabIndex = 9;
            this.buttonCustomShape.Text = "显示自定义形状的窗体";
            this.buttonCustomShape.UseVisualStyleBackColor = true;
            this.buttonCustomShape.Click += new System.EventHandler(this.buttonCustomShape_Click_1);
            // 
            // buttonCenter
            // 
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
            this.buttonCustomPosition.Location = new System.Drawing.Point(241, 13);
            this.buttonCustomPosition.Name = "buttonCustomPosition";
            this.buttonCustomPosition.Size = new System.Drawing.Size(202, 23);
            this.buttonCustomPosition.TabIndex = 7;
            this.buttonCustomPosition.Text = "将新窗体显示在屏幕指定位置";
            this.buttonCustomPosition.UseVisualStyleBackColor = true;
            this.buttonCustomPosition.Click += new System.EventHandler(this.buttonCustomPosition_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCustomShape;
        private System.Windows.Forms.Button buttonCenter;
        private System.Windows.Forms.Button buttonCustomPosition;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}