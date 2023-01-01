using AppWeather.ViewModels;
using AppWeather.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppWeather
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //Routing.RegisterRoute(nameof(LoginUserPage), typeof(LoginUserPage));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginUserPage");
        //}
    }
}
