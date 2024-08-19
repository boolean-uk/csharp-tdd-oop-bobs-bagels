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
        //Person person = new Person("Bob", Role.MANAGER);
        private int MAX_BASKET_SIZE { get; set; } = 5;

        public List<Item> basketItems = new List<Item>();

        //Help method for not having to write the long condition check in the if statement in addItem :)
        public bool Equals(Item one, Item two)
        {
            if (one.id == two.id && one.price == two.price && one.name == two.name && one.variant == two.variant)
            {
                return true;
            }
            return false;
        }

        public bool addItem(Item? plainBagel)
        {
            // initiate max size of basket
            if (plainBagel == null) 
            {
                Console.WriteLine("Wrong input!");
                return false; 
            }

            if (basketItems.Count < MAX_BASKET_SIZE && inventory.getInventory().Any(item => Equals(item, plainBagel))) {
                basketItems.Add(plainBagel);
                return true;
            }
/*
            if (basketItems.Count < MAX_BASKET_SIZE && inventory.getInventory().Any(x => 
                x.id == plainBagel.id && x.price == plainBagel.price && x.name == plainBagel.name && x.variant == plainBagel.variant))
            {
                basketItems.Add(plainBagel);
                return true;
            }
*/
                Console.WriteLine("Basket is full or not in our inventory!");
                return false;

        }
        
        public bool removeBagelOrItem(Item item)
        {
            if (!basketItems.Any(x => Equals(x, item)))
            {
                Console.WriteLine($"{item.name} {item.variant} not in basket!");
                return false;
            }

            basketItems.Remove(item);

            Console.WriteLine("Removed: " + item.variant);
            return true;
        }

        public int changeBasketCapacity(int newCapacity, Role role)
        {
  
            if (role != Role.MANAGER)
            {
                Console.WriteLine("Only the manager can change capacity!");
                return -1;
            }

            MAX_BASKET_SIZE = newCapacity;

            basketItems.Capacity = MAX_BASKET_SIZE;

            Console.WriteLine(basketItems.Capacity);
            return basketItems.Capacity;  
        }

        public double totalCost()
        {
            throw new NotImplementedException();
        }
    }
}
