using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConApp.Infrastructure
{
    public class RsaLicenseProvider : LicenseProvider
    {
        private static readonly RsaLicenseCache licenseCache = new RsaLicenseCache();

        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            RsaLicenseDataAttribute licDataAttr = GetRsaLicenseDataAttribute(type);
            if (licDataAttr == null)
                return null;
            var publicKey = licDataAttr.PublicKey;
            var attrGuid = licDataAttr.Guid;

            if (context.UsageMode == LicenseUsageMode.Designtime)
            {
                return new RsaLicense(type, "", attrGuid, DateTime.MaxValue);
            }

            RsaLicense license = licenseCache.GetLicense(type);
            if (license == null)
            {
                var keyValue = LoadLicenseData(type, "");

                DateTime expireDate = new DateTime();
                if (IsKeyValid(keyValue, publicKey, attrGuid, expireDate))
                {
                    license = new RsaLicense(type, keyValue, attrGuid, expireDate);
                    licenseCache.AddLicense(type, license);
                }
            }
            return license;
        }

        private RsaLicenseDataAttribute GetRsaLicenseDataAttribute(System.Type type)
        {
            object[] attrs = type.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr is RsaLicenseDataAttribute licDataAttr)
                    return licDataAttr;
            }
            return null;
        }

        protected string LoadLicenseData(Type type, String licFilePath)
        {
            string keyValue = "";
            string assemblyName = type.Assembly.GetName().Name;
            string relativePath = "~\\license\\" + assemblyName + ".lic";

            if (File.Exists(licFilePath))
            {
                FileStream file = new FileStream(licFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader rdr = new StreamReader(file);
                keyValue = rdr.ReadLine();
                rdr.Close();
                file.Close();
            }

            return keyValue;
        }

        protected bool IsKeyValid(string keyValue, string publicKey, string guid, DateTime expireDate)
        {
            if (keyValue.Length == 0)
                return false;

            char[] separators = { '#' };
            string[] values = keyValue.Split(separators);
            string signature = values[2];
            string licGuid = values[0];
            string expires = values[1];

            expireDate = Convert.ToDateTime(expires, DateTimeFormatInfo.InvariantInfo);

            return (licGuid == guid && expireDate > DateTime.Now && VerifyHash(publicKey, licGuid, expires, signature));
        }

        private bool VerifyHash(string publicKey, string guid, string expires, string signature)
        {
            byte[] clear = Encoding.ASCII.GetBytes(guid + "#" + expires + "#");
            SHA1Managed provSHA1 = new SHA1Managed();
            byte[] hash = provSHA1.ComputeHash(clear);

            CspParameters paramsCsp = new CspParameters { Flags = CspProviderFlags.UseMachineKeyStore };
            RSACryptoServiceProvider provRSA = new RSACryptoServiceProvider(paramsCsp);
            provRSA.FromXmlString(publicKey);

            byte[] sigBytes = Convert.FromBase64String(signature);
            bool result = provRSA.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), sigBytes);

            return result;
        }
    }
}