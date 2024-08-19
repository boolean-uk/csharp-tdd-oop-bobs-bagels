namespace BobsBagels.main
{
    public class Basket
    {
        private Dictionary<Item, int> _items { get; } = new();
        private int _capacity { get { return Manager.Capacity; } }
        private int _count { get; set; } = 0;

        public bool Add(Item item)
        {
            if (_count == _capacity) return false;
            if (_items.TryGetValue(item, out var value))
            {
                _count += 1;
                _items[item]++;
                return true;
            }

            if (item is Bagel bagel)
                {
                if (_count + 1 + bagel.Fillings.Count > _capacity) return false;
                _count += bagel.Fillings.Count;

            }

            _items[item] = 1;
            _count++;
            return true;
        }
        public bool Remove(Item item)
        {
            if (item is Bagel bagel)
            {
                _count -= bagel.Fillings.Count;
            }
            _count--;
            return _items.Remove(item);
        }
        public bool ChangeCapacity(User user, int capacity) { throw new NotImplementedException(); }
        public float Total() 
        {
            float total = 0;

            foreach (var item in _items)
            {
                if (item.Key is Bagel bagel)
                {
                    total += bagel.Price;
                }
                else
                {
                    total += item.Key.Price;
                }
            }
            return total;
        }

        public Dictionary<Item, int> Items { get { return _items; } }
        public int Count {get { return _count; } }
        public int Capacity { get { return _capacity; } }



    }
}
