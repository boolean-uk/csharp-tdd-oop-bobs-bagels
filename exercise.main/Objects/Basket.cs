using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Basket
    {
        public List<Product> basket { get; } = new List<Product>();
        public Inventory inventory = new Inventory();
        public static int limit = 3;
        
        public Basket()
        {

        }
        public bool Add(string SKU)
        {
            Product foundItem = inventory.items.FirstOrDefault(item => item.SKU == SKU);

            //check if basket is full, if string is empty and if item exists in inventory
            if (foundItem != null && (basket.Count <= limit))
            {
                basket.Add(foundItem);
                return true;
            }         
            return false;
            
        }
        public bool Remove(string SKU)
        {
            Product foundItem = basket.FirstOrDefault(item => item.SKU == SKU);
            if (foundItem != null)
            {
                basket.Remove(foundItem);
                return true;
            }
            return false;
        }
        protected internal bool BasketSize(int newSize)
        {
            if (newSize < 0)
                return false;

            limit = newSize;
            return true;
        }

    }
}
