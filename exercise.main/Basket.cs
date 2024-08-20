using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main

{
    public class Basket
    {
        private Inventory _inventory = new Inventory();
        public Inventory Inventory { get => _inventory; }
        public List<Item> Item { get; set; } = new List<Item> { };

        public int max_capasity { get; set; }

        public bool addItem(Item item)
        {
            if (item == null)
            {
                return false;
            } else if (Item.Count <= max_capasity)
            {
                Item.Add(item);
                return true;
            } else
            {
                return false;
            }


            //if (Item.Count() <= max_capasity)
            //{
            //    Item.Add(item);
            //    return true;
            //} else if (item == null)
            //{
            //    return false;
            //}
            //return false;

        }
        public bool removeItem(Item item)
        {
            if (Item.Count() > max_capasity)
            {
                Item.Remove(item);
                return true;
            }
            return false;

        }
        public bool isFull()
        {
            if (Item.Count() <= max_capasity)
            {
                return true;
            }
            return false;
        }

        public bool changecapacity(int newcapasity)
        {

            if (newcapasity > 0 && newcapasity != max_capasity)
            {
                max_capasity = newcapasity;
                return true;
            }
            return false;

        }
        public string removingNotExisting(Item item)
        {
            if (!Item.Contains(item))
            {
                return "Item does not exists";
            }
            return "Item exists";
        }

        public double getTotalCost()
        {
            return Item.Sum(item => item.Price);

        }

        public double getBagelPrice(string sku)
        {
            Inventory inventory = new Inventory();

            Item bagel = inventory.ShopInventory.Find(item => item.Sku == sku);

            if (inventory.ShopInventory.Contains(bagel))
            {
                return bagel.Price;
            }
            return 0;

        }

        public string getChosenFilling(string sku)
        {
            Inventory inventory = new Inventory();

            Item bagelwithfilling = inventory.ShopInventory.Find(item => item.Sku == sku);

            if (inventory.ShopInventory.Contains(bagelwithfilling))
            {
                return bagelwithfilling.Variant;
            }
            return "Not existing";
        }

        public double getFillingCost(string variant)
        {
            Inventory inventory = new Inventory();
            double fillingprice = 0;

            foreach (Item item in inventory.ShopInventory)
            {
                if (item.Variant == variant)
                {
                    fillingprice = item.Price;
                    return fillingprice;
                }
            }
            return 0.0d;

        }

        /* public bool checknonexistsing(string sku)
        {
            Inventory inventory = new Inventory();

            foreach (Item item in Inventory.ShopInventory)
            {
                if (item.Sku == sku)
                {
                    return true;

                }

            }
            return false;
        }
        */
    }
}
