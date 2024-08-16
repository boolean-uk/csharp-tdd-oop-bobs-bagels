using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Inventory inventory = new Inventory();
        private List<string> basket = new List<string>();
        public void Add(string name, string variant)
        {
            basket.Add(inventory.GetCode(name, variant));
        }

        public bool OrderInBasket(string name, string variant)
        {
            
            foreach (var order in basket)
            {
                if(name == inventory.GetNameAndVariant(order).name &&
                   variant == inventory.GetNameAndVariant(order).variant)
                {
                return true; 
                }
                
            }
            return false;
        }

        public double ShowCost()
        {
            double retCost = 0.0;
            foreach (var sku in basket)
            {
                retCost += inventory.GetPrice(sku);
            }
            return retCost;
        }
    }
}
