using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext entryContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            entryContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var entries = entryContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();

            return View(entries);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = entryContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieEntry movie)
        {
            if (ModelState.IsValid)
            {
                entryContext.Add(movie);
                entryContext.SaveChanges();

                return View("Confirmation", movie);
            }

            else //if invalid
            {
                ViewBag.Categories = entryContext.Categories.ToList();

                return View(movie);
            }

        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = entryContext.Categories.ToList();

            var entry = entryContext.Movies.Single(x => x.MovieId == movieid);

            return View("AddMovie", entry);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry me)
        {
            entryContext.Update(me);
            entryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var entry = entryContext.Movies.Single(x => x.MovieId == movieid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry me)
        {
            entryContext.Movies.Remove(me);
            entryContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
