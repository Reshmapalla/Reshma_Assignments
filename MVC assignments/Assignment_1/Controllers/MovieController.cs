using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Assignment_1.Controllers
{
    public class MovieController : Controller
    {
        MovieRepository movieRepository;
        public MovieController()
        {
            movieRepository = new MovieRepository();
        }
        public IActionResult Index()
        {
            var movies = movieRepository.GetAllMovies();
            return View(movies);
        }
        public IActionResult Details(string name)
        {
            var movie = movieRepository.GetMovieByName(name);
            return View(movie);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            movieRepository.Add(movie);
            return RedirectToAction("Index");

        }
    }
}
