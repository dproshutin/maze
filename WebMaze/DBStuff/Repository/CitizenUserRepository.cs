using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMazeKZ.DBStuff.Model;

namespace WebMazeKZ.DBStuff.Repository
{
    public class CitizenUserRepository : BaseRepository<CitizenUser>
    {
        public CitizenUserRepository(WebMazeContext context) : base(context) { }
    }
}
