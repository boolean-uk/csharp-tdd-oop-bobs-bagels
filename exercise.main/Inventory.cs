using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public Inventory() 
        {
            addDiscounts();
        }
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

        public void addDiscounts()
        {
            GetFromInventory("BGLO").Discount = new Discount(new Dictionary<string, int>() { { "BGLO", 6 } }, 2.49);
            GetFromInventory("BGLP").Discount = new Discount(new Dictionary<string, int>() { { "BGLP", 12 } }, 3.99);
            GetFromInventory("BGLE").Discount = new Discount(new Dictionary<string, int>() { { "BGLE", 6 } }, 2.49);
            GetFromInventory("COFB").Discount = new Discount(new Dictionary<string, int>() { { "COFB", 1 }, { "BGL", 1 } }, 1.25);
        }

        public Product GetFromInventory(string productID)
        {
            return _inventory.First(item => item.SKU == productID);
        }

        public List<Product> inventory { get { return _inventory; } }

    }
}
