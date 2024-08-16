
namespace exercise.main
{
    public class Basket

    {
        //static int CAPACITY { get; set; } = 5;

        public List<ShopItem> Items = new List<ShopItem>();

        private Inventory _inventory = new Inventory();
        
        internal void Add(string sku)
        {
            Items.Add(_inventory.ItemInventory[sku]);
        }
    }
}