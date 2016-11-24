using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Fabrikam_Food.DataModels;

namespace Fabrikam_Food
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Food> foodTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://alexfabrikamfood.azurewebsites.net");
            this.foodTable = this.client.GetTable<Food>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task AddFoodOrder(Food fFood)
        {
            await this.foodTable.InsertAsync(fFood);
        }

        public async Task<List<Food>> GetFoodOrder()
        {
            return await this.foodTable.ToListAsync();
        }
    }
}
