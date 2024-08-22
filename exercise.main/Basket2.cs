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
    }
}
