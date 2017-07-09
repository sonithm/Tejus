using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tejus.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Tejus.Services;


namespace Tejus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Search()
        {
            InitializeComponent();

            BindingContext = new List_oldViewModel();
        }

        //async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
           => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            //if (e.SelectedItem == null)
            //    return;

            //Item it = e.SelectedItem as Item;
            ////await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");
            //TEJUSDonorModel itemTarea = await XamarinAPI.Methods.GetTaskById(it.Text);
            //await DisplayAlert("Name - Description", itemTarea.Name + " " + itemTarea.Phone, "OK");
            //await DisplayAlert("End Date", itemTarea.Email, "OK");
            ////Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }
    }
    class List_oldViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<Grouping<string, Item>> ItemsGrouped { get; }

        public List_oldViewModel()
        {
            Items = new ObservableCollection<Item>();
            foreach (TEJUSDonorModel tr in App.LstTareas)
            {
                Items.Add(new Item { Group = tr.BloodGroup, Text = tr.Name.ToString(), Detail = tr.Email + " - " + tr.Phone });
            }

            var sorted = from item in Items
                         orderby item.Group
                         group item by item.Group into itemGroup
                         select new Grouping<string, Item>(itemGroup.Key, itemGroup);

            ItemsGrouped = new ObservableCollection<Grouping<string, Item>>(sorted);

            RefreshDataCommand = new Command(
                async () => await RefreshData());
            SearchDataCommand = new Command(
               async () => await SearchData());
        }

        public ICommand RefreshDataCommand { get; }
        public ICommand SearchDataCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            //Load Data Here
            await Task.Delay(2000);

            IsBusy = false;
        }
        async Task SearchData()
        {
            IsBusy = true;
            //Load Data Here
            await Task.Delay(2000);

            IsBusy = false;
        }

        bool busy;
        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                ((Command)RefreshDataCommand).ChangeCanExecute();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }
    }
    public class Item
    {
        public string Group { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }

        public override string ToString() => Text;
    }
}