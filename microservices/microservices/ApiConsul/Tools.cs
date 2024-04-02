using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace ApiConsul
{
    public class Tools
    {
        /// <summary>
        /// 产生一个介于minPort-maxPort之间的随机可用端口
        /// </summary>
        /// <param name="minPort"></param>
        /// <param name="maxPort"></param>
        /// <returns></returns>
        public static int GetRandAvailablePort(int minPort = 1024, int maxPort = 65535)
        {
            Random rand = new Random();
            while (true)
            {
                int port = rand.Next(minPort, maxPort);
                if (!IsPortInUsed(port))
                {
                    return port;
                }
            }
        }

        /// <summary>
        /// 判断port端口是否在使用中
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsPortInUsed(int port)
        {
            //using System.Net.NetworkInformation;
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipsTcp = ipGlobalProperties.GetActiveTcpListeners();
            if (ipsTcp.Any(p => p.Port == port))
            {
                return true;
            }

            IPEndPoint[] ipsUdp = ipGlobalProperties.GetActiveUdpListeners();
            if (ipsUdp.Any(p => p.Port == port))
            {
                return true;
            }
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            if (tcpConnInfoArray.Any(conn => conn.LocalEndPoint.Port == port))
            {
                return true;
            }
            return false;
        }

        ///<summary>
        /// Encrypts a file using Rijndael algorithm.  Returns true if successfully encrypts
        /// file, otherwise returns false.
        ///</summary>
        ///<param name="inputFile">Input file to encrypt</param>
        ///<param name="outputFile">Specified output encrypted file</param>
        ///<param name="key">Key used for encrypting the file</param>
        ///<param name="message">Information from the processing of encrypting a file</param>
        internal static bool EncryptFile(string inputFile, string outputFile, string key, out string message)
        {
            message = string.Empty;

            try
            {
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] keyBytes = ue.GetBytes(key);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged rmCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateEncryptor(keyBytes, keyBytes), CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

                // Release stream resources
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();

                fsIn.Dispose();
                cs.Dispose();
                fsCrypt.Dispose();

                return true;
            }
            catch (Exception e)
            {
                message = "ERROR: Encryption Failed - " + e.Message;
                return false;
            }
        }

        ///<summary>
        /// Decrypts a file using Rijndael algorithm.  Returns true if successfully decrypts
        /// file, otherwise returns false.
        ///</summary>
        ///<param name="inputFile">Input file to decrypt</param>
        ///<param name="outputFile">Specified output decrypted file</param>
        ///<param name="key">Key used for decrypting the file</param>
        ///<param name="message">Information from the processing of decrypting a file</param>
        internal static bool DecryptFile(string inputFile, string outputFile, string key, out string message)
        {
            message = string.Empty;

            try
            {
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] keyBytes = ue.GetBytes(key);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged rmCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt, rmCrypto.CreateDecryptor(keyBytes, keyBytes), CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                // Release stream resources
                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

                fsOut.Dispose();
                cs.Dispose();
                fsCrypt.Dispose();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Encryption Failed" + e.Message);
                return false;
            }
        }
    }
}