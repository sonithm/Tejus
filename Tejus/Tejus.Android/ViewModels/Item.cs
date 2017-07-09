using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tejus.Droid.ViewModels
{
    public class Item
    {
        public string Group { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public override string ToString() => Text;
    }
}