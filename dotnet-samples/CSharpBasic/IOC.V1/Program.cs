using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace IOC.V1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Add

            //            Console.WriteLine("请输入用户名");
            //            string name = Console.ReadLine();
            //            Console.WriteLine("请输入密码：");
            //            string password = Console.ReadLine();
            //            string Constr = "Data Source=.;Initial Catalog=MySchoolBase;uid=sa;pwd=sa";
            //            using (SqlConnection con = new SqlConnection(Constr))
            //            {
            //                string sql = @"select count(*) from Admin where LoginID=@loginid
            //                                                       and LoginPwd=@loginpwd";
            //                using (SqlCommand cmd = new SqlCommand(sql, con))
            //                {
            //                    SqlParameter na = new SqlParameter("@loginid", name);
            //                    SqlParameter pa = new SqlParameter("@loginpwd", password);
            //                    cmd.Parameters.Add(na);
            //                    cmd.Parameters.Add(pa);

            //                    con.Open();
            //                    int resulr = Convert.ToInt32(cmd.ExecuteScalar());
            //                    if (resulr > 0)
            //                    {
            //                        Console.WriteLine("查询数据存在");
            //                    }

            //                }
            //            }

            #endregion Add

            #region AddRange

            //            Console.WriteLine("请输入用户名");
            //            string name = Console.ReadLine();
            //            Console.WriteLine("请输入密码：");
            //            string password = Console.ReadLine();
            //            string Constr = "Data Source=.;Initial Catalog=MySchoolBase;uid=sa;pwd=sa";
            //            using (SqlConnection con = new SqlConnection(Constr))
            //            {
            //                string sql = @"select count(*) from Admin where LoginID=@loginid
            //                                                       and LoginPwd=@loginpwd";
            //                using (SqlCommand cmd = new SqlCommand(sql, con))
            //                {
            //                    SqlParameter na = new SqlParameter("@loginid", name);
            //                    SqlParameter pa = new SqlParameter("@loginpwd", password);
            //                    SqlParameter[] parameters = { na, pa };
            //                    parameters[0].Value = name;
            //                    parameters[1].Value = password;
            //                    cmd.Parameters.AddRange(parameters);

            //                    con.Open();
            //                    int resulr = Convert.ToInt32(cmd.ExecuteScalar());
            //                    if (resulr > 0)
            //                    {
            //                        Console.WriteLine("查询数据存在");
            //                    }

            //                }
            //            }

            #endregion AddRange

            #region AddWithValue

            //Console.WriteLine("请输入用户名");
            //string name = Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string password = Console.ReadLine();
            //const string constr = "Data Source=.;Initial Catalog=MySchoolBase;uid=sa;pwd=sa";
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    const string sql = @"select count(*) from Admin where LoginID=@loginid and LoginPwd=@loginpwd";
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        cmd.Parameters.AddWithValue("@loginid", name);
            //        cmd.Parameters.AddWithValue("@loginpwd", password);
            //        con.Open();
            //        int resulr = Convert.ToInt32(cmd.ExecuteScalar());
            //        if (resulr > 0)
            //        {
            //            Console.WriteLine("查询数据存在");
            //        }
            //    }
            //}

            #endregion AddWithValue

            var builder = new ContainerBuilder();
            builder.RegisterType<DataBaseManager>();
            builder.RegisterType<OracleDataBaseDal>().As<IDataBaseDal>();

            using (var container = builder.Build())
            {
                var manager = container.Resolve<DataBaseManager>();
                manager.Search("select * from Users");
            }

            Console.ReadKey();
        }
    }
}