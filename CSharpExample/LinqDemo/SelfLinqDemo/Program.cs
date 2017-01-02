using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SelfLinqDemo
{
    internal class Program
    {
        protected static IEnumerable<Fruit> Fruits { get; set; }

        static Program()
        {
            Fruits = new List<Fruit>()
            {
                new Fruit(07,"苹果", "红色" ),
                new Fruit(10,"橙子", "橙色" ),
                new Fruit(04,"葡萄", "绿色"),
                new Fruit(12,"无花果", "棕色" ),
                new Fruit(02,"葡萄干", "红色" ),
                new Fruit(10,"香蕉", "黄色" ),
                new Fruit(07,"樱桃", "红色" )
            };
        }

        private static void Main(string[] args)
        {
            DataTableEnumerable();
            Console.ReadKey();
        }

        #region Linq1-之简单类型

        private static void Demo1()
        {
            int[] numbers = { 11, 16, 11, 13, 14, 9 };
            IEnumerable<int> lowNums = from n in numbers
                                       where n % 2 == 0
                                       select n;
            foreach (var num in lowNums)
            {
                Console.WriteLine(num);
            }
        }

        #endregion Linq1-之简单类型

        #region Linq2-复杂类型

        private static void Demo2()
        {
            Person p1 = new Person { Name = "A", Age = 26, Sex = '男' };
            Person p2 = new Person { Name = "B", Age = 22, Sex = '男' };
            Person p3 = new Person { Name = "C", Age = 32, Sex = '男' };
            List<Person> ps = new List<Person> { p1, p2, p3 };

            var pss = from p in ps
                      where p.Age > 22
                      select p;
            foreach (var p in pss)
            {
                Console.WriteLine(p.Name);
            }
        }

        #endregion Linq2-复杂类型

        #region Linq3-Lamada表达式

        private static void Demo3()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where((m) => m.Substring(0, 1) == "f");
            shortDigits = digits.Where((m) => m.Length == 3);
            foreach (var s in shortDigits)
            {
                Console.WriteLine(s);
            }

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //Lamada表达式中第一个参数表示数组中的值,尔第二个参数是索引
            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });
            var numInSuoyin = numbers.Select((num, numa) => new { InPlace = (num + " " + numa) });
            var nu = numbers.Select((num) => new { InPlace = num });
            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine("{0}: {1}", n.Num, n.InPlace);
            }
            foreach (var n in numInSuoyin)
            {
                Console.WriteLine("{0}", n.InPlace);
            }
            foreach (var n in nu)
            {
                Console.WriteLine("{0}", n.InPlace);
            }
        }

        #endregion Linq3-Lamada表达式

        #region Linq4索引查找

        private static void Demo4()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var textNums = from n in numbers
                           select strings[n];
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        #endregion Linq4索引查找

        #region Linq5- select new

        private static void Demo5()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var upplow1 = from w in words
                          select new { Upper = w.ToUpper(), Lower = w.ToLower() };
            foreach (var ul in upplow1)
            {
                Console.WriteLine("大写: {0}, 小写: {1}", ul.Upper, ul.Lower);
            }
            Console.WriteLine("");
            var upplow2 = from m in words
                          select new { 大写单词 = m.ToUpper(), 小写单词 = m.ToLower() };
            foreach (var ul in upplow2)
            {
                Console.WriteLine("大写: {0}, 小写: {1}", ul.大写单词, ul.小写单词);
            }

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] strings = { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            var digitOddEvens = from n in numbers
                                select new { num = strings[n], Even = (n % 2 == 0) };
            foreach (var d in digitOddEvens)
            {
                Console.WriteLine("{1}   {0} ", d.num, d.Even ? "even" : "odd");
            }
        }

        #endregion Linq5- select new

        #region Linq6-Compare

        private static void Demo6()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };
            int aa = 0;
            foreach (var pair in pairs)
            {
                aa++;
                Console.WriteLine("{2}:::{0} is less than {1}", pair.a, pair.b, aa);
            }

            var pairs1 = from a in numbersA
                         from b in numbersB
                         select new { a, b };
            int aa1 = 0;
            foreach (var pair in pairs1)
            {
                aa1++;
                Console.WriteLine("{2}:::{0} is less than {1}", pair.a, pair.b, aa1);
            }
        }

        #endregion Linq6-Compare

        #region Linq7-查询指定条件的元素

        private static void Demo7()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var first3Numbers = numbers.Take(3);
            Console.WriteLine("前三个元素:");
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
            var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("All elements starting from first element divisible by 3:");
            foreach (var n in allButFirst3Numbers)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("第三个元素之后的元素:");
            var allButFirst4Numbers = numbers.Skip(3);
            foreach (var n in allButFirst4Numbers)
            {
                Console.Write(n + "  ");
            }
            Console.WriteLine();
            var lastjishu = numbers.LastOrDefault((m) => m % 2 != 0);
            Console.WriteLine("最后一个奇数:" + lastjishu);
            var last3e = numbers.LastOrDefault();
            Console.WriteLine("最后一个元素是:" + last3e);
            Console.WriteLine("最后一个元素是:" + numbers.Last()); ;
            var oushu = numbers.Where(m => m % 2 == 0);
            foreach (var n in oushu)
            {
                Console.WriteLine("{0}是偶数", n);
            }

            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
            Console.WriteLine("First numbers less than 6:");
            foreach (var n in firstNumbersLessThan6)
            {
                Console.WriteLine(n);
            }
            string[] fruits = { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
            IEnumerable<string> query = fruits.TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            query = fruits.TakeWhile((fruit, index) => fruit.Length >= index);
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }
        }

        #endregion Linq7-查询指定条件的元素

        #region Linq8-重点(联合查询)

        private static void Demo8()
        {
            Person p1 = new Person { Name = "A", Age = 26, Sex = '男' };
            Person p2 = new Person { Name = "B", Age = 22, Sex = '男' };
            Person p3 = new Person { Name = "C", Age = 32, Sex = '男' };
            List<Person> ps = new List<Person> { p1, p2, p3 };

            Student s1 = new Student { Name = "A", Sno = " 26", Hobby = "看书" };
            Student s2 = new Student { Name = "B", Sno = "22", Hobby = "花花" };
            Student s3 = new Student { Name = "C", Sno = "32", Hobby = "旅游" };
            List<Student> stus = new List<Student> { s1, s2, s3 };

            var StuInfo = from a in ps
                          from b in stus
                          where a.Name == b.Name
                          select new { a, b };
            foreach (var info in StuInfo)
            {
                Console.WriteLine(info.a.Name + "  " + info.a.Age + "  " + info.a.Sex + "  " + info.b.Sno + "  " + info.b.Hobby);
            }

            var StuInfo1 = from a in ps
                           from b in stus
                           where a.Name == b.Name
                           select new { a.Name, a.Sex, b.Sno, b.Hobby };
            foreach (var info in StuInfo1)
            {
                Console.WriteLine(info);
                Console.WriteLine(info.Sno + "  " + info.Name + "  " + info.Sex + " " + info.Hobby);
            }

            var StuInfo3 = (from a in ps
                            from b in stus
                            where a.Name == b.Name
                            select new { a, b }).Take(2);
            ;
            foreach (var info in StuInfo3)
            {
                Console.WriteLine(info.a.Name + "  " + info.a.Age + "  " + info.a.Sex + "  " + info.b.Sno + "  " + info.b.Hobby);
            }
        }

        #endregion Linq8-重点(联合查询)

        #region Linq9-Order By

        private static void Demo9()
        {
            Person p1 = new Person { Name = "A", Age = 26, Sex = '男' };
            Person p2 = new Person { Name = "B", Age = 22, Sex = '男' };
            Person p3 = new Person { Name = "H", Age = 32, Sex = '男' };
            Person p4 = new Person { Name = "C", Age = 21, Sex = '男' };
            List<Person> ps = new List<Person> { p1, p2, p3, p4 };

            Student s1 = new Student { Name = "A", Sno = "s26", Hobby = "看书" };
            Student s2 = new Student { Name = "B", Sno = "s22", Hobby = "花花" };
            Student s3 = new Student { Name = "C", Sno = "s32", Hobby = "旅游" };
            List<Student> stus = new List<Student> { s1, s2, s3 };

            var oy = from a in ps
                     orderby a.Age
                     select new { a };
            foreach (var p in oy)
            {
                Console.WriteLine(p.a.Name + "  " + p.a.Age + " " + p.a.Sex);
            }

            var oy1 = from a in ps
                      orderby a.Age
                      select a;
            foreach (var p in oy1)
            {
                Console.WriteLine(p.Name + "  " + p.Age + " " + p.Sex);
            }

            var oy2 = from a in ps
                      orderby a.Name
                      select a;
            foreach (var p in oy2)
            {
                Console.WriteLine(p.Name + "  " + p.Age + " " + p.Sex);
            }

            var oyinfo = from pr in ps
                         from stu in stus
                         where pr.Name == stu.Name
                         orderby pr.Age
                         select new { pr, stu };
            foreach (var i in oyinfo)
            {
                Console.WriteLine(i.stu.Sno + " " + i.stu.Name + i.stu.Hobby + " " + i.pr.Age);
            }

            string[] strs = { "aaa", "aaaa", "aa", "aaaaaaa", "a", "aaaaaa" };
            var lenstr = from a in strs
                         orderby a.Length
                         select a;
            foreach (string a in lenstr)
            {
                Console.WriteLine(a);
            }
        }

        #endregion Linq9-Order By

        public static void ToLookupDemo()
        {
            ILookup<string, Fruit> lookup = Fruits.ToLookup(e => e.Color);
            IEnumerator<IGrouping<string, Fruit>> groups = lookup.GetEnumerator();
            while (groups.MoveNext())
            {
                IGrouping<string, Fruit> group = groups.Current;
                Console.WriteLine("Group for {0}", group.Key);
                foreach (Fruit fruit in group)
                {
                    Console.WriteLine($"new Fruit({fruit.ShelfLife},{ fruit.Name},{fruit.Color})");
                }
                Console.WriteLine("\r\n");
            }
        }

        public static void ToDictionaryDemo()
        {
            Dictionary<string, Fruit> dictionary = Fruits.ToDictionary(e => e.Name);
            foreach (KeyValuePair<string, Fruit> kvp in dictionary)
            {
                Console.WriteLine("Name: {0} Color: {1} Shelf Life: {2} days.", kvp.Key, kvp.Value.Color, kvp.Value.ShelfLife);
            }
        }

        public static void DataTableEnumerable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Field0", typeof(int));
            table.Columns.Add("Field1", typeof(string));
            table.Columns.Add("Field2", typeof(string));
            table.Rows.Add(new object[] { 001, "f11", "f21" });
            table.Rows.Add(new object[] { 002, "f12", "f22" });
            table.Rows.Add(new object[] { 003, "f13", "f23" });
            table.Rows.Add(new object[] { 004, "f14", "f24" });
            table.Rows.Add(new object[] { 005, "f15", "f25" });
            table.Rows.Add(new object[] { 006, "f16", "f26" });
            table.Rows.Add(new object[] { 007, "f17", "f27" });
            table.Rows.Add(new object[] { 008, "f18", "f28" });
            table.Rows.Add(new object[] { 009, "f19", "f29" });

            IEnumerable<string> dtEnum = from e in table.AsEnumerable()
                                         select e.Field<string>("Field1");

            EnumerableRowCollection dFruit = from e in table.AsEnumerable()
                         select new
                         {
                             ShelfLife = e.Field<int>("Field0"),
                             Name = e.Field<string>("Field1"),
                             Color = e.Field<string>("Field2")
                         };
            foreach (string str in dtEnum)
            {
                Console.WriteLine("Element {0}", str);
            }
        }
    }
}