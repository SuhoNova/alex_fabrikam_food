using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Fabrikam_Food.Views;
using Fabrikam_Food;
using Plugin.Settings;

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

            string userId = CrossSettings.Current.GetValueOrDefault("user", "");
            string token = CrossSettings.Current.GetValueOrDefault("token", "");

            if (!token.Equals("") && !userId.Equals(""))
            {
                MobileServiceUser user = new MobileServiceUser(userId);
                user.MobileServiceAuthenticationToken = token;

                AzureManager.AzureManagerInstance.AzureClient.CurrentUser = user;

                authenticated = true;
            }

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
                this.ProceedButton.IsVisible = true;
                helloUser.Text = "Hello, user: " + userId;
            }
        }
        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
                this.ProceedButton.IsVisible = true;
                CrossSettings.Current.AddOrUpdateValue("user", AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId);
                CrossSettings.Current.AddOrUpdateValue("token", AzureManager.AzureManagerInstance.AzureClient.CurrentUser.MobileServiceAuthenticationToken);

                helloUser.Text = "Hello, user: " + AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId;
            }
        }
        private void proceedButton_Clicked(object sender, EventArgs e)
        {
            var menuPage = new MenuPage();
            App.RootPage.Detail = new NavigationPage(new HomePage());
            App.RootPage.Master = menuPage;
        }
    }
}
