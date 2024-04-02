using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Token.Client.Common;
using Token.Models;

namespace Token.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int staffId = int.Parse(AppSettingsConfig.StaffId);
            var tokenResult = WebApiHelper.GetSignToken(staffId);

            //staffId = 100;
            Dictionary<string, string> parames = new Dictionary<string, string>
            {
                {"id", "1"},
                {"name", "wahaha"}
            };
            Tuple<string, string> parameters = WebApiHelper.GetQueryString(parames);
            var product1 = WebApiHelper.Get<ProductResultMsg>("http://localhost:806/api/product/getproduct", parameters.Item1, parameters.Item2, staffId, true);

            Product product = new Product
            {
                Id = 1,
                Name = "安慕希",
                Count = 10,
                Price = 58.8
            };
            var product2 = WebApiHelper.Post<ProductResultMsg>("http://localhost:806/api/product/addProduct", JsonConvert.SerializeObject(product), staffId);

            Console.Read();
        }
    }
}