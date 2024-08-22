using exercise.main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket2
    {
        Inventory2 inventory2 = new Inventory2();
        //Person person = new Person("Bob", Role.MANAGER);
        private int MAX_BASKET_SIZE { get; set; } = 5;

        public List<IItem> _basketItems = new List<IItem>();

        public Dictionary<IItem, int> itemsWithCount = new Dictionary<IItem, int>();


        //Help method for not having to write the long condition check in the if statement in addItem :)
        public bool itemsIsEqual(IItem one, IItem two)
        {
            if (one.id == two.id && one.price == two.price && one.name == two.name && one.variant == two.variant)
            {
                return true;
            }
            return false;
        }
        public bool addItem(IItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Wrong input!");
                return false;
            }

            if (_basketItems.Count < MAX_BASKET_SIZE && inventory2.getInventory2().Any(i => itemsIsEqual(i, item)))
            {
                _basketItems.Add(item);
                return true;
            }

            Console.WriteLine("Basket is full or not in our inventory!");
            return false;
        }

        public bool removeItem(IItem item)
        {
            if (!_basketItems.Any(x => itemsIsEqual(x, item)))
            {
                Console.WriteLine($"{item.name} {item.variant} not in basket!");
                return false;
            }

            _basketItems.Remove(item);

            Console.WriteLine($"Removed: {item.name} {item.variant}");
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

            return MAX_BASKET_SIZE;
        }

        public double totalCost()
        {
            return Math.Round(_basketItems.Sum(item => item.price), 2);
        }

        public double getPriceOfItem(IItem item)
        {
            if (!inventory2.getInventory2().Any(x => itemsIsEqual(x, item)))
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


            _basketItems.ForEach(item => {

                if (!itemsCounted.Contains(item.id))
                {
                    int itemCount = 0;
                    foreach (var copy in _basketItems)
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
    }
}
