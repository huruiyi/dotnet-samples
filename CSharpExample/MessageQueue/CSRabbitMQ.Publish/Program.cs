using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
//http://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
namespace CSRabbitMQ.Publish
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //RabbitMQ.Client.ConnectionFactory connectionFactory = new RabbitMQ.Client.ConnectionFactory();
            //connectionFactory.UserName = "admin";
            //connectionFactory.Password = "admin";
            ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection connection = connectionFactory.CreateConnection())
            {
                connection.ConnectionShutdown += Connection_ConnectionShutdown;

                Console.WriteLine(connection.IsOpen);
                Console.WriteLine(connection.RemotePort);

                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    channel.BasicConsume(queue: "hello",
                                         autoAck: true,
                                         consumer: consumer);

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