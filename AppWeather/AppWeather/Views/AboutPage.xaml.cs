using AppWeather.Models;
using System;
using Xamarin.Forms;
using AppWeather.Services;
using Xamarin.Essentials;
using System.Linq;
using AppWeather.Models;

namespace AppWeather.Views
{
    public partial class AboutPage : ContentPage
    {
        Models.Location _Location;
        Services.RestService _restService;
        public AboutPage()
        {
            InitializeComponent();
            _restService = new Services.RestService();
            date.Text = DateTime.Now.ToString();
            Models.Location Current = new Models.Location {LocationName="Thu duc" };
            _Location = Current;
            GetWeather(_Location.LocationName);
        }
        public AboutPage(Models.Location location)
        {
            InitializeComponent();
            _restService = new Services.RestService();
            _Location = location;
            GetWeather(_Location.LocationName);
            date.Text = DateTime.Now.ToString();
        }
        // Nhận giá trị từ trang khác gửi đến
        //public string GetNameLocation { get; set; }
        //

        public async void GetWeather(string location_)
        {
            Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
            BindingContext = weatherData;

            if (string.IsNullOrWhiteSpace(TextInfoLocal.Text))
            {
                await DisplayAlert("Thông báo", "\nKhông có vị trí này trong danh sách tìm kiếm.", "OK");
                await Shell.Current.GoToAsync($"//{nameof(SavedLocationPage)}");
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_Location.LocationName}";
            requestUri += "&units=metric"; // or units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }




    }
}