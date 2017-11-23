using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFDemo
{
    internal class Program
    {
        private static void Main()
        {
            //Add();
            //Query();
            //Edit();
            //Delete();

            List<MovieInfo> list0 =
                (from minfo in DbEntities.Set<MovieInfo>()
                 join mtype in DbEntities.Set<MovieType>() on minfo.MovieTypeId equals mtype.Id
                 orderby minfo.Id
                 select minfo).ToList();

            List<ViewMovieInfo> list1 =
                (from mtype in DbEntities.Set<MovieType>()
                 from minfo in mtype.MovieInfo
                 select new ViewMovieInfo
                 {
                     MovieId = minfo.Id,
                     MovieName = minfo.Name,
                     MoviePrice = minfo.Price,
                     MoveTypeId = mtype.Id,
                     MoveTypeName = mtype.Name
                 }).ToList();

            DbSet<MovieType> dbSet = DbEntities.MovieType;
            List<MovieType> mt = dbSet.Where(m => m.Id == 3).ToList();

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
            //}0

            #endregion 多条件查询,之延迟加载

            Console.WriteLine();
            Console.ReadKey();
        }

        private static readonly ExampleDbEntities DbEntities = new ExampleDbEntities();

        #region Insert操作

        private static void Add()
        {
            Lxrenb lxr = new Lxrenb { xm = "张杰", lbdm = 1, sjhm = "12345678912", qq = "123456789" };
            DbEntities.Lxrenb.Add(lxr);
            DbEntities.SaveChanges();
        }

        #endregion Insert操作

        #region Select查询

        private static void Query()
        {
            List<Lxrenb> myQuery = DbEntities.Lxrenb.Where(m => m.xm == "张杰").ToList();

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
            Lxrenb lxre = DbEntities.Lxrenb.FirstOrDefault(l => l.xm == "张杰");
            ShowInfo(lxre);
            lxre.xm = "胡睿毅";
            ShowInfo(lxre);
            DbEntities.SaveChanges();
        }

        #endregion Update操作

        #region Delete操作

        private static void Delete()
        {
            Lxrenb lxren = new Lxrenb { lxrenbh = 2652 };
            DbEntities.Lxrenb.Attach(lxren);
            DbEntities.Lxrenb.Remove(lxren);
            DbEntities.SaveChanges();
        }

        #endregion Delete操作

        public static void ShowInfo(Lxrenb m)
        {
            Console.WriteLine(m.xm + "  " + m.xmsx + "  " + m.sjhm + "   " + m.qq + "   " + m.lbdm);
        }
    }
}