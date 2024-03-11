using System.Collections.Generic;

namespace IOC.V3.MovieFinder
{
    public interface IMovieFinder
    {
        List<Movie> FindAll();
    }
}