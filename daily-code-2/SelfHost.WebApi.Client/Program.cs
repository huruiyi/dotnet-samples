using SelfHost.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SelfHost.WebApi.Client
{
    internal class Program
    {
        private static HttpClient client = new HttpClient();

        private static void Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:8080");

            ListAllProducts();
            ListProduct(1);
            ListProducts("toys");

            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }

        private static void ListAllProducts()
        {
            HttpResponseMessage resp = client.GetAsync("api/products").Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var p in products)
            {
                Console.WriteLine("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
            }
        }

        private static void ListProduct(int id)
        {
            var resp = client.GetAsync(string.Format("api/products/{0}", id)).Result;
            resp.EnsureSuccessStatusCode();

            var product = resp.Content.ReadAsAsync<Product>().Result;
            Console.WriteLine("ID {0}: {1}", id, product.Name);
        }

        private static void ListProducts(string category)
        {
            Console.WriteLine("Products in '{0}':", category);

            string query = $"api/products?category={category}";

            var resp = client.GetAsync(query).Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}