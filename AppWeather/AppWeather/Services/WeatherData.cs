
using Newtonsoft.Json;

namespace AppWeather.Services
{
    public class WeatherData
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }
        [JsonProperty("message")]
        public int Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List[] List { get; set; }
        [JsonProperty("city")]
        public City City { get; set; }
    }


    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Title { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("timezone")]
        public int Timezone { get; set; }
        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }
        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public class List
    {
        [JsonProperty("dt")]
        public string Dt { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("pop")]
        public double Pop { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string Dt_txt { get; set; }
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("feels_like")]
        public double Feels_like { get; set; }
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }
        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("sea_level")]
        public int Sea_level { get; set; }
        [JsonProperty("grnd_level")]
        public int Grnd_level { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("temp_kf")]
        public double Temp_kf { get; set; }
    }

    public class Rain
    {
        [JsonProperty("3h")]
        public double _3h { get; set; }
    }

    public class Sys
    {
        [JsonProperty("pop")]
        public string Pod { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        public string IconFull => $"{"icon_"}{Icon}{".png"}";
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Deg { get; set; }
        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}

