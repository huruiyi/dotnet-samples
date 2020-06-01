using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class ServerInfoController : Controller
    {
        // GET: ServerInfo
        public ActionResult Index()
        {
            string serverOs = Environment.OSVersion.ToString();                                                                //操作系统：
            string cpuSum = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");         //CPU个数：
            string cpuType = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");             //CPU类型：
            string serverSoft = Request.ServerVariables["SERVER_SOFTWARE"];                     //信息服务软件：
            string machineName = Server.MachineName;                                                        //服务器名
            string serverName = Request.ServerVariables["SERVER_NAME"];                          //服务器域名
            string serverPath = Request.ServerVariables["APPL_PHYSICAL_PATH"];                //虚拟服务绝对路径
            string serverNet = ".NET CLR " + Environment.Version;                         //DotNET 版本
            string serverArea = (DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString(CultureInfo.InvariantCulture)
                : (DateTime.Now - DateTime.UtcNow).TotalHours.ToString(CultureInfo.InvariantCulture);    //服务器时区
            string serverTimeOut = Server.ScriptTimeout.ToString();                             //脚本超时时间
            string serverStart = ((Double)System.Environment.TickCount / 3600000).ToString("N2");   //开机运行时长

            string serverSessions = Session.Contents.Count.ToString();

            string windir = Environment.GetEnvironmentVariable("windir");
            string include = Environment.GetEnvironmentVariable("INCLUDE");
            string tem = Environment.GetEnvironmentVariable("TMP");
            string temp = Environment.GetEnvironmentVariable("TEMP");
            string path = Environment.GetEnvironmentVariable("Path");

            string str1 = Process.GetCurrentProcess().MainModule.FileName;//可获得当前执行的exe的文件名。
            string str2 = Environment.CurrentDirectory;//获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。(备注:按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠（如“C:\”）。如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径[如“C:\mySubDirectory”])。
            string str3 = Directory.GetCurrentDirectory(); //获取应用程序的当前工作目录。
            string str4 = AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集。
            string str5 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的

            string Label1 = "服务器名称：" + Server.MachineName;//服务器名称

            string Label2 = "服务器IP地址：" + Request.ServerVariables["LOCAL_ADDR"];//服务器IP地址
            string Label3 = "服务器域名：" + Request.ServerVariables["SERVER_NAME"];//服务器域名
            string Label4 = ".NET解释引擎版本：" + ".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;//.NET解释引擎版本
            string Label5 = "服务器操作系统版本：" + Environment.OSVersion.ToString();//服务器操作系统版本
            string Label6 = "服务器IIS版本：" + Request.ServerVariables["SERVER_SOFTWARE"];//服务器IIS版本
            string Label7 = "HTTP访问端口：" + Request.ServerVariables["SERVER_PORT"];//HTTP访问端口
            string Label8 = "虚拟目录的绝对路径：" + Request.ServerVariables["APPL_RHYSICAL_PATH"];//虚拟目录的绝对路径
            string Label9 = "执行文件的绝对路径：" + Request.ServerVariables["PATH_TRANSLATED"];//执行文件的绝对路径
            string Label10 = "虚拟目录Session总数：" + Session.Contents.Count.ToString();//虚拟目录Session总数
            string Label12 = "域名主机：" + Request.ServerVariables["HTTP_HOST"];//域名主机
            string Label13 = "服务器区域语言：" + Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];//服务器区域语言
            string Label14 = "用户信息：" + Request.ServerVariables["HTTP_USER_AGENT"];
            string Label15 = "CPU个数：" + Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");//CPU个数
            string Label16 = "CPU类型：" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");//CPU类型

            return View();
        }
    }
}