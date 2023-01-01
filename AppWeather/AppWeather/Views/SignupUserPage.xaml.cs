using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupUserPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyAxRp4OlhUwOtvvzdC_VxZ1WE7ZKqJ5hf8";
        public SignupUserPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void signupbuttonclicked(Object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                //string gettoken = auth.FirebaseToken;
                //await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");

                string check_email = "@gmail.com";
                int index_check = UserNewEmail.Text.IndexOf('@');
                string getfull_check = UserNewEmail.Text.Substring(index_check);
                if (check_email == getfull_check)
                {
                    await App.Current.MainPage.DisplayAlert("Thông báo", "Tạo tài khoản thành công", "Ok");
                    await Navigation.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                await App.Current.MainPage.DisplayAlert("Thông báo", "Kiểm tra lại thông tin tài khoản. \n\n-Tài khoản có thể đã tồn tại. \n-Email: ***@gmail.com \n-Mật khẩu tối thiểu 6 ký tự", "OK");
            }
        }
        void loginbuttonclicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
        }
    }
}