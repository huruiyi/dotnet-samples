namespace WfApp
{
    partial class AdoForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImport3 = new System.Windows.Forms.Button();
            this.btnImport2 = new System.Windows.Forms.Button();
            this.btnImport1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(55, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "数据导出2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "数据导出1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImport3
            // 
            this.btnImport3.Location = new System.Drawing.Point(55, 126);
            this.btnImport3.Name = "btnImport3";
            this.btnImport3.Size = new System.Drawing.Size(75, 23);
            this.btnImport3.TabIndex = 4;
            this.btnImport3.Text = "导入数据3";
            this.btnImport3.UseVisualStyleBackColor = true;
            this.btnImport3.Click += new System.EventHandler(this.btnImport3_Click);
            // 
            // btnImport2
            // 
            this.btnImport2.Location = new System.Drawing.Point(55, 78);
            this.btnImport2.Name = "btnImport2";
            this.btnImport2.Size = new System.Drawing.Size(75, 23);
            this.btnImport2.TabIndex = 5;
            this.btnImport2.Text = "导入数据2";
            this.btnImport2.UseVisualStyleBackColor = true;
            this.btnImport2.Click += new System.EventHandler(this.btnImport2_Click);
            // 
            // btnImport1
            // 
            this.btnImport1.Location = new System.Drawing.Point(55, 30);
            this.btnImport1.Name = "btnImport1";
            this.btnImport1.Size = new System.Drawing.Size(75, 23);
            this.btnImport1.TabIndex = 6;
            this.btnImport1.Text = "导入数据1";
            this.btnImport1.UseVisualStyleBackColor = true;
            this.btnImport1.Click += new System.EventHandler(this.btnImport1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 297);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnImport3);
            this.Controls.Add(this.btnImport2);
            this.Controls.Add(this.btnImport1);
            this.Name = "AdoForm";
            this.Text = "AdoForm";
            this.Load += new System.EventHandler(this.AdoForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImport3;
        private System.Windows.Forms.Button btnImport2;
        private System.Windows.Forms.Button btnImport1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}