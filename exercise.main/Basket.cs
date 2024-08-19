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
        
        public bool addItem(string itemType, string variant)
        {

            Item item = inventory.findItemByName(variant);
            
            if (items_in_basket >= MAX_BASKET_SIZE)
            {
                Console.WriteLine("Basket is full...");
                return false;
            }
            if (item != null) { 
                yourBasket.Add(item);
                items_in_basket++;
                return true;
            }
            else
            {
                Console.WriteLine("No such item...");
                return false;
            }
        }

        public void removeItem(string itemName)
        {
            Item item = inventory.findItemByName(itemName);
            if (!yourBasket.Contains(item))
            {
                Console.WriteLine("Your basket does not contain this item...");
                return;
            }
            else
            {
                yourBasket.Remove(item);
            }
        }

        public void changeCapacity(int newCapacity, Person person)
        {
            if ((newCapacity <= 0) || (person.role == Role.CUSTOMER))
            {
                Console.WriteLine("Cannot change capacity to 0 or lower or you do not have the permission to do this action...");
            }
            else
            {
                MAX_BASKET_SIZE = newCapacity;
            }
        }

        public double checkTotal()
        {
            return yourBasket.Sum(item => item.price);
        }

        public double checkPriceForType(string type)
        {
            return inventory.findItemByName(type).price;
        }
    }
}
