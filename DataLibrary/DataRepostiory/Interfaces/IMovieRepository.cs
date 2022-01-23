using DataLibrary.Models;

namespace DataLibrary.DataRepository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie? GetMovie(int id);
        bool UpdateMovieComment(Comments comments);
    }
}