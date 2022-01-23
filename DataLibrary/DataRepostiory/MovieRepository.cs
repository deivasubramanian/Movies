using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDataContext _dbContext;
        public MovieRepository(MovieDataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies;
        }
        public Movie? GetMovie(int id)
        {
            if (_dbContext.Movies == null)
                return null;
            var movie = _dbContext.Movies.SingleOrDefault(p => p.MovieID == id);
            return movie;
        }
        public bool UpdateMovieComment(Comments comments)
        {
            Movie movieToSave = GetMovie(comments.MovieID);
            if (movieToSave == null)
            {
                return false;
            }
            if(movieToSave.Comments == null)
            {
                movieToSave.Comments = new List<Comments>();
            }
            movieToSave.Comments.Add(new Comments()
            {
                Author = comments.Author,
                Date = DateTime.Now,
                Text = comments.Text,
                MovieID = comments.MovieID
            });
            _dbContext.Update(movieToSave);
            return _dbContext.SaveChanges() > 1 ? true : false;

        }
    }
}
