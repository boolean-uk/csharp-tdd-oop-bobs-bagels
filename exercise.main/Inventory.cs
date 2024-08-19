using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobsBagels.main
{
    public class Inventory
    {
        private HashSet<Item> _stock { get; } =
        [
            new Bagel("BGLO", 0.49f, "Bagel", "Onion"),
            new Bagel("BGLP", 0.39f, "Bagel", "Plain"),
            new Bagel("BGLE", 0.49f, "Bagel", "Everything"),
            new Bagel("BGLS", 0.49f, "Bagel", "Sesame"),
            new Coffee("COFB", 0.99f, "Coffee", "Black"),
            new Coffee("COFW", 1.19f, "Coffee", "White"),
            new Coffee("COFC", 1.29f, "Coffee", "Capuccino"),
            new Coffee("COFL", 1.29f, "Coffee", "Latte"),
            new Filling("FILB", 0.12f, "Filling", "Bacon"),
            new Filling("FILE", 0.12f, "Filling", "Egg"),
            new Filling("FILC", 0.12f, "Filling", "Cheese"),
            new Filling("FILX", 0.12f, "Filling", "Cream Cheese"),
            new Filling("FILS", 0.12f, "Filling", "Smoked Salmon"),
            new Filling("FILH", 0.12f, "Filling", "Ham")
        ];
        public bool ContainsItem(string itemSKU) { throw new NotImplementedException(); }
        public Item SearchInventory(string itemSKU) 
        {
            var result = _stock.Where(item => item.SKU == itemSKU);

            return result.First();
        }
    }
}
