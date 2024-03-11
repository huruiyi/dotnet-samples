using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ConApp.Samples
{
    public class JsonDemo
    {
        public static void Demo1()
        {
            string fff = @"{""kf_list"":[{""kf_account"":""1005@sayyas1998"",""kf_headimgurl"":""http:\/\/ mmbiz.qpic.cn\/ mmbiz\/ oSJVrqYTJPAOvCp0Hg2ia6OhK03NlhClbT94UpcG4R9y1qTwH5ibGqaIJR8jJS0sxK8REGQZStg7AGZFEibz7PoOA\/ 300 ? wx_fmt = png"",""kf_id"":1002,""kf_nick"":""管家"",""kf_wx"":""sayyashome2""},{""kf_account"":""kf2003 @sayyas1998"",""kf_headimgurl"":""http:\/\/ mmbiz.qpic.cn\/ mmbiz\/ oSJVrqYTJPAOHjaQcOU9JBjibZrdYgeD8CYdMxcB9onxXJaIU1NZIvSOGIPMg3nzrhMbPdiarrRH6H3fwAA9OHHg\/ 300 ? wx_fmt = jpeg"",""kf_id"":2003,""kf_nick"":""管家"",""kf_wx"":""zhanghanqi0451""}]}";
            JObject jo = (JObject)JsonConvert.DeserializeObject(fff);
            var data = jo["kf_list"]; ;
            JArray jar = JArray.Parse(jo["kf_list"].ToString());
            for (int i = 0; i < jar.Count; i++)
            {
                var info = jar[i];
            }
            JObject j = JObject.Parse(jar[0].ToString());
            string st = j["kf_account"].ToString();

            var twitterObject = JToken.Parse(fff);
            var trendsArray = twitterObject.Children<JProperty>().FirstOrDefault(x => x.Name == "kf_list").Value;

            foreach (var item in trendsArray.Children())
            {
                var itemProperties = item.Children<JProperty>();
                var myElement = itemProperties.FirstOrDefault(x => x.Name == "kf_account").Value;
            }
        }
    }
}