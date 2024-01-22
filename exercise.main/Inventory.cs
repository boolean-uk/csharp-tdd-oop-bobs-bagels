using System.Collections.Generic;

namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, InventoryItem> Items;
        public class InventoryItem
        {
            public string Name { get; private set; }
            public double Price { get; private set; }
            public string Type { get; private set; }

            public InventoryItem(string name, double price, string type)
            {
                Name = name;
                Price = price;
                Type = type;
            }
        }

        public Inventory()
        {
            Items = new Dictionary<string, InventoryItem>
            {
                {"BGLO", new InventoryItem( "Onion", 0.49, "Bagel")},
                {"BGLP", new InventoryItem( "Plain", 0.39, "Bagel")},
                {"BGLE", new InventoryItem("Everything", 0.49, "Bagel")},
                {"BGLS", new InventoryItem("Sesame", 0.49, "Bagel")},
                {"COFB", new InventoryItem("Black", 0.99, "Coffee")},
                {"COFW", new InventoryItem("White", 1.19, "Coffee")},
                {"COFC", new InventoryItem("Capuccino", 1.29, "Coffee")},
                {"COFL", new InventoryItem("Latte", 1.29, "Coffee")},
                {"FILB", new InventoryItem("Bacon", 0.12, "Filling")},
                {"FILE", new InventoryItem("Egg", 0.12, "Filling")},
                {"FILC", new InventoryItem("Cheese", 0.12, "Filling")},
                {"FILX", new InventoryItem("Cream Cheese", 0.12, "Filling")},
                {"FILS", new InventoryItem("Smoked Salmon", 0.12, "Filling")},
                {"FILH", new InventoryItem("Ham", 0.12, "Filling")}
            };
        }

        public InventoryItem? GetItem(string sku)
        {
            if (Items.TryGetValue(sku, out InventoryItem? item))
            {
                return item;
            }

            return null;
        }
    }
}