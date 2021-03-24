using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using MovieCollection.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iMovieRepository _repository;
        private MovieDbContext _context;

        public int ItemsPerPage = 10;

        public HomeController(ILogger<HomeController> logger, iMovieRepository repository, MovieDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            //Here is where we need to create the object with the model
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("AddConfirmation");
            }
            else
            {
               return View("AddMovie", movie);
            }
        }

        public IActionResult AddConfirmation()
        {
            return View("Confirmation");
        }
        public IActionResult EditConfirmation()
        {
            return View("Confirmation");
        }
        public IActionResult DeleteConfirmation()
        {
            return View("Confirmation");
        }

        [HttpGet]
        public IActionResult FindMovieToEdit(int pageNum)
        {
            return View(new MovieListViewModel
            {
                Movies = _repository.Movies
                .OrderBy(p => p.MovieTitle)
                .Skip((pageNum - 1) * ItemsPerPage)
                .Take(ItemsPerPage),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = ItemsPerPage,
                    TotalNumItems = _repository.Movies.Count()
                }
            });
        }

        [HttpPost]
        public IActionResult FindMovieToEdit(int movieId, string actionType)
        {
            //ViewBag["actionType"] = actionType;
            if (actionType == "Edit")
            {
                var EditMovie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
                return View("EditMovie", EditMovie);
            }
            else if (actionType == "Delete")
            {
                _context.Remove(_context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault());
                _context.SaveChanges();
                return View("DeleteConfirmation");
            }
            else
            {
                return View();
            }
       
        }

        [HttpGet]
        public IActionResult EditMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {

            //Here is where we need to create the object with the model
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();

                return RedirectToAction("EditConfirmation");
            }
            else
            {
                return View("EditMovie", movie);
            }
        }

        [HttpGet]
        public IActionResult MovieList(int pageNum = 1)
        {
            return View(new MovieListViewModel
            {
                Movies = _repository.Movies
                .OrderBy(p => p.MovieTitle)
                .Skip((pageNum - 1) * ItemsPerPage)
                .Take(ItemsPerPage),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = ItemsPerPage,
                    TotalNumItems = _repository.Movies.Count()
                }
            });
        }

        [HttpPost]
        public IActionResult MovieList(int movieId, string actionType)
        {
            if (actionType == "Edit")
            {
                var EditMovie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
                return View("EditMovie", EditMovie);
            }
            else if (actionType == "Delete")
            {
                _context.Remove(_context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault());
                _context.SaveChanges();
                return View("DeleteConfirmation");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Podcasts()
        {
            return View();
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
