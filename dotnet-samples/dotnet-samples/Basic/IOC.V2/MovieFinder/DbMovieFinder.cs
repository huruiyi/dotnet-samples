using System.Collections.Generic;

namespace IOC.V2.MovieFinder
{
    public class DBMovieFinder : IMovieFinder
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