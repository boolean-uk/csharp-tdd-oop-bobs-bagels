using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _basket = new List<Item>();
        private Inventory _inventory = new Inventory();
        private int _capacity = 5;
        public Basket() 
        {
            
        }

        public bool AddItem(string SKU)
        {
            List<Item> bagels = _inventory.listBagels();
            List<Item> coffees = _inventory.listCoffees();
            List<Item> fillings = _inventory.listFillings();

            List<Item> AllProducts = bagels.Concat(coffees).Concat(fillings).ToList();

            if (AllProducts.Exists(x => x.SKU == SKU) && _basket.Count < _capacity)
            {
                Item addedItem = AllProducts.FirstOrDefault(x => x.SKU == SKU);
                _basket.Add(addedItem);
                return true;
            }

            if (_basket.Count >= _capacity)
            {
                Console.WriteLine("Basket size exceeded!");
                return false;
            }

            return false;
        }

        public bool RemoveItem(string SKU)
        {
            if (_basket.Exists(x => x.SKU == SKU))
            {
                Item removedItem = _basket.FirstOrDefault(x => x.SKU == SKU);
                _basket.Remove(removedItem);
                return true;
            }
            else
            {
                Console.WriteLine("Item not in basket!");
            }
            return false;
        }

        public void ChangeCapacity(int newCapacity)
        {
            this._capacity = newCapacity;
        }
    }
}
