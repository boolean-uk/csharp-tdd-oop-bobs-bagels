
namespace exercise.main
{
    public class Basket

    {
        private static int CAPACITY = 5;
        public static int Capacity { get => CAPACITY; }

        private Inventory _inventory = new Inventory();
        private float _totalCost = 0;
        public float TotalCost { get => _totalCost; }

        public List<ShopItem> Items = new List<ShopItem>();
 
        internal bool Add(string sku)
        {
            if (Items.Count < CAPACITY && _inventory.ItemInventory.ContainsKey(sku) )
            {
                ShopItem shopItem = _inventory.ItemInventory[sku];
                _totalCost += shopItem.Price;
                Items.Add(shopItem);

                return true;
            }

            return false;
        }

        internal bool Remove(string sku)
        {
            if (_inventory.ItemInventory.ContainsKey(sku))
            {
                ShopItem shopItem = _inventory.ItemInventory[sku];
                _totalCost -= shopItem.Price;
                return Items.Remove(shopItem);
            }
            return false;
        }

        internal float PriceItem(string sku)
        {
            return _inventory.ItemInventory[sku].Price;
        }

        internal static void ChangeCapacity(int newCapacity, string password)
        {
            if (password.Equals("secret password"))
            {
                CAPACITY = newCapacity;
            }
        }
    }
}