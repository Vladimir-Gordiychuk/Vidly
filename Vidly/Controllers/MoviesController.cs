using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        public ActionResult Details(int id)
        {
            var movie = _context
                .Movies
                .Include(mov => mov.Genre)
                .SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
            {
                return HttpNotFound("Specified movie was not found.");
            }
            else
            {
                return View(movie);
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            return MovieForm(null);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(mov => mov.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return MovieForm(movie);
        }

        private ActionResult MovieForm(Movie movie)
        {
            var viewModel = movie == null
                ? new MovieFormViewModel()
                : new MovieFormViewModel(movie);

            viewModel.Genres = _context.Genres.ToList();

            return View("MovieForm", viewModel);
        }

        public ActionResult Random()
        {
            var movie = new Movie
            {
                Id = 1,
                Name = "Shrek"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Jack" },
                new Customer { Name = "Lily" },
                new Customer { Name = "Christie" },
                new Customer { Name = "Jeff" },
                new Customer { Name = "Derek" },
                new Customer { Name = "Thomas" }
            };

            return View(new RandomMovieViewModel {
                Movie = movie,
                Customers = customers
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return MovieForm(movie);
            }

            if (movie.Id == 0)
            {
                // Add a new Movie to DataBase

                movie.Genre = null;
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(mov => mov.Id == movie.Id);

                existingMovie.Genre = null;
                existingMovie.Name = movie.Name;
                existingMovie.GenreId = movie.GenreId;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Route("movies/released/{year:regex(\\d{4}):min(1800)}")]
        public ActionResult ByReleaseDate(int year)
        {
            return View("Index",
                _context
                .Movies
                .Where(movie => movie.ReleaseDate.Year == year)
                .Include(mov => mov.Genre)
                .ToList());
        }

        [Route("movies/released/{year:regex(\\d{4}):min(1800)}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return View("Index",
                _context
                .Movies
                .Where(movie => movie.ReleaseDate.Year == year && movie.ReleaseDate.Month == month)
                .Include(mov => mov.Genre)
                .ToList());
        }
    }
}