

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

        public void GetDiscounts()
        {
            Console.WriteLine("6 Bagels without filling for 2.49 | 12 Bagels without filling for 3.99 | Coffee and Bagel (without filling) for 1.25");
        }
    }
}
