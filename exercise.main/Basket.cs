

namespace exercise.main
{
    public class Basket

    {
        static int CAPACITY { get; set; } = 5;

        public List<ShopItem> Items = new List<ShopItem>();

        private Inventory _inventory = new Inventory();
        
        internal bool Add(string sku)
        {
            if (Items.Count >= CAPACITY) 
            {
                return false;
            }

            Items.Add(_inventory.ItemInventory[sku]);
            return true;
        }

        internal void Remove(string sku)
        {
            Items.Remove(_inventory.ItemInventory[sku]);
        }
    }
}