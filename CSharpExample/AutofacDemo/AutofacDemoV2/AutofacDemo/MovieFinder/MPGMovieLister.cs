using System.Linq;

namespace AutofacDemo.MovieFinder
{
    public class MPGMovieLister
    {
        private readonly IMovieFinder _movieFinder;

        public MPGMovieLister(IMovieFinder movieFinderzzzzzzzzzz)
        {
            _movieFinder = movieFinderzzzzzzzzzz;
        }

        public Movie[] GetMPG()
        {
            var allMovies = _movieFinder.FindAll();
            return allMovies.Where(m => m.Name.EndsWith(".MPG")).ToArray();
        }
    }
}