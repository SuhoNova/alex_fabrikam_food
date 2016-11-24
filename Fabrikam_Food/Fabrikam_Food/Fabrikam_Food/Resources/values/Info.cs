using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Fabrikam_Food.Resources.values
{
    public class Info
    {
        private string google_map_key = "AIzaSyDqCyr5qgvtt1EqcCehEPMoQm08c35JcPw";
        private string google_matrix_key = "AIzaSyBIyy9lkZK4azYFHMDpimjMfrUmrtpIuHw";
        // Currently britomart bus station coordinates
        private string fabrikam_food_location = "-36.844263,174.76804";
        public Info()
        {
        }

        public string getGoogleMapKey()
        {
            return google_map_key;
        }
        public string getGoogleMatrixKey()
        {
            return google_matrix_key;
        }
        public string getLocation()
        {
            return fabrikam_food_location;
        }
    }
}
