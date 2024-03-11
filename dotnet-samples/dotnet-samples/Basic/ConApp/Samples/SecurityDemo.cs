using System;
using System.Security;
using System.Security.Cryptography;

namespace ConApp
{
    public class SecurityDemo
    {
        public static void DSADemo()
        {
            // Create a digital signature based on RSA encryption.
            SignatureDescription rsaSignature = CreateRSAPKCS1Signature();
            ShowProperties(rsaSignature);

            // Create a digital signature based on DSA encryption.
            SignatureDescription dsaSignature = CreateDSASignature();
            ShowProperties(dsaSignature);

            // Create a HashAlgorithm using the digest algorithm of the signature.
            HashAlgorithm hashAlgorithm = dsaSignature.CreateDigest();
            Console.WriteLine("\nHash algorithm for the DigestAlgorithm property:" + " " + hashAlgorithm.ToString());

            // Create an AsymmetricSignatureFormatter instance using the DSA key.
            DSA dsa = DSA.Create();
            AsymmetricSignatureFormatter asymmetricFormatter = CreateDSAFormatter(dsa);

            // Create an AsymmetricSignatureDeformatter instance using the
            // DSA key.
            AsymmetricSignatureDeformatter asymmetricDeformatter = CreateDSADeformatter(dsa);

            Console.WriteLine("This sample completed successfully; " + "press Enter to exit.");
            Console.ReadLine();
        }

        public static SignatureDescription CreateRSAPKCS1Signature()
        {
            SignatureDescription signatureDescription = new SignatureDescription();

            // Set the key algorithm property for RSA encryption.
            signatureDescription.KeyAlgorithm = "System.Security.Cryptography.RSACryptoServiceProvider";

            // Set the digest algorithm for RSA encryption using the
            // SHA1 provider.
            signatureDescription.DigestAlgorithm = "System.Security.Cryptography.SHA1CryptoServiceProvider";

            // Set the formatter algorithm with the RSAPKCS1 formatter.
            signatureDescription.FormatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureFormatter";

            // Set the formatter algorithm with the RSAPKCS1 deformatter.
            signatureDescription.DeformatterAlgorithm = "System.Security.Cryptography.RSAPKCS1SignatureDeformatter";

            return signatureDescription;
        }

        public static SignatureDescription CreateDSASignature()
        {
            SecurityElement securityElement = new SecurityElement("DSASignature");

            // Create new security elements for the four algorithms.
            securityElement.AddChild(new SecurityElement("Key", "System.Security.Cryptography.DSACryptoServiceProvider"));
            securityElement.AddChild(new SecurityElement("Digest", "System.Security.Cryptography.SHA1CryptoServiceProvider"));
            securityElement.AddChild(new SecurityElement("Formatter", "System.Security.Cryptography.DSASignatureFormatter"));
            securityElement.AddChild(new SecurityElement("Deformatter", "System.Security.Cryptography.DSASignatureDeformatter"));

            SignatureDescription signatureDescription = new SignatureDescription(securityElement);

            return signatureDescription;
        }

        // Create a signature formatter for DSA encryption.
        public static AsymmetricSignatureFormatter CreateDSAFormatter(DSA dsa)
        {
            // Create a DSA signature formatter for encryption.
            SignatureDescription signatureDescription = new SignatureDescription();
            signatureDescription.FormatterAlgorithm = "System.Security.Cryptography.DSASignatureFormatter";

            AsymmetricSignatureFormatter asymmetricFormatter = signatureDescription.CreateFormatter(dsa);

            Console.WriteLine("\nCreated formatter : " + asymmetricFormatter.ToString());
            return asymmetricFormatter;
        }

        // Create a signature deformatter for DSA decryption.
        public static AsymmetricSignatureDeformatter CreateDSADeformatter(DSA dsa)
        {
            // Create a DSA signature deformatter to verify the signature.
            SignatureDescription signatureDescription = new SignatureDescription();
            signatureDescription.DeformatterAlgorithm = "System.Security.Cryptography.DSASignatureDeformatter";

            AsymmetricSignatureDeformatter asymmetricDeformatter = signatureDescription.CreateDeformatter(dsa);

            Console.WriteLine("\nCreated deformatter : " + asymmetricDeformatter.ToString());
            return asymmetricDeformatter;
        }

        // Display to the console the properties of the specified
        // SignatureDescription.
        public static void ShowProperties(SignatureDescription signatureDescription)
        {
            // Retrieve the class path for the specified SignatureDescription.
            string classDescription = signatureDescription.ToString();

            string deformatterAlgorithm = signatureDescription.DeformatterAlgorithm;
            string formatterAlgorithm = signatureDescription.FormatterAlgorithm;
            string digestAlgorithm = signatureDescription.DigestAlgorithm;
            string keyAlgorithm = signatureDescription.KeyAlgorithm;

            Console.WriteLine("\n** " + classDescription + " **");
            Console.WriteLine("DeformatterAlgorithm : " + deformatterAlgorithm);
            Console.WriteLine("FormatterAlgorithm : " + formatterAlgorithm);
            Console.WriteLine("DigestAlgorithm : " + digestAlgorithm);
            Console.WriteLine("KeyAlgorithm : " + keyAlgorithm);
        }
    }
}