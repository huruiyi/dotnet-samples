using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name = "名称")]

        public string Name { get; set; }

        [Display(Name = "类别")]

        public string Genra { get; set; }

        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [Display(Name = "日期")]

        public DateTime Date { get; set; }
    }

    //实体框架的影片数据库内容，负责处理数据库中获取，存储和更新影片类的实例。
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}