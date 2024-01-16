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
        public Basket() 
        {
            
        }

        public bool AddItem(string SKU)
        {
            List<Item> bagels = _inventory.listBagels();
            List<Item> coffees = _inventory.listCoffees();
            List<Item> fillings = _inventory.listFillings();

            List<Item> AllProducts = bagels.Concat(coffees).Concat(fillings).ToList();

            if (AllProducts.Exists(x => x.SKU == SKU))
            {
                Item addedItem = AllProducts.Single(x => x.SKU == SKU);
                _basket.Add(addedItem);
                return true;
            }

            return false;
        }

        public bool RemoveItem(string SKU)
        {
            if (_basket.Exists(x => x.SKU == SKU))
            {
                Item removedItem = _basket.Single(x => x.SKU == SKU);
                _basket.Remove(removedItem);
                return true;
            }
            return false;
        }
    }
}
