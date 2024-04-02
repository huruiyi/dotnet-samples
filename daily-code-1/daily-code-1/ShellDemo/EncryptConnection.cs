using System.Configuration;

namespace ShellDemo
{
    public static class EncryptConnection
    {
        ////加密
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        //    ConfigurationSection section = config.GetSection("connectionStrings");

        //    if (section != null && !section.SectionInformation.IsProtected)
        //    {
        //        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
        //        config.Save();
        //    }

        //}
        ////解密
        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        //    ConfigurationSection section = config.GetSection("connectionStrings");

        //    if (section != null && section.SectionInformation.IsProtected)
        //    {
        //        section.SectionInformation.UnprotectSection();
        //        config.Save();
        //    }
        //}

        /// <summary>
        /// 加密app.config
        /// </summary>
        /// <param name="encrypt"></param>
        public static void EncryptConnectionString(bool encrypt)
        {
            // Open the configuration file and retrieve the connectionStrings section.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.GetSection("connectionStrings");
            if ((!(section.ElementInformation.IsLocked)) && (!(section.SectionInformation.IsLocked)))
            {
                bool isProtected = section.SectionInformation.IsProtected;
                if (encrypt && !isProtected)
                {
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }
                if (!encrypt && isProtected)
                {
                    section.SectionInformation.UnprotectSection();
                }
                ////re-save the configuration file section
                section.SectionInformation.ForceSave = true;
                // Save the current configuration.
                config.Save();
            }
        }
    }
}