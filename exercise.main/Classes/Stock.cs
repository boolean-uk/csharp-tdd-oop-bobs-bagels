using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Stock
    {
        public Stock() { DiscountEvaluate(); } //Calculates discounts when stock is initialized

        public static List<(string SKU, double price, Name name, string variant)> Items { get; } = new()
        {
            ("BGLO", 0.49, Name.Bagel, "Onion"),
            ("BGLP", 0.39, Name.Bagel, "Plain"),
            ("BGLE", 0.49, Name.Bagel, "Everything"),
            ("BGLS", 0.49, Name.Bagel, "Sesame"),
            ("COFB", 0.99, Name.Coffee, "Black"),
            ("COFW", 1.19, Name.Coffee, "White"),
            ("COFC", 1.29, Name.Coffee, "Cappuccino"),
            ("COFL", 1.29, Name.Coffee, "Latte"),
            ("FILB", 0.12, Name.Filling, "Bacon"),
            ("FILE", 0.12, Name.Filling, "Egg"),
            ("FILC", 0.12, Name.Filling, "Cheese"),
            ("FILX", 0.12, Name.Filling, "Cream Cheese"),
            ("FILS", 0.12, Name.Filling, "Smoked Salmon"),
            ("FILH", 0.12, Name.Filling, "Ham")
        };

        public Item? GetInfoFromSKU(string sku)
        {
            foreach (var item in Items)
            {
                if (item.SKU == sku)
                {
                    return new Item(item.SKU, item.price, item.name, item.variant);
                }
            }
            return null;
        }



        //Discount calculations:

        public enum Discount { SixBagel, TwelveBagel, CoffeeBagel }
        List<(List<string> sku, Discount discount, double saved)> deals { get; } = new(); //stores the sku's of items in a discount, the type of discount and the saved value

        //Calculates all deals and stores them in the deals table
        public void DiscountEvaluate()
        {
            deals.Clear();
            List<string> skuList = new();
            foreach (var item in Items)
            {
                
                skuList.Add(item.SKU);

                if (item.name == Name.Bagel) //Check deals for bagels
                {
                    
                    deals.Add(new( skuList, Discount.SixBagel, DiscountSixBagel(item.SKU)));
                    deals.Add(new( skuList, Discount.TwelveBagel, DiscountTwelveBagel(item.SKU)));
                }
                else if(item.name == Name.Coffee) //Check coffee deals
                {
                    foreach (var item2 in Items.ToList().Where(i => i.name == Name.Bagel)) //Perform coffee+bagel check on every bagel
                    {
                        skuList.Add(item2.SKU);
                        deals.Add(new(skuList.ToList(), Discount.CoffeeBagel, DiscountCoffeeAndBagel(item.SKU, item2.SKU)));
                        skuList.RemoveAt(skuList.Count - 1);
                    }
                }
                skuList.Clear();

            }
        }

        //How much saved when buying a coffee and bagel combo
        public double DiscountCoffeeAndBagel(string csku, string bsku)
        {
            double cost = 0;
            cost = Items.Find(x => x.SKU == csku).price;
            cost += Items.Find(x => x.SKU == bsku).price;
            return Math.Round(cost - 1.25, 2);
        }

        //How much is saved when bulk buying 6 bagels
        public double DiscountSixBagel(string sku)
        {
            double cost = 0;
            cost = Items.Find(x => x.SKU == sku).price * 6;
            return Math.Round(cost - 2.49, 2);
        }

        //How much is saved when bulk buying 12 bagels
        public double DiscountTwelveBagel(string sku)
        {
            double cost = 0;
            cost = Items.Find(x => x.SKU == sku).price * 12;
            return Math.Round(cost - 3.99, 2);
        }

    }
}
