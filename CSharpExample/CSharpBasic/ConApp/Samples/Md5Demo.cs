using System;
using System.Security.Cryptography;
using System.Text;

namespace ConApp
{
    public class Md5Demo
    {
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

        public static void Md5TokenDemo()
        {
            string timestamp = DateTime.Now.ToString();

            DateTime stamp;
            DateTime.TryParse(timestamp, out stamp);
            StringBuilder securityKey = new StringBuilder();

            securityKey.Append(GetMd5(stamp.ToString("yyyy"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("MM"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("dd"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("HH"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("mm"), "UTF-8"));
            securityKey.Append(GetMd5(stamp.ToString("ss"), "UTF-8"));

            string key = GetMd5(securityKey.ToString(), "UTF-8");

            Console.WriteLine(timestamp + "\t" + key);

            bool falg = CheckTokenDemo(timestamp, key);

            Console.WriteLine(falg ? "Success" : "Fail");
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
    }
}