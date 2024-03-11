using System.Collections.Generic;

namespace IOC.V3.MovieFinder
{
    public class DbMovieFinder : IMovieFinder
    {
        public List<Movie> FindAll()
        {
            return new List<Movie>
                       {
                           new Movie
                               {
                                   Name = "Die Hard.wmv"
                               },
                           new Movie
                               {
                                   Name = "Resident Evil: Retribution.MPG"
                               }
                       };
        }
    }
}