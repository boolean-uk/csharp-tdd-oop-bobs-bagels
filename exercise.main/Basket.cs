using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Exceptions;
using exercise.main.Items;

namespace exercise.main
{
    public class Basket
    {
        private Dictionary<string, List<Item>> _inventory = new()
        {
            { "Bagel", new() {
                    new Bagel("Onion", .49f),
                    new Bagel("Plain", .39f),
                    new Bagel("Everything", .49f),
                    new Bagel("Sesame", .49f),
            } },
            { "Coffee", new()
            {
                new Coffee("Black", .99f),
                new Coffee("White", 1.19f),
                new Coffee("Capuccino", 1.29f),
                new Coffee("Latte", 1.29f),
            } },
            { "Filling", new()
            {
                new Filling("Bacon", .12f),
                new Filling("Egg", .12f),
                new Filling("Cheese", .12f),
                new Filling("Cream Cheese", .12f),
                new Filling("Smoked Salmon", .12f),
                new Filling("Ham", .12f),
            } }
        };
        private static int _capacity = 25;
        public static int Capacity { get { return _capacity; } }
        private List<Item> _items = [];
        public List<Item> Items { get { return _items; } }

        public bool Add(Item item)
        {
            if (Items.Count >= Capacity) return false;
            Items.Add(item);
            return true;
        }

        public bool Remove(Item item) 
        { 
            return Items.Remove(item);
        }

        public Receipt TotalCost { get { return Receipt.GetReceipt(_items); } }

        public static void UpdateCapacity(int newCapacity, Role role)
        {
            if (role.AccessLevel > Role.GetAccessLevel("manager")) throw new PermissionDeniedException("You do not have permission to perform that action!");
            _capacity = newCapacity;
        }
    }
}
