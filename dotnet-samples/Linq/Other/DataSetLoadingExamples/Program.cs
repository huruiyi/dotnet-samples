using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DataSetLoadingExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSamples samples = new LinqSamples();

            // Comment or uncomment the method calls below to run or not
            samples.DataSetLinq109();   // Create and load a DataTable from a sequence
            //samples.DataSetLinq117a();  // Load an existing DataTable with query results

            Console.ReadKey();
        }

        private class LinqSamples
        {
            private DataSet testDS;

            public LinqSamples()
            {
                testDS = TestHelper.CreateTestDataset();
            }

            #region "DataSet Loading examples"

            [Category("DataSet Loading examples")]
            [Description("Create and load a DataTable from a sequence")]
            public void DataSetLinq109()
            {
                var customers = testDS.Tables["Customers"].AsEnumerable();
                var orders = testDS.Tables["Orders"].AsEnumerable();

                var smallOrders =
                    from c in customers
                    from o in orders
                    where c.Field<string>("CustomerID") == o.Field<string>("CustomerID") &&
                        o.Field<decimal>("Total") < 500.00M
                    select new { CustomerID = (string)c["CustomerID"], OrderID = (int)o["OrderID"], Total = (decimal)o["Total"] };

                DataTable myOrders = new DataTable();
                myOrders.Columns.Add("CustomerID", typeof(string));
                myOrders.Columns.Add("OrderID", typeof(int));
                myOrders.Columns.Add("Total", typeof(decimal));

                foreach (var result in smallOrders.Take(10))
                {
                    myOrders.Rows.Add(new object[] { result.CustomerID, result.OrderID, result.Total });
                }

                PrettyPrintDataTable(myOrders);
            }

            [Category("DataSet Loading examples")]
            [Description("Load an existing DataTable with query results")]
            public void DataSetLinq117a()
            {
                var customers = testDS.Tables["Customers"].AsEnumerable();
                var orders = testDS.Tables["Orders"].AsEnumerable();

                var query = from o in orders
                            where o.Field<decimal>("Total") < 500.00M
                            select o;

                DataTable results = query.CopyToDataTable();

                PrettyPrintDataTable(results);
            }

            private void PrettyPrintDataReader(DbDataReader reader)
            {
                while (reader.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    for (int ii = 0; ii < reader.FieldCount; ii++)
                    {
                        sb.AppendFormat("{0} = {1}  ", reader.GetName(ii), reader.IsDBNull(ii) ? "null" : reader[ii]);
                    }
                    Console.WriteLine(sb.ToString());
                }
            }

            private void PrettyPrintDataTable(DataTable table)
            {
                Console.WriteLine(@"Table: {0}", table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataColumn dc in table.Columns)
                    {
                        sb.AppendFormat("{0} = {1}  ", dc.ColumnName, row.IsNull(dc) ? "null" : row[dc]);
                    }
                    Console.WriteLine(sb.ToString());
                }
            }

            #endregion "DataSet Loading examples"
        }
    }
}