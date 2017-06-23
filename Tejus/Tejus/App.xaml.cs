using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tejus.Views;
using Xamarin.Forms;

using System.Threading.Tasks;
using Tejus.Models;
using Tejus.Services;


namespace Tejus
{
	public partial class App : Application
	{
        public static List<TEJUSDonorModel> LstTareas { get; set; }
        string username;
        string passwrod;
        public App ()
		{
			InitializeComponent();
            LstTareas = new List<TEJUSDonorModel>();
            Task.Run(async () => LstTareas = await XamarinAPI.Methods.GetAllTask());
            //MainPage = new Tejus.MainPage();
            if (Application.Current.Properties.ContainsKey("username"))
            {
                try
                {
                    username = Application.Current.Properties["username"] as string;
                    passwrod = Application.Current.Properties["password"] as string;
                    if (username == "")
                    {
                        MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        MainPage = new NavigationPage(new MasterDetailPage1());
                    }
                }
                catch
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }

            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
