using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Add();
            //Query();
            Edit();
            //Delete();

            #region 多条件查询

            //List<Lxrenb> lxrenbs = dblxrenb.Lxrenb.Where(m => m.lbdm == 0).Where(m =>
            //      (m.xm).Contains("胡") == true).OrderBy(m => m.xm).ToList();
            //foreach (var m in lxrenbs)
            //{
            //    Console.WriteLine(m.xm + "  " + m.xmsx + "  " + m.sjhm + "   " + m.qq + "   " + m.lbdm);
            //}

            #endregion 多条件查询

            #region 多条件查询,之延迟加载

            //DbQuery<Lxrenb> lxrs = dblxrenb.Lxrenb.Where(m => m.lbdm == 0).Where(m =>
            //         (m.xm).Contains("胡") == true).OrderBy(m => m.xm) as DbQuery<Lxrenb>;
            //foreach (var m in lxrs)
            //{
            //    Console.WriteLine(m.xm + "  " + m.xmsx + "  " + m.sjhm + "   " + m.qq + "   " + m.lbdm);
            //}

            #endregion 多条件查询,之延迟加载

            Console.WriteLine();
            Console.ReadKey();
        }

        private static readonly TXGLEntities Dblxrenb = new TXGLEntities();

        #region Insert操作

        private static void Add()
        {
            Lxrenb lxr = new Lxrenb { xm = "张杰", lbdm = 1, sjhm = "12345678912", qq = "123456789" };
            Dblxrenb.Lxrenb.Add(lxr);
            Dblxrenb.SaveChanges();
        }

        #endregion Insert操作

        #region Select查询

        private static void Query()
        {
            List<Lxrenb> myQuery = Dblxrenb.Lxrenb.Where(m => m.xm == "张杰").ToList();

            myQuery.ForEach(Printinfo);
        }



        private static void Printinfo(Lxrenb m)
        {
            Console.WriteLine(m.xm + "  " + m.xmsx + "  " + m.sjhm + "   " + m.qq + "   " + m.lbdm);
        }

        #endregion Select查询

        #region Update操作

        private static void Edit()
        {
            Lxrenb lxre = Dblxrenb.Lxrenb.FirstOrDefault(l => l.xm == "张杰");
            ShowInfo(lxre);
            lxre.xm = "胡睿毅";
            ShowInfo(lxre);
            Dblxrenb.SaveChanges();
        }

        #endregion Update操作

        #region Delete操作

        private static void Delete()
        {
            Lxrenb lxren = new Lxrenb { lxrenbh = 2652 };
            Dblxrenb.Lxrenb.Attach(lxren);
            Dblxrenb.Lxrenb.Remove(lxren);
            Dblxrenb.SaveChanges();
        }

        #endregion Delete操作

        public static void ShowInfo(Lxrenb m)
        {
            Console.WriteLine(m.xm + "  " + m.xmsx + "  " + m.sjhm + "   " + m.qq + "   " + m.lbdm);
        }
    }
}