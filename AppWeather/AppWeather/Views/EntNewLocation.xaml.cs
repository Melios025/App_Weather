using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntNewLocation : ContentPage
    {
        Services.RestService _restService;
        public EntNewLocation()
        {
            InitializeComponent();
            _restService = new Services.RestService();
        }


        // Tìm thông tin thời tiết và kiểm tra dữ liệu được nhập
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                Services.WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Services.Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;

                if (string.IsNullOrWhiteSpace(txtLocal.Text))
                {
                    DisplayAlert("Thông báo", "\nKhông có vị trí này trong danh sách tìm kiếm. \n\nVí dụ: Ha Noi", "đóng");
                }
                else
                {
                    nameWeather.Text = "Thời tiết ổn định đó";
                }

            }
            else
            {
                DisplayAlert("Thông báo", "\nBạn chưa nhập vị trí cần tìm. \n\nVí dụ: Ha Noi", "đóng");
            }
        }


        private async void btnUserLocation(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                DisplayAlert("Thông báo", "\nBạn chưa nhập vị trí cần tìm. \n\nVí dụ: Ha Noi", "đóng");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }


        //Tạo một API với vị trí được nhập
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; // units=metric
            requestUri += $"&APPID={Services.Constants.OpenWeatherMapAPIKey}";
            requestUri += "&lang=vi";
            return requestUri;
        }
    }
}