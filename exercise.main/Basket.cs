using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public struct BasketItem
        {
            public string coffeeOrBagel = string.Empty;
            public string filling = string.Empty;

            public BasketItem(string coffeeOrBagel)
            {
                this.coffeeOrBagel = coffeeOrBagel;
            }
            public BasketItem(string coffeeOrBagel, string filling)
            {
                this.coffeeOrBagel = coffeeOrBagel;
                this.filling = filling;
            }
        }
   
        Inventory inventory = new Inventory();
        private List<BasketItem> basket = new List<BasketItem>();
        public void Add(BasketItem item)
        {
            basket.Add(item);
        }

        public bool OrderInBasket(string name, string variant)
        {
            
            foreach (var order in basket)
            {
                if(name == inventory.GetNameAndVariant(order.coffeeOrBagel).name &&
                   variant == inventory.GetNameAndVariant(order.coffeeOrBagel).variant)
                {
                    return true; 
                }
                
            }
            return false;
        }

        public double ShowCost()
        {
            double retCost = 0.0;
            foreach (var item in basket)
            {
                retCost += inventory.GetPrice(item.coffeeOrBagel);
                retCost += inventory.GetPrice(item.filling);
            }
            return retCost;
        }
    }
}
