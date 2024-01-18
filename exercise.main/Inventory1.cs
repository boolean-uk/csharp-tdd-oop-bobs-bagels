using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory1 : IInventory
    {
        private Dictionary<string, Item> _inventory = new Dictionary<string, Item> {
            {"BGLO", new Item("BGLO", 0.49m, "Bagel", "Onion")},
            {"BGLP", new Item("BGLP", 0.39m, "Bagel", "Plain")},
            {"BGLE", new Item("BGLE", 0.49m, "Bagel", "Everything")},
            {"BGLS", new Item("BGLS", 0.49m, "Bagel", "Sesame")},
            {"COFB", new Item("COFB", 0.99m, "Coffee", "Black")},
            {"COFW", new Item("COFW", 1.19m, "Coffee", "White")},
            {"COFC", new Item("COFC", 1.29m, "Coffee", "Capuccino")},
            {"COFL", new Item("COFL", 1.29m, "Coffee", "Latte")},
            {"FILB", new Item("FILB", 0.12m, "Filling", "Bacon")},
            {"FILE", new Item("FILE", 0.12m, "Filling", "Egg")},
            {"FILC", new Item("FILC", 0.12m, "Filling", "Cheese")},
            {"FILX", new Item("FILX", 0.12m, "Filling", "Cream Cheese")},
            {"FILS", new Item("FILS", 0.12m, "Filling", "Smoked Salmon")},
            {"FILH", new Item("FILH", 0.12m, "Filling", "Ham")}
        };

      

      

        public Item GetFilling(string sku)
        {
            if (_inventory.TryGetValue(sku, out Item item)) {
                return item;
            }
            return null;
        }


        /*7. As a customer,
        So I know what the damage will be,
        I'd like to know the cost of a bagel before I add it to my basket.
        */
        /*9. As a customer,
        So I don't over-spend,
        I'd like to know the cost of each filling before I add it to my bagel order.
        */
        public decimal GetProductPrice(string sku)
        {
            if (_inventory.TryGetValue(sku, out Item item)) {
                return item.Price;
            }
           return 0.0m;
        }

        /*10. As the manager,
        So we don't get any weird requests,
        I want customers to only be able to order things that we stock in our inventory.
        */
        public bool IsItemInStock(string sku)
        {
            return _inventory.ContainsKey(sku);
        }
    }
}