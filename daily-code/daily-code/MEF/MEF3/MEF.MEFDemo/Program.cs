using MEF.BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace MEF.MEFDemo
{
    class Program
    {
        //其中AllowRecomposition=true参数就表示运行在有新的部件被装配成功后进行部件集的重组.
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<ICard, IMetaData>> cards { get; set; }

        private static void Main(string[] args)
        {
            Program pro = new Program();
            pro.Compose();
            foreach (var c in pro.cards)
            {
                if (c.Metadata.CardType == "BankOfChina")
                {
                    Console.WriteLine("Here is a card of Bank Of China ");
                    Console.WriteLine(c.Value.GetCountInfo());
                }
                if (c.Metadata.CardType == "NongHang")
                {
                    Console.WriteLine("Here is a card of Nong Ye Yin Hang ");
                    Console.WriteLine(c.Value.GetCountInfo());
                }
            }
            Console.Read();
        }

        private void Compose()
        {
            var catalog = new DirectoryCatalog(@"C:\Users\Admin\source\repos\VS2017DotNet\MEF\MEF3\MEF.MEFDemo\bin\Debug");
            //var catalog = new DirectoryCatalog("Cards");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
