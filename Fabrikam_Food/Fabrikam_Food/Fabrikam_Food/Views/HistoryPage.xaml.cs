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
        private List<Food> _foodList;
        private List<Food> temp = new List<Food>();
        public HistoryPage()
        {
            _foodList = new List<Food>();
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
            temp = await AzureManager.AzureManagerInstance.GetFoodOrder();
            foreach (Food f in temp){

                if (f.UserId.Equals(AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId))
                {
                    _foodList.Add(f);
                }
            }
            GettingIndicator.IsRunning = false;
            
            FoodHistoryList.ItemsSource = _foodList;
            
            FoodHistoryList.ItemSelected += async (s, ev) =>
            {
                if (ev.SelectedItem == null)
                {
                    return;
                }
                var answer = await DisplayAlert("Delete", "Do you want to delete this order?", "Delete", "Cancel");
                if (answer)
                {
                    await DisplayAlert("Sorry", "Order Deletion is not supported yet, please call us if you want to cancel your order", "OK");

                }
            };
        }
    }
}
