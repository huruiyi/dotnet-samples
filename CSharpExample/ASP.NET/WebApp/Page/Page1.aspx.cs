using System;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace WebApp.page
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(
                  "<br>版本号的主版本号：" + Request.Browser.ClrVersion.Major.ToString()
                  + "<br>版本号的次版本号：" + Request.Browser.ClrVersion.Minor.ToString()
                  + "<br>修定号的高16位：" + Request.Browser.ClrVersion.MajorRevision.ToString()
                  + "<br>修定号的低16位：" + Request.Browser.ClrVersion.MinorRevision.ToString()
                  + "<br>内部版本号部分值(Build)：" + Request.Browser.ClrVersion.Build.ToString()
                  + "<br>版本号的修定号部分的值(Revision)：" + Request.Browser.ClrVersion.Revision.ToString()
                  );
            string frameworkInstallDir = RuntimeEnvironment.GetRuntimeDirectory();

            string sysVersion = RuntimeEnvironment.GetSystemVersion();
            Evidence evidence = new Evidence();

            System.Security.HostSecurityManager hs = new System.Security.HostSecurityManager();

            Label1.Text = "Page=" + Request.QueryString["page"] + " PathInfo=" + Request.PathInfo;
        }
    }
}