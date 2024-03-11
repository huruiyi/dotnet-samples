using System;
using Unity;

namespace ConApp.Samples
{
    public interface IOtherHelper
    {
        string GetSqlConnection();
    }

    public class MyOtherHelper : IOtherHelper
    {
        private readonly ISqlHelper sql;

        public MyOtherHelper(ISqlHelper sql)
        {
            this.sql = sql;
        }

        public string GetSqlConnection()
        {
            return this.sql.SqlConnection();
        }
    }

    public interface ISqlHelper
    {
        string SqlConnection();
    }

    public class MssqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mssql.";
        }
    }

    public class MysqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mysql.";
        }
    }

    public class IOCUnity
    {
        public static void Demo1()
        {
            IUnityContainer container = new UnityContainer();

            //mysql
            container.RegisterType<ISqlHelper, MysqlHelper>();
            ISqlHelper mysql = container.Resolve<ISqlHelper>();
            Console.WriteLine(mysql.SqlConnection());

            //mssql
            container.RegisterType<ISqlHelper, MssqlHelper>();
            ISqlHelper mssql = container.Resolve<ISqlHelper>();
            Console.WriteLine(mssql.SqlConnection());
        }

        public static void Demo2()
        {
            IUnityContainer container = new UnityContainer();

            //mysql
            container.RegisterType<ISqlHelper, MysqlHelper>();
            container.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mysql = container.Resolve<IOtherHelper>();
            Console.WriteLine(mysql.GetSqlConnection());

            //mssql
            container.RegisterType<ISqlHelper, MssqlHelper>();
            container.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mssql = container.Resolve<IOtherHelper>();
            Console.WriteLine(mssql.GetSqlConnection());
        }

        public static void Demo3()
        {
            IUnityContainer container = new UnityContainer();

            //mysql
            container.RegisterInstance<ISqlHelper>(new MysqlHelper());
            container.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mysql = container.Resolve<IOtherHelper>();
            Console.WriteLine(mysql.GetSqlConnection());

            //mssql
            container.RegisterInstance<ISqlHelper>(new MssqlHelper());
            container.RegisterType<IOtherHelper, MyOtherHelper>();
            IOtherHelper mssql = container.Resolve<IOtherHelper>();
            Console.WriteLine(mssql.GetSqlConnection());
        }
    }
}