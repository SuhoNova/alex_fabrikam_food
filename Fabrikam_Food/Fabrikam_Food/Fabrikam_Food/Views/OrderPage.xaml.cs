using Fabrikam_Food.DataModels;
using Fabrikam_Food.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam_Food.Views
{
    public partial class OrderPage : ContentPage
    {
        List<FoodDetail> _foodList = new List<FoodDetail>();

        public OrderPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
            this.getFoodList();
            FoodList.ItemsSource = _foodList;
            FoodList.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                FoodDetail fd = (FoodDetail)e.SelectedItem;
                App.RootPage.Detail = new NavigationPage(new OrderFoodPage(fd.name, fd.price));
                App.MenuIsPresented = false;
            };
        }
        public void getFoodList()
        {
            FoodList fList = new FoodList();
            _foodList = fList.getMenuList();
        }
    }
}
