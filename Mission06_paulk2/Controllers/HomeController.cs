using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_paulk2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_paulk2.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieTable() 
        {
           var applications = _movieContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(applications);
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult NewMovieForm(ApplicationResponse ar)
        {

            if (ModelState.IsValid)
            {
                _movieContext.Add(ar);
                _movieContext.SaveChanges();
                return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Responses.Single(x => x.MovieId == id);

            return View("NewMovieForm", movie);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(ar);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieTable");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View("NewMovieForm");
            }            
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = _movieContext.Responses.Single(x => x.MovieId == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse ar)
        {
            _movieContext.Responses.Remove(ar);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
