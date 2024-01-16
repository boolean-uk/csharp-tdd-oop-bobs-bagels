using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _inventory;
        private int _capacity;
        public List<Item> Inventory { get; }

        public Basket(int capacity = 10)
        {
            _capacity = capacity;

        }

        public Item AddItem(string SKU)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string SKU)
        {
            throw new NotImplementedException();
        }

        public float TotalCost()
        {
            throw new NotImplementedException();
        }

        public int ChangeCapacity(int newCapacity)
        {
            throw new NotImplementedException();
        }
        public float GetPrice(string SKU)
        {
            throw new NotImplementedException();
        }
    }
}
