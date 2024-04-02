using System.Linq;

namespace IOC.V3.MovieFinder
{
    public class MpgMovieLister
    {
        private readonly IMovieFinder _movieFinder;

        public MpgMovieLister(IMovieFinder movieFinder)
        {
            _movieFinder = movieFinder;
        }

        public Movie[] GetMPG()
        {
            var allMovies = _movieFinder.FindAll();
            return allMovies.Where(m => m.Name.EndsWith(".MPG")).ToArray();
        }
    }
}