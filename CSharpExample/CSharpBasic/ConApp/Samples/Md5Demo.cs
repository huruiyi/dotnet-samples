using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ConApp
{
    public partial class Md5Demo
    {
        #region Demo1

        public static string GetMd5(string input, string charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(input));
            StringBuilder builder = new StringBuilder(32);
            foreach (byte t in data)
            {
                builder.Append(t.ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool CheckTokenDemo(string timestamp, string key)
        {
            if (string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(key))
            {
                return false;
            }

            DateTime stamp;
            try
            {
                stamp = DateTime.Parse(timestamp);
            }
            catch
            {
                return false;
            }

            TimeSpan timeSpan = new TimeSpan(0, 0, 8);
            if ((DateTime.Now - stamp) <= timeSpan)
            {
                StringBuilder s = new StringBuilder();

                s.Append(GetMd5(stamp.ToString("yyyy"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("MM"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("dd"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("HH"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("mm"), "UTF-8"));
                s.Append(GetMd5(stamp.ToString("ss"), "UTF-8"));

                if (key == GetMd5(s.ToString(), "UTF-8"))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Demo1()
        {
            string timestamp = DateTime.Now.ToString();

            DateTime.TryParse(timestamp, out var stamp);
            StringBuilder securityKey = new StringBuilder();

            securityKey.Append(GetMd5(stamp.ToString("yyyy"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("MM"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("dd"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("HH"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("mm"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("ss"), "UTF-8"));

            string key = GetMd5(securityKey.ToString(), "UTF-8");

            Console.Write(timestamp + "\t" + key);

            for (int i = 0; i < 100; i++)
            {
                bool falg = CheckTokenDemo(timestamp, key);
                Console.WriteLine(DateTime.Now.ToString() + "\t" + (falg ? "Success" : "Fail"));
                Thread.Sleep(700);
            }
        }

        #endregion Demo1

        #region Demo2

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            StringBuilder sBuilder = new StringBuilder();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        public static void Demo2()
        {
            string source = "Hello World!";

            using (MD5 md5Hash = MD5.Create())
            {
                string hashPwd = GetMd5Hash(md5Hash, source);
                Console.WriteLine("The MD5 hash of " + source + " is: " + hashPwd + ".");
                Console.WriteLine("Verifying the hash...");
                Console.WriteLine(VerifyMd5Hash(md5Hash, source, hashPwd)
                    ? "The hashes are the same."
                    : "The hashes are not same.");
            }
        }

        #endregion Demo2
    }
}