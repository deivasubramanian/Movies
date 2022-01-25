using AutoMapper;
using DataLibrary.Models;
using Movies.DTOMapper;
using Movies.Models;
using System.Collections.Generic;
using Xunit;
using ExpectedObjects;
namespace UnitTests
{
    public class AutomapperTest
    {
        private static IMapper _mapper;
  
        public AutomapperTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MovieMapperProile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void TestMapper()
        {
            var movieEntity = new Movie
            {
               Year = 2020,
               Title = "Test",
                Comments = new List<Comments>
                {
                    new Comments
                    {
                        Author = "author1"
                    },
                    new Comments
                    {
                       Author = "author2"
                    }
                }
            };

            var expected = new MovieViewModel
            {
                Year = 2020,
                Title = "Test",
                Comments = new List<CommentsViewModel>
                {
                     new CommentsViewModel
                    {
                        Author = "author1"
                    },
                    new CommentsViewModel
                    {
                       Author = "author2"
                    }
                }
            }.ToExpectedObject();//;extension used with unit tests to compare objects

            var movie = _mapper.Map<MovieViewModel>(movieEntity);

            expected.ShouldEqual(movie);

        }
    }
}