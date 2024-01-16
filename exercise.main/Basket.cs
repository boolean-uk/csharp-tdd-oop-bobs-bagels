using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _basket = new List<Item>();
        private Inventory _inventory = new Inventory();
        private int _capacity = 5;
        private List<float> totalCost = new List<float>();
        private enum Bundles { b6, b12, bac };
        public Basket() 
        {
            
        }

        // helper
        public void priceRemover(float price, int iter)
        {
            for (int i = 0;  i < iter; i++)
            {
                totalCost.Remove(price);
            }
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
                Item newItem = new Item(addedItem.data.SKU, addedItem.data.Name, addedItem.data.Price, addedItem.data.Variant);
                totalCost.Add(addedItem.data.Price);
                _basket.Add(newItem);

                return newItem;
            }


            if (_basket.Count >= _capacity)
            {
                Console.WriteLine("Basket size exceeded!");
                return noneItem;
            }

            return noneItem;
        }

        public void BundleOrder(string descr, string SKU, string SKU2)
        {
            float extract = _basket.FirstOrDefault(x => x.data.SKU == SKU).data.Price;
            Console.WriteLine(Bundles.b12.ToString());

            if (Bundles.b6.ToString() == descr)
            {
                int res = _basket.Count(x => x.data.SKU.Contains(SKU));
                if (res >= 6)
                {
                    priceRemover(extract, 6);
                    totalCost.Add(2.49F);
                }
            }

            if (Bundles.bac.ToString() == descr)
            {
                int resb = _basket.Count(x => x.data.SKU.Contains(SKU));
                int resc = _basket.Count(x => x.data.SKU.Contains(SKU2));

                float extract2 = _basket.FirstOrDefault(x => x.data.SKU == SKU2).data.Price;

                if (resb >= 1 && resc >= 1)
                {
                    priceRemover(extract, 1);
                    priceRemover(extract2, 1);
                    totalCost.Add(1.25F);
                }
            }

            if (Bundles.b12.ToString() == descr)
            {
                  
                int res2 = _basket.Count(x => x.data.SKU.Contains(SKU));

                if (res2 >= 12)
                {
                    priceRemover(extract, 12);
                    totalCost.Add(3.99F);
                }

            }
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
                totalCost.Add(fill.data.Price);
            }
        }
        public float TotalCost()
        {
            return totalCost.Sum();
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
