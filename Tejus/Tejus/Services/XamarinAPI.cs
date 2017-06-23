using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tejus.Models;
using Tejus.Views;
using Xamarin.Forms;

namespace Tejus.Services
{
    public class XamarinAPI
    {
      
        public static XamarinAPI Methods = new XamarinAPI();
          public const string urlapi = "http://localhost:61207/api/Login/LogIn?username=a&password=sonith";
        //  public const string urlapi = "http://tejus.vaspublications.com//api/Login/LogIn?username=a&password=sonith";
        public const string urldonor = "http://tejus.vaspublications.com/api/Login/Donor";
        public async Task<List<TEJUSDonorModel>> GetAllTask()
        {
            List<TEJUSDonorModel> LstTask = new List<TEJUSDonorModel>();
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(urldonor);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<List<TEJUSDonorModel>>(content);
                }
            }
            catch (Exception ex)
            {

            }
            return LstTask;
        }
        public static async Task<TEJUSResultModel> Login(string Username, string Password)
        {
            TEJUSResultModel LstTask = new TEJUSResultModel();
           
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                string urltejus = @"http://tejus.vaspublications.com//api/Login/LogIn?username="+Username.Trim()+"&password=sonith";
                var uri = new Uri(urltejus);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<TEJUSResultModel>(content);
                    if (LstTask.SuccessStatus)
                    {
                        //DisplayAlert("Login", "Login Success", "Ok");
                        //NavigationPage.SetHasNavigationBar(this, false);
                        //Navigation.PushAsync(new MasterDetailPage1());
                        // await SaveAsync();
                        saveset(Username, Password);
                        App.Current.MainPage = new NavigationPage(new MasterDetailPage1());
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                        // DisplayAlert("Login", "Login Not Correct, empty username or password", "Ok");
                    }
                  //  ActivitySpinner.IsVisible = false;
                }
            }
            catch (Exception ex)
            {

            }
            return LstTask;
        }

       

        private static void saveset(string userName,string Password)
        {
          
            Application.Current.Properties["username"] = userName;
            Application.Current.Properties["password"] = Password;

        }



        public static bool Logins()
        {
            TEJUSResultModel LstTask = new TEJUSResultModel();
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://tejus.vaspublications.com/api/Login/LogIn?username=sonith&password=sonith").Result;

                if (response.IsSuccessStatusCode)
                {
                  
                    // by calling .Result you are performing a synchronous call
                    //   var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    // string responseString = responseContent.ReadAsStringAsync().Result;
                    var content = response.Content.ReadAsStringAsync();
                    //   LstTask = JsonConvert.DeserializeObject<TEJUSResultModel>(content);
                    //var outObject = JsonConvert.DeserializeObject<TEJUSResultModel>(response.ToString());
                    ////return true;
                    //var user = JsonConvert.DeserializeObject<TEJUSResultModel>(content);
                    //// LstTask = (TEJUSResultModel)JsonConvert.DeserializeObject(content.ToString());

                    ////    MyAccount.EmployeeID = (string)o["employeeid"][0];


                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<Tareas> GetTaskById(int Id)
        {
            Tareas ItemTask = new Tareas();
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(urlapi + "/" + Id);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemTask = JsonConvert.DeserializeObject<Tareas>(content);
                }
            }
            catch (Exception ex)
            {

            }
            return ItemTask;
        }
        public async Task<bool> SaveItemTarea(Tareas model, bool esNuevo = false)
        {
            bool ejecucionCorrecta = false;
            try
            {
                HttpClient client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(urlapi + (esNuevo == true ? string.Empty : "/" + model.Id));
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (esNuevo)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    ejecucionCorrecta = true;
                }
            }
            catch (Exception ex)
            {

            }
            return ejecucionCorrecta;
        }
    }
}
