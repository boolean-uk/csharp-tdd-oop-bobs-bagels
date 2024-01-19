using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory1 : IInventory
    {
        private Dictionary<string, Product> _inventory = new Dictionary<string, Product> {
            {"BGLO", new Product("BGLO", 0.49m, "Bagel", "Onion")},
            {"BGLP", new Product("BGLP", 0.39m, "Bagel", "Plain")},
            {"BGLE", new Product("BGLE", 0.49m, "Bagel", "Everything")},
            {"BGLS", new Product("BGLS", 0.49m, "Bagel", "Sesame")},
            {"COFB", new Product("COFB", 0.99m, "Coffee", "Black")},
            {"COFW", new Product("COFW", 1.19m, "Coffee", "White")},
            {"COFC", new Product("COFC", 1.29m, "Coffee", "Capuccino")},
            {"COFL", new Product("COFL", 1.29m, "Coffee", "Latte")},
            {"FILB", new Product("FILB", 0.12m, "Filling", "Bacon")},
            {"FILE", new Product("FILE", 0.12m, "Filling", "Egg")},
            {"FILC", new Product("FILC", 0.12m, "Filling", "Cheese")},
            {"FILX", new Product("FILX", 0.12m, "Filling", "Cream Cheese")},
            {"FILS", new Product("FILS", 0.12m, "Filling", "Smoked Salmon")},
            {"FILH", new Product("FILH", 0.12m, "Filling", "Ham")}
        };

      

      

        public Product GetFilling(string sku)
        {
            if (_inventory.TryGetValue(sku, out Product product)) {
                return product;
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
            if (_inventory.TryGetValue(sku, out Product product)) {
                return product.Price;
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

        public Product GetProduct(string sku) {
            if (_inventory.TryGetValue(sku, out Product product)) {
                return product;
            }
            throw new Exception($"Product with SKU {sku} not found in inventory");
        }
            
    }
}