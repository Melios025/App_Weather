using AppWeather.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        private async void btnNewLocation(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntNewLocation());
        }
        // Đăng xuất ra trang FirebaseAthPage
        private void btnLoginUserPageclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
        }

    }
}