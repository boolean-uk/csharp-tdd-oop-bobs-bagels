namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Inventory
    {
        private List<IProduct> items;

        public Inventory()
        {
            items = new List<IProduct>();
            StockInventory();
        }

        private void StockInventory()
        {
            items.Add(new Bagel("BGLO", 0.49M, "Bagel", "Onion"));
            items.Add(new Bagel("BGLP", 0.39M, "Bagel", "Plain"));
            items.Add(new Bagel("BGLE", 0.49M, "Bagel", "Everything"));
            items.Add(new Bagel("BGLS", 0.49M, "Bagel", "Sesame"));
            items.Add(new Coffee("COFB", 0.99M, "Black"));
            items.Add(new Coffee("COFW", 1.19M, "White"));
            items.Add(new Coffee("COFC", 1.29M, "Capuccino"));
            items.Add(new Coffee("COFL", 1.29M, "Latte"));
            items.Add(new Filling("FILB", 0.12M, "Bacon"));
            items.Add(new Filling("FILE", 0.12M, "Egg"));
            items.Add(new Filling("FILC", 0.12M, "Cheese"));
            items.Add(new Filling("FILX", 0.12M, "Cream Cheese"));
            items.Add(new Filling("FILS", 0.12M, "Smoked Salmon"));
            items.Add(new Filling("FILH", 0.12M, "Ham"));
        }

        public bool DoesTheItemExist(string sku)
        {
            return items.Any(item => item.SKU == sku);
        }

        public decimal GetPriceOfItem(string sku)
        {
            var item = items.FirstOrDefault(i => i.SKU == sku);
            return item?.GetPrice() ?? 0M;
        }
        public IEnumerable<T> GetProductsOfType<T>() where T : IProduct //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=net-7.0
        {
            return items.OfType<T>();
        }
    }
}