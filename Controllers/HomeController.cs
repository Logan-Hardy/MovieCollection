using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
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
            //if ()
            return View();
        }

        [HttpGet]
        public IActionResult FindMovieToEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindMovieToEdit(int MovieId)
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
            return View();
        }

        public IActionResult MovieList()
        {
            return View();
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
