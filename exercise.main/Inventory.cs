using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        private static List<Product> _stock = new List<Product>
        {
        new Product("BGLP", 0.39m, ProductType.bagel, "Plain"),
        new Product("BGLO", 0.49m, ProductType.bagel, "Onion"),
        new Product("BGLE", 0.49m, ProductType.bagel, "Everything"),
        new Product("BGLS", 0.49m, ProductType.bagel, "Sesame"),
        new Product("COFB", 0.99m, ProductType.coffee, "Black"),
        new Product("COFW", 1.19m, ProductType.coffee, "White"),
        new Product("COFC", 1.29m, ProductType.coffee, "Capuccino"),
        new Product("COFL", 1.29m, ProductType.coffee, "Latte"),
        new Product("FILB", 0.12m, ProductType.filling, "Bacon"),
        new Product("FILE", 0.12m, ProductType.filling, "Egg"),
        new Product("FILC", 0.12m, ProductType.filling, "Cheese"),
        new Product("FILX", 0.12m, ProductType.filling, "Cream Cheese"),
        new Product("FILS", 0.12m, ProductType.filling, "Smoked Salmon"),
        new Product("FILH", 0.12m, ProductType.filling, "Ham"),
    } ;

        public bool FindItemWithSKU(string sku)
        {
            return Stock.Exists(i => i.SKU == sku);
        }
        public List<Product> Stock { get {  return _stock; } set { _stock = value; } }   
    }
}
