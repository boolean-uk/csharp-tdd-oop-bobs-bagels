using System.Reflection.Metadata.Ecma335;

namespace exercise.main
{
    //not really that necessary as of now, but will maybe add more functionallity later?
    internal class Inventory
    {
        private Dictionary<string, ShopItem> _inventory = new Dictionary<string, ShopItem>
        {
            ["bglo"] = new ShopItem("bglo", "Onion", 0.49f),
            ["bglp"] = new ShopItem("bglp", "Plain", 0.39f),
            ["bgle"] = new ShopItem("bgle", "Everything", 0.49f),
            ["bgls"] = new ShopItem("bgls", "Sesame", 0.49f),
            ["cofb"] = new ShopItem("cofb", "Black", 0.99f),
            ["cofw"] = new ShopItem("cofw", "White", 1.19f),
            ["cofc"] = new ShopItem("cofc", "Capuccino", 1.29f),
            ["cofl"] = new ShopItem("cofl", "Latte", 1.29f),
            ["filb"] = new ShopItem("filb", "Bacon", 0.12f),
            ["file"] = new ShopItem("file", "Egg", 0.12f),
            ["filc"] = new ShopItem("filc", "Cheese", 0.12f),
            ["filx"] = new ShopItem("filx", "Cream Cheese", 0.12f),
            ["fils"] = new ShopItem("fils", "Smoked Salmon", 0.12f),
            ["filh"] = new ShopItem("filh", "Ham", 0.12f),
        };

        public Dictionary<string, ShopItem> ItemInventory { get => _inventory; }
    }
}