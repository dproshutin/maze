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

        public DbSet<CitizenUser> CitizenUser { get; set; }

        public DbSet<Address> Address { get; set; }

        public WebMazeContext(DbContextOptions dbContext) : base(dbContext) { }
    }
}
