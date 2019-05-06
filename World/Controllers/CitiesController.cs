using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
            List<City> allcities = City.GetAll();
            return View(allcities);
        }

        [HttpGet("/cities/{cityName}")]
        public ActionResult Show(string cityName)
        {
            City city = City.GetByName(cityName);   
            return View(city);
 
        }

        [HttpPost("/cities")]
        public ActionResult Show(string userSearch, string category)
        {
            List<City> results = City.Search()
            return View();
        }
    }
}