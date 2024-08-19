using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BobsInventory
    {
        private List<InventoryItem> _BobsInventory = new List<InventoryItem>();

        public void BobsInventorylist() 
        {
            _BobsInventory.Add(new InventoryItem("BGLO", 0.49, "Bagel", "Onion"));
            _BobsInventory.Add(new InventoryItem("BGLP", 0.39, "Bagel", "Plain"));
            _BobsInventory.Add(new InventoryItem("BGLE", 0.49, "Bagel", "Everything"));
            _BobsInventory.Add(new InventoryItem("BGLS", 0.49, "Bagel", "Sesame"));


            _BobsInventory.Add(new InventoryItem("COFB", 0.99, "Coffee", "Black"));
            _BobsInventory.Add(new InventoryItem("COFW", 1.19, "Coffee", "White"));
            _BobsInventory.Add(new InventoryItem("COFC", 1.29, "Coffee", "Capuccino"));
            _BobsInventory.Add(new InventoryItem("COFL", 1.29, "Coffee", "Latte"));

            _BobsInventory.Add(new InventoryItem("FILB", 0.12, "Filling", "Bacon"));
            _BobsInventory.Add(new InventoryItem("FILE", 0.12, "Filling", "Egg"));
            _BobsInventory.Add(new InventoryItem("FILC", 0.12, "Filling", "Cheese"));
            _BobsInventory.Add(new InventoryItem("FILX", 0.12, "Filling", "Cream Cheese"));
            _BobsInventory.Add(new InventoryItem("FILS", 0.12, "Filling", "Smoked Salmon"));
            _BobsInventory.Add(new InventoryItem("FILH", 0.12, "Filling", "Ham"));


        }

        public decimal CostofItem { get; set; }

    }
}
