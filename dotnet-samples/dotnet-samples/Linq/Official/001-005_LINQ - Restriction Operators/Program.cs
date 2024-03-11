using System;

namespace _001_005_LINQ___Restriction_Operators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSamples samples = new LinqSamples();

            //Comment or uncomment the method calls below to run or not

            samples.Linq1(); // This sample  uses the where clause  to find all elements  of an array with a value
            // less than 5

            samples.Linq2(); // This sample uses the where clause to find all products that are out of stock

            //samples.Linq3(); // This sample uses the where clause to find all products that are in  stock and cost
            // more than 3.00 per unit

            //samples.Linq4(); // This sample uses the where  clause to find all customers in Washington and then it
            // uses a foreach loop to iterate over the orders collection that belongs to each
            // customer

            //samples.Linq5(); // This sample demonstrates an indexed where clause that returns digits whose name is
            // shorter than their value
            Console.ReadKey();
        }
    }
}