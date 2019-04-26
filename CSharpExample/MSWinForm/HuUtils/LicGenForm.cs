using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class LicGenForm : Form
    {
        public LicGenForm()
        {
            InitializeComponent();
        }

        private string GetLicenseText()
        {
            return GUID.Text + "#" + Expires.Value.ToShortDateString() + "#";
        }

        private void btnGenLicense_Click(object sender, System.EventArgs e)
        {
            GUID.Text = Guid.NewGuid().ToString();
            byte[] clear = Encoding.ASCII.GetBytes(GetLicenseText());
            SHA1Managed provSHA1 = new SHA1Managed();
            byte[] hash = provSHA1.ComputeHash(clear);

            RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider();
            PublicKey.Text = provRSA.ToXmlString(false);
            PrivateKey.Text = provRSA.ToXmlString(true);

            byte[] signature = provRSA.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

            License.Text = GetLicenseText() + Convert.ToBase64String(signature, 0, signature.Length);



            GUID.ReadOnly = true;
            GUID.BackColor = System.Drawing.SystemColors.ButtonFace;
            PublicKey.ReadOnly = true;
            PublicKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            PrivateKey.ReadOnly = true;
            PrivateKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            License.ReadOnly = true;
            License.BackColor = System.Drawing.SystemColors.ButtonFace;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValLicense_Click(object sender, EventArgs e)
        {
    

            string[] values = License.Text.Split('#');
            byte[] clear = Encoding.ASCII.GetBytes(values[0] + "#" + values[1] + "#");

            // recompute the hash value
            SHA1Managed provSHA1 = new SHA1Managed();
            byte[] hash = provSHA1.ComputeHash(clear);

            // reload the RSA provider based on the public key only
            RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider();
            provRSA.FromXmlString(PublicKey.Text);


            byte[] sigBytes = Convert.FromBase64String(values[2]);

   
            bool result = provRSA.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"),sigBytes);
            MessageBox.Show("Signature verified:" + result);
        }

        private void btnCreateFile_Click(object sender, System.EventArgs e)
        {
            saveFileDialog1.Filter = " License Files (*.lic) |*.lic|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "lic";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                using (FileStream stm = new FileStream(filename, FileMode.Truncate))
                {
                    using (StreamWriter wtr = new StreamWriter(stm))
                    {
                        wtr.Write(License.Text);
                    }
                }
            }
        }

        private void LicGenForm_Load(object sender, EventArgs e)
        {
            Expires.Value = DateTime.Now.Date.Add(new TimeSpan(365 * 10, 0, 0, 0));
        }
    }
}