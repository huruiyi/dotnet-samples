using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ConApp.Samples
{
    class RegexDemo
    {
        public static void RegexDemo03()
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("https://github.com/mono");
            string result = Encoding.Default.GetString(bytes);
            Regex re = new Regex("href=\"/mono/.*?\"");
            MatchCollection mc = re.Matches(result);
            foreach (Match match in mc)
            {
                string url = match.Result("${urladdress}");
                Console.WriteLine(url);
                Console.WriteLine(match.Value);
                Console.WriteLine();
            }
        }

        private static void RegexDemo02()
        {
            string input = "1851 1999 1950 1905 2003";
            string pattern = @"(?<=19)\d{2}\b";
            foreach (Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine(match.Value);
            }
        }

        private static void RegexDemo01()
        {
            string s = "例如：http://www.asd.com,http://wwww.gongjuji.net?name=zhangsan&age=10,http://md5.gongjuji.net/dencrypt/";
            Regex re = new Regex(@"(?<urladdress>http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)");
            MatchCollection mc = re.Matches(s);
            foreach (Match m in mc)
            {
                string url = m.Result("${urladdress}");
                Console.WriteLine(url);
            }
        }
    }
}
