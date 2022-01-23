using AutoMapper;
using DataLibrary;
using DataLibrary.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
  
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, IMapper mapper)
        {
            _logger = logger;
            _movieRepository = repository;
            _mapper = mapper;


        }

        public IActionResult Index()
        {

            var movies = _movieRepository.GetAllMovies();
            var listToReturn = _mapper.Map<IEnumerable<DataLibrary.Models.Movie>, IEnumerable<MovieViewModel>>(movies);


            return View(listToReturn);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}