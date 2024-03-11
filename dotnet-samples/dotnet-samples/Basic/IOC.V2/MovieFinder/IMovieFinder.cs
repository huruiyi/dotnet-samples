using System.Collections.Generic;

namespace IOC.V2.MovieFinder
{
    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }
}