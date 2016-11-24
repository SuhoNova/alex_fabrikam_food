using Fabrikam_Food.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam_Food.Resources
{
    public class FoodList
    {
        private List<FoodDetail> _foodMenuList;
        public FoodList()
        {
            _foodMenuList = new List<FoodDetail>();
            this.loadMenu();
        }
        public void loadMenu()
        {
            _foodMenuList.Add(new FoodDetail { name = "chicken", price = 29.99, mood = "anger" });
            _foodMenuList.Add(new FoodDetail { name = "pasta", price = 15.00, mood = "anger" });
            _foodMenuList.Add(new FoodDetail { name = "apple", price = 1.00, mood = "contempt" });
            _foodMenuList.Add(new FoodDetail { name = "steak", price = 19.99, mood = "contempt" });
            _foodMenuList.Add(new FoodDetail { name = "pineapple", price = 8.99, mood = "disgust" });
            _foodMenuList.Add(new FoodDetail { name = "celery", price = 0.99, mood = "disgust" });
            _foodMenuList.Add(new FoodDetail { name = "salad", price = 15.00, mood = "fear" });
            _foodMenuList.Add(new FoodDetail { name = "cookie", price = 2.99, mood = "fear" });
            _foodMenuList.Add(new FoodDetail { name = "pizza", price = 12.99, mood = "happiness" });
            _foodMenuList.Add(new FoodDetail { name = "nugggets", price = 2.00, mood = "happiness" });
            _foodMenuList.Add(new FoodDetail { name = "bread", price = 4.00, mood = "neutral" });
            _foodMenuList.Add(new FoodDetail { name = "sandwich", price = 5.99, mood = "neutral" });
            _foodMenuList.Add(new FoodDetail { name = "coke", price = 1.00, mood = "sadness" });
            _foodMenuList.Add(new FoodDetail { name = "ice cream", price = 0.50, mood = "sadness" });
            _foodMenuList.Add(new FoodDetail { name = "chips", price = 2.50, mood = "surprise" });
            _foodMenuList.Add(new FoodDetail { name = "carrot", price = 1.99, mood = "surprise" });
        }
        public List<FoodDetail> getMenuList()
        {
            return _foodMenuList;
        }
    }
}
