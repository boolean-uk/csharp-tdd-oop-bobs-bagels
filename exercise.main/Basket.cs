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
        private IInventory _inventory;
        private int _capacity = 5;
        private List<float> totalCost = new List<float>();
        private enum Bundles { b6, b12, bac };

        public Basket(IInventory inventory) 
        {
            this._inventory = inventory;
        }

        // helper for handling discounts
        public void priceRemover(float price, int iter)
        {
            for (int i = 0;  i < iter; i++)
            {
                totalCost.Remove(price);
            }
        } 

        public Item AddItem(Item item)
        {
            Item noneItem = new Bagel();

            List<Item> AllProducts = _inventory.listContents();

            if (AllProducts.Exists(x => x.SKU == item.SKU) && _basket.Count < _capacity)
            {
                Item addedItem = AllProducts.FirstOrDefault(x => x.SKU == item.SKU);
                Item newItem = new Bagel(addedItem.SKU, addedItem.Name, addedItem.Price, addedItem.Variant);
                totalCost.Add(addedItem.Price);
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
            float extract = _basket.FirstOrDefault(x => x.SKU == SKU).Price;
            Console.WriteLine(Bundles.b12.ToString());

            if (Bundles.b6.ToString() == descr)
            {
                int res = _basket.Count(x => x.SKU.Contains(SKU));
                if (res >= 6)
                {
                    priceRemover(extract, 6);
                    totalCost.Add(2.49F);
                }
            }

            if (Bundles.bac.ToString() == descr)
            {
                int resb = _basket.Count(x => x.SKU.Contains(SKU));
                int resc = _basket.Count(x => x.SKU.Contains(SKU2));

                float extract2 = _basket.FirstOrDefault(x => x.SKU == SKU2).Price;

                if (resb >= 1 && resc >= 1)
                {
                    priceRemover(extract, 1);
                    priceRemover(extract2, 1);
                    totalCost.Add(1.25F);
                }
            }

            if (Bundles.b12.ToString() == descr)
            {
                  
                int res2 = _basket.Count(x => x.SKU.Contains(SKU));

                if (res2 >= 12)
                {
                    priceRemover(extract, 12);
                    totalCost.Add(3.99F);
                }

            }
        }

        public bool RemoveItem(Item item)
        {
            if (_basket.Exists(x => x.SKU == item.SKU))
            {
                Item removedItem = _basket.FirstOrDefault(x => x.SKU == item.SKU);
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

        public void AddFilling(string ID, Filling filling)
        {
            Bagel it = (Bagel)_basket.Single(x => x.ID == ID);
            List<Item> fillings = _inventory.listContents();

            if (fillings.Exists(x => x.SKU  == filling.SKU) )
            {
                Item fill = fillings.Single(x => x.SKU == filling.SKU);
                it.AddFilling(fill);
                totalCost.Add(fill.Price);
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

        public float GetItemPrice(Item item)
        {
            List<Item> AllProducts = _inventory.listContents();

            if (AllProducts.Exists(x => x.SKU == item.SKU))
            {
                Item resultItem = AllProducts.FirstOrDefault(x => x.SKU == item.SKU);
                return resultItem.Price;
            }

            Console.WriteLine("Product not found!");
            return 0F;
        }

        public void PrintReceit()
        {

        }
    }
}
