
using System.Dynamic;
using System.Globalization;

namespace exercise.main
{
    public class Basket

    {
        private static int CAPACITY = 10;
        public static int Capacity { get => CAPACITY; }

        private Inventory _inventory = new Inventory();

        public List<ShopItem> Items = new List<ShopItem>();

        public Dictionary<ShopItem, int> itemAmounts = new Dictionary<ShopItem, int>();
 
        internal bool Add(string sku)
        {
            if (Items.Count < CAPACITY && _inventory.ItemInventory.ContainsKey(sku) )
            {
                ShopItem shopItem = _inventory.ItemInventory[sku];

                Items.Add(shopItem);

                if (itemAmounts.ContainsKey(shopItem))
                {
                    itemAmounts[shopItem]++;
                }
                else 
                {
                    itemAmounts[shopItem] = 1;
                }

                return true;
            }

            return false;
        }

        internal bool Remove(string sku)
        {
            if (_inventory.ItemInventory.ContainsKey(sku))
            {
                ShopItem shopItem = _inventory.ItemInventory[sku];
                
                if (itemAmounts.ContainsKey(shopItem)) 
                { 
                    itemAmounts[shopItem]--; 
                    if (itemAmounts[shopItem] == 0)
                    {
                        itemAmounts.Remove(shopItem);
                    }
                }
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