using Microsoft.Build.Evaluation;
using Microsoft.Build.Utilities;
using Net.Tools.MSBuild;
using Net.Tools.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace Net.Tools
{
    internal class Program
    {
        public static SecureString ReadString()
        {
            SecureString str = new SecureString();

            ConsoleKeyInfo nextChar = Console.ReadKey(true);

            while (nextChar.Key != ConsoleKey.Enter)
            {
                if (nextChar.Key == ConsoleKey.Backspace)
                {
                    if (str.Length > 0)
                    {
                        str.RemoveAt(str.Length - 1);

                        Console.Write(nextChar.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextChar.KeyChar);
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
                else
                {
                    str.AppendChar(nextChar.KeyChar);
                    Console.Write("*");
                }

                nextChar = Console.ReadKey(true);
            }

            str.MakeReadOnly();
            return str;
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Personb a = new Personb("小王", 20, '男', 12345);
            string appSecret = "123456";
            string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(a);

            string token = new MD5Helper().GetToken(appSecret, requestJson);

            //ShortcutHelper.CreateShortcut(Environment.SpecialFolder.Desktop.ToString());
            //ShortcutHelper.CreateShortcut(Environment.SpecialFolder.StartMenu.ToString());

            //Stream dataArray = null;
            //HashAlgorithm sha = new SHA1CryptoServiceProvider();
            //byte[] result = sha.ComputeHash(dataArray);

            RandomNumberGenerator rnd = RandomNumberGenerator.Create();

            byte[] input = new byte[20];
            rnd.GetBytes(input);

            Console.WriteLine("Input        : {0}\n", BytesToStr(input));
            PrintHash(input);
            PrintHashOneBlock(input);
            PrintHashMultiBlock(input, 1);
            PrintHashMultiBlock(input, 2);
            PrintHashMultiBlock(input, 3);
            PrintHashMultiBlock(input, 5);
            PrintHashMultiBlock(input, 10);
            PrintHashMultiBlock(input, 11);
            PrintHashMultiBlock(input, 19);
            PrintHashMultiBlock(input, 20);
            PrintHashMultiBlock(input, 21);

            Console.ReadKey();
        }

        public void ShellContextMenuTest()
        {
            ShellContextMenu scm = new ShellContextMenu();
            FileInfo[] files = new FileInfo[1];
            files[0] = new FileInfo(@"c:\windows\notepad.exe");
            scm.ShowContextMenu(files, Cursor.Position);
        }

        public static void PrimeHelperTest()
        {
            PrimeHelper prime = new PrimeHelper(2, 100);
            prime.GetEnumerator();
        }

        public static void BuildDemo()
        {
            #region BuildDemo1

            Microsoft.Build.Tasks.MSBuild msbuildTask = new Microsoft.Build.Tasks.MSBuild
            {
                BuildEngine = new MockEngine(),
                Projects = new Microsoft.Build.Framework.ITaskItem[]
                {
                    new TaskItem(@"E:\workspace\StudyRoad.Demo\StudyRoad.Demo\StudyRoad.Demo.csproj")
                }
            };

            msbuildTask.Execute();

            #endregion BuildDemo1

            #region BuildDemo2

            Project project = new Project(@"E:\workspace\StudyRoad.Demo\StudyRoad.Demo\StudyRoad.Demo.csproj");

            project.SetProperty("OutputPath", @"E:\workspace\StudyRoad.Demo\StudyRoad.Demo\bin");

            project.SetProperty("OutDir", @"E:\workspace\StudyRoad.Demo\StudyRoad.Demo\bin\_PublishedWebsites");

            project.SetProperty("Configuration", "Release");

            MockLogger logger = new MockLogger();

            project.Build(logger);

            #endregion BuildDemo2

            Console.Read();
        }

        public static string BytesToStr(byte[] bytes)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                str.AppendFormat("{0:X2}", bytes[i]);

            return str.ToString();
        }

        public static void PrintHash(byte[] input)
        {
            SHA256Managed sha = new SHA256Managed();
            Console.WriteLine("ComputeHash  : {0}", BytesToStr(sha.ComputeHash(input)));
        }

        public static void PrintHashOneBlock(byte[] input)
        {
            SHA256Managed sha = new SHA256Managed();
            sha.TransformFinalBlock(input, 0, input.Length);
            Console.WriteLine("FinalBlock   : {0}", BytesToStr(sha.Hash));
        }

        public static void PrintHashMultiBlock(byte[] input, int size)
        {
            SHA256Managed sha = new SHA256Managed();
            int offset = 0;

            while (input.Length - offset >= size)
                offset += sha.TransformBlock(input, offset, size, input, offset);

            sha.TransformFinalBlock(input, offset, input.Length - offset);
            Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash));
        }

        public string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            string encryptPassword = null;
            if (PasswordFormat == "SHA1")
            {
                encryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");
            }
            else if (PasswordFormat == "MD5")

            {
                encryptPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
            }
            return encryptPassword;
        }

        public static void ClipboardDemo()
        {
            Clipboard.SetDataObject("https://msdn.microsoft.com/zh-cn/library/system.windows.forms.clipboard.getdataobject(v=vs.110).aspx");

            string clipboardData = "";
            IDataObject iData = Clipboard.GetDataObject();

            if (iData.GetDataPresent(DataFormats.Text))
            {
                clipboardData = (string)iData.GetData(DataFormats.Text);
            }
            else
            {
                clipboardData = "Could not retrieve data off the clipboard.";
            }
            Console.WriteLine(clipboardData);
        }

        public static void ProcessStartInfoDemo()
        {
            string user = "";

            Console.Write("Enter the user name: ");
            user = Console.ReadLine();

            Console.Write("Enter the user's password: ");
            using (SecureString pword = ReadString())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.FileName = "notepad.exe";
                startInfo.UserName = user;
                startInfo.Password = pword;
                startInfo.UseShellExecute = false;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;

                    try
                    {
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n\nCould not start Notepad process.");
                        Console.WriteLine(ex);
                    }
                }
            }

            Console.WriteLine("\n\nMain method complete. Press Enter.");
            Console.ReadLine();
        }
    }

    public class EncryptionDecryption
    {
        public string Encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        public string Decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }

        private const string KEY_64 = "VavicApp";//注意了，是8个字符，64位

        private const string IV_64 = "VavicApp";

        public string Encode1(string data)
        {
            byte[] byKey = Encoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = Encoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public string Decode1(string data)
        {
            byte[] byKey = Encoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = Encoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        public string GetMD5(string s, string _input_charset)
        {
            //MD5不可逆加密    (32位加密)
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        public static string GetMd5Str(string ConvertString)
        {
            //(16位加密)

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        //加密文件
        private static void EncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);

            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }

            encStream.Close();
            fout.Close();
            fin.Close();
        }

        //解密文件
        private static void DecryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);

            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }

            encStream.Close();
            fout.Close();
            fin.Close();
        }
    }

    public class SecurityDES
    {
        public SecurityDES()
        {
        }

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /**//**//**//// <summary>

        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /**//**//**//// <summary>

        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }

    public class Personb
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public char Sex { get; set; }

        public string[] Hobbys { get; set; }

        public Dictionary<int, string> Attributes { get; set; }

        public int Age { get; set; }

        public int Sallary { get; set; }

        public Personb(string name, int age, char sex, int sallary)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Sallary = sallary;
        }
    }
}