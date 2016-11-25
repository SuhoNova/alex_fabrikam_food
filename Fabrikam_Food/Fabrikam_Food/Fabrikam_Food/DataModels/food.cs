using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fabrikam_Food.DataModels
{
    public class Food
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

    }
}
