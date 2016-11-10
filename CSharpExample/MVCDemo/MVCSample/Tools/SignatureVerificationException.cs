using System;

namespace MVCSample.Tools
{
    public class SignatureVerificationException : Exception
    {
        public SignatureVerificationException(string message)
            : base(message)
        {
        }
    }
}