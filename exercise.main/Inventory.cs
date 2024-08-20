using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private List<Product> _inventory { get; set; } = new List<Product>()
        {
            new Product("BGLO", 0.49, "bagel","onion"),
            new Product("BGLP", 0.39, "bagel","plain"),
            new Product("BGLE", 0.49, "bagel", "everything"),
            new Product("BGLS", 0.49, "bagel", "sesame"),
            new Product("COFB", 0.99, "coffee", "black"),
            new Product("COFW", 1.19, "coffee", "white"),
            new Product("COFC", 1.29, "coffee", "capuccino"),
            new Product("COFL", 1.29, "coffee", "latte"),
            new Product("FILB", 0.12, "filling", "bacon"),
            new Product("FILE", 0.12, "filling", "egg"),
            new Product("FILC", 0.12, "filling", "cheese"),
            new Product("FILX", 0.12, "filling", "cream cheese"),
            new Product("FILS", 0.12, "filling", "smoked salmon"),
            new Product("FILB", 0.12, "filling", "ham"),
        };

        private List<Discount> _discounts = new List<Discount>()
        {
            new Discount(new List<string>() { "BGLO", "BGLO", "BGLO", "BGLO", "BGLO", "BGLO" }, 2.49),
            new Discount(new List<string>() { "BGLP" , "BGLP" , "BGLP"  , "BGLP"  , "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP", "BGLP" }, 3.99),
            new Discount(new List<string>() { "BGLE", "BGLE", "BGLE","BGLE", "BGLE", "BGLE" }, 2.49),
            new Discount(new List<string>() { "COFB", "BGL" }, 1.25)
        };

        //The coffee and bagel discount was quite difficult, will do that later
        // Will probably have a list of discounts instead of adding them to the product

        public Product GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU == productID);
        }

        public List<Product> GetListFromInventory(string productID)
        {
            return _inventory.Where(item =>  item.SKU == productID).ToList();
        }

        public double GetCostOfProduct(string productId)
        {
            return GetFromInventory(productId).Price;
        }

        public List<Product> inventory { get { return _inventory; } }

        public List<Discount> Discounts { get { return _discounts; } }
    }
        

}
