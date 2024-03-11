using System;
using System.Data;
using System.Linq;

namespace ConApp
{
    public class DataTableDemo
    {
        public static void DataTableDemo0()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Resource_Id"),
                new DataColumn("TA"),
                new DataColumn("TB"),
                new DataColumn("TC"),
                new DataColumn("TD")
            });
            table.Rows.Add(1, 1, 2, 0, 0);
            table.Rows.Add(1, 3, 0, 3, 4);
            table.Rows.Add(2, 5, 6, 0, 0);
            table.Rows.Add(2, 7, 0, 7, 8);

            var aa = from t in table.AsEnumerable()
                     group t by new { t1 = t.Field<string>("Resource_Id") } into m
                     select new
                     {
                         name = m.Key.t1,
                         score = m.Sum(n => n.Field<decimal>("TA"))
                     };
        }

        public static void DataTableDemo1()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("name", typeof(string)),
                new DataColumn("sex", typeof(string)),
                new DataColumn("score", typeof(int))
            });
            dt.Rows.Add(new object[] { "张三", "男", 26 });
            dt.Rows.Add(new object[] { "张三", "男", 40 });
            dt.Rows.Add(new object[] { "李四", "男", 10 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            DataTable dtResult = dt.Clone();
            DataTable dtName = dt.DefaultView.ToTable(true, "name", "sex");
            for (int i = 0; i < dtName.Rows.Count; i++)
            {
                DataRow[] rows = dt.Select("name='" + dtName.Rows[i]["name"] + "' and sex='" + dtName.Rows[i]["sex"] + "'");
                //temp用来存储筛选出来的数据
                DataTable temp = dtResult.Clone();
                foreach (DataRow row in rows)
                {
                    temp.Rows.Add(row.ItemArray);
                }

                DataRow dr = dtResult.NewRow();
                dr[0] = dtName.Rows[i][0].ToString();
                dr[1] = temp.Compute("sum(score)", "");
                dtResult.Rows.Add(dr);
            }
        }

        public static void DataTableDemo2()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("name", typeof(string)),
                                         new DataColumn("sex", typeof(string)),
                                         new DataColumn("score", typeof(decimal)) });
            dt.Rows.Add(new object[] { "张三", "男", 1 });
            dt.Rows.Add(new object[] { "张三", "男", 4 });
            dt.Rows.Add(new object[] { "李四", "男", 100 });
            dt.Rows.Add(new object[] { "李四", "女", 90 });
            dt.Rows.Add(new object[] { "王五", "女", 77 });
            var query = from t in dt.AsEnumerable()
                        group t by new { t1 = t.Field<string>("name"), t2 = t.Field<string>("sex") } into m
                        select new
                        {
                            name = m.Key.t1,
                            sex = m.Key.t2,
                            score = m.Sum(n => n.Field<decimal>("score"))
                        };
            if (query.ToList().Count > 0)
            {
                query.ToList().ForEach(q =>
                {
                    Console.WriteLine(q.name + "," + q.sex + "," + q.score);
                });
            }
        }
    }
}