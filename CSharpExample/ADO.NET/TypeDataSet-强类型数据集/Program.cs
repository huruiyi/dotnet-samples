using System;

namespace TypeDataSet_强类型数据集
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NorthwindDataSet.CustomersDataTable sss = new NorthwindDataSet.CustomersDataTable();
            NorthwindDataSetTableAdapters.CustomersTableAdapter ss = new NorthwindDataSetTableAdapters.CustomersTableAdapter();
            ss.Fill(sss);
            foreach (NorthwindDataSet.CustomersRow ct in sss.Rows)
            {
                Console.WriteLine(ct.CustomerID + "  " + ct.CompanyName);
            }

            NorthwindDataSet nds = new NorthwindDataSet();

            NorthwindDataSetTableAdapters.CustomersTableAdapter ndsAdapter = new NorthwindDataSetTableAdapters.CustomersTableAdapter();
            ndsAdapter.Fill(nds.Customers);

            //foreach (NorthwindDataSet.CustomersRow ct in nds.Customers.Rows)
            //{
            //    Console.WriteLine(ct.CustomerID + "  " + ct.CompanyName);
            //}
            //Console.WriteLine("********************************************");

            NorthwindDataSetTableAdapters.OrdersTableAdapter ordTblApt = new NorthwindDataSetTableAdapters.OrdersTableAdapter();
            ordTblApt.Fill(nds.Orders);
            //foreach (NorthwindDataSet.OrdersRow ordRow in nds.Orders.Rows)
            //{
            //    Console.WriteLine(ordRow.CustomerID + "  " + ordRow.OrderID + "  " + ordRow.OrderDate);
            //}
            //Console.WriteLine("********************************************");

            //DataRow CustomersdrALFKI = nds.Customers.Rows.Find("ALFKI");
            //Console.WriteLine(CustomersdrALFKI["CompanyName"]);
            //Console.WriteLine("********************************************");

            ////通过Customers表中的CustomerID(主键)查找Orders表中对应的数据
            //NorthwindDataSet.CustomersRow cusRow1 = (NorthwindDataSet.CustomersRow)nds.Customers.Rows.Find("WOLZA");
            //NorthwindDataSet.CustomersRow cusRow = nds.Customers.FindByCustomerID("WOLZA");
            //foreach (var rowResult in cusRow.GetOrdersRows())
            //{
            //    Console.WriteLine(rowResult.OrderID + " " + rowResult.OrderDate + "  " + rowResult.CustomerID);
            //}
            //Console.WriteLine("********************************************");

            ////通过Orders表中的CustomerID(外键)查找Customers表中的数据
            //NorthwindDataSet.OrdersRow ordRowResult = (NorthwindDataSet.OrdersRow)nds.Orders.Rows.Find("10374");
            //Console.WriteLine(ordRowResult.CustomerID);
            //Console.WriteLine(ordRowResult.OrderDate);
            ////修改数据
            //NorthwindDataSet.CustomersRow cr = ordRowResult.CustomersRow;
            //Console.WriteLine(cr.CustomerID);
            //Console.WriteLine(cr.CompanyName);
            //cr.CompanyName = "name19:44";
            //ndsAdapter.Update(cr);
            //Console.WriteLine(cr.CompanyName);
            //Console.WriteLine("********************************************");

            ////修改数据
            //NorthwindDataSet.CustomersRow cusRow = nds.Customers.FindByCustomerID("WOLZA");
            //cusRow.CompanyName = "MyCompanyName";
            //ndsAdapter.Update(cusRow);
            //Console.WriteLine(cusRow.CompanyName);
            //Console.WriteLine("********************************************");

            ////添加一行数据
            //NorthwindDataSet.CustomersRow newRow = nds.Customers.AddCustomersRow("aMyID", "aMyName");
            //ndsAdapter.Update(newRow);
            //Console.WriteLine("********************************************");

            ndsAdapter.Delete("aMyID", "aMyName");

            //NorthwindDataSet.OrdersRow ordRowResult = (NorthwindDataSet.OrdersRow)nds.Orders.Rows.Find(10374);
            //ordRowResult.SetOrderDateNull();
            //ordTblApt.Update(ordRowResult);
            //if (ordRowResult.IsOrderDateNull())
            //{
            //    Console.WriteLine("Null");
            //}
            //else
            //{
            //    Console.WriteLine("Not Null");
            //}

            //string ins = "insert into Customers( CustomerID,CompanyName,City,Country) values( 'a','b','c','d')";
            //string Constring = "Data Source=.;Initial Catalog=Northwind;User ID=sa;Password=sa";
            //SqlConnection con = new SqlConnection(Constring);
            //DataSet ds = new DataSet();
            //SqlDataAdapter sda = new SqlDataAdapter(ins, con);
            //SqlCommandBuilder bulider = new SqlCommandBuilder(sda);
            //sda.Fill(ds);

            Console.ReadKey();
        }
    }
}