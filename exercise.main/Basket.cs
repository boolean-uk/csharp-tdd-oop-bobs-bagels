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
        private float totalCost = 0F;
        public Basket() 
        {
            
        }

        public Item AddItem(string SKU)
        {
            Item noneItem = new Item();

            List<Item> bagels = _inventory.listBagels();
            List<Item> coffees = _inventory.listCoffees();
            List<Item> fillings = _inventory.listFillings();

            List<Item> AllProducts = bagels.Concat(coffees).Concat(fillings).ToList();

            if (AllProducts.Exists(x => x.data.SKU == SKU) && _basket.Count < _capacity)
            {
                Item addedItem = AllProducts.FirstOrDefault(x => x.data.SKU == SKU);
                totalCost = totalCost + addedItem.data.Price;
                _basket.Add(addedItem);
                return addedItem;
            }

            if (_basket.Count >= _capacity)
            {
                Console.WriteLine("Basket size exceeded!");
                return noneItem;
            }

            return noneItem;
        }

        public bool RemoveItem(string SKU)
        {
            if (_basket.Exists(x => x.data.SKU == SKU))
            {
                Item removedItem = _basket.FirstOrDefault(x => x.data.SKU == SKU);
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

        public void AddFilling(string ID, string SKU)
        {
            Item it = _basket.Single(x => x.ID == ID);
            List<Item> fillings = _inventory.listFillings();

            if (fillings.Exists(x => x.data.SKU  == SKU) )
            {
                Item fill = fillings.Single(x => x.data.SKU == SKU);
                it.Contents.Add(fill);
            }
        }
        public float TotalCost()
        {
            return totalCost;
        }

        public Item GetItem(string ID)
        {
            Item item = _basket.Single(x => x.ID == ID);
            return item;
        }

        public float GetItemPrice(string SKU)
        {
            List<Item> bagels = _inventory.listBagels();
            List<Item> coffees = _inventory.listCoffees();
            List<Item> fillings = _inventory.listFillings();

            List<Item> AllProducts = bagels.Concat(coffees).Concat(fillings).ToList();

            if (AllProducts.Exists(x => x.data.SKU == SKU))
            {
                Item resultItem = AllProducts.FirstOrDefault(x => x.data.SKU == SKU);
                return resultItem.data.Price;
            }

            return 0F;
        }
    }
}
