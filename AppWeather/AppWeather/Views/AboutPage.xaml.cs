using AppWeather.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class AboutPage : ContentPage
    {
        Location _Location;
        List<Hourly> HourlyList;
        List<Daily> DailyList;
        Services.RestService _restService;
        public AboutPage()
        {
            InitializeComponent();
            _restService = new Services.RestService();
            _Location = new Location { LocationName = "Thu Duc" };
            labelDate.Text = DateTime.Now.ToString();
            UnitsMetricSpan.Text = "℃";
            GetWeather(_Location);
        }
        public AboutPage(Location location)
        {
            InitializeComponent();
            _restService = new Services.RestService();
            _Location = location;
            GetWeather(_Location);
            labelDate.Text = DateTime.Now.ToString();
            //Feelslike.Text = "Feelslike like ";
            UnitsMetricSpan.Text = "℃";
        }

        // Nhận giá trị từ trang khác gửi đến
        //public string GetNameLocation { get; set; }
        //

        public async void GetWeather(Location location_)
        {
            Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
            BindingContext = weatherData;
            HourlyList = new List<Hourly>();
            DailyList = new List<Daily>();

            //Add infor hourly
            for (int i = 1; i <= 12; i++)
            {
                Hourly Hour1 = new Hourly { TimeHourly = weatherData.List[i].Dt_txt.Remove(0, 10).Remove(5, 3), IconHourly = weatherData.List[i].Weather[0].IconFull, TempHourly = weatherData.List[i].Main.Temp };
                HourlyList.Add(Hour1);
            }
            hourlyForecast.ItemsSource = HourlyList;

            //Add infor daily
            for (int i = 0; i <= 36; i=i+8)
            {
                if (weatherData.List[i].Dt_txt != null) {
                Daily Daily1 = new Daily { TimeDaily=weatherData.List[i].Dt_txt.Remove(10,9), IconDaily=weatherData.List[i].Weather[0].IconFull, Max=weatherData.List[i].Main.Temp_max,Min=weatherData.List[i].Main.Temp_min,DesDaily=weatherData.List[i].Weather[0].Description };
                DailyList.Add(Daily1); 
                }
            }
            DailyForecast.ItemsSource = DailyList;

            //Check valid
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
            requestUri += "&lang=vi";
            return requestUri;
        }
    }
}