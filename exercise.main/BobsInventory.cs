using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BobsInventory
    {
        private List<InventoryItem> inventory = new List<InventoryItem>();
        private string _itemVariant;

        public BobsInventory() 
        {
            inventory.Add(new InventoryItem("BGLO", 0.49, "Bagel", "Onion"));
            inventory.Add(new InventoryItem("BGLP", 0.39, "Bagel", "Plain"));
            inventory.Add(new InventoryItem("BGLE", 0.49, "Bagel", "Everything"));
            inventory.Add(new InventoryItem("BGLS", 0.49, "Bagel", "Sesame"));


            inventory.Add(new InventoryItem("COFB", 0.99, "Coffee", "Black"));
            inventory.Add(new InventoryItem("COFW", 1.19, "Coffee", "White"));
            inventory.Add(new InventoryItem("COFC", 1.29, "Coffee", "Capuccino"));
            inventory.Add(new InventoryItem("COFL", 1.29, "Coffee", "Latte"));

            inventory.Add(new InventoryItem("FILB", 0.12, "Filling", "Bacon"));
            inventory.Add(new InventoryItem("FILE", 0.12, "Filling", "Egg"));
            inventory.Add(new InventoryItem("FILC", 0.12, "Filling", "Cheese"));
            inventory.Add(new InventoryItem("FILX", 0.12, "Filling", "Cream Cheese"));
            inventory.Add(new InventoryItem("FILS", 0.12, "Filling", "Smoked Salmon"));
            inventory.Add(new InventoryItem("FILH", 0.12, "Filling", "Ham"));

        }

        public List<InventoryItem> _Bobsinventory { get { return inventory; } }
        public string ItemVariant { get { return _itemVariant; } set { _itemVariant = value; } }
        public double GetCostofItem { get { return _Bobsinventory.First(item => item.Variant == ItemVariant).Price ; } }

        //{ return _Bobsinventory.Price.Where(item => item.Variant == variant); }
    }
}
