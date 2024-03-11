using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Fairy.ConApp.Test
{
    public class SqlTest
    {
        private static readonly String ConStr = "Data Source=.;Initial Catalog=Management;User Id=sa;password=sa";

        public static void Test1()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand comm = connection.CreateCommand();
                comm.CommandText = "SELECT * From Test where Id in (1,2,3,4)";
                object refVal = comm.ExecuteScalar();
                Console.WriteLine(refVal);
            }
        }

        /// <summary>
        /// In 字符串
        /// </summary>
        public static void Test2()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                comm.CommandText = "exec('SELECT * From Test where Id in('+@IDS+')')";
                comm.Parameters.Add(new SqlParameter("@IDS", SqlDbType.VarChar, -1) { Value = "3,4" });

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + "  " + reader["Name"]);
                }
            }
        }

        public static void Test3()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                //使用CHARINDEX，实现参数化查询，可以复用查询计划，同时会使索引失效
                //comm.CommandText = "select * from Test(nolock) where CHARINDEX(','+ltrim(str(Id))+',',','+@Id+',')>0";
                //comm.CommandText = "select * from Test(nolock) where CHARINDEX(ltrim(str(Id)),','+@Id+',')>0";
                //comm.CommandText = "select * from Test(nolock) where CHARINDEX(ltrim(str(Id)),@Id)>0";

                //使用like，实现参数化查询，可以复用查询计划，同时会使索引失效
                comm.CommandText = "select * from Test(nolock) where ','+@Id+',' like  '%,'+ltrim(str(Id))+',%' ";
                comm.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar, -1) { Value = "1,4" });

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + "  " + reader["Name"]);
                }
            }
        }

        public static void Test4()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                comm.CommandText = "select * from Test(nolock) where Id in (@Id1,@Id2)";
                comm.Parameters.AddRange(
                    new SqlParameter[]{
                        new SqlParameter("@Id1", SqlDbType.Int) { Value = 4},
                        new SqlParameter("@Id2", SqlDbType.Int) { Value = 3}
                    });
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + "  " + reader["Name"]);
                }
            }
        }

        public static void Test5()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlCommand comm = connection.CreateCommand();
                string sql = @"
                    declare @Temp_Variable varchar(max)
                    create table #Temp_Table
                    (
                        Item varchar(max)
                    )
                    while(LEN(@Temp_Array) > 0)
                        begin
                            if (CHARINDEX(',', @Temp_Array) = 0)
                                begin
                                    set @Temp_Variable = @Temp_Array
                                    set @Temp_Array = ''
                                end
                            else
                                begin
                                    set @Temp_Variable = LEFT(@Temp_Array, CHARINDEX(',', @Temp_Array) - 1)
                                    set @Temp_Array = RIGHT(@Temp_Array, LEN(@Temp_Array) - LEN(@Temp_Variable) - 1)
                                end
                            insert into #Temp_Table(Item) values (@Temp_Variable)
                        end
                    select *
                    from Test (nolock)
                    where exists(select 1 from #Temp_Table (nolock) where #Temp_Table.Item = Test.Id)
                    drop table #Temp_Table ";
                comm.CommandText = sql;
                comm.Parameters.Add(new SqlParameter("@Temp_Array", SqlDbType.VarChar, -1) { Value = "1,2,3,4" });
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + "  " + reader["Name"]);
                }
            }
        }

        public static void Test6()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                string sql = "select * from Test order by Id desc";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                sqlDataAdapter.Fill(ds);
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row["Id"] + "   " + row["Name"]);
            }
        }

        public static void Test7()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            SqlTransaction sqlTrans = null;
            try
            {
                sqlConn.Open();
                using (sqlTrans = sqlConn.BeginTransaction())
                {
                    using (SqlCommand sqlCommand = sqlConn.CreateCommand())
                    {
                        sqlCommand.Transaction = sqlTrans;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandTimeout = 120;

                        sqlCommand.CommandText = "insert into dbo.TransTestTable values (77,'77');"; ;
                        sqlCommand.ExecuteNonQuery();

                        sqlCommand.CommandText = "update dbo.TransTestTable set [Name] = '777777777777777777777777777777777777777777777' where [Id] = 77;"; ;
                        sqlCommand.ExecuteNonQuery();
                        //throw new Exception("test exception.the transaction must rollback");

                        sqlTrans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (sqlTrans != null)
                {
                    sqlTrans.Rollback();
                }
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConn.State != ConnectionState.Closed)
                {
                    sqlConn.Close();
                }
            }

            Console.ReadLine();
        }

        public static void Test8()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                string insertSql = "insert into [TransTestTable] values(11,'11')";
                string updateSql = "update [TransTestTable] set [Name] = '11' where [Id] = 11";

                SqlCommand sqlComm = new SqlCommand(insertSql, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.ExecuteNonQuery();

                sqlComm = new SqlCommand(updateSql, sqlConn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.ExecuteNonQuery();

                sqlConn.Close();

                scope.Complete();
            }
        }

        //end
    }
}