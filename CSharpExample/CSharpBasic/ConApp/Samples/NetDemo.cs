using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace ConApp
{
    public class MyEmail
    {
        private MailMessage mMailMessage;   //主要处理发送邮件的内容（如：收发人地址、标题、主体、图片等等）
        private SmtpClient mSmtpClient; //主要处理用smtp方式发送此邮件的配置信息（如：邮件服务器、发送端口号、验证方式等等）
        private int mSenderPort;   //发送邮件所用的端口号（htmp协议默认为25）
        private string mSenderServerHost;    //发件箱的邮件服务器地址（IP形式或字符串形式均可）
        private string mSenderPassword;    //发件箱的密码
        private string mSenderUsername;   //发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）
        private bool mEnableSsl;    //是否对邮件内容进行socket层加密传输
        private bool mEnablePwdAuthentication;  //是否对发件人邮箱进行密码验证

        ///<summary>
        /// 构造函数
        ///</summary>
        ///<param name="server">发件箱的邮件服务器地址</param>
        ///<param name="toMail">收件人地址（可以是多个收件人，程序中是以“;"进行区分的）</param>
        ///<param name="fromMail">发件人地址</param>
        ///<param name="subject">邮件标题</param>
        ///<param name="emailBody">邮件内容（可以以html格式进行设计）</param>
        ///<param name="username">发件箱的用户名（即@符号前面的字符串，例如：hello@163.com，用户名为：hello）</param>
        ///<param name="password">发件人邮箱密码</param>
        ///<param name="port">发送邮件所用的端口号（htmp协议默认为25）</param>
        ///<param name="sslEnable">true表示对邮件内容进行socket层加密传输，false表示不加密</param>
        ///<param name="pwdCheckEnable">true表示对发件人邮箱进行密码验证，false表示不对发件人邮箱进行密码验证</param>
        public MyEmail(string server, string toMail, string fromMail, string subject, string emailBody, string username, string password, string port, bool sslEnable, bool pwdCheckEnable)
        {
            try
            {
                mMailMessage = new MailMessage();
                mMailMessage.To.Add(toMail);
                mMailMessage.From = new MailAddress(fromMail);
                mMailMessage.Subject = subject;
                mMailMessage.Body = emailBody;
                mMailMessage.IsBodyHtml = true;
                mMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mMailMessage.Priority = MailPriority.Normal;
                this.mSenderServerHost = server;
                this.mSenderUsername = username;
                this.mSenderPassword = password;
                this.mSenderPort = Convert.ToInt32(port);
                this.mEnableSsl = sslEnable;
                this.mEnablePwdAuthentication = pwdCheckEnable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        ///<summary>
        /// 添加附件
        ///</summary>
        ///<param name="attachmentsPath">附件的路径集合，以分号分隔</param>
        public void AddAttachments(string attachmentsPath)
        {
            try
            {
                string[] path = attachmentsPath.Split(';'); //以什么符号分隔可以自定义
                Attachment data;
                ContentDisposition disposition;
                for (int i = 0; i < path.Length; i++)
                {
                    data = new Attachment(path[i], MediaTypeNames.Application.Octet);
                    disposition = data.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(path[i]);
                    disposition.ModificationDate = File.GetLastWriteTime(path[i]);
                    disposition.ReadDate = File.GetLastAccessTime(path[i]);
                    mMailMessage.Attachments.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        ///<summary>
        /// 邮件的发送
        ///</summary>
        public void Send()
        {
            try
            {
                if (mMailMessage != null)
                {
                    mSmtpClient = new SmtpClient();
                    mSmtpClient.Host = this.mSenderServerHost;
                    mSmtpClient.Port = this.mSenderPort;
                    mSmtpClient.UseDefaultCredentials = false;
                    mSmtpClient.EnableSsl = this.mEnableSsl;
                    if (this.mEnablePwdAuthentication)
                    {
                        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(this.mSenderUsername, this.mSenderPassword);
                        mSmtpClient.Credentials = nc.GetCredential(mSmtpClient.Host, mSmtpClient.Port, "NTLM");
                    }
                    else
                    {
                        mSmtpClient.Credentials = new System.Net.NetworkCredential(this.mSenderUsername, this.mSenderPassword);
                    }
                    mSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    mSmtpClient.Send(mMailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

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

        public static void SendEmailDemo1()
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

        public static void SendEmailDemo2()
        {
            string senderServerIp = "123.125.50.133";
            string toMailAddress = "761516331@qq.com";
            string fromMailAddress = "pei669@163.com";
            string subjectInfo = "Test sending e_mail";
            string bodyInfo = "Hello Eric, This is my first testing e_mail";
            string mailUsername = "pei669@163.com";
            string mailPassword = "******"; //发送邮箱的密码（）
            string mailPort = "25";
            string attachPath = "E:\\123123.txt";//这句代码的意思是：在E盘下有123123.txt这个文件，然后发这个文件

            MyEmail email = new MyEmail(senderServerIp, toMailAddress, fromMailAddress, subjectInfo, bodyInfo, mailUsername, mailPassword, mailPort, false, false);
            email.AddAttachments(attachPath);
            email.Send();
            Console.WriteLine("邮件发送成功！");
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

        public static bool AutoUpdate()
        {
            return true;
        }

        public static void AutoUpdateSupplierMcScoreAsyncCallback(IAsyncResult ar)
        {
            Func<bool> pc = (Func<bool>)ar.AsyncState;
            var endInvoke = pc.EndInvoke(ar);
            if (endInvoke)
            {
            }
            else
            {
                //执行异常
            }
        }

        public static void AsyncResultDemo()
        {
            Func<bool> asncRun = AutoUpdate;
            asncRun.BeginInvoke(AutoUpdateSupplierMcScoreAsyncCallback, asncRun);
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
                Console.Write("运行中。。。。。");

                Console.ReadKey();
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

        public static void TaskHttp()
        {
            Testing("http://localhost:802/Task/SyncAction", 10);
            Testing("http://localhost:802/Task/AsyncAction", 10);
        }

        private static void Testing(string url, int iteration)
        {
            List<Task> taskList = new List<Task>();

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iteration; i++)
            {
                var task = new Task(() => { Get(url); });
                task.Start();
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "application/json";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader dataStream = new StreamReader(response.GetResponseStream()))
                {
                    var responseStr = dataStream.ReadToEnd();
                    return responseStr;
                }
            }
        }
    }
}