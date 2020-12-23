using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMazeKZ.DBStuff.Model
{
    public class CountryDetails : BaseModel
    {
        public string CountryName { get; set; }

        public string Capital { get; set; }

        public int Population { get; set; }

        public double Area { get; set; }

        public string Flag { get; set; }
    }
}
