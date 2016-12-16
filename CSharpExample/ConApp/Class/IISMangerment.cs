using Microsoft.Web.Administration;
using System;

namespace ConApp.Class
{
    public class IISMangerment
    {
        /// <summary>
        /// 网站的默认名称(协议和应用程序池)
        /// </summary>
        public static void ServerManagerSites()
        {
            ServerManager manager = new ServerManager();
            foreach (Site s in manager.Sites)
            {
                ApplicationDefaults d = s.ApplicationDefaults;
                Console.WriteLine("Site: {0}", s.Name);
                Console.WriteLine("  |--Default Application Pool:  {0}", d.ApplicationPoolName);
                Console.WriteLine("  +--Default Protocols Enabled: {0}\r\n", d.EnabledProtocols);
            }
        }

        /// <summary>
        /// 网站下的站点获取与操作
        /// </summary>
        public static void ServerManagerMethods()
        {
            ServerManager iis = new ServerManager();
            foreach (Microsoft.Web.Administration.Site item in iis.Sites)
            {
                //item.Start();
                //item.Stop();
                foreach (ConfigurationMethod itemMethod in item.Methods)
                {
                    if (itemMethod.Name == "Stop")
                    {
                        ConfigurationMethodInstance methodInstance = itemMethod.CreateInstance();
                        methodInstance.Execute();
                    }
                    Console.WriteLine(itemMethod.Name);
                }

                Console.WriteLine("网站:{0},状态：{1} ", item.Name, item.State);
                foreach (Application app in item.Applications)
                {
                    Console.WriteLine("\t应用程序池:{0}", app.ApplicationPoolName);
                    Console.WriteLine("\t      应用:{0}", app.Path);
                    Console.WriteLine();
                }
            }
        }

        public static void CreateSite(string siteName, string bindingInfo, string physicalPath)
        {
            CreateSite(siteName, "http", bindingInfo, physicalPath, true, siteName + "Pool", ProcessModelIdentityType.NetworkService, null, null, ManagedPipelineMode.Integrated, null);
        }

        private static void CreateSite(string siteName, string protocol, string bindingInformation, string physicalPath,
            bool createAppPool, string appPoolName, ProcessModelIdentityType identityType, string appPoolUserName, string appPoolPassWord,
            ManagedPipelineMode appPoolPipelineMode, string managedRuntimeVersion)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Site site = mgr.Sites.Add(siteName, protocol, bindingInformation, physicalPath);

                // PROVISION APPPOOL IF NEEDED
                if (createAppPool)
                {
                    ApplicationPool pool = mgr.ApplicationPools.Add(appPoolName);
                    if (pool.ProcessModel.IdentityType != identityType)
                    {
                        pool.ProcessModel.IdentityType = identityType;
                    }
                    if (!string.IsNullOrEmpty(appPoolUserName))
                    {
                        pool.ProcessModel.UserName = appPoolUserName;
                        pool.ProcessModel.Password = appPoolPassWord;
                    }
                    if (appPoolPipelineMode != pool.ManagedPipelineMode)
                    {
                        pool.ManagedPipelineMode = appPoolPipelineMode;
                    }

                    site.Applications["/"].ApplicationPoolName = pool.Name;
                }

                mgr.CommitChanges();
            }
        }

        public static void DeleteSite(string siteName)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Site site = mgr.Sites[siteName];
                if (site != null)
                {
                    mgr.Sites.Remove(site);
                    mgr.CommitChanges();
                }
            }
        }

        /// <summary>
        ///  创建应用程序池
        /// </summary>
        /// <param name="appPoolName"></param>
        /// <param name="pipelineMode">模式(经典、继承)</param>
        /// <param name="version">名称（v4.0,v2.0）</param>
        public static void CreateAppPool(string appPoolName, ManagedPipelineMode pipelineMode, string version)
        {
            try
            {
                ServerManager serverManager = new ServerManager();
                serverManager.ApplicationPools.Add(appPoolName);
                ApplicationPool apppool = serverManager.ApplicationPools[appPoolName];
                apppool.ManagedPipelineMode = pipelineMode;
                serverManager.CommitChanges();
                apppool.ManagedRuntimeVersion = version;
                apppool.Recycle();
            }
            catch
            {
            }
        }

        public static void CreateVDir(string siteName, string vDirName, string physicalPath)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Site site = mgr.Sites[siteName];
                if (site == null)
                {
                    throw new ApplicationException(String.Format("Web site {0} does not exist", siteName));
                }
                site.Applications.Add("/" + vDirName, physicalPath);
                mgr.CommitChanges();
            }
        }

        public static bool CreateVdir(string vdir, string phydir)
        {
            ServerManager serverManager = new ServerManager();
            Site mySite = serverManager.Sites["Default Web Site"];
            mySite.Applications.Add("/" + vdir, phydir);
            serverManager.CommitChanges();
            return true;
        }

        public static void DeleteVDir(string siteName, string vDirName)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Site site = mgr.Sites[siteName];
                if (site != null)
                {
                    Application app = site.Applications["/" + vDirName];
                    if (app != null)
                    {
                        site.Applications.Remove(app);
                        mgr.CommitChanges();
                    }
                }
            }
        }

        public static void DeletePool(string appPoolName)
        {
            using (ServerManager mgr = new ServerManager())
            {
                ApplicationPool pool = mgr.ApplicationPools[appPoolName];
                if (pool != null)
                {
                    mgr.ApplicationPools.Remove(pool);
                    mgr.CommitChanges();
                }
            }
        }

        public static void AddDefaultDocument(string siteName, string defaultDocName)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Configuration cfg = mgr.GetWebConfiguration(siteName);
                ConfigurationSection defaultDocumentSection = cfg.GetSection("system.webServer/defaultDocument");
                ConfigurationElement filesElement = defaultDocumentSection.GetChildElement("files");
                ConfigurationElementCollection filesCollection = filesElement.GetCollection();

                foreach (ConfigurationElement elt in filesCollection)
                {
                    if (elt.Attributes["value"].Value.ToString() == defaultDocName)
                    {
                        return;
                    }
                }

                try
                {
                    ConfigurationElement docElement = filesCollection.CreateElement();
                    docElement.SetAttributeValue("value", defaultDocName);
                    filesCollection.Add(docElement);
                }
                catch (Exception) { }   //this will fail if existing

                mgr.CommitChanges();
            }
        }

        public static bool VerifyVirtualPathIsExist(string siteName, string path)
        {
            using (ServerManager mgr = new ServerManager())
            {
                Site site = mgr.Sites[siteName];
                if (site != null)
                {
                    foreach (Application app in site.Applications)
                    {
                        if (app.Path.ToUpper().Equals(path.ToUpper()))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool VerifyWebSiteIsExist(string siteName)
        {
            using (ServerManager mgr = new ServerManager())
            {
                for (int i = 0; i < mgr.Sites.Count; i++)
                {
                    if (mgr.Sites[i].Name.ToUpper().Equals(siteName.ToUpper()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool VerifyWebSiteBindingsIsExist(string bindingInfo)
        {
            string temp = string.Empty;
            using (ServerManager mgr = new ServerManager())
            {
                for (int i = 0; i < mgr.Sites.Count; i++)
                {
                    foreach (Binding b in mgr.Sites[i].Bindings)
                    {
                        temp = b.BindingInformation;
                        if (temp.IndexOf('*') < 0)
                        {
                            temp = "*" + temp;
                        }
                        if (temp.Equals(bindingInfo))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        public static bool DeleteVdir(string siteName, string vDirName)
        {
            ServerManager serverManager = new ServerManager();
            Site mySite = serverManager.Sites[siteName];
            Application application = mySite.Applications["/" + vDirName];
            mySite.Applications.Remove(application);
            serverManager.CommitChanges();
            return true;
        }
        public static void AssignVDirToAppPool(string siteName,string vdir, string appPoolName)
        {
            ServerManager serverManager = new ServerManager();
            Site site = serverManager.Sites[siteName];
            site.Applications["/" + vdir].ApplicationPoolName = appPoolName;
            serverManager.CommitChanges();
        }

    }
}