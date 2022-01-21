using BlockBuster.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            List<Movie> movies = GetMovies();

            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
    }
}
