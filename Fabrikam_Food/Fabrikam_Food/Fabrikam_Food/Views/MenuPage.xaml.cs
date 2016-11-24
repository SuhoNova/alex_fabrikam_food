using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fabrikam_Food.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            Title = "Menu";
            Icon = Device.OS == TargetPlatform.Android ? "menu.png" : null;
            InitializeComponent();
        }
    }
}
