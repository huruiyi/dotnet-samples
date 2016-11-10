using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现接口索引器
{
    // Indexer on an interface:
    public interface ISomeInterface
    {
        // Indexer declaration:
        int this[int index]
        {
            get;
            set;
        }
    }
    class IndexerClass : ISomeInterface
    {
        private int[] arr = new int[100];
        public int this[int index]   // indexer declaration
        {
            get
            {
                // The arr object will throw IndexOutOfRange exception.
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IndexerClass test = new IndexerClass();
            Random rand = new Random();
            // Call the indexer to initialize its elements.
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Element #{0} = {1}", i, test[i]);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
