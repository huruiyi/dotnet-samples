using System;

namespace _046_053_LINQ___Set_Operators
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSamples samples = new LinqSamples();

            //Comment or uncomment the method calls below to run or not

            samples.Linq46(); // This sample uses Distinct to remove  duplicate  elements in a sequence of factors of 300

            //samples.Linq47(); // This sample uses Distinct to find the unique Category names

            //samples.Linq48(); // This sample uses Union to create  one sequence that contains the unique values from both
            // arrays

            //samples.Linq49(); // This sample uses the Union method to create  one sequence that contains the unique first
            // letter from both product and customer names. Union is only available through method
            // syntax

            //samples.Linq50(); // This sample uses Intersect to create one sequence that contains the common values shared
            // by both arrays

            //samples.Linq51(); // This sample uses Intersect  to create one sequence that contains the common first letter
            // from both product and customer names

            //samples.Linq52(); // This sample uses Except to create a sequence that contains the values from numbersA that
            // are not also in numbersB

            //samples.Linq53(); // This sample uses Except to create one  sequence that contains the 1st letters of product
            // names that are not also first letters of customer names
            Console.ReadKey();
        }
    }
}