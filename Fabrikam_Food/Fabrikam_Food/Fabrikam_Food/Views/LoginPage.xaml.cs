using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Fabrikam_Food.Views;
using Fabrikam_Food;

namespace Fabrikam_Food
{
    public partial class LoginPage : ContentPage
    {
        // Track whether the user has authenticated.
        bool authenticated = false;

        public LoginPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            if (authenticated == true)
            {
                // Hide the Sign-in button.
                this.loginButton.IsVisible = false;
            }
        }
        async void loginButton_Clicked(object sender, EventArgs e)
        {
            var menuPage = new MenuPage();
            App.RootPage.Detail = new NavigationPage(new HomePage());

            App.RootPage.Master = menuPage;
            //App.MenuIsPresented = false;

            /*
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
            }*/
        }
    }
}
