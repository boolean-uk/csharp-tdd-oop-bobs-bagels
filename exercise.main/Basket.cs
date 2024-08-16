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
        public int MAX_BASKET_SIZE { get; set; } = 3;
        public List<Item> yourBasket = new List<Item>();
        public int items_in_basket = 0;
        public void addItem(string itemType, string variant)
        {

            Item item = inventory.findItemByName(variant);
            Console.WriteLine(item.variant + " - " + itemType);
            if (items_in_basket >= MAX_BASKET_SIZE)
            {
                Console.WriteLine("Basket is full...");
                return;
            }
            if (item != null) { 
                yourBasket.Add(item);
            }
            else
            {
                Console.WriteLine("No such item...");
            }

            //throw new NotImplementedException();
        }
    }
}
