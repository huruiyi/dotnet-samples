using System;

namespace ConApp.Infrastructure
{
    /// <summary>
    /// Custom attribute for annotating licensing data on LiveSearch Lib controls
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false,
        AllowMultiple = false)]
    public sealed class RsaLicenseDataAttribute : Attribute
    {
        /// <summary>
        /// Constructor for RsaLicenseDataAttribute
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="publicKey"></param>
        public RsaLicenseDataAttribute(string guid, string publicKey)
        {
            this.Guid = guid;
            this.PublicKey = publicKey;
        }

        /// <summary>
        /// Guid representing specific build of server control type
        /// </summary>
        public string Guid { get; }

        /// <summary>
        /// Public key representing specific build of server control type
        /// </summary>
        public string PublicKey { get; }
    }
}