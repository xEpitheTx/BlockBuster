﻿using BlockBuster.Data;
using BlockBuster.Models;
using BlockBuster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        private const string formViewName = "MovieForm";
        public MoviesController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie is null)
            {
                return StatusCode(404);
            }

            return View(movie);
        }
        public ActionResult NewMovie()
        {
            List<Genre>? genres = _context.Genres.ToList();
            MovieFormViewModel? viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View(formViewName, viewModel);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie is null)
            {
                return StatusCode(404);
            }

            MovieFormViewModel? viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View(formViewName, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
#if DEBUG
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
#endif

            bool diditwork = ModelState.Remove("movie.Genre"); //I have no idea why MembershipType is required and this is a shameless hack
            if (!ModelState.IsValid)
            {
                MovieFormViewModel? viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View(formViewName, viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            else
            {
                UpdateExistingMovie(movie);
            }

            return RedirectToAction("Index", "Movies");
        }

        private void UpdateExistingMovie(Movie movie)
        {
            Movie? movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            if (movieInDb != null)
            {
                //Couldn't get mapper to work, sadness
                //customerInDb = _mapper.Map<Customer>(customerInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreID = movie.GenreID;
                movieInDb.Stock = movie.Stock;

                _context.SaveChanges();
            }
            else
            {
                //throw error customer not found
            }
        }
    }
}
