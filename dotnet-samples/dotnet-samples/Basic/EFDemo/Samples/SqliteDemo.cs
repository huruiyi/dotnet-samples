using System.Data;
using System.Data.SQLite;

namespace EFDemo.Samples
{
    public class SqliteDemo
    {
        private const string SqliteFilePath = "sqlitedb.db";

        public static void SqLiteCreate()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    comm.CommandText = @"CREATE TABLE COMPANY(
                                                ID INTEGER PRIMARY KEY   AUTOINCREMENT,
                                                NAME           TEXT      NOT NULL,
                                                AGE            INT       NOT NULL,
                                                ADDRESS        CHAR(50),
                                                SALARY         REAL
                                            );";
                    comm.ExecuteNonQuery();
                }
            }
        }

        public static void SqLiteSelect()
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    //comm.Parameters.Clear();
                    comm.CommandText = "Select * From COMPANY";
                    //  comm.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' and name='COMPANY'";

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
        }

        public static void SqLiteInsert()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + SqliteFilePath))
            {
                using (SQLiteCommand comm = conn.CreateCommand())
                {
                    conn.Open();

                    #region 1.1插入数据

                    comm.CommandText = @"INSERT INTO COMPANY (NAME,AGE,ADDRESS,SALARY) VALUES ( 'Paul', 32, 'California', 20000.00 );";
                    comm.ExecuteNonQuery();

                    #endregion 1.1插入数据

                    #region 1.2使用参数插入数据

                    //comm.CommandText = "INSERT INTO COMPANY VALUES(@id,@name)";
                    //comm.Parameters.AddRange(
                    //    new[]
                    //    {
                    //        CreateSqliteParameter("@id", DbType.Int32, 4, 11),
                    //        CreateSqliteParameter("@name", DbType.String, 10, "Hello 11")
                    //    });
                    //comm.ExecuteNonQuery();

                    #endregion 1.2使用参数插入数据
                }
            }
        }

        public static SQLiteParameter CreateSqliteParameter(string name, DbType type, int size, object value)
        {
            SQLiteParameter parm = new SQLiteParameter(name, type, size) { Value = value };
            return parm;
        }
    }
}