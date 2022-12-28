using AppWeather.Models;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class AboutPage : ContentPage
    {
        Location _Location;
        Services.RestService _restService;
        public AboutPage()
        {
            InitializeComponent();
            _restService = new Services.RestService();
        }
        public AboutPage(Location location)
        {
            InitializeComponent();
            _restService = new Services.RestService();
            _Location = location;
            GetWeather(_Location);
        }
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_Location.LocationName}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
        public async void GetWeather(Location location_)
        {
            if (!string.IsNullOrWhiteSpace(location_.LocationName))
            {
                Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
            else Navigation.PushAsync(new SavedLocationPage());
        }


    }
}