using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Net.Tools.Security
{
    public class RSAHelper
    {
        /// <summary>
        /// 使用RSA实现加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <returns></returns>
        public static string RSAEncrypt(string data)
        {
            //C#默认只能使用[公钥]进行加密(想使用[公钥解密]可使用第三方组件BouncyCastle来实现)
            string publicKeyPath = "PublicKey.xml";
            string publicKey = File.ReadAllText(publicKeyPath);
            //创建RSA对象并载入[公钥]
            RSACryptoServiceProvider rsaPublic = new RSACryptoServiceProvider();
            rsaPublic.FromXmlString(publicKey);
            //对数据进行加密
            byte[] publicValue = rsaPublic.Encrypt(Encoding.UTF8.GetBytes(data), false);
            string publicStr = Convert.ToBase64String(publicValue);//使用Base64将byte转换为string
            return publicStr;
        }

        /// <summary>
        /// 使用RSA实现解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <returns></returns>
        public static string RSADecrypt(string data)
        {
            //C#默认只能使用[私钥]进行解密(想使用[私钥加密]可使用第三方组件BouncyCastle来实现)
            string privateKeyPath = "PrivateKey.xml";
            string privateKey = File.ReadAllText(privateKeyPath);
            //创建RSA对象并载入[私钥]
            RSACryptoServiceProvider rsaPrivate = new RSACryptoServiceProvider();
            rsaPrivate.FromXmlString(privateKey);
            //对数据进行解密
            byte[] privateValue = rsaPrivate.Decrypt(Convert.FromBase64String(data), false);//使用Base64将string转换为byte
            string privateStr = Encoding.UTF8.GetString(privateValue);
            return privateStr;
        }

        public static void CreateKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            using (StreamWriter writer = new StreamWriter("PrivateKey.xml"))
            {
                writer.WriteLine(rsa.ToXmlString(true));
            }

            using (StreamWriter writer = new StreamWriter("PublicKey.xml"))
            {
                writer.WriteLine(rsa.ToXmlString(false));
            }

            //string orginData = "abcdefghijklmopqrstuvwxyz";
            //string encryData = RSAEncrypt(orginData);
            //string decryData = RSADecrypt(encryData);

            //if (orginData == decryData)
            //{
            //    Console.WriteLine("解密成功");
            //}
            //else
            //{
            //    Console.WriteLine("解密失败");
            //}
        }
    }
}