using AppWeather.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedLocationPage : ContentPage
    {  
        Location _Location;
        public ObservableCollection<Location> LocalNames;
        public SavedLocationPage()
        {
            InitializeComponent();
            //===============Tạo dữ liệu ban đầu để làm thanh searchbar============
            //LocalNames = new ObservableCollection<Location>
            //{
            //    new Location{LocationName="Ho Chi Minh", LocationId=1},
            //    new Location{LocationName="Ha Noi", LocationId=2},
            //    new Location{LocationName="Vung Tau", LocationId=3},
            //    new Location{LocationName="Thu Duc", LocationId=4},
            //    new Location{LocationName="Binh Duong", LocationId=5},
            //    new Location{LocationName="Loc Ninh", LocationId=6},
            //};
            //CVLocation.ItemsSource = LocalNames;
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
        private void SearchBar_TextLocation(object sender, EventArgs e)
        {

        }
       
    }
}