using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Bagel_shop
    {
        private int capacity;
        private List<Item> products;


        public int Capacity { get { return capacity; } set { capacity = value; } }
        public List<Item> Products { get { return products; } set { products = value; } } 

        public Bagel_shop()
        {
            Capacity = 5;
            Products = new List<Item>();
            Products.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            Products.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            Products.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            Products.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            Products.Add(new Item("COFB", 0.99f, "Coffee", "Black"));
            Products.Add(new Item("COFW", 1.19f, "Coffee", "White"));
            Products.Add(new Item("COFC", 1.29f, "Coffee", "Cappucino"));
            Products.Add(new Item("COFL", 1.29f, "Coffee", "Latte"));
            Products.Add(new Item("FILB", 0.12f, "Filling", "Bacon"));
            Products.Add(new Item("FILE", 0.12f, "Filling", "Egg"));
            Products.Add(new Item("FILC", 0.12f, "Filling", "Cheese"));
            Products.Add(new Item("FILX", 0.12f, "Filling", "Cream Cheese"));
            Products.Add(new Item("FILS", 0.12f, "Filling", "Smoked Salmon"));
            Products.Add(new Item("FILH", 0.12f, "Filling", "Ham"));

        }



        public bool addItems(User user, Item item)
        {
            if (user.Role.Equals("Member of the public"))
            {
                if (checkCapacity(user))
                {
                    foreach(Item product in products)
                    {
                        if (product.Sku.Equals(item.Sku))
                        {
                            user.Items.Add(item);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool removeItems(User user, Item item)
        {
            if (user.Role.Equals("Member of the public"))
            {
                if (checkIfItemExist(user, item))
                {
                    foreach (Item item1 in user.Items)
                    {
                        if (item1.Sku.Equals(item.Sku))
                        {
                            user.Items.Remove(item1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkCapacity(User user)
        {
            if (user.Items.Count < Capacity)
            {
                return true;
            }
            return false;
        }

        public bool checkIfItemExist(User user, Item item)
        {
            foreach (Item item1 in user.Items)
            {
                if (item1.Sku.Equals(item.Sku))
                {
                    return true;
                }
            }
            return false;
        }

        public void changeCapacity(User user, int newvalue)
        {
            if (user.Role.Equals("Manager"))
            {
                Capacity = newvalue;
            }
        }

        public float totalCost(User user)
        {
            float total = 0.00f;
            if (user.Role.Equals("Customer"))
            {
                foreach (Item item in user.Items)
                {
                    total += item.Price;
                }
            }
            return total;
        }

        public float itemCost(User user, string code)
        {
            if (user.Role.Equals("Customer"))
            {
                foreach (Item product in products)
                {
                    if (product.Sku.Equals(code))
                    {
                        return product.Price;
                    }
                }
            }
            return 0f;
        }

        public void addFilling(User user, string code, string filling)
        {
            if (user.Role.Equals("Customer"))
            {
                foreach (Item item in user.Items)
                {
                    if (item.Sku.Equals(code))
                    {
                        foreach (Item product in products)
                        {
                            if (product.Variant.Equals(filling))
                            {
                                item.Price += product.Price;
                            }
                        }
                    }
                }
            }
        }

        public float costOfFilling(User user, string filling)
        {
           if (user.Role.Equals("Customer"))
            {
                foreach(Item product in products)
                {
                    if (product.Variant.Equals(filling))
                    {
                        return product.Price;
                    }
                }
            }
            return 0f;
        }


    }
}
