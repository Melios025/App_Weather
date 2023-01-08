using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUserPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyAxRp4OlhUwOtvvzdC_VxZ1WE7ZKqJ5hf8";
        public LoginUserPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //Ẩn hiện mật khẩu
        async void IsCheckedPassword(object sender, CheckedChangedEventArgs e)
        {
            bool isCheck = CheckBoxPass.IsChecked;
            if (!isCheck)
            {
                UserLoginPassword.IsPassword = true;
                TextShowHidePassword.Text = "Hiện mật khẩu";
            }
            else
            {
                UserLoginPassword.IsPassword = false;
                TextShowHidePassword.Text = "Ẩn mật khẩu";
            }
        }
        async void loginbuttonclicked(Object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await App.Current.MainPage.DisplayAlert("Thông báo", "Đăng nhập thành công", "Ok");
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Email hoặc mật khẩu không hợp lệ", "OK");
            }
        }
        void signuppageclicled(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupUserPage());
        }
    }
}