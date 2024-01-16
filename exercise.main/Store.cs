

namespace exercise.main
{
    public class Store
    {
        public List<Item> inventory = new List<Item>();
        public void AddItemToInventory(Item item)
        {
            inventory.Add(item);
        }

        public List<Item> GetItemsInInventory()
        {
            return inventory;
        }
    }
}
