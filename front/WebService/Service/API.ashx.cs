using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Model;

namespace WebService.Service
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "GetCountrys":
                    GetCountrys(context);
                    break;

                case "GetJsonPName":
                    GetJsonPName(context);
                    break;

                case "GetJsonPMsg":
                    GetJsonPMsg(context);
                    break;
            }
        }

        private void GetCountrys(HttpContext context)
        {
            List<City> response = new List<City>();
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=world";
                con.Open();
                string cmdText = "SELECT * FROM world.city limit 0 ,15";
                using (MySqlCommand cmd = new MySqlCommand(cmdText, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            response.Add(new City
                            {
                                ID = Convert.ToInt64(reader["ID"]),
                                CountryCode = reader["CountryCode"].ToString(),
                                District = reader["District"].ToString(),
                                Name = reader["Name"].ToString(),
                                Population = Convert.ToInt64(reader["Population"])
                            });
                        }
                    }
                }
            }
            context.Response.Write(JsonConvert.SerializeObject(response));
        }

        /*
        $.ajax({
            type : "get",
            async:false,
            url : "http://localhost:801/Service/API.ashx?action=GetJsonPName",
            dataType : "jsonp",
            jsonp: "callbackparam",
            jsonpCallback:"success_jsonpCallback",
            success : function(json){
                alert(json[0].name);
            },
            error:function(){
                alert('fail');
            }
        });
        */

        /// <summary>
        /// Jsonp请求示例
        /// </summary>
        /// <param name="context"></param>
        public void GetJsonPName(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string callbackFunName = context.Request["callbackparam"];
            context.Response.Write(callbackFunName + "([{ name:\"John\"}])");
        }

        /*
        function GetJsonPMsg() {
            $.ajax({
                type: "GET",
                url: "http://localhost:801/Service/API.ashx?action=GetJsonPMsg",
                dataType: "jsonp",
                jsonp: "callback",
                success: function(json) {
                    alert(json.msg);
                }
            });
        }
        */

        public void GetJsonPMsg(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string callback = context.Request.Params["callback"];
            context.Response.Write(callback + "({\"msg\":\"JSONP Test!\"})");
        }

        public bool IsReusable => false;
    }
}