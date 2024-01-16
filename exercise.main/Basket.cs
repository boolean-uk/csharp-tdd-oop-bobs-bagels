namespace exercise.main
{
    public class Basket
    {
        public List<string> Items { get; set; }
        private int _capacity;

        public Basket()
        {
            Items = new List<string>();
            _capacity = 39; //Arbitrarily chosen default capacity
        }
        public Basket(int capacity)
        {
            Items = new List<string>();
            _capacity = capacity;
        }
        public void AddBagel(string bagel)
        {
            if (Items.Count >= _capacity)
            {
                return;
            }
            Items.Add(bagel);
        }

        public List<string> GetBagels()
        {
            return Items;
        }

        public bool RemoveBagel(string bagel)
        {
            if (!Items.Contains(bagel))
            {
                Console.WriteLine("No such bagel");
                return false;
            }
            else
            {
                Items.Remove(bagel);
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
    }
}
