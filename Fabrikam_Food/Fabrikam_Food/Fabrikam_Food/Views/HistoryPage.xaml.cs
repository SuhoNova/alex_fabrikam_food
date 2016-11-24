using Fabrikam_Food.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam_Food.Views
{
    public partial class HistoryPage : ContentPage
    {
        private List<Food> _foodList = new List<Food>();

        public HistoryPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
        }
        private void GoBack(Object sender, EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new OrderPage());
            App.MenuIsPresented = false;
        }

        public async void Clicked_History(Object sender, EventArgs e)
        {
            GettingIndicator.IsRunning = true;
            _foodList = await AzureManager.AzureManagerInstance.GetFoodOrder();
            GettingIndicator.IsRunning = false;
            
            FoodHistoryList.ItemsSource = _foodList;
            /*
            FoodHistoryList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                var answer = await DisplayAlert("Delete", "Do you want to delete this order?", "Delete", "Cancel");
                if (answer)
                {
                    FoodDetail fd = (FoodDetail)e.SelectedItem;
                    
                }
                App.RootPage.Detail = new NavigationPage(new OrderFoodPage(fd.name, fd.price));
                App.MenuIsPresented = false;
            };*/
        }
    }
}
