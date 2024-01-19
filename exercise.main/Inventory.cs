using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory

    {
        private List<Item> _Inventory = new List<Item>();

        public Inventory() 
        
        {
            SetupInventory();

        }

        private void SetupInventory()
        {
            _Inventory.AddRange(new List<Item>
        {
            new Item("BGLO", 0.49d, "Bagel", "Onion", new SpecialOffer { Quantity = 6, SpecialPrice = 2.49 }),
            new Item("BGLP", 0.39d, "Bagel", "Plain", new SpecialOffer { Quantity = 12, SpecialPrice = 3.99 }),
            new Item("BGLE", 0.49d, "Bagel", "Everything", new SpecialOffer { Quantity = 6, SpecialPrice = 2.49 }),
            new Item("BGLS", 0.49d, "Bagel", "Sesame"),
            new Item("COFB", 0.99d, "Coffee", "Black"),
            new Item("COFW", 1.19d, "Coffee", "White"),
            new Item("COFC", 1.29d, "Coffee", "Capuccino"),
            new Item("COFL", 1.29d, "Coffee", "Latte"),
            new Item("FILB", 0.12d, "Filling", "Bacon"),
            new Item("FILE", 0.12d, "Filling", "Egg"),
            new Item("FILC", 0.12d, "Filling", "Cheese"),
            new Item("FILX", 0.12d, "Filling", "Cream Cheese"),
            new Item("FILS", 0.12d, "Filling", "Smoked Salmon"),
            new Item("FILH", 0.12d, "Filling", "Ham"),

        });
        }

        public Item GetItemBySKU(string sku)
        {
            return _Inventory.Where(item => item.Sku == sku).FirstOrDefault();
        }



        public List<Item> Stock { get { return _Inventory; } }

    }
}
