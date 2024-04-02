using System;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerDapper.BusinessObjects;

namespace SqlServerDapper
{
    [TestClass]
    public class AdventureWorksTests
    {
        [TestMethod]
        public void RunTests()
        {
            QuerySQL1();
            //QuerySQL2();
            //QueryMultipleSQL1();
            //QueryMultipleSQL2();
            //ToDataTable();
            //ToEnumerable();
            //ToDataSet();
            //ExecuteScalarSQL();
            //ExecuteSQL();
        }

        private void QuerySQL1()
        {
            var products = SqlHelper.QuerySql<Product>("select * from Production.Product where ProductID = @ProductID", new { ProductID = 1 });

            Console.WriteLine("Query 1");
            Console.WriteLine();
            var enumerable = products as Product[] ?? products.ToArray();
            foreach (var product in enumerable)
                Console.WriteLine(product.ProductId + " " + product.Name);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsTrue(enumerable.Count() == 1);
        }

        private void QuerySQL2()
        {
            var products = SqlHelper.QuerySql<Product>("select top 4 * from Production.Product order by ProductID");

            Console.WriteLine("Query 2");
            Console.WriteLine();
            var enumerable = products as Product[] ?? products.ToArray();
            foreach (var product in enumerable)
                Console.WriteLine(product.ProductId + " " + product.Name);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsTrue(enumerable.Count() == 4);
        }

        private void QueryMultipleSQL1()
        {
            var results = SqlHelper.QueryMultipleSql<Product, Person>(@"
                select top 4 * from Production.Product order by ProductID;
                select top 4 * from Person.Person order by BusinessEntityID;
            ");

            var products = results.Item1;
            var people = results.Item2;

            Console.WriteLine("Query Multiple 1 (Different Types of Result Sets)");
            Console.WriteLine();
            var enumerable = products as Product[] ?? products.ToArray();
            foreach (var product in enumerable)
                Console.WriteLine(product.ProductId + " " + product.Name);
            Console.WriteLine();
            var persons = people as Person[] ?? people.ToArray();
            foreach (var person in persons)
                Console.WriteLine(person.BusinessEntityId + " " + person.FirstName + " " + person.LastName);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsNotNull(people);
            Assert.IsTrue(enumerable.Count() == 4);
            Assert.IsTrue(persons.Count() == 4);
        }

        private void QueryMultipleSQL2()
        {
            var results = SqlHelper.QueryMultipleSql<Product, Product, Product, Product, Product, Product, Product, Product, Product, Product, Product, Product, Product, Product>(@"
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
                select top 1 * from Production.Product order by ProductID;
            ");

            var productLists = new[] {
                results.Item1,
                results.Item2,
                results.Item3,
                results.Item4,
                results.Item5,
                results.Item6,
                results.Item7,
                results.Rest.Item1,
                results.Rest.Item2,
                results.Rest.Item3,
                results.Rest.Item4,
                results.Rest.Item5,
                results.Rest.Item6,
                results.Rest.Item7,
            };

            Console.WriteLine("Query Multiple 2 (14 Result Sets)");
            Console.WriteLine();

            int index = 0;
            foreach (var products in productLists)
            {

                var product = products.First();
                Console.WriteLine("Result Set " + (++index) + ": " + product.ProductId + " " + product.Name);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            foreach (var products in productLists)
            {
                Assert.IsNotNull(products);
                Assert.IsTrue(products.Count() == 1);
            }
        }

        private void ToDataTable()
        {
            var products = SqlHelper.QuerySql<Product>("select top 4 * from Production.Product order by ProductID").ToDataTable();

            Console.WriteLine("To DataTable");
            Console.WriteLine();
            foreach (DataRow product in products.Rows)
                Console.WriteLine(product["ProductID"] + " " + product["Name"]);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Rows.Count == 4);
        }

        private void ToEnumerable()
        {
            var products = SqlHelper.QuerySql<Product>("select top 4 * from Production.Product order by ProductID").ToDataTable().Cast<Product>();

            Console.WriteLine("To Enumerable");
            Console.WriteLine();
            var enumerable = products as Product[] ?? products.ToArray();
            foreach (var product in enumerable)
                Console.WriteLine(product.ProductId + " " + product.Name);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsTrue(enumerable.Count() == 4);
        }

        private void ToDataSet()
        {
            var results = SqlHelper.QueryMultipleSql<Product, Person>(@"
                select top 4 * from Production.Product order by ProductID;
                select top 4 * from Person.Person order by BusinessEntityID;
            ").ToDataSet();

            var products = results.Tables[0];
            var people = results.Tables[1];

            Console.WriteLine("To DataSet");
            Console.WriteLine();
            foreach (DataRow product in products.Rows)
                Console.WriteLine(product["ProductID"] + " " + product["Name"]);
            Console.WriteLine();
            foreach (DataRow person in people.Rows)
                Console.WriteLine(person["BusinessEntityID"] + " " + person["FirstName"] + " " + person["LastName"]);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsNotNull(products);
            Assert.IsNotNull(people);
            Assert.IsTrue(products.Rows.Count == 4);
            Assert.IsTrue(people.Rows.Count == 4);
        }

        private void ExecuteScalarSQL()
        {
            int minProductID = SqlHelper.ExecuteScalarSql<int>("select min(ProductID) from Production.Product");
            int maxProductID = SqlHelper.ExecuteScalarSql<int>("select max(ProductID) from Production.Product");

            Console.WriteLine("Execute Scalar");
            Console.WriteLine();
            Console.WriteLine("Min ProductID: " + minProductID);
            Console.WriteLine("Max ProductID: " + maxProductID);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsTrue(minProductID > 0);
            Assert.IsTrue(maxProductID > 0);
        }

        private void ExecuteSQL()
        {
            var outParam = new DynamicParameters("MinProductID", sqlDbType: SqlDbType.Int, direction: ParameterDirection.Output);
            outParam.Add("MaxProductID", sqlDbType: SqlDbType.Int, direction: ParameterDirection.Output);

            SqlHelper.ExecuteSQL(@"
                select @MinProductID = min(ProductID) from Production.Product;
                select @MaxProductID = max(ProductID) from Production.Product;
            ", outParam: outParam);

            int minProductID = (int)outParam.Get()["MinProductID"];
            int maxProductID = outParam.Get<int>()["MaxProductID"];

            Console.WriteLine("Execute");
            Console.WriteLine();
            Console.WriteLine("Min ProductID: " + minProductID);
            Console.WriteLine("Max ProductID: " + maxProductID);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            Assert.IsTrue(minProductID > 0);
            Assert.IsTrue(maxProductID > 0);
        }
    }
}
