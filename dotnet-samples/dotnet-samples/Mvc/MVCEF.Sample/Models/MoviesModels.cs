using System;
using System.Data.Entity;

namespace MVCEF.Sample.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    #region MovieDB SQL Srcipt

    /*
  use [ExampleDb]
  go

  set ansi_nulls on
  go

  set quoted_identifier on
  go

  create table [dbo].[Movies](
      [ID] [int] identity(1,1) not null,
      [Title] [nvarchar](max) null,
      [ReleaseDate] [datetime] not null,
      [Genre] [nvarchar](max) null,
      [Price] [decimal](18, 2) not null,
   constraint [PK_dbo.Movies] primary key clustered
  (
      [ID] asc
  )with (pad_index = off, statistics_norecompute = off, ignore_dup_key = off, allow_row_locks = on, allow_page_locks = on) on [PRIMARY]
  ) on [PRIMARY] textimage_on [PRIMARY]

  go
   */

    #endregion MovieDB SQL Srcipt

    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}