using ConApp.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;

namespace ConApp.Samples
{
    public class NetDemo
    {
        #region 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

        public static void GetIPDemo()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation t in connections)
            {
                Console.Write(@"Local endpoint: {0} ", t.LocalEndPoint);
                Console.Write(@"Remote endpoint: {0} ", t.RemoteEndPoint);
                Console.WriteLine(@"{0}", t.State);
            }
        }

        #endregion 返回有关本地计算机上的 Internet 协议版本 4 (IPv4) 和 IPv6 传输控制协议 (TCP) 连接的信息。

        #region 下载相关

        public static void DownLoadDemo1()
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://img1.40017.cn/cn/s/yry/img/shouceV1.1.pdf");
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.pdf"));
        }

        public static void DownLoadDemo2()
        {
            HttpContext.Current.Response.WriteFile(@"H:\Workplace\WebApp\Image\示例图片abc12.jpg", true);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("示例图片abc12.jpg"));
        }

        #endregion 下载相关

        #region 发送邮件

        public static void SendEmail()
        {
            SmtpClient client = new SmtpClient("smtp.163.com", 25)
            {
                Credentials = new NetworkCredential("13372171750@163.com", "mail163")
            };
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("13372171750@163.com");
                msg.Subject = "Subject..........Greetings from Visual C# Recipes";
                msg.Body = "Body.................This is a message from Recipe 10-07 of";
                msg.Attachments.Add(new Attachment(@"ConsoleOutput.txt", "text/plain"));
                msg.Attachments.Add(new Attachment(@"ConApp.exe", "application/octet-stream"));
                msg.To.Add(new MailAddress("807776962@qq.com"));

                client.Send(msg);
            }
            Console.WriteLine("发送成功");
        }

        #endregion 发送邮件

        #region WebRequestDemo

        public static void WebRequestDemo()
        {
            WebRequest request = WebRequest.Create("http://www.baidu.com");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            Console.WriteLine("响应信息，内容长度：{0}，类型:{1},Uri:{2}", response.ContentLength, response.ContentType, response.ResponseUri);
            using (StreamReader sr = new StreamReader(stream))
            {
                Console.Write(sr.ReadToEnd());
            }
        }

        #endregion WebRequestDemo

        #region DirectorySecurity

        public static void DirectorySecurityDemo0()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ent0 = Dns.GetHostByAddress("10.101.42.77");
            IPHostEntry ent1 = Dns.GetHostEntry(hostEntry.HostName);
            IPHostEntry name = Dns.GetHostEntry("hry6464");
            string hostName = Dns.GetHostName();
            Console.Write("Provide full directory path: ");
            string mentionedDir = @"D:\";
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(mentionedDir);

                if (myDir.Exists)
                {
                    DirectorySecurity myDirSec = myDir.GetAccessControl();

                    foreach (FileSystemAccessRule fileRule in myDirSec.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        Console.WriteLine("{0} {1} {2} access for {3}", mentionedDir, fileRule.AccessControlType == AccessControlType.Allow ? "provides" : "denies", fileRule.FileSystemRights, fileRule.IdentityReference);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Incorrect directory provided!");
            }
        }

        public static void DirectorySecurityDemo1()
        {
            DirectorySecurity security = new DirectorySecurity();
            const string path = @"D:\temp";
            //设置权限的应用为文件夹本身、子文件夹及文件,所以需要InheritanceFlags.ContainerInherit 或 InheritanceFlags.ObjectInherit
            security.AddAccessRule(new FileSystemAccessRule("NETWORK SERVICE",
                FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow));
            security.AddAccessRule(new FileSystemAccessRule("Everyone",
                FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(path, security);
        }

        #endregion DirectorySecurity

        #region AsyncWaitHandle

        public static void AsyncWaitHandleDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");
            result.AsyncWaitHandle.WaitOne();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine("{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine("{0}", t.ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion AsyncWaitHandle

        #region AsyncOperationDemo

        public static void AsyncOperationDemo()
        {
            string[] args = { };

            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing your request for information...");
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion AsyncOperationDemo

        #region AsyncResultDemo

        public static void AsyncResultDemo()
        {
            Func<bool> asncRun = Extension.AutoUpdate;
            asncRun.BeginInvoke(Extension.AutoUpdateSupplierMcScoreAsyncCallback, asncRun);
        }

        #endregion AsyncResultDemo

        #region GetHostEntryDemo

        public static void GetHostEntryDemo()
        {
            string[] args = { };
            if (args.Length == 0 || args[0].Length == 0)
            {
                Console.WriteLine(@"You must specify the name of a host computer.");
                return;
            }
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine(@"Processing request for information...");

            while (result.IsCompleted != true)
            {
                Extension.UpdateUserInterface();
            }

            Console.WriteLine();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases");
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(t);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses");
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"An exception occurred while processing the request: {0}", e.Message);
            }
        }

        #endregion GetHostEntryDemo
    }
}