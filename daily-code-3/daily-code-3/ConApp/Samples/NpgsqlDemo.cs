using System;
using Npgsql;

namespace ConApp.Samples
{
    public class NpgsqlDemo
    {
        private static void Npgsql_Insert_Demo()
        {
            Console.WriteLine("Hello World!");

            var connString = "Host=127.0.0.1;Username=npgsql_tests;Password=npgsql_tests;Database=npgsql_tests";

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine(conn.State);
                    // Insert some data
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO public.\"Product\"(\"Id\", \"Name\")VALUES (18, 'Postgresql数据库');";
                        //cmd.CommandText = "INSERT INTO public.\"Product\"(\"Id\", \"Name\")VALUES (8, @pname);";
                        //cmd.Parameters.AddWithValue("pname", "蓝天白云");
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.Write("插入数据成功");
                        }
                        else
                        {
                            Console.Write("插入数据失败");
                        }
                    }

                    // Retrieve all rows
                    using (var cmd = new NpgsqlCommand("SELECT * FROM public.\"Product\" ORDER BY \"Id\" ASC ", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0) + "  " + reader.GetString(1));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}