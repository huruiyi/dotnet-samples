using RabbitMQ.Client;
using System;
using System.Text;

namespace _02CSRabbitMQ.WorkQueue.NewTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                for (int i = 0; i < 1000; i++)
                {
                    string message = string.Format("Hello Num {0}", i);

                    byte[] body = Encoding.UTF8.GetBytes(message);

                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = false;

                    channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}