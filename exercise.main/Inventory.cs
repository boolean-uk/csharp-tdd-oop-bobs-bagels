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
            new ("BGLO", 0.49f, "Bagel", "Onion"),
            new ("BGLP", 0.39f, "Bagel", "Plain"),
            new ("BGLE", 0.49f, "Bagel", "Everything"),
            new ("BGLS", 0.49f, "Bagel", "Sesame"),
            new ("COFB", 0.99f, "Coffee", "Black"),
            new ("COFW", 1.19f, "Coffee", "White"),
            new ("COFC", 1.29f, "Coffee", "Capuccino"),
            new ("COFL", 1.29f, "Coffee", "Latte"),
            new ("FILB", 0.12f, "Filling", "Bacon"),
            new ("FILE", 0.12f, "Filling", "Egg"),
            new ("FILC", 0.12f, "Filling", "Cheese"),
            new ("FILX", 0.12f, "Filling", "Cream Cheese"),
            new ("FILS", 0.12f, "Filling", "Smoked Salmon"),
            new ("FILH", 0.12f, "Filling", "Ham")
        ];
        public bool ContainsItem(string itemSKU) { throw new NotImplementedException(); }
        public Item SearchInventory(string itemSKU) 
        {
            var result = _stock.Where(item => item.SKU == itemSKU);

            return result.First();
        }
    }
}
