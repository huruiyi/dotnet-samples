using Microsoft.Web.Administration;
using System;

namespace ConApp
{
    public class IISDemo
    {
        public static void RemoteRecycle()
        {
            ServerManager manager = ServerManager.OpenRemote("184.12.15.157");
            ApplicationPoolCollection appPools = manager.ApplicationPools;
            foreach (var ap in appPools)
            {
                ap.Recycle();
            }
            /*
             * 回收注意事项：
                1.需要添加引用 C:\Windows\System32\inetsrv\Microsoft.Web.Administration.dll ,然后using Microsoft.Web.Administration;
                2.远程账号需要有管理员权限；
                3.远程主机的账号密码添加在服务器的凭据管理器中 (控制面板->凭据管理器) ，能成功使用mstsc 登录即可；
                4.远程主机需要关闭UAC！！ 因为这个问题卡了好几个礼拜才无意发现。
             */
        }

        public static void AddIsapiCgi()
        {
            //appcmd.exe set config -section:system.webServer/security/isapiCgiRestriction /+"[path='C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll',allowed='True',groupId='ContosoGroup',description='Contoso Extension']" /commit:apphost
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();
                ConfigurationSection isapiCgiRestrictionSection = config.GetSection("system.webServer/security/isapiCgiRestriction");
                ConfigurationElementCollection isapiCgiRestrictionCollection = isapiCgiRestrictionSection.GetCollection();

                ConfigurationElement addElement = isapiCgiRestrictionCollection.CreateElement("add");
                addElement["path"] = @"C:\Inetpub\www.contoso.com\wwwroot\isapi\custom.dll";
                addElement["allowed"] = true;
                addElement["groupId"] = @"ContosoGroup";
                addElement["description"] = @"Contoso Extension";
                isapiCgiRestrictionCollection.Add(addElement);
                serverManager.CommitChanges();
            }
        }

        public static void ConfigurationSectionDemo0()
        {
            const string siteName = "fairy.vip";

            using (ServerManager manager = new ServerManager())
            {
                //获得 IIS 站点信息。
                var site = manager.Sites[siteName];

                //获得站点根目录下的“Web.Config”文件配置信息。
                Configuration config = site.GetWebConfiguration();

                ConfigurationSection httpRedirectSection = config.GetSection("system.webServer/httpRedirect");
                /*
                 * 设置节点参数。
                 * enabled：是否启用。
                 * destination：目标 URL 或者文件。
                 * exactDestination：
                 * httpResponseStatus：
                 */
                httpRedirectSection["enabled"] = false;
                httpRedirectSection["destination"] = @"http://www.rapid.com/error/500$S$Q";
                httpRedirectSection["exactDestination"] = true;
                httpRedirectSection["httpResponseStatus"] = @"Temporary";

                //回收应用程序池。
                manager.ApplicationPools[siteName].Recycle();

                //提交。
                manager.CommitChanges();
            }
        }

        public static void ConfigurationSectionDemo1()
        {
            const string isAPI_partialPath = @"v4.0.30319\aspnet_isapi.dll";
            using (ServerManager manager = new ServerManager())
            {
                Configuration config = manager.GetApplicationHostConfiguration();

                ConfigurationSection section = config.GetSection("system.webServer/security/isapiCgiRestriction");

                foreach (ConfigurationElement item in section.GetCollection())
                {
                    if (item.Attributes.Count > 0 && item.Attributes["path"].Value != null && item.Attributes["path"].Value.ToString().EndsWith(isAPI_partialPath))
                    {
                        item.Attributes["allowed"].Value = true;
                    }
                }
                manager.CommitChanges();
            }
        }

        public static void AppSetingSet()
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetWebConfiguration("Default Web Site");
                ConfigurationSection appSettingsSection = config.GetSection("appSettings");
                ConfigurationElementCollection appSettingsCollection = appSettingsSection.GetCollection();
                ConfigurationElement addElement = appSettingsCollection.CreateElement("add");
                addElement["key"] = @"key1";
                addElement["value"] = @"value1";
                appSettingsCollection.Add(addElement);
                serverManager.CommitChanges();
            }
        }

        public static void GetIISRequest()
        {
            using (ServerManager manager = new ServerManager())
            {
                foreach (WorkerProcess w3wp in manager.WorkerProcesses)
                {
                    Console.WriteLine("W3WP()", w3wp.ProcessId);

                    foreach (Request request in w3wp.GetRequests(0))
                    {
                        Console.WriteLine(" - ,,", request.Url, request.ClientIPAddr, request.TimeElapsed, request.TimeInState);
                    }
                }
            }
        }
    }
}