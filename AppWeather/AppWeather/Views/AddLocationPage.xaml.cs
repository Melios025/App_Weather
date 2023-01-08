using AppWeather.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocationPage : ContentPage
    {
        Location _location;
        public AddLocationPage()
        {
            InitializeComponent();
            Title = "Thêm vị trí mới";
        }
        public AddLocationPage(Location location)
        {
            InitializeComponent();
            Title = "Sửa ví trí";
            _location = location;
            EntLocationName.Text = _location.LocationName;
            EntLocationName.Focus();


        }

        private async void BtnAddNewLocatoin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntLocationName.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            else if (_location != null)
            {
                _location.LocationName = EntLocationName.Text;

                App.LocationDb.UpdateLocation(_location);
                await Navigation.PopAsync();
            }
            else
            {
                Location local = new Location
                {
                    LocationName = EntLocationName.Text,
                };

                if (App.LocationDb.CreateLocation(local))
                {
                    await DisplayAlert("Thông báo", "Thêm mới thành công!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Lỗi", "Thêm mới thất bại!", "OK");
                }
            }
        }
    }
}