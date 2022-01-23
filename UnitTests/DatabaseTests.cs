using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class DatabaseTests : IDisposable
    {
        private MovieDataContext _dbcontext;
        public DatabaseTests()
        {
            _dbcontext = new MovieDataContext(new DbContextOptionsBuilder<MovieDataContext>()
               .UseInMemoryDatabase("MoviesTest")
               .Options);

            _dbcontext.Movies.AddRange(
                    new DataLibrary.Models.Movie
                    {
                        Year = 2021,
                        Title = "Test title",
                        Duration = 2,
                        Popularity = 1,
                        Rating = 2,
                        MovieID  = 8

                    });
            _dbcontext.SaveChanges();


        }

        [Fact]
        public void Can_add_comment()
        {
            var Comment = new DataLibrary.Models.Comments
            {
                Author =   "testAuthor",
                Text = "test",
                MovieID =8,
                Date = DateTime.Now,
            };

            var movie  = _dbcontext.Movies.SingleOrDefault(p=>p.MovieID == Comment.MovieID);
            Assert.NotNull(movie);
            movie.Comments.Add(Comment);
            
            Assert.NotEmpty(movie.Comments);
            Assert.NotEmpty(_dbcontext.Movies.ToArray()[0].Comments);
            Assert.Equal(_dbcontext.Movies.ToArray()[0].Comments.Count, 1);
        }

        public void Dispose()
        {
            _dbcontext?.Dispose();
        }
    }
}
