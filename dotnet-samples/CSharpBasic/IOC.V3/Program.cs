using Autofac;
using IOC.V3.MovieFinder;
using System;

namespace IOC.V3
{
    internal class Program
    {
        private static IContainer _container;

        private static void Main(string[] args)
        {
            InitIoC();

            var lister = _container.Resolve<MpgMovieLister>();

            foreach (var movie in lister.GetMPG())
            {
                Console.WriteLine(movie.Name);
            }
            Console.Read();
        }

        private static void InitIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces();
            builder.RegisterType<DbMovieFinder>().AsImplementedInterfaces();
            builder.RegisterType<MpgMovieLister>();
            _container = builder.Build();
        }
    }
}