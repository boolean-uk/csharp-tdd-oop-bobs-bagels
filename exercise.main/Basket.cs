using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Item> _basket = new List<Item>();
        private Inventory _inventory;
        private int _capacity = 5;
        private List<float> totalCost = new List<float>();
        private enum Bundles { b6, b12, bac };


        public Basket(Inventory inventory) 
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
                throw new Exception("Basket size exceeded!");
            }

            throw new Exception("SKU not found!");
        }

        public void BundleOrder(string descr, List<Item> items)
        {
            float extract = _basket.FirstOrDefault(x => x.SKU == items[0].SKU).Price;

            if (Bundles.b6.ToString() == descr)
            {
                bagelBundle(items, extract, 6, 2.49F);
            }

            if (Bundles.bac.ToString() == descr)
            {
                BagelCoffeeBundle(items, extract);
            }

            if (Bundles.b12.ToString() == descr)
            {
                bagelBundle(items, extract, 12, 3.99F);
                  
            }
        }

        private void bagelBundle(List<Item> items, float extract, int amount, float newCost)
        {
            int res = _basket.Count(x => x.SKU.Contains(items[0].SKU));
            List<Item> basketItems = _basket.Where(x => x.SKU == items[0].SKU).Where(x => x.isInBundle() == false).Take(amount).ToList();
            List<string> idList = basketItems.Select(x => x.ID).ToList();

            if (res >= 6)
            {
                priceRemover(extract, amount);
                totalCost.Add(newCost);

                foreach (Item it in basketItems)
                {

                    if (it.isInBundle() == false)
                    {
                        it.putToBundle(idList);
                    }

                }
            }
        }

        private void BagelCoffeeBundle(List<Item> items, float extract)
        {
            int resb = _basket.Count(x => x.SKU.Contains(items[0].SKU));
            int resc = _basket.Count(x => x.SKU.Contains(items[1].SKU));

            float extract2 = _basket.FirstOrDefault(x => x.SKU == items[1].SKU).Price;

            List<string> skuList = new List<string> { items[0].SKU, items[1].SKU };

            List<Item> basketItems = _basket.Where(x => x.isInBundle() == false)
                                            .Where(x => skuList.Contains(x.SKU))
                                            .GroupBy(x => x.SKU).Select(x => x.First()).ToList();

            List<string> idList = basketItems.Select(x => x.ID).ToList();

            if (resb >= 1 && resc >= 1)
            {
                priceRemover(extract, 1);
                priceRemover(extract2, 1);
                totalCost.Add(1.25F);

                foreach (Item it in basketItems)
                {
                    if (it.isInBundle() == false)
                    {
                        it.putToBundle(idList);
                    }
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
            if(newCapacity < _basket.Count )
            {
                throw new Exception("Cannot reduce the basket size below current item count!");
            }
            this._capacity = newCapacity;
        }



        public void AddFilling(string ID, Filling filling)
        {
            
             Bagel it = (Bagel)_basket.Single(x => x.ID == ID);

            List<Item> fillings = _inventory.listContents();

            if (fillings.Exists(x => x.SKU  == filling.SKU) )
            {
                it.AddFillingToBagel(filling);
                totalCost.Add(filling.Price);
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

        public void PrintReceipt(Receit receit)
        {
            float totalprice = TotalCost();
            receit.PrintReceit(totalprice, _basket);

        }
    }
}
