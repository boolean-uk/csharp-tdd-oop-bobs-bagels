namespace exercise.main
{
    public class Inventory
    {
        private Dictionary<string, Iitems> _items;

        public Inventory()
        {
            _items = new Dictionary<string, Iitems>
            {
                { "BGLO", new Bagel("BGLO", 0.49f, "Bagel", "Onion") },
                { "BGLP", new Bagel("BGLP", 0.39f, "Bagel", "Plain") },
                { "BGLE", new Bagel("BGLE", 0.49f, "Bagel", "Everything") },
                { "BGLS", new Bagel("BGLS", 0.49f, "Bagel", "Sesame") },
                { "COFB", new Filling("COFB", 0.99f, "Coffee", "Black") },
                { "COFW", new Filling("COFW", 1.19f, "Coffee", "White") },
                { "COFC", new Filling("COFC", 1.29f, "Coffee", "Cappuccino") },
                { "COFL", new Filling("COFL", 1.29f, "Coffee", "Latte") },
                { "FILB", new Filling("FILB", 0.12f, "Filling", "Bacon") },
                { "FILE", new Filling("FILE", 0.12f, "Filling", "Egg") },
                { "FILC", new Filling("FILC", 0.12f, "Filling", "Cheese") },
                { "FILX", new Filling("FILX", 0.12f, "Filling", "Cream Cheese") },
                { "FILS", new Filling("FILS", 0.12f, "Filling", "Smoked Salmon") },
                { "FILH", new Filling("FILH", 0.12f, "Filling", "Ham") }
            };
        }

        public bool ItemExists(string sku)
        {
            return _items.ContainsKey(sku);
        }

        public float GetPrice(string sku)
        {
            if (this.ItemExists(sku))
            {
                return _items[sku].GetPrice();
            }
            else
            {
                return 0;
            }
        }

        public Iitems GetItem(string sku)
        {
            if (this.ItemExists(sku))
            {
                return _items[sku];
            }
            else return null;
        }
    }
}
