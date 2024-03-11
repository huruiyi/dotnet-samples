using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace _006_019_LINQ___Projection_Operators
{
    public class LinqSamples
    {
        private DataSet testDS;

        public LinqSamples()
        {
            testDS = TestHelper.CreateTestDataset();
        }

        #region "Projection Operators"

        [Category("Projection Operators")]
        [Description("This sample uses select to produce a sequence of ints one higher than " +
                     "those in an existing array of ints.")]
        public void DataSetLinq6()
        {
            var numbers = testDS.Tables["Numbers"].AsEnumerable();

            var numsPlusOne =
                from n in numbers
                select n.Field<int>(0) + 1;

            Console.WriteLine("Numbers + 1:");
            foreach (var i in numsPlusOne)
            {
                Console.WriteLine(i);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses select to return a sequence of just the names of a list of products.")]
        public void DataSetLinq7()
        {
            var products = testDS.Tables["Products"].AsEnumerable();

            var productNames =
                from p in products
                select p.Field<string>("ProductName");

            Console.WriteLine("Product Names:");
            foreach (var productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses select to produce a sequence of strings representing " +
                     "the text version of a sequence of ints.")]
        public void DataSetLinq8()
        {
            var numbers = testDS.Tables["Numbers"].AsEnumerable();
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var textNums = numbers.Select(p => strings[p.Field<int>("number")]);

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses select to produce a sequence of the uppercase " +
                     "and lowercase versions of each word in the original array.")]
        public void DataSetLinq9()
        {
            var words = testDS.Tables["Words"].AsEnumerable();

            var upperLowerWords = words.Select(p => new
            {
                Upper = (p.Field<string>(0)).ToUpper(),
                Lower = (p.Field<string>(0)).ToLower()
            });

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: " + ul.Upper + ", Lowercase: " + ul.Lower);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses select to produce a sequence containing text " +
                     "representations of digits and whether their length is even or odd.")]
        public void DataSetLinq10()
        {
            var numbers = testDS.Tables["Numbers"].AsEnumerable();
            var digits = testDS.Tables["Digits"];
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitOddEvens = numbers.
                Select(n => new
                {
                    Digit = digits.Rows[n.Field<int>("number")]["digit"],
                    Even = (n.Field<int>("number") % 2 == 0)
                });

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine(@"The digit {0} is {1}.", d.Digit, d.Even ? "even" : "odd");
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses select to produce a sequence containing some properties " +
                     "of Products, including UnitPrice which is renamed to Price " +
                     "in the resulting type.")]
        public void DataSetLinq11()
        {
            var products = testDS.Tables["Products"].AsEnumerable();

            var productInfos = products.
                Select(n => new
                {
                    ProductName = n.Field<string>("ProductName"),
                    Category = n.Field<string>("Category"),
                    Price = n.Field<decimal>("UnitPrice")
                });

            Console.WriteLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses an indexed Select clause to determine if the value of ints " +
                     "in an array match their position in the array.")]
        public void DataSetLinq12()
        {
            var numbers = testDS.Tables["Numbers"].AsEnumerable();

            var numsInPlace = numbers.Select((num, index) => new
            {
                Num = num.Field<int>("number"),
                InPlace = (num.Field<int>("number") == index)
            });

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine(@"{0}: {1}", n.Num, n.InPlace);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample combines select and where to make a simple query that returns " +
                     "the text form of each digit less than 5.")]
        public void DataSetLinq13()
        {
            var numbers = testDS.Tables["Numbers"].AsEnumerable();
            var digits = testDS.Tables["Digits"];

            var lowNums =
                from n in numbers
                where n.Field<int>("number") < 5
                select digits.Rows[n.Field<int>("number")].Field<string>("digit");

            Console.WriteLine("Numbers < 5:");
            foreach (var num in lowNums)
            {
                Console.WriteLine(num);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses a compound from clause to make a query that returns all pairs " +
                     "of numbers from both arrays such that the number from numbersA is less than the number " +
                     "from numbersB.")]
        public void DataSetLinq14()
        {
            var numbersA = testDS.Tables["NumbersA"].AsEnumerable();
            var numbersB = testDS.Tables["NumbersB"].AsEnumerable();

            var pairs =
                from a in numbersA
                from b in numbersB
                where a.Field<int>("number") < b.Field<int>("number")
                select new { a = a.Field<int>("number"), b = b.Field<int>("number") };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine(@"{0} is less than {1}", pair.a, pair.b);
            }
        }

        [Category("Projection Operators")]
        [Description("This sample uses a compound from clause to select all orders where the " +
                     "order total is less than 500.00.")]
        public void DataSetLinq15()
        {
            var customers = testDS.Tables["Customers"].AsEnumerable();
            var orders = testDS.Tables["Orders"].AsEnumerable();

            var smallOrders =
                from c in customers
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                    && o.Field<decimal>("Total") < 500.00M
                select new
                {
                    CustomerID = c.Field<string>("CustomerID"),
                    OrderID = o.Field<int>("OrderID"),
                    Total = o.Field<decimal>("Total")
                };

            ObjectDumper.Write(smallOrders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses a compound from clause to select all orders where the " +
                     "order was made in 1998 or later.")]
        public void DataSetLinq16()
        {
            var customers = testDS.Tables["Customers"].AsEnumerable();
            var orders = testDS.Tables["Orders"].AsEnumerable();

            var myOrders =
                from c in customers
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID") &&
                o.Field<DateTime>("OrderDate") >= new DateTime(1998, 1, 1)
                select new
                {
                    CustomerID = c.Field<string>("CustomerID"),
                    OrderID = o.Field<int>("OrderID"),
                    OrderDate = o.Field<DateTime>("OrderDate")
                };

            ObjectDumper.Write(myOrders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses a compound from clause to select all orders where the " +
                     "order total is greater than 2000.00 and uses from assignment to avoid " +
                     "requesting the total twice.")]
        public void DataSetLinq17()
        {
            var customers = testDS.Tables["Customers"].AsEnumerable();
            var orders = testDS.Tables["Orders"].AsEnumerable();

            var myOrders =
                from c in customers
                from o in orders
                let total = o.Field<decimal>("Total")
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                    && total >= 2000.0M
                select new { CustomerID = c.Field<string>("CustomerID"), OrderID = o.Field<int>("OrderID"), total };

            ObjectDumper.Write(myOrders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses multiple from clauses so that filtering on customers can " +
                     "be done before selecting their orders.  This makes the query more efficient by " +
                     "not selecting and then discarding orders for customers outside of Washington.")]
        public void DataSetLinq18()
        {
            var customers = testDS.Tables["Customers"].AsEnumerable();
            var orders = testDS.Tables["Orders"].AsEnumerable();
            DateTime cutoffDate = new DateTime(1997, 1, 1);

            var myOrders =
                from c in customers
                where c.Field<string>("Region") == "WA"
                from o in orders
                where c.Field<string>("CustomerID") == o.Field<string>("CustomerID")
                && (DateTime)o["OrderDate"] >= cutoffDate
                select new { CustomerID = c.Field<string>("CustomerID"), OrderID = o.Field<int>("OrderID") };

            ObjectDumper.Write(myOrders);
        }

        [Category("Projection Operators")]
        [Description("This sample uses an indexed SelectMany clause to select all orders, " +
                     "while referring to customers by the order in which they are returned " +
                     "from the query.")]
        public void DataSetLinq19()
        {
            var customers = testDS.Tables["Customers"].AsEnumerable();
            var orders = testDS.Tables["Orders"].AsEnumerable();

            var customerOrders =
                customers.SelectMany(
                    (cust, custIndex) =>
                    orders.Where(o => cust.Field<string>("CustomerID") == o.Field<string>("CustomerID"))
                        .Select(o => new { CustomerIndex = custIndex + 1, OrderID = o.Field<int>("OrderID") }));

            foreach (var c in customerOrders)
            {
                Console.WriteLine("Customer Index: " + c.CustomerIndex +
                                    " has an order with OrderID " + c.OrderID);
            }
        }

        #endregion "Projection Operators"
    }
}