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

        public int GetSize()
        {
            return basket.Count;
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

        public bool RemoveFromBasket(string name, string variant)
        {
            string code = inventory.GetCode(name, variant);
            if(name == "Coffee" || name == "Bagel")
            {
                for(int i = 0; i < basket.Count; i++)
                {
                    if (basket[i].coffeeOrBagel == code)
                    {
                        basket.RemoveAt(i);
                        return true;
                    }
                }
            }
            if (name == "Filling")
            {
                for (int i = 0; i < basket.Count; i++)
                {
                    if (basket[i].filling == code)
                    {
                        BasketItem replaceItem = basket[i];
                        replaceItem.filling = string.Empty;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
