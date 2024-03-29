﻿using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost
{
    public class HelloController : ApiController
    {
        public string Get()
        {
            return "Hello, world!";
        }
    }

    internal class Program
    {
        private static readonly Uri BaseAddress = new Uri("http://localhost:40000/");
        private static readonly Uri Address = new Uri(BaseAddress, "/api/hello");

        private static void Main(string[] args)
        {
            HttpSelfHostServer server = null;
            try
            {
                // Set up server configuration
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(BaseAddress);

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                // Create server
                server = new HttpSelfHostServer(config);

                // Start listening
                server.OpenAsync().Wait();
                Console.WriteLine("Listening on " + BaseAddress);

                // Call the web API and display the result
                HttpClient client = new HttpClient();
                client.GetStringAsync(Address).ContinueWith(getTask =>
                {
                    if (getTask.IsCanceled)
                    {
                        Console.WriteLine("Request was canceled");
                    }
                    else if (getTask.IsFaulted)
                    {
                        Console.WriteLine("Request failed: {0}", getTask.Exception);
                    }
                    else
                    {
                        Console.WriteLine("Client received: {0}", getTask.Result);
                    }
                });
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not start server: {0}", e.GetBaseException().Message);
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }
            finally
            {
                if (server != null)
                {
                    // Stop listening
                    server.CloseAsync().Wait();
                }
            }
        }
    }
}