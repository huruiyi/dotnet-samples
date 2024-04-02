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
