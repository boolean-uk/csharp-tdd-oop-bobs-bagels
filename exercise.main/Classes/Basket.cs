using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Basket
    {
        public List<Item> Items { get; set; } = new();
        public int Capacity { get; set; }

        public Basket(int capacity) 
        { 
            Capacity = capacity;
            //Items.Add(new Item("", 0, 0, ""));
        }

        public string Add(Item item) //code is "decoded" in store class
        {

            if (Items.Count < Capacity)
            {
                if (item.SKU[..2] == "FIL")
                {
                    //add filling to previous Bagel added to cart
                    List<Bagel> bagels = Items.ToList().Where(i => i.Name == Name.Bagel).ToList().ConvertAll(x => (Bagel)x);
                    if (bagels.Count > 0)
                    {
                        bagels.First().AddFilling((Filling)item);
                    }
                    else { Items.Add((Filling)item); } //Add filling to nothing
                }
                else {
                    Items.Add(item);
                }
                return "";
            }
            return "Basket is full";
            
        }

        public string Remove(string sku) 
        { 
            //Check if filling and remove the first instance on the first bagel available
            if (sku[..2] == "FIL")
            {
                List<Bagel> bagels = Items.ToList().Where(i => i.Name == Name.Bagel).ToList().ConvertAll(x => (Bagel)x);
                if (bagels.Count > 0)
                {
                    foreach (Bagel bagel in bagels)
                    {
                        if (bagel.Fillings.ToList().Where(f => f.SKU == sku).Count() > 0)
                        {
                            bagel.RemoveFilling(sku);
                            return "";
                        }
                    }
                }
            }
            //Otherwise remove the first occurence of sku
            foreach (Item item in Items) 
            { 
                if (item.SKU == sku)
                {
                    Items.Remove(item);
                    return "";
                }
            }

            return "Could not find given item type";
        }

        public double Cost()
        {
            double cost = 0;
            foreach(Item item in Items)
            {
                if (item.Name == Name.Bagel)
                {
                    foreach (Filling filling in item.GetFilling())
                    {
                        cost += filling.Price;
                    }
                }
                cost += item.Price;
            }
            return cost;
        }

    }
}
