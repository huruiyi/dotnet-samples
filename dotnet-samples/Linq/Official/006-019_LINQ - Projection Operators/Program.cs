using System;

namespace _006_019_LINQ___Projection_Operators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSamples samples = new LinqSamples();

            // Comment or uncomment the method calls below to run or not
            samples.DataSetLinq6();     // This sample uses select to produce a sequence of ints one higher than those in an existing array of ints.
            //samples.DataSetLinq7();     // This sample uses select to return a sequence of just the names of a list of products.
            //samples.DataSetLinq8();     // This sample uses select to produce a sequence of strings representing the text version of a sequence of ints.
            //samples.DataSetLinq9();     // This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array.
            //samples.DataSetLinq10();    // This sample uses select to produce a sequence containing text representations of digits and whether their length is even or odd.
            //samples.DataSetLinq11();    // This sample uses select to produce a sequence containing some properties of Products...
            //samples.DataSetLinq12();    // This sample uses an indexed Select clause to determine if the value of ints in an array match their position in the array.
            //samples.DataSetLinq13();    // This sample combines select and where to make a simple query that returns the text form of each digit less than 5.
            //samples.DataSetLinq14();    // This sample uses a compound from clause to make a query that returns all pairs of numbers...
            //samples.DataSetLinq15();    // This sample uses a compound from clause to select all orders where the order total is less than 500.00.
            //samples.DataSetLinq16();    // This sample uses a compound from clause to select all orders where the order was made in 1998 or later.
            //samples.DataSetLinq17();    // This sample uses a compound from clause to select all orders where order total is greater than 2000.00...
            //samples.DataSetLinq18();    // This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders...
            //samples.DataSetLinq19();    // This sample uses an indexed SelectMany clause to select all orders...
            Console.ReadKey();
        }
    }
}