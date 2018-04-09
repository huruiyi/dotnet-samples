using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SelfHostAPI.Client
{
    internal class Program
    {
        #region Private member variables

        private static readonly HttpClient Client = new HttpClient();

        #endregion Private member variables

        #region Main method for execution entry

        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            Client.BaseAddress = new Uri("http://localhost:8082");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddProduct();

            GetAllProducts();
            GetProduct();
            EditProduct();
            DeleteProduct();
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }

        #endregion Main method for execution entry

        #region Private client methods

        /// <summary>
        /// Fetch all products
        /// </summary>
        private static void GetAllProducts()
        {
            HttpResponseMessage resp = Client.GetAsync("api/products").Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result.ToList();
            if (products.Any())
            {
                Console.WriteLine("Displaying all the products...");
                foreach (var p in products)
                {
                    Console.WriteLine("{0} {1} ", p.ProductId, p.ProductName);
                }
            }
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        private static void GetProduct()
        {
            const int id = 1;
            var resp = Client.GetAsync($"api/products/{id}").Result;
            resp.EnsureSuccessStatusCode();

            var product = resp.Content.ReadAsAsync<Product>().Result;
            Console.WriteLine("Displaying product having id : " + id);
            Console.WriteLine("ID {0}: {1}", id, product.ProductName);
        }

        /// <summary>
        /// Add product
        /// </summary>
        private static void AddProduct()
        {
            var newProduct = new Product() { ProductName = "Samsung Phone" };
            var response = Client.PostAsJsonAsync("api/products", newProduct);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Product added.");
            }
        }

        /// <summary>
        /// Edit product
        /// </summary>
        private static void EditProduct()
        {
            const int productToEdit = 4;
            var product = new Product() { ProductName = "Xamarin" };

            var response =
                Client.PutAsJsonAsync("api/products/" + productToEdit, product);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Product edited.");
            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        private static void DeleteProduct()
        {
            const int productToDelete = 2;
            var response = Client.DeleteAsync("api/products/" + productToDelete);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine("Product deleted.");
            }
        }

        #endregion Private client methods
    }
}
