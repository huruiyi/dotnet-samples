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

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">需签名的数据</param>
        /// <returns>签名后的值</returns>
        public string SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature)
        {
            byte[] rgbHash = Convert.FromBase64String(m_strHashbyteSignature);
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPrivate);
            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("MD5");
            byte[] inArray = formatter.CreateSignature(rgbHash);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="p_strHashbyteDeformatter">待验证的用户名</param>
        /// <param name="p_strDeformatterData">注册码</param>
        /// <returns>签名是否符合</returns>
        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            byte[] rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPublic);
            RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
            deformatter.SetHashAlgorithm("MD5");
            byte[] rgbSignature = Convert.FromBase64String(p_strDeformatterData);
            if (deformatter.VerifySignature(rgbHash, rgbSignature))
            {
                return true;
            }
            return false;
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

            string orginData = "abcdefghijklmopqrstuvwxyz";
            string encryData = RSAEncrypt(orginData);
            string decryData = RSADecrypt(encryData);

            if (orginData == decryData)
            {
                Console.WriteLine("解密成功");
            }
            else
            {
                Console.WriteLine("解密失败");
            }
        }
    }
}