using System.Windows.Input;

namespace AppWeather.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Vị trí";
        }

        public ICommand OpenWebCommand { get; }
    }
}