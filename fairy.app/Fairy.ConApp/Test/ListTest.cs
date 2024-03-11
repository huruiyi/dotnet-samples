using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fairy.ConApp.Model.List;

namespace Fairy.ConApp.Test
{
    public class ListTest
    {
        private static void Test()
        {
            List<Budge> list = new List<Budge>
            {
                new Budge {Year = "2018",Accd = "12"},
                new Budge {Year = "2018",Accd = "11"},
                new Budge {Year = "2012",Accd = "1"},
                new Budge {Year = "2013",Accd = "2"},
                new Budge {Year = "2018",Accd = "3"},
            };
            Type type = typeof(Budge);
            PropertyInfo p = type.GetProperty("BgYear");
            Console.WriteLine(list.Distinct(m => m.Year).Count());
            Console.WriteLine(list.Distinct(m => m.Accd).Count());
            ;
            int length = list.Distinct(new ObjStringCompare(p)).Count();
            Console.WriteLine(length);
            Console.ReadKey();
        }
    }
}