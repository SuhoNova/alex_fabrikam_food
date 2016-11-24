using Fabrikam_Food.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam_Food.Views
{
    public partial class OrderFoodPage : ContentPage
    {
        public String _name { get; set; }
        public double _price { get; set; }

        public OrderFoodPage(String name, double price)
        {
            _name = name;
            _price = price;
            InitializeComponent();
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            BindingContext = this;
        }

        private void GoBack(Object sender, EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new OrderPage());
            App.MenuIsPresented = false;
        }

        private async void OrderIt(Object sender, EventArgs e)
        {
            OrderingIndicator.IsRunning = true;
            try
            {
                // SEND TO EASY TABLE
                Food food = new Food()
                {
                    Name = _name,
                    Price = _price,
                    Quantity = 1,
                    Date = DateTime.Now
                };

                await AzureManager.AzureManagerInstance.AddFoodOrder(food);
                OrderingIndicator.IsRunning = false;
                await DisplayAlert(_name + " Successfully Ordered", "The food will be prepared as soon as possible", "Ok");
                App.RootPage.Detail = new NavigationPage(new OrderPage());
                App.MenuIsPresented = false;
            }
            catch(Exception ex)
            {
                errorLabel.Text = ex.Message;
                OrderingIndicator.IsRunning = false;
                await DisplayAlert("Order Failed", "If it doesn't work again, please contact us by phone", "Ok");
            }
            
        }

    }
}
