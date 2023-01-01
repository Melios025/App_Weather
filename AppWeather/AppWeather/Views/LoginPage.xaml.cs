using AppWeather.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Linq;
using AppWeather.Models;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(); 
        }
        //Đăng nhập vào trang EntNewLocation
        private void btnNewLocation(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntNewLocation());
        }
        // Đăng xuất ra trang FirebaseAthPage
        private void btnLoginUserPageclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
        }
        public async void GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,Timeout = TimeSpan.FromSeconds(30)
                    }) ;
                }
                if (location == null)
                {
                    DisplayAlert("Lỗi", "Không có GPS", "Ok");
                }
                else
                {
                    var lat = location.Latitude;
                    var lon = location.Longitude;
                    var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);
                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        Models.Location SendLocation = new Models.Location { };
                        SendLocation.LocationName= placemark.AdminArea.ToString();                    
                        Navigation.PushAsync(new AboutPage(SendLocation));
                    }
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            
        }

        private void CurrentLocation_Clicked(object sender, EventArgs e)
        {
            GetLocation();
        }
    }
}