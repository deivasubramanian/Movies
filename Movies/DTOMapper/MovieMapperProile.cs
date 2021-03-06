using Movies.Models;
using DataLibrary.Models;
using AutoMapper;
namespace Movies.DTOMapper
{
    public class MovieMapperProile: Profile
    {
        public MovieMapperProile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<Comments, CommentsViewModel>().ReverseMap();
        }

    }
}
