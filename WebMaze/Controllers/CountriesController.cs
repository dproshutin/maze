using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            var countries = new List<CountriesViewModel>();

            var germany = new CountriesViewModel("Germany", "Berlin", 81_770_900, "https://restcountries.eu/data/deu.svg", 357114.0);
            countries.Add(germany);
            var switzerland = new CountriesViewModel("Switzerland", "Bern", 8_341_600, "https://restcountries.eu/data/che.svg", 41284.0);
            countries.Add(switzerland);
            var austria = new CountriesViewModel("Austria", "Vienna", 8_725_931, "https://restcountries.eu/data/aut.svg", 83871.0);
            countries.Add(austria);
            var poland = new CountriesViewModel("Poland", "Warsaw", 38_437_239, "https://restcountries.eu/data/pol.svg", 312679.0);
            countries.Add(poland);
            var ukraine = new CountriesViewModel("Ukraine", "Kiev", 42_692_393, "https://restcountries.eu/data/ukr.svg", 603700.0);
            countries.Add(ukraine);
            var georgia = new CountriesViewModel("Georgia", "Tbilisi", 3_720_400, "https://restcountries.eu/data/geo.svg", 69700.0);
            countries.Add(georgia);
            var turkey = new CountriesViewModel("Turkey", "Ankara", 78_741_053, "https://restcountries.eu/data/tur.svg", 783562.0);
            countries.Add(turkey);
            var israel = new CountriesViewModel("Israel", "Jerusalem", 8_527_400, "https://restcountries.eu/data/isr.svg", 20770.0);
            countries.Add(israel);
            var thailand = new CountriesViewModel("Thailand", "Bangkok", 65_327_652, "https://restcountries.eu/data/tha.svg", 513120.0);
            countries.Add(thailand);
            var britain = new CountriesViewModel("United Kingdom", "London", 65_110_000, "https://restcountries.eu/data/gbr.svg", 242900.0);
            countries.Add(britain);
            var russia = new CountriesViewModel("Russian Federation", "Moscow", 146_599_183, "https://restcountries.eu/data/rus.svg", 17124442.0);
            countries.Add(russia);
            var indonesia = new CountriesViewModel("Indonesia", "Jakarta", 258_705_000, "https://restcountries.eu/data/idn.svg", 1904569.0);
            countries.Add(indonesia);

            return View(countries);
        }
    }
}
