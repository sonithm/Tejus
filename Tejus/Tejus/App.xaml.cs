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
        public App ()
		{
			InitializeComponent();
            LstTareas = new List<TEJUSDonorModel>();
            Task.Run(async () => LstTareas = await XamarinAPI.Methods.GetAllTask());
            //MainPage = new Tejus.MainPage();
            MainPage = new NavigationPage(new LoginPage());
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
