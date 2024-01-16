
namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        private int _capacity;

        public Basket()
        {
            Items = [];
            _capacity = 39; //Arbitrarily chosen default capacity
        }
        public Basket(int capacity)
        {
            Items = [];
            _capacity = capacity;
        }
        public void AddItem(Item item)
        {
            if (IsFull())
            {
                return;
            }
            Items.Add(item);
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

        public bool DoesItemExist(Item item)
        {
            return (Items.Contains(item));
        }

        public double GetBasketCost()
        {
            return Items.Sum(x => x.Price);
        }
    }
}
