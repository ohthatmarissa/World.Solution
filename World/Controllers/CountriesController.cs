using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CountriesController : Controller
    {
        [HttpGet("/countries")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }

        [HttpGet("/countries/{countryName}")]
        public ActionResult Show(string countryName)
        {
            Country country = Country.GetByName(countryName);   
            return View(country);
        }
    }
}