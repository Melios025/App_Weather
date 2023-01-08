
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapWeatherPage : ContentPage
    {
        public MapWeatherPage()
        {
            InitializeComponent();
            //MapWeatherView.Source = "https://openweathermap.org/weathermap?basemap=map&cities=true&layer=pressure&lat=9.7943&lon=107.1263&zoom=6";
            //MapWeatherView.Source = "https://www.windy.com/?11.652,107.183,8";
            MapWeatherView.Source = "https://embed.windy.com/embed2.html?lat=11.232&lon=107.545&detailLat=11.631&detailLon=107.161&width=650&height=450&zoom=7&level=500h&overlay=wind&product=ecmwf&menu=&message=true&marker=&calendar=12&pressure=&type=map&location=coordinates&detail=&metricWind=km%2Fh&metricTemp=%C2%B0C&radarRange=-1";
        }
    }
}