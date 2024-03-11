using Grpc.Net.Client;

namespace GrpcService1.Client
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            //将 localhost 端口号 7042 替换为在 GrpcService1 服务项目的 Properties/launchSettings.json 中指定的 HTTPS 端口号。
            using var channel = GrpcChannel.ForAddress("https://localhost:7058");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}