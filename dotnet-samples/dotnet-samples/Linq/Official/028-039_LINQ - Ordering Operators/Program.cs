using System;

namespace _028_039_LINQ___Ordering_Operators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSamples samples = new LinqSamples();

            //Comment or uncomment the method calls below to run or not

            samples.Linq28(); // This sample uses orderby to sort a list of words alphabetically

            //samples.Linq29(); // This sample uses orderby to sort a list of words by length

            //samples.Linq30(); // This sample uses orderby to sort a list of products by name. Use the \"descending\"
            // keyword at the end of the clause to perform a reverse ordering

            //samples.Linq31(); // This sample uses an  OrderBy clause with a custom comparer to do a case-insensitive
            // sort of the words in an array

            //samples.Linq32(); // This sample uses  orderby and  descending to sort a list of doubles from highest to
            // lowest

            //samples.Linq33(); // This sample uses  orderby to sort a list of products by units in stock from highest
            // to lowest

            //samples.Linq34(); // This sample uses method syntax to call OrderByDescending  because it enables you to
            // use a custom comparer

            //samples.Linq35(); // This sample uses a compound  orderby to  sort a list of digits,  first by length of
            // their name, and then alphabetically by the name itself

            //samples.Linq36(); // The first query in this sample uses method syntax to call OrderBy and ThenBy with a
            // custom comparer to sort first by word length and then by a case-insensitive sort of
            // the words in an array.  The second two queries show another way to perform the same
            // task

            //samples.Linq37(); // This sample uses a compound  orderby to sort a list of products,  first by category,
            // and then by unit price, from highest to lowest

            //samples.Linq38(); // This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first
            // by word length and  then by a case-insensitive  descending  sort of  the words in an
            // array

            //samples.Linq39(); // This sample uses Reverse to  create a list of  all digits in the  array whose second
            // letter is 'i' that is reversed from the order in the original array
            Console.ReadKey();
        }
    }
}