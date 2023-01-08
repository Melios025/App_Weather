using AppWeather.Models;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedLocationPage : ContentPage
    {
        public SavedLocationPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CVLocation.ItemsSource = App.LocationDb.ReadLocation();
        }

        private void TIAddLocation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddLocationPage());
        }


        //Chuyển đến trang AboutPage để tìm thông tin thời tiết
        private void CVLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Location selectedLocation = (Location)CVLocation.SelectedItem;
            Navigation.PushAsync(new AboutPage(selectedLocation));
        }

        //Xóa & sửa tên vị trí
        private async void SWDelete_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var location = swipeItem.CommandParameter as Location;

            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa {location.LocationName} không?", "CÓ", "KHÔNG");
            if (answer)
            {
                App.LocationDb.DeleteLocation(location);
                CVLocation.ItemsSource = App.LocationDb.ReadLocation();
            }
        }
        public void SWEdit_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var location = swipeItem.CommandParameter as Location;
            Navigation.PushAsync(new AddLocationPage(location));
        }
        private void SearchBar_TextLocation(object sender, TextChangedEventArgs e)
        {
            CVLocation.ItemsSource = App.LocationDb.ReadLocation().Where(a => a.LocationName.ToLower().StartsWith(e.NewTextValue));
        }
    }
}