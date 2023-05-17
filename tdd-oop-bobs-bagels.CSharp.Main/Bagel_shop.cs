using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main.Products;
using Users;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Bagel_shop
    {
        private int capacity;
        private List<Items> products;


        public int Capacity { get { return capacity; } set { capacity = value; } }
        public List<Items> Products { get { return products; } set { products = value; } }

        public Bagel_shop()
        {
            Capacity = 5;
            Products = new List<Items>();
            Products.Add(new Bagel("BGLO", 0.49f, "Onion")); ;
            Products.Add(new Bagel("BGLP", 0.39f, "Plain"));
            Products.Add(new Bagel("BGLE", 0.49f, "Everything"));
            Products.Add(new Bagel("BGLS", 0.49f, "Sesame"));
            Products.Add(new Coffee("COFB", 0.99f, "Black"));
            Products.Add(new Coffee("COFW", 1.19f, "White"));
            Products.Add(new Coffee("COFC", 1.29f, "Cappucino"));
            Products.Add(new Coffee("COFL", 1.29f, "Latte"));
            Products.Add(new Filling("FILB", 0.12f, "Bacon"));
            Products.Add(new Filling("FILE", 0.12f, "Egg"));
            Products.Add(new Filling("FILC", 0.12f, "Cheese"));
            Products.Add(new Filling("FILX", 0.12f, "Cream Cheese"));
            Products.Add(new Filling("FILS", 0.12f, "Smoked Salmon"));
            Products.Add(new Filling("FILH", 0.12f, "Ham"));

        }



        public bool addItems(Userr user, Items item)
        {
            if (user is Member)
            {
                if (checkCapacity(user))
                {
                    foreach (Items product in products)
                    {
                        if (product.sku.Equals(item.sku))
                        {
                            user.items.Add(item);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool removeItems(Userr user, Items item)
        {
            if (user is Member)
            {
                if (checkIfItemExist(user, item))
                {
                    foreach (Items item1 in user.items)
                    {
                        if (item1.sku.Equals(item.sku))
                        {
                            user.items.Remove(item1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool checkCapacity(Userr user)
        {
            if (user.items.Count < Capacity)
            {
                return true;
            }
            return false;
        }

        public bool checkIfItemExist(Userr user, Items item)
        {
            foreach (Items item1 in user.items)
            {
                if (item1.sku.Equals(item.sku))
                {
                    return true;
                }
            }
            return false;
        }

        public void changeCapacity(Userr user, int newvalue)
        {
            if (user is Manager)
            {
                Capacity = newvalue;
            }
        }

        public float totalCost(Userr user)
        {
            float total = 0.00f;
            if (user is Customer)
            {
                foreach (Items item in user.items)
                {
                    total += item.price;
                }
            }
            return total;
        }

        public float itemCost(Userr user, string code)
        {
            if (user is Customer)
            {
                foreach (Items product in products)
                {
                    if (product.sku.Equals(code))
                    {
                        return product.price;
                    }
                }
            }
            return 0f;
        }

        public void addFilling(Userr user, string code, string filling)
        {
            if (user is Customer)
            {
                foreach (Items item in user.items)
                {
                    if (item.sku.Equals(code))
                    {
                        foreach (Items product in products)
                        {
                            if (product.variant.Equals(filling))
                            {
                                item.price += product.price;
                            }
                        }
                    }
                }
            }
        }

        public float costOfFilling(Userr user, string filling)
        {
            if (user is Customer)
            {
                foreach (Items product in products)
                {
                    if (product.variant.Equals(filling))
                    {
                        return product.price;
                    }
                }
            }
            return 0f;
        }


    }
}
