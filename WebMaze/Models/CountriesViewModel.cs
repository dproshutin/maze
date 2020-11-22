using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    public class CountriesViewModel
    {
        public string CountryName { get; set; }
        public string CapitalName { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; }
        public double CountryArea { get; set; }

        public CountriesViewModel(string country, string capital, int population, string flag, double area)
        {
            CountryName = country;
            CapitalName = capital;
            Population = population;
            Flag = flag;
            CountryArea = area;
        }
    }
}
