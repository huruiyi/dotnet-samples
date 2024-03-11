using System;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using ThriftDemo.Contract;

namespace ThriftDemo.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TServerTransport transport = new TServerSocket(8800);
            //var processor = new UserService.Processor(new UserServiceImpl());
            //TServer server = new TThreadPoolServer(processor, transport);
            //server.Serve();
            //Console.ReadKey();

            TServerTransport transport = new TServerSocket(8800);
            var processorUserService = new UserService.Processor(new UserServiceImpl());
            var processorCalcService = new CalcService.Processor(new CalcServiceImpl());
            var processorMulti = new TMultiplexedProcessor();
            processorMulti.RegisterProcessor("UserService", processorUserService);
            processorMulti.RegisterProcessor("CalcService", processorCalcService);
            TServer server = new TThreadPoolServer(processorMulti, transport);
            server.Serve();
            Console.ReadKey();
        }
    }
}