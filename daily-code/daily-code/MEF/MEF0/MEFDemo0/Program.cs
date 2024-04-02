using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace MEFDemo0
{
    public interface IBookService
    {
        string BookName { get; set; }

        string GetBookName();
    }

    [Export("MusicBook")]
    public class MusicBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MusicBook";
        }
    }

    [Export("MathBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook";
        }
    }

    [Export("HistoryBook", typeof(IBookService))]
    public class HistoryBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "HistoryBook";
        }
    }

    internal class Program
    {
        [ImportMany("MathBook")]
        public IEnumerable<object> MathBookServices { get; set; }


        [ImportMany("MusicBook")]
        public IEnumerable<object> MusicBookServices { get; set; }

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            if (pro.MathBookServices != null)
            {
                foreach (var s in pro.MathBookServices)
                {
                    var ss = (IBookService)s;
                    Console.WriteLine(ss.GetBookName());
                }
            }

            if (pro.MusicBookServices != null)
            {
                foreach (var s in pro.MusicBookServices)
                {
                    var ss = (IBookService)s;
                    Console.WriteLine(ss.GetBookName());
                }
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}