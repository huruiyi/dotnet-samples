using System;
using System.Collections;

namespace ConApp.Infrastructure
{
    internal class RsaLicenseCache
    {
        private Hashtable hash = new Hashtable();

        public void AddLicense(Type type, RsaLicense license)
        {
            hash.Add(type, license);
        }

        public RsaLicense GetLicense(Type type)
        {
            RsaLicense license = null;
            if (hash.ContainsKey(type))
                license = (RsaLicense)hash[type];
            return license;
        }

        public void RemoveLicense(Type type)
        {
            hash.Remove(type);
        }
    }
}