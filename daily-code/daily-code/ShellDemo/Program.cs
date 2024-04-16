using Shell32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace ShellDemo
{
    internal class Program
    {
        public static IEnumerable<string> GetRecycleBinFilenames()
        {
            Shell shell = new Shell();
            Folder recycleBin = shell.NameSpace(10);

            foreach (FolderItem2 recfile in recycleBin.Items())
            {
                yield return recfile.Name;
            }
            Marshal.FinalReleaseComObject(shell);
        }

        public static void VerifyDataDemo()
        {
            //先要将字符串转换为字节数组，这与编码有关。
            string str = "this is a test.";
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            //选择签名方式，有RSA和DSA
            DSACryptoServiceProvider dsac = new DSACryptoServiceProvider();
            byte[] sign = dsac.SignData(bytes);
            //sign便是出来的签名结果。

            //下面是认证了
            DSACryptoServiceProvider dsac2 = new DSACryptoServiceProvider();
            dsac2.FromXmlString(dsac.ToXmlString(false));
            bool ver = dsac2.VerifyData(bytes, sign);
            if (ver)
            {
                Console.WriteLine("通过");
            }
            else
            {
                Console.WriteLine("不能通过");
            }
        }

        public static void GetTypeFromProgIDDemo()
        {
            try
            {
                // Use the ProgID localhost\HKEY_CLASSES_ROOT\DirControl.DirList.1.
                string theProgramID = "DirControl.DirList.1";
                // Use the server name localhost.
                string theServer = "localhost";
                // Make a call to the method to get the type information for the given ProgID.
                Type myType = Type.GetTypeFromProgID(theProgramID, theServer);
                if (myType == null)
                {
                    throw new Exception("Invalid ProgID or Server.");
                }
                Console.WriteLine("GUID for ProgID DirControl.DirList.1 is {0}.", myType.GUID);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred.");
                Console.WriteLine("Source: {0}", e.Source);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        private static void Main()
        {
            EncryptConnection.EncryptConnectionString(true);
            Console.ReadKey();
        }
    }
}