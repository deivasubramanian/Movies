using AutoMapper;
using DataLibrary;
using DataLibrary.DataRepository;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    [AllowAnonymous]
    [Route("Movie")]  
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieController(ILogger<MovieController> logger, IMovieRepository repository, IMapper mapper)
        {
            _logger = logger; 
            _movieRepository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddComment")]
        public IActionResult UpdateComments([FromBody]CommentsViewModel model)
        {
            model.Date = DateTime.Now;
            var commentsDTO = _mapper.Map<CommentsViewModel, Comments>(model);
            bool success =_movieRepository.UpdateMovieComment(commentsDTO);
            if (!success)
            {
                _logger.LogError("Failed to save data");
            }
            var movie = _movieRepository.GetMovie(model.MovieID);
            var movieViewModel = _mapper.Map<Movie, MovieViewModel>(movie);

            return PartialView("~/Views/Home/_Comments.cshtml", movieViewModel);
        }
    }
}