using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    class Program
    {
        [ImportMany(typeof(ICard))]
        public IEnumerable<ICard> cards { get; set; }

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            foreach (var c in pro.cards)
            {
                Console.WriteLine(c.GetCountInfo());
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog(@"C:\Users\Admin\source\repos\VS2017DotNet\MEF\MEF2\MEFDemo\bin\Debug");
            //var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
