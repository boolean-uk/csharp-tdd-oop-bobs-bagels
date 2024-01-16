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
        int limit = 0;
        public Basket(int limit)
        {
            this.limit = limit;

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
            return false;
        }
        
    }
}
