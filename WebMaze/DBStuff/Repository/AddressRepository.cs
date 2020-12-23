using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMazeKZ.DBStuff.Model;

namespace WebMazeKZ.DBStuff.Repository
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(WebMazeContext context) : base(context) { }

        public List<Address> GetAddressByCity(string city)
        {
            return dbSet.Where(x => x.City == city).ToList();
        }
    }
}
