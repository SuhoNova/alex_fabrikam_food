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
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" +
                     _currentLocation +
                     "&destinations=" +
                     _fabLocation +
                     "&key=" +
                     _key;
            //JSValue json = await FetchDistanceAndTime(url);

        }
        /*
        private async Task<JSValue> FetchDistanceAndTime(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }*/

    }
}
