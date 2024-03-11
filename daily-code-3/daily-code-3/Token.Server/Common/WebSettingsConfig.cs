using System.Configuration;
using System.Runtime.CompilerServices;

namespace Token.Server.Common
{
    public class WebSettingsConfig
    {
        public static string UrlExpireTime => AppSettingValue();

        private static string AppSettingValue([CallerMemberName] string key = null)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}