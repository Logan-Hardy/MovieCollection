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
            //Check for validity
            if (ModelState.IsValid)
            {

                //Here is where we need to create the object with the model
                _context.Movies.Add(movie);
                _context.SaveChanges();

                //Redirect to confirmation page, saying the movie has been added
                return RedirectToAction("AddConfirmation");
            }
            else
            {
                //if model isn't valid, return to the same view and send back the movie info they inputted
                //this makes it easier so they don't have to repeat the info and can make the change(s) they need to 
                return View("AddMovie", movie);
            }
        }

        //Confirmations 
        public IActionResult AddConfirmation()
        {
            return View();
        }
        public IActionResult EditConfirmation()
        {
            return View();
        }
        public IActionResult DeleteConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            //Check for validity
            if (ModelState.IsValid)
            {
                //update the context with changes made to the movie
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
                //if user wants to edit a movie, pass that movie information to the EditMovie 
                var EditMovie = _context.Movies.Where(m => m.MovieId == movieId).FirstOrDefault();
                return View("EditMovie", EditMovie);
            }
            else if (actionType == "Delete")
            {
                //if user wants to delete a movie, remove it from context by MovieId
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
