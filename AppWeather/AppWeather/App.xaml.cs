using AppWeather.Services;
using AppWeather.Helper;
using AppWeather.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather
{
    public partial class App : Application
    {
        public static LocationDatabase LocationDb = new LocationDatabase();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
