
namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        private int _capacity;

        public Basket()
        {
            Items = new();
            _capacity = 39; //Arbitrarily chosen default capacity
        }
        public Basket(int capacity)
        {
            Items = new();
            _capacity = capacity;
        }
        public void AddBagel(Bagel bagel)
        {
            if (Items.Count >= _capacity)
            {
                return;
            }
            Items.Add(bagel);
        }

        public List<Item> GetBagels()
        {
            return Items;
        }

        public bool RemoveItem(Item item)
        {
            if (!Items.Contains(item))
            {
                Console.WriteLine("No such item");
                return false;
            }
            else
            {
                Items.Remove(item);
                return true;
            }
        }

        public bool IsFull()
        {
            return Items.Count >= _capacity;
        }

        public void ChangeBasketCapacity(int v)
        {
            _capacity = v;
        }

        public bool DoesItemExist(Item bagel)
        {
            throw new NotImplementedException();
        }

        public double GetBasketCost()
        {
            throw new NotImplementedException();
        }
    }
}
