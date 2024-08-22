using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class CheckOut
    {
        private static List<Item> sixBagelDiscount(Basket basket)
        {
            List<Item> bagels = new List<Item>();
            foreach (Item item in basket.Items) 
            { 
                if ( item.GetType() == typeof(Bagel))
                {
                    bagels.Add(item);
                    if (bagels.Count == 6)
                    {
                        foreach (Item item2 in bagels)
                        {
                            basket.RemoveItem(item2);
                        }
                        return bagels;
                    }
                }
            }
            return null;
        } 

        private static List<Item> twelveBagelDiscount(Basket basket) 
        {
            List<Item> bagels = new List<Item>();
            foreach (Item item in basket.Items)
            {   
                if (item.GetType() == typeof(Bagel))
                {
                    bagels.Add(item);
                    if (bagels.Count == 12)
                    {
                        foreach (Item item2 in bagels)
                        {
                            basket.RemoveItem(item2);
                        }
                        return bagels;
                    }
                }
            }
            return null;
        }

        private static List<Item> bagelAndCoffe(Basket basket)
        {   
            List<Item> CoffeAndBagel = new List<Item>();
            bool Coffee = false;
            bool Bagel = false;
            foreach (Item item in basket.Items)
            {
                if (item.GetType() == typeof(Coffee) && !Coffee)
                {
                    CoffeAndBagel.Add(item);
                    Coffee = true;
                    if (CoffeAndBagel.Count == 2)
                    {
                        foreach (Item item2 in CoffeAndBagel)
                        {
                            basket.RemoveItem(item2);
                        }
                        return CoffeAndBagel;
                    }
                } else if (item.GetType() == typeof(Bagel) && !Bagel)
                {
                    CoffeAndBagel.Add(item);
                    Bagel = true;
                    if (CoffeAndBagel.Count == 2)
                    {
                        foreach (Item item2 in CoffeAndBagel)
                        {
                            basket.RemoveItem(item2);
                        }
                        return CoffeAndBagel;
                    }
                }
            }
            return null;
        }

        private static List<Item> checkDiscount(Basket basket)
        {
            return null;
        }

        private static List<Discount> populateList(Basket basket)
        {
            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount("BGLE", "12 x Bagel Discount", twelveBagelDiscount, 3.99f, basket));
            discounts.Add(new Discount("BGLE", "6 x Bagel Discount", sixBagelDiscount, 2.49f, basket));
            discounts.Add(new Discount("COFB", "Bagel & Coffee Discount", bagelAndCoffe, 1.25f, basket));

            return discounts;
        }

        public static Receipt checkOut(Basket basket)
        {
            List<Discount> discounts = populateList(basket);
            foreach (Discount discount in discounts)
            {
                List<Item> discnt = discount.getDiscounts();
                foreach (Item item in discnt)
                {
                    basket.AddItem(item);
                }
            }
            return new Receipt(basket);
        }
        public static float checkOutPrice(Basket basket)
        {
            List<Discount> discounts = populateList(basket);
            foreach (Discount discount in discounts)
            {
                List<Item> discnt = discount.getDiscounts();
                foreach (Item item in discnt)
                {
                    basket.AddItem(item);
                }
            }
            return basket.GetCost();
        }
    }
}
