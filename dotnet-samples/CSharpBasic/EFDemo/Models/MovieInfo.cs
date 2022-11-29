using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Models
{
  public  class ViewMovieInfo
    {
        public long MovieId { get; set; }
        public string MovieName { get; set; }
        public decimal MoviePrice { get; set; }

        public long MoveTypeId { get; set; }
        public string MoveTypeName { get; set; }
    }
}
