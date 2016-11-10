namespace _0423_1
{
    partial class updateStuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtstuNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxGrade = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBorn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学号：";
            // 
            // txtstuNo
            // 
            this.txtstuNo.Location = new System.Drawing.Point(161, 33);
            this.txtstuNo.Name = "txtstuNo";
            this.txtstuNo.Size = new System.Drawing.Size(100, 21);
            this.txtstuNo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(161, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(161, 114);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 21);
            this.txtAddress.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "出生日期";
            // 
            // cbxGrade
            // 
            this.cbxGrade.FormattingEnabled = true;
            this.cbxGrade.Location = new System.Drawing.Point(399, 184);
            this.cbxGrade.Name = "cbxGrade";
            this.cbxGrade.Size = new System.Drawing.Size(121, 20);
            this.cbxGrade.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "性别：";
            // 
            // cbxSex
            // 
            this.cbxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxSex.Location = new System.Drawing.Point(399, 147);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(121, 20);
            this.cbxSex.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "电话：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(399, 75);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(327, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(399, 33);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Email：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(399, 114);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 21);
            this.txtEmail.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "年级：";
            // 
            // txtBorn
            // 
            this.txtBorn.Location = new System.Drawing.Point(161, 147);
            this.txtBorn.Name = "txtBorn";
            this.txtBorn.Size = new System.Drawing.Size(100, 21);
            this.txtBorn.TabIndex = 4;
            // 
            // addStuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 325);
            this.Controls.Add(this.txtBorn);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cbxSex);
            this.Controls.Add(this.cbxGrade);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtstuNo);
            this.Controls.Add(this.label1);
            this.Name = "updateStuForm";
            this.Text = "updateStuForm";
            this.Load += new System.EventHandler(this.addStuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtstuNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBorn;
    }
}