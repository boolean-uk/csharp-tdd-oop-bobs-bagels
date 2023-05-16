using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels_Csharp_Classes
{

    public class Inventory
    {
        private List<ShopItem> inventoryList = new List<ShopItem>()
        {
            new ShopItem("BGLO", "Onion", 0.49m, "Bagel"),
            new ShopItem("BGLP", "Plain", 0.39m, "Bagel"),
            new ShopItem("BGLE", "Everything", 0.49m, "Bagel"),
            new ShopItem("BGLS", "Sesame", 0.49m, "Bagel"),
            new ShopItem("COFB", "Black", 0.99m, "Coffee"),
            new ShopItem("COFW", "White", 1.19m, "Coffee"),
            new ShopItem("COFC", "Capuccino", 1.29m, "Coffee"),
            new ShopItem("COFL", "Latte", 1.29m, "Coffee"),
            new ShopItem("FILB", "Bacon", 0.12m, "Filling"),
            new ShopItem("FILE", "Egg", 0.12m, "Filling"),
            new ShopItem("FILC", "Cheese", 0.12m, "Filling"),
            new ShopItem("FILX", "Cream Cheese", 0.12m, "Filling"),
            new ShopItem("FILS", "Smoked Salmon", 0.12m, "Filling"),
            new ShopItem("FILH", "Ham", 0.12m, "Filling")
        };

        public List<ShopItem> InventoryList { get { return inventoryList; } set { inventoryList = value; } }
        public List<ShopItem> InventoryListNoChange { get { return inventoryList; } }

    }

}
