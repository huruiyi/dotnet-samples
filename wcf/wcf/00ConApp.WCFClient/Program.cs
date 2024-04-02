using _00ConApp.WCFClient.CalcServiceReference;
using System;
using System.Threading.Tasks;

namespace _00ConApp.WCFClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Add_decimalRequest request = new Add_decimalRequest
            {
                Number1 = "2345",
                Number2 = "1234"
            };
            CalcServiceClient client = new CalcServiceClient();
            Task<Add_decimalResponse> result = client.Add_decimalAsync(request);

            Console.WriteLine(result.Result.Add_decimalResult);
            Console.WriteLine("结束了");
            Console.Read();
        }
    }
}