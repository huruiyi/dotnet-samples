using AngularJSDemo.Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;

namespace AngularJSDemo.Service
{
    /// <summary>
    /// Demo 的摘要说明
    /// </summary>
    public class Demo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                case "GetCountrys":
                    GetCountrys(context);
                    break;

                default:
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}