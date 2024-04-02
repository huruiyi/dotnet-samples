using System;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftDemo.Contract;

namespace ThriftDemo.Client
{
    internal class Program
    {
        private static void SingleService1()
        {
            using (TTransport transport = new TSocket("localhost", 8800))
            {
                using (TProtocol protocol = new TBinaryProtocol(transport))
                {
                    using (var clientUser = new UserService.Client(protocol))
                    {
                        transport.Open();
                        User u = clientUser.Get(1); Console.WriteLine($"{u.Id},{u.Name}");
                    }
                }
            }
        }

        private static void SingleService2()
        {
            using (TTransport transport = new TSocket("localhost", 8800))
            {
                using (TProtocol protocol = new TBinaryProtocol(transport))
                {
                    using (var calcClient = new CalcService.Client(protocol))
                    {
                        transport.Open();
                        Console.WriteLine(calcClient.Add(2, 1));
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            using (TTransport transport = new TSocket("localhost", 8800))
            using (TProtocol protocol = new TBinaryProtocol(transport))
            using (var protocolUserService = new TMultiplexedProtocol(protocol, "UserService"))
            using (var clientUser = new UserService.Client(protocolUserService))
            using (var protocolCalcService = new TMultiplexedProtocol(protocol, "CalcService"))
            using (var clientCalc = new CalcService.Client(protocolCalcService))
            {
                transport.Open();
                User u = clientUser.Get(1);
                Console.WriteLine($"{u.Id},{u.Name}");
                Console.WriteLine(clientCalc.Add(1, 2));
            }
        }
    }
}