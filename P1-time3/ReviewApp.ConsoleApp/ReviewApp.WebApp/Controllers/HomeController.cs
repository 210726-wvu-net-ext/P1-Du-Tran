using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ReviewApp.Domain;
using ReviewApp.DataAccess;

namespace ReviewApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReviewRepo _repo;
        public HomeController(ILogger<HomeController> logger, IReviewRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            //var customers = _repo.GetAllCustomers();
            return View();
        }

        //search for everything on the home page
        public IActionResult SearchResults(string searchString)
        {
            if (searchString == null)
            {
                return NotFound();
            }

            var foundRestaurant = _repo.FindARestaurant(searchString);
            //if (foundRestaurant == null)
                
            //add all found restaurants to List<>
            List<ReviewApp.Domain.Restaurant> restaurants = new List<ReviewApp.Domain.Restaurant>();
            
            if (foundRestaurant != null)
                ViewBag.restaurant = restaurants.Count;
                TempData["error"] = "Sorry! Nothing to show based on your input :(";
            
            restaurants.Add(foundRestaurant);
            return View(restaurants);
        }


        //privacy
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy");
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This Exception from Privacy Page");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
