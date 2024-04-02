using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace ConApp.Samples
{
    public class Pkcs12ProtectedConfigurationProvider : ProtectedConfigurationProvider
    {
        private string thumbprint;

        /// <summary>
        /// Initializes the provider with default settings.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="configurationValues">A NameValueCollection collection of values to use
        /// when initializing the object. This must include a thumbprint value for the thumbprint of
        /// the certificate used to encrypt the configuration section.
        /// </param>
        public override void Initialize(string name, NameValueCollection configurationValues)
        {
            base.Initialize(name, configurationValues);
            if (configurationValues["thumbprint"] == null || configurationValues["thumbprint"].Length == 0)
            {
                throw new ApplicationException("thumbprint not set in the configuration");
            }

            this.thumbprint = configurationValues["thumbprint"];
        }

        /// <summary>
        /// Decrypts the XML node passed to it.
        /// </summary>
        /// <param name="encryptedNode">The XmlNode to decrypt.</param>
        /// <returns></returns>
        public override XmlNode Decrypt(XmlNode encryptedNode)
        {
            XmlDocument document = new XmlDocument();

            // Get the RSA private key.  This key will decrypt
            // a symmetric key that was embedded in the XML document.
            RSACryptoServiceProvider cryptoServiceProvider = this.GetCryptoServiceProvider(false);
            document.PreserveWhitespace = true;
            document.LoadXml(encryptedNode.OuterXml);
            var xml = new EncryptedXml(document);

            // Add a key-name mapping.This method can only decrypt documents
            // that present the specified key name.
            xml.AddKeyNameMapping("rsaKey", cryptoServiceProvider);
            xml.DecryptDocument();
            cryptoServiceProvider.Clear();
            return document.DocumentElement ?? throw new InvalidOperationException();
        }

        /// <summary>
        /// Encrypts the XML node passed to it.
        /// </summary>
        /// <param name="node">The XmlNode to encrypt.</param>
        /// <returns></returns>
        public override XmlNode Encrypt(XmlNode node)
        {
            // Get the RSA public key to encrypt the node. This key will encrypt
            // a symmetric key, which will then be encryped in the XML document.
            RSACryptoServiceProvider cryptoServiceProvider = this.GetCryptoServiceProvider(true);

            // Create an XML document and load the node to be encrypted in it.
            XmlDocument document = new XmlDocument
            {
                PreserveWhitespace = true
            };
            document.LoadXml("<Data>" + node.OuterXml + "</Data>");

            // Create a new instance of the EncryptedXml class
            // and use it to encrypt the XmlElement with the
            // a new random symmetric key.
            EncryptedXml xml = new EncryptedXml(document);
            XmlElement documentElement = document.DocumentElement;
            SymmetricAlgorithm symmetricAlgorithm = new RijndaelManaged();

            // Create a 192 bit random key.
            symmetricAlgorithm.Key = this.GetRandomKey();
            symmetricAlgorithm.GenerateIV();
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] buffer = xml.EncryptData(documentElement ?? throw new InvalidOperationException(), symmetricAlgorithm, true);

            // Construct an EncryptedData object and populate
            // it with the encryption information.
            EncryptedData encryptedData = new EncryptedData();
            encryptedData.Type = EncryptedXml.XmlEncElementUrl;

            // Create an EncryptionMethod element so that the
            // receiver knows which algorithm to use for decryption.
            encryptedData.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES192Url);
            encryptedData.KeyInfo = new KeyInfo();

            // Encrypt the session key and add it to an EncryptedKey element.
            EncryptedKey encryptedKey = new EncryptedKey
            {
                EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url),
                KeyInfo = new KeyInfo(),
                CipherData = new CipherData
                {
                    CipherValue = EncryptedXml.EncryptKey(symmetricAlgorithm.Key, cryptoServiceProvider, false)
                }
            };
            KeyInfoName clause = new KeyInfoName
            {
                Value = "rsaKey"
            };

            // Add the encrypted key to the EncryptedData object.
            encryptedKey.KeyInfo.AddClause(clause);
            KeyInfoEncryptedKey key2 = new KeyInfoEncryptedKey(encryptedKey);
            encryptedData.KeyInfo.AddClause(key2);
            encryptedData.CipherData = new CipherData();
            encryptedData.CipherData.CipherValue = buffer;

            // Replace the element from the original XmlDocument
            // object with the EncryptedData element.
            EncryptedXml.ReplaceElement(documentElement, encryptedData, true);
            foreach (XmlNode node2 in document.ChildNodes)
            {
                if (node2.NodeType == XmlNodeType.Element)
                {
                    foreach (XmlNode node3 in node2.ChildNodes)
                    {
                        if (node3.NodeType == XmlNodeType.Element)
                        {
                            return node3;
                        }
                    }
                }
            }
            return null;
        }

        private byte[] GetRandomKey()
        {
            byte[] data = new byte[0x18];
            new RNGCryptoServiceProvider().GetBytes(data);
            return data;
        }

        /// <summary>
        /// Get either the public key for encrypting configuration sections or the private key to decrypt them.
        /// </summary>
        /// <param name="IsEncryption"></param>
        /// <returns></returns>
        private RSACryptoServiceProvider GetCryptoServiceProvider(bool IsEncryption)
        {
            RSACryptoServiceProvider provider;
            X509Certificate2 cert = GetCertificate(this.thumbprint);
            if (IsEncryption)
            {
                provider = (RSACryptoServiceProvider)cert.PublicKey.Key;
            }
            else
            {
                provider = (RSACryptoServiceProvider)cert.PrivateKey;
            }
            return provider;
        }

        /// <summary>
        /// Get certificate from the Local Machine store, based on the given thumbprint
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        public X509Certificate2 GetCertificate(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                X509Certificate2 result = null;

                certificates = store.Certificates;

                foreach (X509Certificate2 cert in certificates)
                {
                    if (cert.Thumbprint.ToLower().CompareTo(thumbprint.ToLower()) == 0)
                    {
                        result = new X509Certificate2(cert);

                        return result;
                    }
                }

                if (result == null)
                {
                    throw new ApplicationException(string.Format("No certificate was found for thumbprint {0}", thumbprint));
                }

                return null;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }

                store.Close();
            }
        }

        private static void Sample1()
        {
            Console.WriteLine("\r\nExists Certs Name and Location");
            Console.WriteLine("------ ----- -------------------------");

            foreach (StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
            {
                foreach (StoreName storeName in (StoreName[])Enum.GetValues(typeof(StoreName)))
                {
                    X509Store store = new X509Store(storeName, storeLocation);

                    try
                    {
                        store.Open(OpenFlags.OpenExistingOnly);

                        Console.WriteLine("Yes    {0,4}  {1}, {2}", store.Certificates.Count, store.Name, store.Location);
                    }
                    catch (CryptographicException)
                    {
                        Console.WriteLine("No           {0}, {1}", store.Name, store.Location);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Sample2()
        {
            //Create new X509 store called teststore from the local certificate store.
            X509Store store = new X509Store("teststore", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            //Create certificates from certificate files.
            //You must put in a valid path to three certificates in the following constructors.
            X509Certificate2 certificate1 = new X509Certificate2("c:\\mycerts\\*****.cer");
            X509Certificate2 certificate2 = new X509Certificate2("c:\\mycerts\\*****.cer");
            X509Certificate2 certificate5 = new X509Certificate2("c:\\mycerts\\*****.cer");

            //Create a collection and add two of the certificates.
            X509Certificate2Collection collection = new X509Certificate2Collection
            {
                certificate2,
                certificate5
            };

            //Add certificates to the store.
            store.Add(certificate1);
            store.AddRange(collection);

            X509Certificate2Collection storecollection = store.Certificates;
            Console.WriteLine("Store name: {0}", store.Name);
            Console.WriteLine("Store location: {0}", store.Location);
            foreach (X509Certificate2 x509 in storecollection)
            {
                Console.WriteLine("certificate name: {0}", x509.Subject);
            }

            //Remove a certificate.
            store.Remove(certificate1);
            X509Certificate2Collection storecollection2 = store.Certificates;
            Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine);
            foreach (X509Certificate2 x509 in storecollection2)
            {
                Console.WriteLine("certificate name: {0}", x509.Subject);
            }

            //Remove a range of certificates.
            store.RemoveRange(collection);
            X509Certificate2Collection storecollection3 = store.Certificates;
            Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine);
            if (storecollection3.Count == 0)
            {
                Console.WriteLine("Store contains no certificates.");
            }
            else
            {
                foreach (X509Certificate2 x509 in storecollection3)
                {
                    Console.WriteLine("certificate name: {0}", x509.Subject);
                }
            }

            //Close the store.
            store.Close();
        }
    }
}