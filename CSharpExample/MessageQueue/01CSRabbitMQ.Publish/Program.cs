using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace _01CSRabbitMQ.Publish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = "127.0.0.1",
                VirtualHost = "/",
                UserName = "admin",
                Password = "admin"
            };

            using (IConnection connection = connectionFactory.CreateConnection())
            {
                connection.ConnectionShutdown += Connection_ConnectionShutdown;

                Console.WriteLine(connection.IsOpen);
                Console.WriteLine(connection.RemotePort);

                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    for (int i = 0; i < 1000; i++)
                    {
                        string message = $"Hello World!I am Num {i}";
                        var body = Encoding.UTF8.GetBytes(message);
                        Thread.Sleep(1000);
                        channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                        Console.WriteLine(" [x] Sent {0}", message);
                    }

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        private static void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine(e.ReplyText);
        }
    }
}