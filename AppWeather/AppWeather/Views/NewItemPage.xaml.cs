using AppWeather.Models;
using AppWeather.ViewModels;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}