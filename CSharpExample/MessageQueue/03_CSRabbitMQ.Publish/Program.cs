using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace _03_CSRabbitMQ.Publish
{
    internal class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                for (int i = 0; i < 1000; i++)
                {
                    string message = string.Format("Hello World! I am Num {0}", i);
                    var body = Encoding.UTF8.GetBytes(message);
                    Thread.Sleep(1000);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}