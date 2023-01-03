using SQLite;
using System;
using System.Threading.Tasks;

namespace AppWeather.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public static implicit operator Location(Task<Location> v)
        {
            throw new NotImplementedException();
        }
    }
}
