using AppWeather.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppWeather.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}