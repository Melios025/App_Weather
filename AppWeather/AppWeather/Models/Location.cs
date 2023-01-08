using SQLite;

namespace AppWeather.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
