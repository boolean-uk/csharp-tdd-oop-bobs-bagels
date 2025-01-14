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

        private static int _capacity = 25;
        public static int Capacity { get { return _capacity; } }
        private List<Item> _items = [];
        public List<Item> Items { get { return _items.ToList(); } }

        public bool Add(Item item)
        {
            if (_items.Count >= Capacity) return false;
            _items.Add(item);
            return true;
        }

        public bool Remove(Item item) 
        { 
            return _items.Remove(item);
        }

        public Receipt TotalCost { get { return new Receipt(_items); } }

        public static void UpdateCapacity(int newCapacity, Role role)
        {
            if (role.AccessLevel > Role.GetAccessLevel("manager")) throw new PermissionDeniedException("You do not have permission to perform that action!");
            _capacity = newCapacity;
        }
    }
}
