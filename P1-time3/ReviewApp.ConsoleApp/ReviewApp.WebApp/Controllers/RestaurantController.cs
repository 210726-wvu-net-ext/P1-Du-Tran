using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReviewApp.Domain;
using ReviewApp.DataAccess;
using ReviewApp.DataAccess.Entities;

namespace ReviewApp.WebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IReviewRepo _repo;
        private readonly ReviewDbContext _context;
        public RestaurantController(IReviewRepo repo, ReviewDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        //Get all list of restaurants
        public IActionResult Index()
        {
            var restaurants = _repo.GetAllRestaurants();

            return View(restaurants);
        }

        //Search for a restaurant
        public IActionResult SearchForARestaurantForm()
        {
            return View();
        }
        //Show the search results
        public IActionResult ShowSearchResults(string searchString)
        {
             if (searchString == null)
             {
                 return NotFound();
             }
             var foundRestaurant = _repo.FindARestaurant(searchString);
             
             if (foundRestaurant == null)
             {
                 return NotFound();
             }
             //add all found restaurants to List<>
             List<ReviewApp.Domain.Restaurant> restaurants = new List<ReviewApp.Domain.Restaurant>();
             restaurants.Add(foundRestaurant);

             return View("Index", restaurants);
        }
        
    }
}
