using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMaze.Models;
using WebMazeKZ.DBStuff;
using WebMazeKZ.DBStuff.Model;

namespace WebMaze.Controllers
{
    public class CountriesController : Controller
    {
        private WebMazeContext _webMazeContext;

        public CountriesController(WebMazeContext webMazeContext)
        {
            _webMazeContext = webMazeContext;
        }

        public IActionResult Index()
        {
            var countriesViewModels = new List<CountriesViewModel>();
            var dbCountries = _webMazeContext.CountryDetails;

            foreach (var country in dbCountries)
            {
                var viewModel = new CountriesViewModel();
                viewModel.CountryName = country.CountryName;
                viewModel.CapitalName = country.Capital;
                viewModel.Population = country.Population;
                viewModel.Flag = country.Flag;
                viewModel.CountryArea = country.Area;
                countriesViewModels.Add(viewModel);
            }

            return View(countriesViewModels);
        }

        public IActionResult AddCountry(string country, string capital, int population, double area, string flag)
        {
            var dbModel = new CountryDetails()
            {
                CountryName = country,
                Capital = capital,
                Population = population,
                Area = area,
                Flag = flag
            };
            _webMazeContext.CountryDetails.Add(dbModel);
            _webMazeContext.SaveChanges();
            return RedirectToAction("Index", "Countries");
        }
    }
}
