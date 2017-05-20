using Microsoft.Web.Administration;
using System;
using System.Linq;
using System.Net;

namespace Net.Tools.Web
{
    public class IISHelper
    {
        public static void AddDomianTmSuite(string portalAlias, string siteName)
        {
            using (ServerManager iis = new ServerManager())
            {
                Site site = iis.Sites[siteName];
                if (site != null)
                {
                    Binding binding = GetBinding(site.Bindings, "*:80:" + portalAlias);
                    if (binding == null)
                    {
                        AddBinding(site.Bindings, "*:80:" + portalAlias);
                    }
                    iis.CommitChanges();
                }
            }
        }

        public static void DeleteDomainTmSuite(string portalAlias, string siteName)
        {
            using (ServerManager iis = new ServerManager())
            {
                Site site = iis.Sites[siteName];
                if (site != null)
                {
                    Binding binding = GetBinding(site.Bindings, "*:80:" + portalAlias);
                    if (binding != null)
                    {
                        site.Bindings.Remove(binding);
                    }
                    iis.CommitChanges();
                }
            }
        }

        public static Binding GetBinding(BindingCollection bindings, string BindingInformation)
        {
            return bindings.FirstOrDefault(binding => binding.BindingInformation.ToLower() == BindingInformation.ToLower());
        }

        public static void AddBinding(BindingCollection bindings, string BindingInformation)
        {
            Binding binding2 = bindings.CreateElement();
            binding2.BindingInformation = BindingInformation;
            binding2.Protocol = @"http";
            bindings.Add(binding2);
        }

        public static void ShowSites()
        {
            ServerManager manager = new ServerManager();
            foreach (Site item in manager.Sites)
            {
                Console.WriteLine("网站:{0}\t\t{1}", item.Name, item.LogFile.Directory);
                foreach (var app in item.Applications)
                {
                    Console.WriteLine("\t应用:{0}", app.Path);
                }

                foreach (var binding in item.Bindings)
                {
                    IPEndPoint ep = binding.EndPoint;
                    Console.WriteLine(binding.EndPoint.Port);
                }
            }
        }

        public static void AddApplicationPool(string appPoolName)
        {
            ServerManager manager = new ServerManager();
            ApplicationPool myAppPool = manager.ApplicationPools.Add(appPoolName);
            myAppPool.AutoStart = true;
            myAppPool.Cpu.Action = ProcessorAction.KillW3wp;
            myAppPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
            myAppPool.ManagedRuntimeVersion = "V4.0";
            myAppPool.ProcessModel.IdentityType = ProcessModelIdentityType.NetworkService;
            myAppPool.ProcessModel.IdleTimeout = TimeSpan.FromMinutes(2);
            myAppPool.ProcessModel.MaxProcesses = 1;
            manager.CommitChanges();
        }

        public static void AddSite(string siteName, string sitePoolName, string phyPath)
        {
            ServerManager serverManager = new ServerManager();
            serverManager.Sites.Add(siteName, @"http", "10.101.18.27:8091:", phyPath);
            serverManager.Sites[siteName].ServerAutoStart = true;
            serverManager.ApplicationPools.Remove(serverManager.ApplicationPools[sitePoolName]);
            ApplicationPool pool = serverManager.ApplicationPools.Add(sitePoolName);
            pool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
            pool.ManagedRuntimeVersion = "v4.0";
            serverManager.Sites[siteName].ApplicationDefaults.ApplicationPoolName = pool.Name;
            serverManager.CommitChanges();
        }

        public static bool CreateVdir(string siteName, string vdir, string phydir)
        {
            ServerManager manager = new ServerManager();
            Site mySite = manager.Sites[siteName];
            mySite.Applications.Add("/" + vdir, phydir);
            manager.CommitChanges();
            return true;
        }

        private static void DisplaySections()
        {
            // 获取IIS配置文件：applicationHost.config

            using (ServerManager manager = new ServerManager())
            {
                Configuration configuration = manager.GetAdministrationConfiguration();
                Configuration config = manager.GetApplicationHostConfiguration();

                ConfigurationSection log = config.GetSection("system.applicationHost/log");
                ConfigurationElement logFile = log.GetChildElement("centralW3CLogFile");
                string logPath = logFile.GetAttributeValue("directory").ToString();

                ConfigurationSection configPaths = config.GetSection("configPaths");
                foreach (ConfigurationElement configPath in configPaths.GetCollection())
                {
                    string path = (string)configPath["path"];
                    string locationPath = (string)configPath["locationPath"];

                    Console.WriteLine();

                    Console.WriteLine("Config Path:" + path);
                    if (!String.IsNullOrEmpty(locationPath))
                    {
                        Console.WriteLine("<locationPath path=" + locationPath + "'>");
                    }

                    foreach (ConfigurationElement section in configPath.GetCollection())
                    {
                        Console.WriteLine("  " + section["name"]);
                    }
                }
            }
        }

        private static void DisplaySectionsForSite(string siteName)
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration appHost = serverManager.GetWebConfiguration(siteName);
                ConfigurationSection configPaths = appHost.GetSection("configPaths");

                foreach (ConfigurationElement configPath in configPaths.GetCollection())
                {
                    string path = (string)configPath["path"];
                    string locationPath = (string)configPath["locationPath"];

                    Console.WriteLine();

                    Console.WriteLine("Config Path:" + path);
                    if (!String.IsNullOrEmpty(locationPath))
                    {
                        Console.WriteLine("<locationPath path=" + locationPath + "'>");
                    }

                    foreach (ConfigurationElement section in configPath.GetCollection())
                    {
                        Console.WriteLine(" " + section["name"]);
                    }
                }
            }
        }

        public static void AddVirtualDirectories(string siteName, string applicationName, string virName, string virPath)
        {
            using (ServerManager manager = new ServerManager())
            {
                Application app = manager.Sites[siteName].Applications["/" + applicationName];
                if (app != null)
                {
                    app.VirtualDirectories.Add("/" + virName, virPath);
                }
                manager.CommitChanges();
            }
        }
    }

    
}