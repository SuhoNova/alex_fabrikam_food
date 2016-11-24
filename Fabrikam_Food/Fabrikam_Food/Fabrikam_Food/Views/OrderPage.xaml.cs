using Fabrikam_Food.DataModels;
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
        List<FoodDetail> foodList = new List<FoodDetail>();

        public OrderPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
            this.getFoodList();
            FoodList.ItemsSource = foodList;
            FoodList.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
                }
                FoodDetail fd = (FoodDetail)e.SelectedItem;
                App.RootPage.Detail = new NavigationPage(new OrderFoodPage(fd.name, fd.price));
                App.MenuIsPresented = false;
                //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
                //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
            };
        }
        public void getFoodList()
        {
            foodList.Add(new FoodDetail { name = "chicken", price = 29.99, mood= "anger" });
            foodList.Add(new FoodDetail { name = "pasta", price = 15.00, mood = "anger" });
            foodList.Add(new FoodDetail { name = "apple", price = 1.00, mood = "contempt" });
            foodList.Add(new FoodDetail { name = "steak", price = 19.99, mood = "contempt" });
            foodList.Add(new FoodDetail { name = "pineapple", price = 8.99, mood = "disgust" });
            foodList.Add(new FoodDetail { name = "celery", price = 0.99, mood = "disgust" });
            foodList.Add(new FoodDetail { name = "salad", price = 15.00, mood = "fear" });
            foodList.Add(new FoodDetail { name = "cookie", price = 2.99, mood = "fear" });
            foodList.Add(new FoodDetail { name = "pizza", price = 12.99, mood = "happiness" });
            foodList.Add(new FoodDetail { name = "nugggets", price = 2.00, mood = "happiness" });
            foodList.Add(new FoodDetail { name = "bread", price = 4.00, mood = "neutral" });
            foodList.Add(new FoodDetail { name = "sandwich", price = 5.99, mood = "neutral" });
            foodList.Add(new FoodDetail { name = "coke", price = 1.00, mood = "sadness" });
            foodList.Add(new FoodDetail { name = "ice cream", price = 0.50, mood = "sadness" });
            foodList.Add(new FoodDetail { name = "chips", price = 2.50, mood = "surprise" });
            foodList.Add(new FoodDetail { name = "carrot", price = 1.99, mood = "surprise" });
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
