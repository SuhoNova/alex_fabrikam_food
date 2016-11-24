using Android.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Android.OS;
using Android.Runtime;
using Plugin.Geolocator;
using Fabrikam_Food.Resources.values;
using JavaScriptCore;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Org.Json;
using Fabrikam_Food.DataModels.json;


namespace Fabrikam_Food.Views
{
    public partial class JourneyPage : ContentPage
    {
        private string _key;
        private string _fabLocation;
        private string _currentLocation;
        public JourneyPage()
        {
            BindingContext = new Fabrirkam_Food.MenuPageViewModel();
            InitializeComponent();
            Info info = new Info();
            _key = info.getGoogleMatrixKey();
            _fabLocation = info.getLocation();
            fabrikamLocation.Text = "Fabrikam Food Location: " + _fabLocation;
            getCurrentLocation();
        }
        
        public async void getCurrentLocation()
        {
            LocationFinding.IsRunning = true;

            currentLocation.Text = "Searching your location ...";

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50; //50m accuracy

            var position = await locator.GetPositionAsync(10000);

            _currentLocation = position.Latitude + "," + position.Longitude;
            currentLocation.Text = "Your Location is: " + _currentLocation;

            LocationFinding.IsRunning = false;

        }
        public async void FindDistanceAndTime(Object sender, EventArgs e)
        {
            // mode default is driving, if i want to change it then after fablocation "&mode=bicycling"
            try
            {
                string url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" +
                         _currentLocation +
                         "&destinations=" +
                         _fabLocation +
                         "&key=" +
                         _key;
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");
                var response = client.GetAsync("distancematrix/json?origins=" +
                        _currentLocation +
                         "&destinations=" +
                         _fabLocation +
                         "&key=" +
                         _key).Result;

                var jsonString = response.Content.ReadAsStringAsync().Result;
                List<DataModels.json.Element> data = getData(jsonString);
                distance.Text = "You have to travel " + data[0].distance.text + " to get to Fabrikam Food";
                time.Text = "It is estimated to take " + data[0].duration.text + " by car";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed getting distance and duration", ex.Message, "OK");
            }
        }
        public List<DataModels.json.Element> getData(string jsonString)
        {
            var json = JsonConvert.DeserializeObject<RootObject>(jsonString);
            return json.rows[0].elements;
        }
    }
}
