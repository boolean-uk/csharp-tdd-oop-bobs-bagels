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

            int bagelAmount = basket.Count(t => t.Type == Product.pType.Bagel);
            //check if basket is full, if string is empty and if item exists in inventory
            if (foundItem != null && (bagelAmount <= limit))
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

        public double Sum()
        {
            double sum = 0;
            foreach (Product product in basket.Where(item=>item.Type == Product.pType.Bagel))
            {
                if (product.Filling.Count > 0) sum += product.Price;
            }
            sum += basket.Sum(item => item.Price);

            return sum;
        }
        
    }
}
