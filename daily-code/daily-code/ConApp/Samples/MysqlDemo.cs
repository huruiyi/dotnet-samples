using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ConApp.Samples
{
    internal class MysqlDemo
    {
        private static string conStr = "Data Source=172.22.12.172;database=vl_test;uid=chj;pwd=chj;Charset=utf8;Port=3306;";
        // static string conStr = "Data Source=localhost;database=world;uid=root;pwd=root;Charset=utf8;Port=3306;";

        #region 批量操作

        ///  <summary>
        /// 使用MySqlDataAdapter批量更新数据
        ///  </summary>
        /// <param name="table">数据表</param>
        public static void BatchUpdate(DataTable table)
        {
            MySqlConnection connection = new MySqlConnection(conStr);
            MySqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            MySqlCommandBuilder commandBulider = new MySqlCommandBuilder(adapter);
            commandBulider.ConflictOption = ConflictOption.OverwriteChanges;

            MySqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                //设置批量更新的每次处理条数
                adapter.UpdateBatchSize = table.Rows.Count;
                //设置事物
                adapter.SelectCommand.Transaction = transaction;

                if (table.ExtendedProperties["SQL"] != null)
                {
                    adapter.SelectCommand.CommandText = table.ExtendedProperties["SQL"].ToString();
                }
                adapter.Update(table);
                transaction.Commit();/////提交事务
            }
            catch (MySqlException)
            {
                transaction?.Rollback();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        ///  <summary>
        /// 大批量数据插入,返回成功插入行数
        ///  </summary>
        /// <param name="table">数据表</param>
        ///  <returns>返回成功插入行数</returns>
        public static int BulkInsert(DataTable table)
        {
            if (string.IsNullOrEmpty(table.TableName)) throw new Exception("请给DataTable的TableName属性附上表名称");
            if (table.Rows.Count == 0) return 0;
            string tmpPath = table.TableName + DateTime.Now.ToString("yyyy-MM-dd");
            string csv = DataTableToCsv(table);
            File.WriteAllText(tmpPath, csv);
            int insertCount;
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                MySqlTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    MySqlBulkLoader bulk = new MySqlBulkLoader(conn)
                    {
                        FieldTerminator = ",",
                        FieldQuotationCharacter = '"',
                        EscapeCharacter = '"',
                        LineTerminator = "\r\n",
                        FileName = tmpPath,
                        NumberOfLinesToSkip = 0,
                        TableName = table.TableName,
                    };
                    bulk.Columns.AddRange(table.Columns.Cast<DataColumn>().Select(colum => colum.ColumnName).ToList());
                    insertCount = bulk.Load();
                    tran.Commit();
                }
                catch (MySqlException)
                {
                    tran?.Rollback();
                    throw;
                }
            }
            //File.Delete(tmpPath);
            return insertCount;
        }

        /// <summary>
        ///将DataTable转换为标准的CSV
        /// </summary>
        /// <param name="table">数据表</param>
        /// <returns>返回标准的CSV</returns>
        private static string DataTableToCsv(DataTable table)
        {
            //以半角逗号（即,）作分隔符，列为空也要表达其存在。
            //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。
            //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        #endregion 批量操作

        public static void Demo2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string cmdText_t_dlvy_info = "SELECT * FROM t_vehicle_info where VIN='UDK2018BJBJ000601'";  //1
            DataSet dataSet = GetDateSet(cmdText_t_dlvy_info);
            if (dataSet == null || dataSet.Tables.Count <= 0)
            {
                return;
            }

            DataTable dataTablebuk = dataSet.Tables[0];
            dataTablebuk.TableName = "t_vehicle_info";

            DataRow dataRow = dataSet.Tables[0].Rows[0];
            DataRow inRow;

            for (int i = 0; i < 10000; i++)
            {
                inRow = dataTablebuk.NewRow();
                inRow.ItemArray = dataRow.ItemArray;
                inRow["Id"] = "0";
                inRow["vin"] = i;
                dataTablebuk.Rows.Add(inRow);
            }

            dataTablebuk.Rows.Remove(dataRow);
            BulkInsert(dataTablebuk);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private static DataSet GetDateSet(string cmdText)
        {
            DataSet ds = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(conStr))
            {
                connection.Open();
                using (DataAdapter adapter = new MySqlDataAdapter(cmdText, connection))
                {
                    adapter.Fill(ds);
                }
            }

            return ds;
        }
    }
}
