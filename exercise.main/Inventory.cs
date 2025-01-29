using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Inventory
    {
        private Dictionary<string, InventoryItem> inventory;
        private Dictionary<String, String> mapTypeVariantToSKU;
        private List<List<string>> itemsList = new List<List<string>>{
            new List<string>{"BGLO", "0,49", "Bagel", "Onion"},
            new List<string>{"BGLP", "0,39", "Bagel", "Plain"},
            new List<string>{ "BGLE", "0,49", "Bagel", "Everything"},
            new List<string>{ "BGLS", "0,49", "Bagel", "Sesame"},

            new List<string>{ "COFB", "0,99", "Coffee", "Black"},
            new List<string>{ "COFW", "1,19", "Coffee", "White"},
            new List<string>{ "COFC", "1,29", "Coffee", "Capuccino"},
            new List<string>{ "COFL", "1,29", "Coffee", "Latte"},

            new List<string>{ "FILB", "0,12", "Filling", "Bacon"},
            new List<string>{ "FILE", "0,12", "Filling", "Egg"},
            new List<string>{ "FILC", "0,12", "Filling", "Cheese"},
            new List<string>{ "FILX", "0,12", "Filling", "Cream Cheese"},
            new List<string>{ "FILS", "0,12", "Filling", "Smoked Salmon"},
            new List<string>{ "FILH", "0,12", "Filling", "Ham"}
        };
        
        public Inventory() 
        {
            inventory = new Dictionary<string, InventoryItem>();
            mapTypeVariantToSKU = new Dictionary<string, string>();

            foreach (var item in itemsList)
            {
                inventory.Add(item[0], new InventoryItem(item[2], item[3], double.Parse(item[1]), 0));
                mapTypeVariantToSKU.Add(inventory[item[0]].GetNametype, item[0]);
            }
        }

        public Dictionary<string, InventoryItem> GetInventory { get { return inventory; } }
        public Dictionary<String, String> GetMapTypeVariantToSKU { get { return mapTypeVariantToSKU; } }

    }
}