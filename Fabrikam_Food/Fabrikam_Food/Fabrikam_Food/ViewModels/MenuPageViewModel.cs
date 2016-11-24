using Fabrikam_Food;
using Fabrikam_Food.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fabrirkam_Food
{
    public class MenuPageViewModel
    {
        public ICommand GoHomeCommand { get; set; }
        public ICommand GoJourneyCommand { get; set; }
        public ICommand GoSuggestCommand { get; set; }
        public ICommand GoOrderCommand { get; set; }
        public ICommand GoHistoryCommand { get; set; }

        public MenuPageViewModel()
        {
            GoHomeCommand = new Command(GoHome);
            GoJourneyCommand = new Command(GoJourney);
            GoSuggestCommand = new Command(GoSuggest);
            GoOrderCommand = new Command(GoOrder);
            GoHistoryCommand = new Command(GoHistory);
        }

        void GoHome(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new HomePage());
            App.MenuIsPresented = false;
        }
        void GoJourney(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new JourneyPage());
            App.MenuIsPresented = false;
        }
        void GoSuggest(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new MoodPage());
            App.MenuIsPresented = false;
        }
        void GoOrder(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new OrderPage());
            App.MenuIsPresented = false;
        }
        void GoHistory(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new HistoryPage());
            App.MenuIsPresented = false;
        }
    }
}
