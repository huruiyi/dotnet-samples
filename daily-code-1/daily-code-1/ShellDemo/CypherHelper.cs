using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShellDemo
{
    internal class CypherHelper
    {
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="word">被加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>加密后字符串</returns>
        public static string Encrypt(string word, string key)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(key, "^[a-zA-Z]*$"))
            {
                throw new Exception("key 必须由字母组成");
            }
            key = key.ToLower();
            //逐个字符加密字符串
            char[] s = word.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char a = word[i];
                char b = key[i % key.Length];
                s[i] = EncryptChar(a, b);
            }
            return new string(s);
        }

        /// <summary>
        /// 加密单个字符
        /// </summary>
        /// <param name="a">被加密字符</param>
        /// <param name="b">密钥</param>
        /// <returns>加密后字符</returns>
        private static char EncryptChar(char a, char b)
        {
            int c = a + b - 'a';
            if (a >= '0' && a <= '9') //字符0-9的转换
            {
                while (c > '9') c -= 10;
            }
            else if (a >= 'a' && a <= 'z') //字符a-z的转换
            {
                while (c > 'z') c -= 26;
            }
            else if (a >= 'A' && a <= 'Z') //字符A-Z的转换
            {
                while (c > 'Z') c -= 26;
            }
            else return a; //不再上面的范围内，不转换直接返回
            return (char)c; //返回转换后的字符
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="word">被解密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>解密后字符串</returns>
        public static string Decrypt(string word, string key)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(key, "^[a-zA-Z]*$"))
            {
                throw new Exception("key 必须由字母组成");
            }
            key = key.ToLower();
            //逐个字符解密字符串
            char[] s = word.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char a = word[i];
                char b = key[i % key.Length];
                s[i] = DecryptChar(a, b);
            }
            return new string(s);
        }

        /// <summary>
        /// 解密单个字符
        /// </summary>
        /// <param name="a">被解密字符</param>
        /// <param name="b">密钥</param>
        /// <returns>解密后字符</returns>
        private static char DecryptChar(char a, char b)
        {
            int c = a - b + 'a';
            if (a >= '0' && a <= '9') //字符0-9的转换
            {
                while (c < '0') c += 10;
            }
            else if (a >= 'a' && a <= 'z') //字符a-z的转换
            {
                while (c < 'a') c += 26;
            }
            else if (a >= 'A' && a <= 'Z') //字符A-Z的转换
            {
                while (c < 'A') c += 26;
            }
            else return a; //不再上面的范围内，不转换直接返回
            return (char)c; //返回转换后的字符
        }

        private static string encryptKey = "Oyea";

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();  //实例化加/解密类对象
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥
            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串
            MemoryStream MStream = new MemoryStream();//实例化内存流对象
                                                      //使用内存流实例化加密流对象
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);  //向加密流中写入数据
            CStream.FlushFinalBlock();             //释放加密流
            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <returns>返回解密后的字符串</returns>
        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();  //实例化加/解密类对象
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串
            MemoryStream MStream = new MemoryStream();//实例化内存流对象
                                                      //使用内存流实例化解密流对象
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);      //向解密流中写入数据
            CStream.FlushFinalBlock();              //释放解密流
            return Encoding.Unicode.GetString(MStream.ToArray());      //返回解密后的字符串
        }
    }
}

/*
//1.加密
string a = CypherHelper.Encrypt("TsybiusLee1234", "Galatea");
Console.WriteLine("加密：TsybiusLee1234 → " + a);
//2.解密
string b = CypherHelper.Decrypt(a, "Galatea");
Console.WriteLine("解密：" + a + " → " + b);
Console.ReadLine();
*/