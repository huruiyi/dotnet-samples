using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class LicGenForm2 : Form
    {
        public LicGenForm2()
        {
            InitializeComponent();
        }

        private void buttonSelectMarkcert_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                labelMakeCertPath.Text = of.FileName;
            }
        }

        private void buttonCreatPfx_Click(object sender, EventArgs e)
        {
            string MakeCert = labelMakeCertPath.Text;
            string x509Name = "CN=" + textBoxCnName.Text.Trim();
            string param = " -pe -ss my -n \"" + x509Name + "\" ";
            Process p = Process.Start(MakeCert, param);
            p.WaitForExit();
            p.Close();
            MessageBox.Show("创建完毕！");
        }

        private void buttonSelectExportPfxPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                labelExportPfxPath.Text = fb.SelectedPath;
            }
        }

        private void buttonExportPfxPath_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == "CN=" + textBoxCnName.Text.Trim())
                {
                    Debug.Print(string.Format("certificate name: {0}", x509.Subject));
                    byte[] pfxByte = x509.Export(X509ContentType.Pfx, textBoxExportKey.Text.Trim());
                    using (FileStream fileStream = new FileStream(Path.Combine(labelExportPfxPath.Text.Trim(), textBoxCnName.Text.Trim() + ".pfx"), FileMode.Create))
                    {
                        // Write the data to the file, byte by byte.
                        for (int i = 0; i < pfxByte.Length; i++)
                            fileStream.WriteByte(pfxByte[i]);
                        // Set the stream position to the beginning of the file.
                        fileStream.Seek(0, SeekOrigin.Begin);
                        // Read and verify the data.
                        for (int i = 0; i < fileStream.Length; i++)
                        {
                            if (pfxByte[i] != fileStream.ReadByte())
                            {
                                MessageBox.Show("Error writing data.");
                                return;
                            }
                        }
                        fileStream.Close();
                        MessageBox.Show("导出PFX完毕");
                    }
                    //string myname = "my name is luminji! and i love huzhonghua!";
                    //string enStr = this.RSAEncrypt(x509.PublicKey.Key.ToXmlString(false), myname);
                    //MessageBox.Show("密文是：" + enStr);
                    //string deStr = this.RSADecrypt(x509.PrivateKey.ToXmlString(true), enStr);
                    //MessageBox.Show("明文是：" + deStr);
                }
            }
            store.Close();
            store = null;
            storecollection = null;
        }

        private void buttonSelectExportCERPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                labelExportCerPath.Text = fb.SelectedPath;
            }
        }

        private void buttonExportCERPath_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
            foreach (X509Certificate2 x509 in storecollection)
            {
                if (x509.Subject == "CN=" + textBoxCnName.Text.Trim())
                {
                    Debug.Print(string.Format("certificate name: {0}", x509.Subject));
                    byte[] pfxByte = x509.Export(X509ContentType.Cert);
                    using (FileStream fileStream = new FileStream(Path.Combine(labelExportCerPath.Text.Trim(), textBoxCnName.Text.Trim() + ".cert"), FileMode.Create))
                    {
                        // Write the data to the file, byte by byte.
                        for (int i = 0; i < pfxByte.Length; i++)
                            fileStream.WriteByte(pfxByte[i]);
                        // Set the stream position to the beginning of the file.
                        fileStream.Seek(0, SeekOrigin.Begin);
                        // Read and verify the data.
                        for (int i = 0; i < fileStream.Length; i++)
                        {
                            if (pfxByte[i] != fileStream.ReadByte())
                            {
                                MessageBox.Show("Error writing data.");
                                return;
                            }
                        }
                        fileStream.Close();
                        MessageBox.Show("导出CERT完毕");
                    }
                }
            }
            store.Close();
            store = null;
            storecollection = null;
        }

        private void buttonSelectPfx_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                labelPfxPath.Text = of.FileName;
            }
        }

        private void buttonGetKeyPair_Click(object sender, EventArgs e)
        {
            X509Certificate2 pc = new X509Certificate2(labelPfxPath.Text.Trim(), textBoxPfxKey.Text.Trim(), X509KeyStorageFlags.Exportable);
            labelMd5.Text = pc.Thumbprint;
            labelName.Text = pc.SubjectName.Name;
            textBoxPublic.Text = pc.PublicKey.Key.ToXmlString(false);
            textBoxPrivate.Text = pc.PrivateKey.ToXmlString(true);
            pc = null;
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            textBoxEncrypt.Text = this.RSAEncrypt(textBoxPublic.Text.Trim(), textBoxOrigin.Text.Trim());
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            label1Decrypt.Text = this.RSADecrypt(textBoxPrivate.Text, textBoxEncrypt.Text);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="m_strDecryptString"></param>
        /// <returns></returns>
        public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPrivateKey);
            byte[] rgb = Convert.FromBase64String(m_strDecryptString);
            byte[] bytes = provider.Decrypt(rgb, false);
            return new UnicodeEncoding().GetString(bytes);
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="xmlPublicKey"></param>
        /// <param name="m_strEncryptString"></param>
        /// <returns></returns>
        public string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            byte[] bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));
        }
    }
}