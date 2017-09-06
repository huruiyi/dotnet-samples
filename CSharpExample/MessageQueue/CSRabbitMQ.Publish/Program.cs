using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

//http://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html

namespace CSRabbitMQ.Publish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RabbitMQ.Client.ConnectionFactory connectionFactory = new RabbitMQ.Client.ConnectionFactory();
            connectionFactory.UserName = "admin";
            connectionFactory.Password = "admin";

            using (IConnection connection = connectionFactory.CreateConnection())
            {
                connection.ConnectionShutdown += Connection_ConnectionShutdown;

                Console.WriteLine(connection.IsOpen);
                Console.WriteLine(connection.RemotePort);

                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                                queue: "hello",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

                    for (int i = 0; i < 1000; i++)
                    {
                        string message = string.Format("Hello World!I am Num {0}", i);
                        var body = Encoding.UTF8.GetBytes(message);
                        Thread.Sleep(1000);
                        channel.BasicPublish(
                           exchange: "",
                           routingKey: "hello",
                           basicProperties: null,
                           body: body);
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