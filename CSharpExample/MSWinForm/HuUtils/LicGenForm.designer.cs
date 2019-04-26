namespace HuUtils
{
  partial class LicGenForm
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
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.License = new System.Windows.Forms.TextBox();
            this.btnValLicense = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Expires = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GUID = new System.Windows.Forms.TextBox();
            this.PrivateKey = new System.Windows.Forms.TextBox();
            this.btnGenLicense = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PublicKey = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(396, 493);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(112, 22);
            this.btnCreateFile.TabIndex = 29;
            this.btnCreateFile.Text = "Create Lic File";
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "License ";
            // 
            // License
            // 
            this.License.BackColor = System.Drawing.SystemColors.Window;
            this.License.Location = new System.Drawing.Point(12, 368);
            this.License.Multiline = true;
            this.License.Name = "License";
            this.License.Size = new System.Drawing.Size(827, 99);
            this.License.TabIndex = 27;
            // 
            // btnValLicense
            // 
            this.btnValLicense.Location = new System.Drawing.Point(268, 493);
            this.btnValLicense.Name = "btnValLicense";
            this.btnValLicense.Size = new System.Drawing.Size(112, 22);
            this.btnValLicense.TabIndex = 26;
            this.btnValLicense.Text = "Validate License";
            this.btnValLicense.Click += new System.EventHandler(this.btnValLicense_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Expires";
            // 
            // Expires
            // 
            this.Expires.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Expires.Location = new System.Drawing.Point(92, 311);
            this.Expires.Name = "Expires";
            this.Expires.Size = new System.Drawing.Size(200, 21);
            this.Expires.TabIndex = 24;
            this.Expires.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(572, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 21);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Guid";
            // 
            // GUID
            // 
            this.GUID.BackColor = System.Drawing.SystemColors.Window;
            this.GUID.Location = new System.Drawing.Point(7, 21);
            this.GUID.Multiline = true;
            this.GUID.Name = "GUID";
            this.GUID.Size = new System.Drawing.Size(496, 22);
            this.GUID.TabIndex = 21;
            // 
            // PrivateKey
            // 
            this.PrivateKey.BackColor = System.Drawing.SystemColors.Window;
            this.PrivateKey.Location = new System.Drawing.Point(7, 66);
            this.PrivateKey.Multiline = true;
            this.PrivateKey.Name = "PrivateKey";
            this.PrivateKey.Size = new System.Drawing.Size(827, 101);
            this.PrivateKey.TabIndex = 19;
            // 
            // btnGenLicense
            // 
            this.btnGenLicense.Location = new System.Drawing.Point(148, 493);
            this.btnGenLicense.Name = "btnGenLicense";
            this.btnGenLicense.Size = new System.Drawing.Size(112, 22);
            this.btnGenLicense.TabIndex = 16;
            this.btnGenLicense.Text = "Generate License";
            this.btnGenLicense.Click += new System.EventHandler(this.btnGenLicense_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Private Key";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Public Key";
            // 
            // PublicKey
            // 
            this.PublicKey.BackColor = System.Drawing.SystemColors.Window;
            this.PublicKey.Location = new System.Drawing.Point(7, 190);
            this.PublicKey.Multiline = true;
            this.PublicKey.Name = "PublicKey";
            this.PublicKey.Size = new System.Drawing.Size(827, 115);
            this.PublicKey.TabIndex = 17;
            // 
            // LicGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 529);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.License);
            this.Controls.Add(this.btnValLicense);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Expires);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GUID);
            this.Controls.Add(this.PrivateKey);
            this.Controls.Add(this.btnGenLicense);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PublicKey);
            this.Name = "LicGenForm";
            this.Text = "License Generator Form";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCreateFile;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox License;
    private System.Windows.Forms.Button btnValLicense;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker Expires;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox GUID;
    private System.Windows.Forms.TextBox PrivateKey;
    private System.Windows.Forms.Button btnGenLicense;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox PublicKey;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}

