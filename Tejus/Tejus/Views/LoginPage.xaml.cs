using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejus.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tejus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            InIt();

        }
        void InIt()
        {
            BackgroundColor = Constants.BackgroundColor;
            // Lbl_Username.TextColor = Constants.MainTextColor;
            //  Lbl_Password.TextColor = Constants.MainTextColor;
            Btn_Login.BackgroundColor = Constants.BackgroundColor;
            ActivitySpinner.IsVisible = false;
            //LoginIcon.HeightRequest = Constants.LoginIconHeight;
            Entry_Username.Completed += (s, e) => Entry_Username.Focus();
            Entry_Password.Completed += (s, e) => Entry_Password.Focus();
            //Btn_Register.Text = "Click Me!";
            //Btn_Register.Font = Font.SystemFontOfSize(NamedSize.Large);
            //Btn_Register.BorderWidth = 1;
            //Btn_Register.HorizontalOptions = LayoutOptions.Center;
            //Btn_Register.VerticalOptions = LayoutOptions.CenterAndExpand;

            //////Btn_Register.BorderWidth = 1;
            //Btn_Search.HorizontalOptions = LayoutOptions.Center;
            //Btn_Search.VerticalOptions = LayoutOptions.CenterAndExpand;
            ////Btn_Login.HorizontalOptions = LayoutOptions.Center;
            ////Btn_Login.VerticalOptions = LayoutOptions.CenterAndExpand;
            //Btn_Search.BackgroundColor = Constants.BackgroundColor;
            //Btn_Register.BackgroundColor = Constants.BackgroundColor;
            Btn_Register.BackgroundColor = Constants.BackgroundColor;
            Btn_Search.BackgroundColor = Constants.BackgroundColor;
        }
        private void Btn_Login_Clicked(object sender, EventArgs e)
        {
            ActivitySpinner.IsVisible = true;
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                //DisplayAlert("Login", "Login Success", "Ok");
                //NavigationPage.SetHasNavigationBar(this, false);
                //Navigation.PushAsync(new MasterDetailPage1());
                App.Current.MainPage = new NavigationPage(new MasterDetailPage1());
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password", "Ok");
            }
            ActivitySpinner.IsVisible = false;
        }

        private void Btn_Register_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Register());

        }

        private void Btn_Search_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Search());
        }
    }
}