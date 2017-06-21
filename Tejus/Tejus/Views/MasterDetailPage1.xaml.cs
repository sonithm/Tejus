using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tejus.Models;
namespace Tejus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1 : MasterDetailPage
    {
        public MasterDetailPage1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPage1MenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            if (item.Id.Equals(1))
            {
                Detail = new NavigationPage(new Search());
            }
            else if(item.Id.Equals(0))
            {
                Detail = new NavigationPage(new Register());
            }
            else if (item.Id.Equals(3))
            {
                Detail = new NavigationPage(new About());
            }
            else if (item.Id.Equals(5))
            {
                Detail = new NavigationPage(new Associates());
            }
            else
            { Detail = new NavigationPage(page); }
            
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}