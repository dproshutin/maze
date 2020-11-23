using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMazeKZ.DBStuff.Model;

namespace WebMazeKZ.DBStuff
{
    public class WebMazeContext : DbContext
    {
        public DbSet<CountryDetails> CountryDetails { get; set; }

        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }
    }
}
