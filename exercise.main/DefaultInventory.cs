using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class DefaultInventory
    {
        public static List<Item> Inventory { get; private set; }
        public static List<Item> SpecialOffers { get; private set; }
        static DefaultInventory()
        {
            Inventory = new List<Item>
            {
                new Item("BGLO", 0.49d, Name.Bagel, "Onion"), new Item("BGLP", 0.39d, Name.Bagel, "Plain"),new Item("BGLE", 0.49d, Name.Bagel, "Everything"),new Item("BGLS", 0.49d, Name.Bagel, "Sesame"),
                new Item("COFB", 0.99d, Name.Coffe, "Black"), new Item("COFW", 1.19d, Name.Coffe, "White"), new Item("COFC", 1.29d, Name.Coffe, "Cappucino"), new Item("COFL", 1.29d, Name.Coffe, "Latte"),
                new Item("FILB", 0.12d, Name.Filling, "Bacon"), new Item("FILE", 0.12d, Name.Filling, "Egg"), new Item("FILC", 0.12d, Name.Filling, "Cheese"),new Item("FILX", 0.12d, Name.Filling, "Cream cheese"),new Item("FILS", 0.12d, Name.Filling, "Smoked salmon"), new Item("FILH", 0.12d, Name.Filling, "Ham")

            };

            SpecialOffers = new List<Item>
            {
                new Item("SOBO", 2.49d, Name.Special, "6 for 2.49"), new Item("SOBP", 3.99d, Name.Special, "12 for 3.99"),
                new Item("SOBE", 2.49d, Name.Special, "6 for 2.49"), new Item("SOCB", 1.25d, Name.Special, "Coffee & Bagel for 1.25")
            };
        }

        
        public static Item FindItemInInventoryBySKU(string sku)
        {
            return Inventory.FirstOrDefault(item => item.Sku == sku);
        }
        public static Item FindItemInSpecialOffersBySKU(string sku)
        {
            return SpecialOffers.FirstOrDefault(item => item.Sku == sku);
        }
        public static double FindBagelCost(List<Item> items)
        {
            return items.Where(i => i.Name == Name.Filling || i.Name == Name.Bagel).Sum(i => i.Price);
        }
        public static double FindFillingCost(Item filling)
        {
            return filling.Price;
        }
        
        
    }
}
