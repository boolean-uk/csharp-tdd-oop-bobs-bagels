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

        //Returns cost of cart after discounts
        public double DiscountedCost()
        {
            double cost = 0;
            

            //cost = stock.DiscountEvaluate();

            return cost;
        }

        //Finds the best discount values and returns which items should be used for which discount
        public double BestDiscountValue()
        {
            Stock stock = new();
            List<(Discount discount, List<Item> items, double originalPrice, double discountPrice)> Checkout = new(); //Contains all products as they are checked out

            //Check if everything a coffee deal
            double tempDeal = 0;
            List<Item> coffees = new();
            List<Item> bagels = new();
            coffees = Items.ToList().Where(c => c.Name == Name.Coffee).OrderByDescending(c => c.Price).ToList();
            bagels = Items.ToList().Where(b => b.Name == Name.Bagel).OrderByDescending(b => b.Price).ToList();
            //For the most expensive coffee+bagel pairs
            for(int i = 0; i < coffees.Count && i < bagels.Count; i++)
            {
                //For the coffee deals with the SKU, get the first bagel deal that matches bagel SKU
                tempDeal += stock.deals.ToList().Where(c => c.sku[0] == coffees[i].SKU).First(b => b.sku[1] == bagels[i].SKU).saved;
            
            }
            //Compare it to 12 and 6 bagel deals
            List<Item> Twelveof = Items.ToList().GroupBy(x => x).Where(g => g.Count() > 11).SelectMany(g => g).ToList(); // Get all bagels that there are 12 of
            List<Item> Sixof = Items.ToList().GroupBy(x => x).Where(g => g.Count() > 5 && g.Count() < 12).SelectMany(g => g).ToList(); // Get all bagels that there are 6 of but less than 12
            double dealTwelveOf = 0;
            double dealSixOf = 0;
            foreach (Item bagel in Twelveof)
            {
                dealTwelveOf += stock.deals.ToList().Find(b => bagel.SKU == b.sku[0] && b.discount == Discount.TwelveBagel).saved;
            }
            foreach (Item bagel in Sixof)
            {
                dealSixOf += stock.deals.ToList().Find(b => bagel.SKU == b.sku[0] && b.discount == Discount.SixBagel).saved;
            }
            if (tempDeal > dealTwelveOf + dealSixOf)
            {
                return tempDeal;
            }
            

            return dealTwelveOf+dealSixOf;
        }

    }
}
