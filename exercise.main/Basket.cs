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

        public Dictionary<Item, int> countOfItems = new Dictionary<Item, int>();

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
            return basketItems.Sum(item => item.price);
        }

        public double getPriceOfItem(Item item)
        {
            if (!inventory.getInventory().Any(x => Equals(x, item)))
            {
                Console.WriteLine($"{item.name} {item.variant} not in Bobs inventory");
                return -1;
            }

            return item.price;
        }

        public void Receipt()
        { 
           
            List<string> itemsCounted = new List<string>();

            string receipt = "~~~ Bob's Bagels ~~~" + "\n\n" +
                DateTime.Now.ToString() + "\n\n" +
                "------------------------" + "\n\n";


            basketItems.ForEach(item => {

                if (!itemsCounted.Contains(item.id))
                {
                    int itemCount = 0;
                    foreach (var copy in basketItems)
                    {
                        if (copy.id == item.id)
                        {
                            itemCount++;
                        }
                    }
                 receipt += $"{item.name} {item.variant}   {itemCount}  £{item.price * itemCount} \n\n";
                 itemsCounted.Add(item.id);
                }            
            });

            receipt += $"------------------------ \n\nTotal             £{totalCost()} \n\nThank you for your order!";

            Console.WriteLine(receipt);
        }

        public double discount()
        {

            List<string> itemsCounted = new List<string>();
           
            basketItems.ForEach((item) =>
            {

                if (!itemsCounted.Contains(item.id))
                {
                    int itemCount = 0;
                    foreach (var copy in basketItems)
                    {
                        if (copy.id == item.id)
                        {
                            itemCount++;
                        }
                    }

                    countOfItems.Add(item, itemCount);
                    itemsCounted.Add(item.id);
                }
            });

            // if (basketItems.Contains("COF") && basketItems.Contains("BGL")) ;

            double bagAndCof = 1.25;
            double sixBagels = 2.49;
            double twelBagels = 3.99;

            List<Item> cof = inventory.getInventory().Where(item => item.id.Contains("COF")).ToList();
            List<Item> bgl = inventory.getInventory().Where(item => item.id.Contains("BGL")).ToList();

            Console.WriteLine(basketItems.Count);

            if (basketItems.Count == 2 && ((itemsCounted.Any().ToString() == cof.Any().ToString() && itemsCounted.Any().ToString() == bgl.Any().ToString())))
            {
                return bagAndCof;
            }

            if (countOfItems.Count > 0)
            {

                foreach (var item in countOfItems)
                {
                   
                    if (item.Key.id.Contains("BGL") && item.Value == 6)
                    {
                        return sixBagels;
                    }
                    else if (item.Key.id.Contains("BGL") && item.Value == 12)
                    {
                        return twelBagels;
                    }
                    else
                    { 
                        return 0; 
                    }
                }
            }

            return 0;
        }
    }
}
