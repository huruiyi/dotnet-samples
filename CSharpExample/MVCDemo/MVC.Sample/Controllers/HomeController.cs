using MVC.Sample.Models;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Web.Mvc;

namespace MVC.Sample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonXml()
        {
            var model = new Person
            {
                FirstName = "Brad",
                LastName = "Wilson",
                Blog = "http://bradwilson.typepad.com"
            };
            return new XmlResult(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult HostInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>OSVersion</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.OSVersion);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>MachineName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.MachineName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>ProcessorCount</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.ProcessorCount);
            stringBuilder.Append("</tr>");
            string arg = ((double)Environment.TickCount / 3600000.0).ToString("N2");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>TickCount</td>");
            stringBuilder.AppendFormat("<td>{0}-{1}:小时</td>", Environment.TickCount, arg);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserDomainName:</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserDomainName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserInteractive</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserInteractive);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>UserName:</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Environment.UserName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Version</td>");
            stringBuilder.AppendFormat("<td>.NETCLR{0}</td>", Environment.Version);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>EnvironmentVariables.Key</td>");
            stringBuilder.AppendFormat("<td>EnvironmentVariables.Value</td>");
            stringBuilder.Append("</tr>");
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry dictionaryEntry in environmentVariables)
            {
                stringBuilder.Append("<trclass='active'>");
                stringBuilder.AppendFormat("<td>{0}</td>", dictionaryEntry.Key);
                stringBuilder.AppendFormat("<td>{0}</td>", dictionaryEntry.Value);
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.HeaServerVariablesders.Key</td>");
            stringBuilder.AppendFormat("<td>Request.ServerVariables.Key</td>");
            stringBuilder.Append("</tr>");
            NameValueCollection serverVariables = Request.ServerVariables;
            foreach (string text in serverVariables)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.AppendFormat("<td>{0}</td>", text);
                stringBuilder.AppendFormat("<td>{0}</td>", serverVariables[text]);
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Headers.Key</td>");
            stringBuilder.AppendFormat("<td>Request.Headers.Key</td>");
            stringBuilder.Append("</tr>");
            NameValueCollection headers = Request.Headers;
            foreach (string text2 in headers)
            {
                stringBuilder.Append("<tr>");
                stringBuilder.AppendFormat("<td>{0}</td>", text2);
                stringBuilder.AppendFormat("<td>{0}</td>", headers.Get(text2));
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.AbsolutePath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.AbsolutePath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.AbsoluteUri</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.AbsoluteUri);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.Authority</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.Authority);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.IsAbsoluteUri</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.IsAbsoluteUri);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.PathAndQuery</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.PathAndQuery);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.DnsSafeHost</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.DnsSafeHost);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.Host</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.Host);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.HostNameType</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.HostNameType);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.LocalPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.LocalPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Url.UserInfo</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Url.UserInfo);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.UserHostName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.UserHostName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.UserHostAddress</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.UserHostAddress);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.Path</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.Path);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PathInfo</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PathInfo);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PhysicalApplicationPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PhysicalApplicationPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.PhysicalPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.PhysicalPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.AppRelativeCurrentExecutionFilePath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.AppRelativeCurrentExecutionFilePath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Request.ApplicationPath</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Request.ApplicationPath);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Server.MachineName</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Server.MachineName);
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.AppendFormat("<td>Server.ScriptTimeout</td>");
            stringBuilder.AppendFormat("<td>{0}</td>", Server.ScriptTimeout);
            stringBuilder.Append("</tr>");

            MachineMessage model = new MachineMessage
            {
                Message = stringBuilder.ToString()
            };
            return View(model);
        }

        public ActionResult Ueditor()
        {
            return View();
        }

        public ActionResult Modal()
        {
            return View();
        }
    }
}